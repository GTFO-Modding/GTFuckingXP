using CustomBoostersXp.Information;
using GTFuckingXP.Managers;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomBoostersXp.Manager
{
    public class BoosterScriptManager
    {
        public const string CustomBoostersFileName = "CustomBoostersXP.json";

        private bool _isInitialized;

        public void Initialize()
        {
            if (_isInitialized)
                return;

            _isInitialized = true;

            var xpScriptManager = ScriptManager.Instance;
            if(!xpScriptManager.IsInitialized)
            {
                xpScriptManager.Initialize();
            }



            var folderPath = ScriptManager.Instance.GetFolderPath();

            //TODO save some static information.

            WriteDefaultJsonFiles(folderPath);
            UpdateEverything(folderPath);
        }

        public void UpdateEverything(string folderPath)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            serializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        public void WriteDefaultJsonFiles(string folderPath)
        {
            var boosterPath = Path.Combine(folderPath, CustomBoostersFileName);
            if(!File.Exists(boosterPath))
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    IncludeFields = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                serializerOptions.Converters.Add(new JsonStringEnumConverter());

                File.WriteAllText(boosterPath, JsonSerializer.Serialize(DefaultBoosterData.GetDefaultBoosters(), serializerOptions));
            }
        }
    }
}
