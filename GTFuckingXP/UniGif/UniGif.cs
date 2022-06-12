/*
UniGif
Copyright (c) 2015 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using GTFuckingXP.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGif
{
    public static partial class UniGif
    {
        /// <summary>
        /// Get GIF texture list Coroutine
        /// </summary>
        /// <param name="bytes">GIF file byte data</param>
        /// <param name="callback">Callback method(param is GIF texture list, Animation loop count, GIF image width (px), GIF image height (px))</param>
        /// <param name="filterMode">Textures filter mode</param>
        /// <param name="wrapMode">Textures wrap mode</param>
        /// <param name="debugLog">Debug Log Flag</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator GetTextureListCoroutine(
            byte[] bytes,
            Action<List<GifTexture>, int, int, int> callback,
            FilterMode filterMode = FilterMode.Bilinear,
            TextureWrapMode wrapMode = TextureWrapMode.Clamp,
            bool debugLog = false)
        {
            int loopCount = -1;
            int width = 0;
            int height = 0;

            // Set GIF data
            var gifData = new GifData();
            if (SetGifData(bytes, ref gifData, debugLog) == false)
            {
                LogManager.Error("GIF file data set error.");
                if (callback != null)
                {
                    callback(null, loopCount, width, height);
                }
                yield break;
            }

            // Decode to textures from GIF data
            List<GifTexture> gifTexList = null;
            LogManager.Debug("Before Decode Texture Corouting");
            yield return DecodeTextureCoroutine(gifData, result => gifTexList = result, filterMode, wrapMode);
            LogManager.Debug("After Decode Texture Corouting");

            if (gifTexList == null || gifTexList.Count <= 0)
            {
                LogManager.Error("GIF texture decode error.");
                if (callback != null)
                {
                    callback(null, loopCount, width, height);
                }
                yield break;
            }

            loopCount = gifData.m_appEx.loopCount;
            width = gifData.m_logicalScreenWidth;
            height = gifData.m_logicalScreenHeight;

            if (callback != null)
            {
                callback(gifTexList, loopCount, width, height);
            }

            yield break;
        }
    }
}