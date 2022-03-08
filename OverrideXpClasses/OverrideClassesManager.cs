using BepInEx;
using EndskApi.Api;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.ClassSelector;
using GTFuckingXP.Information.Level;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OverrideXpClasses
{
    internal class OverrideClassesManager
    {
        public const string LevelLayoutFileName = "OverrideClassLayouts.json";
        public const string BoosterLayoutFileName = "OverrideBoosterEffects.json";
        public const string GroupFileName = "OverrideGroups.json";

        private string _folderPath;

        public OverrideClassesManager()
        {
            EndskApi.Api.InitApi.AddInitCallback(Initialize);
        }

        public void Initialize()
        {
            _folderPath = Path.Combine(Paths.PluginPath, "OverrideXpClasses");

            WriteDefaultJsonBlocks();
            UpdateEverything();
        }

        public void UpdateEverything()
        {
            var newData = ReadJsonBlocks();

            LogManager.Debug($"OverrideReceived: {newData.levelLayouts.Count} levelLayouts, {newData.boosterBuffs.Count} BoosterLayouts, {newData.groups.Count} Groups");

            CacheApi.SaveInstance(newData.levelLayouts, CacheApiWrapper.XpModCacheName);
            CacheApi.SaveInstance(newData.boosterBuffs, CacheApiWrapper.XpModCacheName);
            CacheApi.SaveInstance(newData.groups, CacheApiWrapper.XpModCacheName);
        }

        private void WriteDefaultJsonBlocks()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            serializerOptions.Converters.Add(new JsonStringEnumConverter());

            var levelLayoutsPath = Path.Combine(_folderPath, LevelLayoutFileName);
            if (!File.Exists(levelLayoutsPath))
            {
                File.WriteAllText(levelLayoutsPath, JsonSerializer.Serialize(GTFuckingXP.Information.DefaultXpData.GetDefaultLevelLayout(), serializerOptions));
            }

            var boosterLayoutsPath = Path.Combine(_folderPath, BoosterLayoutFileName);
            if (!File.Exists(boosterLayoutsPath))
            {
                File.WriteAllText(boosterLayoutsPath, JsonSerializer.Serialize(GTFuckingXP.Information.DefaultXpData.GetDefaultBoosterBuffs(), serializerOptions));
            }

            var groupsPath = Path.Combine(_folderPath, GroupFileName);
            if (!File.Exists(groupsPath))
            {
                File.WriteAllText(groupsPath, JsonSerializer.Serialize(GTFuckingXP.Information.DefaultXpData.GetDefaultGroups(), serializerOptions));
            }
        }

        public (List<LevelLayout> levelLayouts, List<BoosterBuffs> boosterBuffs, List<Group> groups) ReadJsonBlocks()
        {
            var serializerSettings = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            serializerSettings.Converters.Add(new JsonStringEnumConverter());

            var levelLayouts = JsonSerializer.Deserialize<List<LevelLayout>>(
                File.ReadAllText(Path.Combine(_folderPath, LevelLayoutFileName)), serializerSettings);

            if (levelLayouts is null || levelLayouts.Count == 0)
            {
                LogManager.Warn("No Data found for XpLayouts/LevelLayouts!");
            }

            var boosterEffects = JsonSerializer.Deserialize<List<BoosterBuffs>>(
               File.ReadAllText(Path.Combine(_folderPath, BoosterLayoutFileName)), serializerSettings);

            if (boosterEffects is null || boosterEffects.Count == 0)
            {
                LogManager.Warn("No Data found for BoosterEffectLayouts!");
            }

            var groups = JsonSerializer.Deserialize<List<Group>>(
                File.ReadAllText(Path.Combine(_folderPath, GroupFileName)), serializerSettings);

            if (groups is null || groups.Count == 0)
            {
                LogManager.Warn("Not data found for Groups!");
            }

            return (levelLayouts, boosterEffects, groups);
        }
    }
}
