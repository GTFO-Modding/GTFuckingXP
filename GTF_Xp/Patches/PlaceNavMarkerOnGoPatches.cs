using GTFuckingXP.Extensions;
using HarmonyLib;

namespace GTFuckingXP.Patches
{
    [HarmonyPatch(typeof(PlaceNavMarkerOnGO))]
    public class PlaceNavMarkerOnGoPatches
    {
        [HarmonyPatch(nameof(PlaceNavMarkerOnGO.UpdateName))]
        [HarmonyPrefix]
        public static void UpdateNamePrefix(PlaceNavMarkerOnGO __instance, ref string name)
        {
            var playerToLevelMap = CacheApiWrapper.GetPlayerToLevelMapping();
            if (playerToLevelMap.TryGetValue(__instance.m_player.PlayerSlotIndex, out var levelNumber))
            {
                name = $"<color=#{BepInExLoader.LevelColor.Value}>Lv.{levelNumber.LevelNumber}</color> {name}";
            }
        }
    }
}
