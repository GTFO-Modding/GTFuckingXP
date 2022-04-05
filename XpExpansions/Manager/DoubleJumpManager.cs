using EndskApi.Api;
using GTFuckingXP.Information.Level;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using XpExpansions.Information.DoubleJump;

namespace XpExpansions.Manager
{
    public class DoubleJumpManager : BaseManager
    {
        public const string DoubleJumpXpExpansionId = "Endskill.DoubleJumpExpansion";
        private const string _expansionFileName = "DoubleJumpExpansion.json";

        private bool _harmonyState;

        public DoubleJumpManager()
        {
            DoubleJumpHarmonyAbility = new Harmony(DoubleJumpXpExpansionId);
            Harmony.UnpatchID(DoubleJump.EntryPoint.GUID);
            _harmonyState = false;
        }

        public Harmony DoubleJumpHarmonyAbility { get; private set; }

        public override void Initialize()
        {
            WriteDefaultJsonBlocks();
            UpdateEverything();
        }

        public override void LevelCleanup()
        {
            if (_harmonyState)
            {
                DoubleJumpHarmonyAbility.UnpatchSelf();
                _harmonyState = false;
            }
        }

        public override void LevelReached(Level level)
        {
            LogManager.Message($"LevelReached, DoubleJump {level.ToString()}");

            var levelLayout = GTFuckingXP.Extensions.CacheApiWrapper.GetCurrentLevelLayout();
            var data = CacheApi.GetInstance<List<DoubleJumpData>>(Extensions.CacheApiWrapper.ExtensionCacheName);
            var doubleJump = data.FirstOrDefault(it => it.LevelLayoutPersistentId == levelLayout.PersistentId);
            if (doubleJump != null)
            {
                if (doubleJump.UnlockAtLevel <= level.LevelNumber)
                {
                    if (!_harmonyState)
                    {
                        var doubleJumpAssembly = Assembly.GetAssembly(typeof(DoubleJump.EntryPoint));
                        DoubleJumpHarmonyAbility.PatchAll(doubleJumpAssembly);
                        _harmonyState = true;
                    }
                }
                else if (_harmonyState)
                {
                    DoubleJumpHarmonyAbility.UnpatchSelf();
                    _harmonyState = false;
                }
            }
            else if (_harmonyState)
            {
                DoubleJumpHarmonyAbility.UnpatchSelf();
                _harmonyState = false;
            }
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
            CacheApi.SaveInstance(JsonSerializer.Deserialize<List<DoubleJumpData>>(
                File.ReadAllText(Path.Combine(FolderPath, _expansionFileName))),
                Extensions.CacheApiWrapper.ExtensionCacheName);
        }

        private List<DoubleJumpData> GetDefaultData()
        {
            var data = new List<DoubleJumpData>();

            for (int i = 0; i < 20; i++)
            {
                data.Add(new DoubleJumpData(i, 3));
            }

            return data;
        }
    }
}
