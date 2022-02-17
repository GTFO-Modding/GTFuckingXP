using EndskApi.Api;
using GTFuckingXP.Communication;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using XpDoubleJumpExpansion.Information;

namespace XpDoubleJumpExpansion.Manager
{
    public class DoubleJumpExpansionManager
    {
        private const string _expansionFileName = "DoubleJumpExpansion.json";
        internal static string CacheString => CacheApiWrapper.XpModCacheName;
        private List<DoubleJumpExpansionData> _data;
        private readonly Harmony _harmony;
        private bool _harmonyState;
        private bool _initialized = false;
        private string _folderPath;

        public DoubleJumpExpansionManager()
        {
            _harmony = new Harmony(BepinexLoader.GUID);
            _harmony.UnpatchAll(DoubleJump.EntryPoint.GUID);
            _harmonyState = false;

            InitApi.AddInitCallback(Initialize);
            EndLevelApi.AddEndLevelCallback(LevelCleanup);
        }

        public void Initialize()
        {
            if (!_initialized)
            {
                _folderPath = Path.Combine(ScriptManager.Instance.GetFolderPath(), "Expansions");
                XpApi.AddOnLevelUpCallback(LevelUp);
                WriteDefaultJsonBlocks();
                UpdateEverything();
                _initialized = true;
            }
        }

        private void LevelCleanup()
        {
            if(_harmonyState)
            {
                _harmony.UnpatchSelf();
                _harmonyState = false;
            }
        }

        private void LevelUp(Level level)
        {
            var levelLayout = CacheApiWrapper.GetCurrentLevelLayout();
            var doubleJump = _data.FirstOrDefault(it => it.LevelLayoutPersistentId == levelLayout.PersistentId);
            if(doubleJump != null)
            {
                if (!_harmonyState && doubleJump.UnlockAtLevel <= level.LevelNumber)
                {
                    var doubleJumpAssembly = Assembly.GetAssembly(typeof(DoubleJump.EntryPoint));
                    _harmony.PatchAll(doubleJumpAssembly);
                    _harmonyState = true;
                }
                else if (_harmonyState)
                {
                    _harmony.UnpatchSelf();
                    _harmonyState = false;
                }
            }
            else if(_harmonyState)
            {
                _harmony.UnpatchSelf();
                _harmonyState = false;
            }
        }

        private void WriteDefaultJsonBlocks()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var doubleJumpPath = Path.Combine(_folderPath, _expansionFileName);
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
            _data = JsonSerializeManager.Deserialize<List<DoubleJumpExpansionData>>(
                File.ReadAllText(Path.Combine(_folderPath, _expansionFileName)));
        }

        private List<DoubleJumpExpansionData> GetDefaultData()
        {
            var data = new List<DoubleJumpExpansionData>();

            for(int i = 0; i < 20; i++)
            {
                data.Add(new DoubleJumpExpansionData(i, 3));
            }

            return data;
        }
    }
}
