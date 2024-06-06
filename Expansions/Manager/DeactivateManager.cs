using GTFuckingXP.Information.Level;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace XpExpansions.Manager
{
    public class DeactivateManager : BaseManager
    {
        private const string _expansionFileName = "DeactivateOnMissions.json";
        private const string _expansionClassFileName = "DeactivateClassLayout.json";

        public override void Initialize()
        {

        }

        public override void LevelReached(Level level)
        {

        }

        private void WriteDefaultJsonBlocks()
        {
            if (!FolderPath.Contains("BepInEx"))
                return;

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            var doubleJumpPath = Path.Combine(FolderPath, _expansionFileName);
            if (!File.Exists(doubleJumpPath))
            {
               
                File.WriteAllText(doubleJumpPath, JsonSerializer.Serialize(new List<int>() { 69420,42069}, serializerOptions));
            }
        }
    }
}
