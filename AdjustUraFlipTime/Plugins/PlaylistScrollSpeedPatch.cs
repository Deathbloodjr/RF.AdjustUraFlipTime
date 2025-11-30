using HarmonyLib;
using Scripts.OutGame.SongSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustUraFlipTime.Plugins
{
    internal class PlaylistScrollSpeedPatch
    {
        [HarmonyPatch(typeof(UiFilterScroller))]
        [HarmonyPatch(nameof(UiFilterScroller.AfterScroll))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPrefix]
        public static void UiFilterScroller_AfterScroll_Prefix(UiFilterScroller __instance, ref bool isRepeatFast)
        {
            isRepeatFast = true;
        }
    }
}
