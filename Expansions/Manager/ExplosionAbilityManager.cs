using GTFuckingXP.Information.Level;
using HarmonyLib;
using XpExpansions.Patches;

namespace XpExpansions.Manager
{
    public class ExplosionAbilityManager : BaseManager
    {
        public const string ExplosionHarmonyInstanceId = "Endskill.ExplosionAbility";

        public ExplosionAbilityManager()
        {
            ExplosionHarmony = new Harmony(ExplosionHarmonyInstanceId);
        }

        public Harmony ExplosionHarmony { get; private set; }

        public override void Initialize()
        {
            //ExplosionHarmony.PatchAll(typeof(MwsAttackSwingBasePatches));
        }

        public override void LevelReached(Level level)
        {
        }

        public override void LevelCleanup()
        {
        }
    }
}
