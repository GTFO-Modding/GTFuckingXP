using EndskApi.Api;
using GTFuckingXP.Information.Level;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using XpExpansions.Information.BioTrackerLocal;
using XpExpansions.Information.DoubleJump;
using XpExpansions.Scripts;

namespace XpExpansions.Manager
{
    public class ClientSidedBioTrackerManager : BaseManager
    {
        private const string _expansionFileName = "BioTracker.json";

        public ClientSidedBioTrackerManager()
        {
            EndskApi.Api.LevelApi.AddEndLevelCallback(DestroyBioTrackerAbility);
        }

        public override void Initialize()
        {
            WriteDefaultJsonBlocks();
            UpdateEverything();
        }

        public override void LevelReached(Level level)
        {
            var levelLayout = GTFuckingXP.Extensions.CacheApiWrapper.GetCurrentLevelLayout();
            var data = CacheApi.GetInstance<List<LocalBioTrackerData>>(Extensions.CacheApiWrapper.ExtensionCacheName);
            var localBioTrackerData = data.FirstOrDefault(it => it.LevelLayoutPersistentId == levelLayout.PersistentId);
            if (localBioTrackerData != null)
            {
                if(localBioTrackerData.UnlockAtLevel <= level.LevelNumber)
                {
                    GTFuckingXP.Extensions.CacheApiWrapper.DestroyOldCreateRegisterAndReturnComponent<ClientSidedBioTrackerAbility>();
                }
                else
                {
                    DestroyBioTrackerAbility();
                }
            }
        }

        public void DestroyBioTrackerAbility()
        {
            GTFuckingXP.Extensions.CacheApiWrapper.KillScript<ClientSidedBioTrackerAbility>();
        }

        private void WriteDefaultJsonBlocks()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var doubleJumpPath = Path.Combine(FolderPath, _expansionFileName);
            if (!File.Exists(doubleJumpPath))
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    IncludeFields = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                File.WriteAllText(doubleJumpPath, JsonSerializer.Serialize(GetDefaultData(), serializerOptions));
            }
        }

        private void UpdateEverything()
        {
            CacheApi.SaveInstance(JsonSerializer.Deserialize<List<LocalBioTrackerData>>(
                File.ReadAllText(Path.Combine(FolderPath, _expansionFileName))),
                Extensions.CacheApiWrapper.ExtensionCacheName);
        }

        private List<LocalBioTrackerData> GetDefaultData()
        {
            var data = new List<LocalBioTrackerData>();

            for (int i = 0; i < 20; i++)
            {
                data.Add(new LocalBioTrackerData(i, 3));
            }

            return data;
        }
    }
}
