using Enemies;
using GTFuckingXP.Managers;
using HarmonyLib;

namespace GTFuckingXP.Patches.EnemyScaling
{
    [HarmonyPatch(typeof(EnemyAgent))]
    public class EnemyAgentPatches
    {
        [HarmonyPatch(nameof(EnemyAgent.Setup))]
        [HarmonyPostfix]
        public static void SetupPostfix(EnemyAgent __instance)
        {
            var test = RundownManager.GetActiveExpeditionData();
            if(test != null)
            {
                LogManager.Debug($"ExpeditionIndex = {test.expeditionIndex} and Tier: {test.tier}");
            }
            else
            {
                LogManager.Warn("ActiveExpedition was not set yet!");
            }
                
                var courseNode = __instance.GetCourseNode();
            //courseNode.m_zone.Alias;
        }
    }
}
