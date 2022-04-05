using EndskApi.Api;
using GameData;
using GTFuckingXP.Information.Level;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using XpExpansions.Information.StartingXp;

namespace XpExpansions.Manager
{
    internal class StartingLevelXpManager : BaseManager
    {
        private const string _expansionFileName = "StartingXP.json";

        public StartingLevelXpManager()
        {
        }

        public override void Initialize()
        {
            WriteDefaultJsonBlocks();
            UpdateEverything();
        }

        public override void LevelReached(Level level)
        {
        }

        public override void LevelInitialized(Level level)
        {
            var expedition = RundownManager.ActiveExpedition;
            var startingXpData = CacheApi.GetInstance<List<StartingXpData>>(Extensions.CacheApiWrapper.ExtensionCacheName);
 
            var apply = startingXpData.FirstOrDefault(it => it.LevelLayoutData == expedition.LevelLayoutData);
            if(apply != null)
            {
                GTFuckingXP.Communication.XpApi.AddXp(apply.StartingXp);
            }
        }

        private void UpdateEverything()
        {
            CacheApi.SaveInstance(JsonSerializer.Deserialize<List<StartingXpData>>(
                File.ReadAllText(Path.Combine(FolderPath, _expansionFileName))),
                Extensions.CacheApiWrapper.ExtensionCacheName);
        }

        private void WriteDefaultJsonBlocks()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var startXpPath = Path.Combine(FolderPath, _expansionFileName);
            if (!File.Exists(startXpPath))
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    IncludeFields = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                File.WriteAllText(startXpPath, JsonSerializer.Serialize(GetDefaultData(), serializerOptions));
            }
        }

        private List<StartingXpData> GetDefaultData()
        {
            var result = new List<StartingXpData>();
            foreach (var level in GameDataBlockBase<RundownDataBlock>.GetAllBlocks())
            {
                foreach (var inner in level.TierD)
                {
                    result.Add(new StartingXpData(inner.LevelLayoutData, 100));
                }
            }

            return result;
        }
    }
}
