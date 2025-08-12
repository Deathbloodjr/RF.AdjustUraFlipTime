using HarmonyLib;
using Scripts.OutGame.SongSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustUraFlipTime.Plugins
{
    internal class SonglistScrollSpeedPatch
    {
        [HarmonyPatch(typeof(UiSongScroller))]
        [HarmonyPatch(nameof(UiSongScroller.Setup))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPrefix]
        public static bool UiSongScroller_Setup_Prefix(UiSongScroller __instance)
        {
            __instance.scrollWait = Plugin.Instance.ConfigSongScrollWait.Value;
            __instance.MoveTime = Plugin.Instance.ConfigSongMoveTime.Value;
            __instance.MoveTimeFast = Plugin.Instance.ConfigSongMoveTimeFast.Value;
            __instance.centerButton.fadeTime = Plugin.Instance.ConfigSongExpandTime.Value;
            return true;
        }
    }
}
