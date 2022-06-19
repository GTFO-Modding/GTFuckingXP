﻿/*
UniGif
Copyright (c) 2015 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using BepInEx.IL2CPP.Utils.Collections;
using GTFuckingXP.Managers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UniGif
{
    /// <summary>
    /// Texture Animation from GIF image
    /// </summary>
    public class UniGifImage : MonoBehaviour
    {
        /// <summary>
        /// This component state
        /// </summary>
        public enum State
        {
            None,
            Loading,
            Ready,
            Playing,
            Pause,
        }

        // Target row image
        internal RawImage m_rawImage;
        // Image Aspect Controller
        internal UniGifImageAspectController m_imgAspectCtrl;
        // Textures filter mode
        private FilterMode m_filterMode = FilterMode.Point;
        // Textures wrap mode
        private TextureWrapMode m_wrapMode = TextureWrapMode.Clamp;
        // Load from url on start
        private bool m_loadOnStart;
        // GIF image url (WEB or StreamingAssets path)
        private string m_loadOnStartUrl;
        // Rotating on loading
        private bool m_rotateOnLoading;
        // LogManager log flag
        private bool m_outputDebugLog;

        // Decoded GIF texture list
        private List<UniGif.GifTexture> m_gifTextureList;
        // Delay time
        private float m_delayTime;
        // Texture index
        private int m_gifTextureIndex;
        // loop counter
        private int m_nowLoopCount;

        /// <summary>
        /// Now state
        /// </summary>
        public State nowState
        {
            get;
            private set;
        }

        /// <summary>
        /// Animation loop count (0 is infinite)
        /// </summary>
        public int loopCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Texture width (px)
        /// </summary>
        public int width
        {
            get;
            private set;
        }

        /// <summary>
        /// Texture height (px)
        /// </summary>
        public int height
        {
            get;
            private set;
        }

        private void Start()
        {
            if (m_rawImage == null)
            {
                m_rawImage = GetComponent<RawImage>();
            }
            if (m_loadOnStart)
            {
                SetGifFromUrl(m_loadOnStartUrl);
            }
        }

        private void OnDestroy()
        {
            Clear();
        }

        private void Update()
        {
            switch (nowState)
            {
                case State.None:
                    break;

                case State.Loading:
                    if (m_rotateOnLoading)
                    {
                        transform.Rotate(0f, 0f, 30f * Time.deltaTime, Space.Self);
                    }
                    break;

                case State.Ready:
                    break;

                case State.Playing:
                    if (m_rawImage == null || m_gifTextureList == null || m_gifTextureList.Count <= 0)
                    {
                        return;
                    }
                    if (m_delayTime > Time.time)
                    {
                        return;
                    }
                    // Change texture
                    m_gifTextureIndex++;
                    if (m_gifTextureIndex >= m_gifTextureList.Count)
                    {
                        m_gifTextureIndex = 0;

                        if (loopCount > 0)
                        {
                            m_nowLoopCount++;
                            if (m_nowLoopCount >= loopCount)
                            {
                                Stop();
                                return;
                            }
                        }
                    }
                    m_rawImage.texture = m_gifTextureList[m_gifTextureIndex].m_texture2d;
                    m_delayTime = Time.time + m_gifTextureList[m_gifTextureIndex].m_delaySec;
                    break;

                case State.Pause:
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Set GIF texture from url
        /// </summary>
        /// <param name="url">GIF image url (WEB or StreamingAssets path)</param>
        /// <param name="autoPlay">Auto play after decode</param>
        public void SetGifFromUrl(string url, bool autoPlay = true)
        {
            StartCoroutine(SetGifFromUrlCoroutine(url, autoPlay).WrapToIl2Cpp()) ;
        }

        /// <summary>
        /// Set GIF texture from url
        /// </summary>
        /// <param name="url">GIF image url (WEB or StreamingAssets path)</param>
        /// <param name="autoPlay">Auto play after decode</param>
        /// <returns>IEnumerator</returns>
        public IEnumerator SetGifFromUrlCoroutine(string url, bool autoPlay = true)
        {
            if (string.IsNullOrEmpty(url))
            {
                LogManager.Warn("URL is nothing.");
                yield break;
            }

            if (nowState == State.Loading)
            {
                LogManager.Warn("Already loading.");
                yield break;
            }
            nowState = State.Loading;

            string path;
            if (url.StartsWith("http"))
            {
                // from WEB
                path = url;
            }
            else
            {
                // from StreamingAssets
                path = Path.Combine("file:///" + Application.streamingAssetsPath, url);
            }

            // Load file            
            //yield return www;

            var www = UnityWebRequest.Get(path);
            yield return www.SendWebRequest();

            LogManager.Debug("Before creating string comparison");
            if (!(www.error == "" || www.error is null))
            {
                LogManager.Debug("In if clausel");
                LogManager.Error("File load error.\n" + www.error);
                nowState = State.None;
                yield break;
            }

            Clear();
            nowState = State.Loading;

            // Get GIF textures
            yield return StartCoroutine((UniGif.GetTextureListCoroutine(www.downloadHandler.GetData(), (gifTexList, loopCount, width, height) =>
            {
                LogManager.Debug("Bruh, idk");
                if (gifTexList != null)
                {
                    m_gifTextureList = gifTexList;
                    this.loopCount = loopCount;
                    this.width = width;
                    this.height = height;
                    nowState = State.Ready;

                    //if()

                    m_imgAspectCtrl.FixAspectRatio(width, height);

                    if (m_rotateOnLoading)
                    {
                        transform.localEulerAngles = Vector3.zero;
                    }

                    if (autoPlay)
                    {
                        Play();
                    }
                }
                else
                {
                    LogManager.Error("Gif texture get error.");
                    nowState = State.None;
                }
                LogManager.Debug("Bruh, idk2");
            },
            m_filterMode, m_wrapMode, m_outputDebugLog)).WrapToIl2Cpp());

            LogManager.Debug("Nach der innerem Coroutine");

            www.Dispose();
        }

        /// <summary>
        /// Clear GIF texture
        /// </summary>
        public void Clear()
        {
            if (m_rawImage != null)
            {
                m_rawImage.texture = null;
            }

            if (m_gifTextureList != null)
            {
                for (int i = 0; i < m_gifTextureList.Count; i++)
                {
                    if (m_gifTextureList[i] != null)
                    {
                        if (m_gifTextureList[i].m_texture2d != null)
                        {
                            Destroy(m_gifTextureList[i].m_texture2d);
                            m_gifTextureList[i].m_texture2d = null;
                        }
                        m_gifTextureList[i] = null;
                    }
                }
                m_gifTextureList.Clear();
                m_gifTextureList = null;
            }

            nowState = State.None;
        }

        /// <summary>
        /// Play GIF animation
        /// </summary>
        public void Play()
        {
            LogManager.Debug("Play method");

            if (nowState != State.Ready)
            {
                LogManager.Warn("State is not READY.");
                return;
            }
            if (m_rawImage == null || m_gifTextureList == null || m_gifTextureList.Count <= 0)
            {
                LogManager.Error("Raw Image or GIF Texture is nothing.");
                return;
            }
            nowState = State.Playing;
            m_rawImage.texture = m_gifTextureList[0].m_texture2d;
            m_delayTime = Time.time + m_gifTextureList[0].m_delaySec;
            m_gifTextureIndex = 0;
            m_nowLoopCount = 0;
        }

        /// <summary>
        /// Stop GIF animation
        /// </summary>
        public void Stop()
        {
            if (nowState != State.Playing && nowState != State.Pause)
            {
                LogManager.Warn("State is not Playing and Pause.");
                return;
            }
            nowState = State.Ready;
        }

        /// <summary>
        /// Pause GIF animation
        /// </summary>
        public void Pause()
        {
            if (nowState != State.Playing)
            {
                LogManager.Warn("State is not Playing.");
                return;
            }
            nowState = State.Pause;
        }

        /// <summary>
        /// Resume GIF animation
        /// </summary>
        public void Resume()
        {
            if (nowState != State.Pause)
            {
                LogManager.Warn("State is not Pause.");
                return;
            }
            nowState = State.Playing;
        }
    }
}