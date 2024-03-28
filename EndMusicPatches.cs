using HarmonyLib;
using StardewValley;

namespace AlvadeasWitchTower
{
    internal static class EndMusicPatches
    {
        public static void Apply(Harmony harmony)
        {
            harmony.Patch(
                original: AccessTools.Method(typeof(GameLocation), nameof(GameLocation.cleanupBeforePlayerExit)),
                prefix: new HarmonyMethod(typeof(EndMusicPatches), nameof(EndMusicPatches.Prefix_CleanupBeforePlayerExit))
            );

        }

        private static void Prefix_CleanupBeforePlayerExit(GameLocation __instance)
        {
            if (Game1.currentLocation.NameOrUniqueName == "Custom_WalWitchtower")
            {
                Game1.changeMusicTrack("none", music_context: StardewValley.GameData.MusicContext.Default);
            }

            if (Game1.currentLocation.NameOrUniqueName == "Custom_WalWitchtowerCave")
            {
                Game1.changeMusicTrack("none", music_context: StardewValley.GameData.MusicContext.Default);
            }
        }
    }
}
