using EndskApi.Manager;
using EndskApi.Scripts;
using GTFO.API;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Video;
using EndskApi.Information.Menus;
using SNetwork;
using EndskApi.Enums.Menus;
using EndskApi.Api;
using System.Collections.Generic;
using UniGif;

namespace GTFuckingXP.Scripts.EasterEgg
{
    public class EasterEggScript : BaseMenu
    {
        private const string UriFile = "JumpScareUrls.json";
        private static VideoPlayer _videoPlayer;
        private static UniGifImage _rawImage;
        private static bool _videoPlayerState;

        private List<UrlWithDescription> _urls;
        private SNet_Player _selectedPlayer;
        private int _playerIndex = -1;
        private UrlWithDescription _selectedUrl;
        private int _urlIndex;

        public EasterEggScript(IntPtr intPtr) : base(intPtr)
        {
            _urls = ProfileIndependentDataApi.Load<List<UrlWithDescription>>(UriFile);
            if (_urls.Count == 0)
            {
                _urls.Add(new UrlWithDescription(@"https://i.imgur.com/3C27kAt.mp4", "Hello_my_name_is_Becky", 1f, 1f));
                _urls.Add(new UrlWithDescription(@"https://i.imgur.com/dA7kDrk.mp4", "Jeff jumpscare", 3f, 1f));
                _urls.Add(new UrlWithDescription(@"https://media.vlipsy.com/vlips/IjGuUQmI/480p.mp4", "Some Outlast stuff", 1f, 0.1f));
                ProfileIndependentDataApi.Save(_urls, UriFile);
            }

            PageTitle = "Horror+ Menu";

            _currentState = MenuStates.Deactivated;
            _tools.Add(new Tool("Switch Player{...}", MenuInputProvider.F1, false, SwitchPlayer));
            _tools.Add(new Tool("Switch Url {...}", MenuInputProvider.F2, false, SwitchUrl));
            _tools.Add(new Tool("Apply Jumpscare on selected user", MenuInputProvider.F3, false, CommitJumpScare));
            _tools.Add(new Tool("Apply Jumpscare on all", MenuInputProvider.F4, false, CommitJumpScareAll));
            _tools.Add(new Tool("Reload Urls", MenuInputProvider.F5, false, ReloadUrls));
        }

        protected override void Update()
        {
            if (_videoPlayer != null && _videoPlayerState)
            {
                if (_videoPlayer.frame > 5 && (ulong)(_videoPlayer.frame + 5) > _videoPlayer.frameCount)
                {
                    _videoPlayer.Stop();
                    _videoPlayerState = false;
                }
            }

            base.Update();
        }

        public override void SetState(MenuStates newState)
        {
            _currentState = newState;
        }

        internal void RunJumpScare(string url, float playBackSpeed, float volume)
        {
            if (url.EndsWith("mp4"))
            {
                ShowMp4(url, playBackSpeed, volume);
            }
            else if (url.EndsWith("gif"))
            {
                ShowGif(url);
            }
        }

        private void SwitchPlayer(Tool tool)
        {
            if (_playerIndex + 1 >= SNet.LobbyPlayers.Count)
            {
                _playerIndex = 0;
            }
            else
            {
                _playerIndex++;
            }

            _selectedPlayer = SNet.Slots.GetPlayerInSlot(_playerIndex);


            tool.Text = $"Switch Player{{{_selectedPlayer.NickName}}}";
        }

        public void SwitchUrl(Tool tool)
        {
            _urlIndex++;
            if (_urlIndex >= _urls.Count)
            {
                _urlIndex = 0;
            }

            _selectedUrl = _urls[_urlIndex];
            tool.Text = $"Switch Url {{{_selectedUrl.Description}}}";
        }

        private void CommitJumpScare(Tool _)
        {
            if (_selectedPlayer.IsLocal)
            {
                RunJumpScare(_selectedUrl.Url, _selectedUrl.PlayBackSpeed, _selectedUrl.Volume);
            }
            else
            {
                EasterEggNetworkManager.SendJumpScare(_selectedPlayer, new JumpScare 
                    { Url = _selectedUrl.Url, PlayBackSpeed = _selectedUrl.PlayBackSpeed, Volume = _selectedUrl.Volume });
            }
        }

        private void CommitJumpScareAll(Tool _)
        {
            EasterEggNetworkManager.SendJumpScareToAll(new JumpScare 
                { Url = _selectedUrl.Url, PlayBackSpeed = _selectedUrl.PlayBackSpeed, Volume = _selectedUrl.Volume });
        }

        private void ReloadUrls(Tool _)
        {
            _urls = ProfileIndependentDataApi.Load<List<UrlWithDescription>>(UriFile);
        }

        void ShowMp4(string url, float playBackSpeed, float volume)
        {
            if (_videoPlayer is null)
            {
                _videoPlayer = GuiManager.Current.m_CellUIHUDRoot.gameObject.AddComponent<VideoPlayer>();

                _videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
                _videoPlayer.playOnAwake = false;
                _videoPlayer.targetCameraAlpha = 0.7f;
                _videoPlayer.isLooping = false;
                _videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
            }

            _videoPlayer.playbackSpeed = playBackSpeed;
            _videoPlayer.url = url;
            _videoPlayer.SetDirectAudioVolume(0, volume);
            _videoPlayer.Play();
            _videoPlayerState = true;
        }

        void ShowGif(string url)
        {
            if(_rawImage is null)
            {
                _rawImage = GuiManager.Current.m_CellUIHUDRoot.gameObject.AddComponent<UniGifImage>();
                _rawImage.m_imgAspectCtrl = _rawImage.gameObject.AddComponent<UniGifImageAspectController>();
                _rawImage.m_rawImage = _rawImage.gameObject.AddComponent<RawImage>();
                _rawImage.gameObject.AddComponent<Canvas>();
                _rawImage.enabled = false;
            }

            _rawImage.SetGifFromUrl(url);
        }
    }

    internal class EasterEggNetworkManager
    {
        internal const string JumpScareKey = "JumpScare_DevTools";

        public static void Setup()
        {
            NetworkAPI.RegisterEvent<JumpScare>(JumpScareKey, ReceiveJumpScare);
        }

        public static void ReceiveJumpScare(ulong snetPlayer, JumpScare jmp)
        {
            CacheApi.GetInstance<EasterEggScript>().RunJumpScare(jmp.Url, jmp.PlayBackSpeed, jmp.Volume);
            //JumpScareMenu.CommitJumpScare(null);
        }

        public static void SendJumpScare(SNet_Player receiver, JumpScare jumpScare)
        {
            NetworkAPI.InvokeEvent(JumpScareKey, jumpScare, receiver);
        }

        public static void SendJumpScareToAll(JumpScare jumpScare)
        {
            NetworkAPI.InvokeEvent(JumpScareKey, jumpScare);
        }
    }

    internal struct JumpScare
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Url;
        public float PlayBackSpeed;
        public float Volume;
    }

    internal class UrlWithDescription
    {
        public UrlWithDescription(string url, string description, float playBackSpeed, float volume = 1f)
        {
            Url = url;
            Description = description;
            PlayBackSpeed = playBackSpeed;
            Volume = volume;
        }

        public string Url { get; set; }
        public string Description { get; set; }
        public float PlayBackSpeed { get; set; }
        public float Volume { get; set; }
    }
}
