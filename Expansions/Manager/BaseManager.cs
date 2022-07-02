using GTFuckingXP.Information.Level;
using XpExpansions.Extensions;

namespace XpExpansions.Manager
{
    public abstract class BaseManager
    {
        private static string? _folderPath = null;

        protected string FolderPath
        {
            get
            {
                if(string.IsNullOrEmpty(_folderPath))
                {
                    _folderPath =  CacheApiWrapper.GetFolderPath();
                }

                return _folderPath;
            }
        }

        public abstract void LevelReached(Level level);
        public virtual void LevelInitialized(Level level) { }
        public virtual void Initialize() { }
        public virtual void LevelCleanup() { }
    }
}
