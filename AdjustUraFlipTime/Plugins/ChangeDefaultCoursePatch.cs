using HarmonyLib;
using Scripts.OutGame.SongSelect;
using Scripts.OutGame.SongSelect.DiffSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustUraFlipTime.Plugins
{
    internal class ChangeDefaultCoursePatch
    {
        [HarmonyPatch(typeof(UiDiffSelect1P))]
        [HarmonyPatch(nameof(UiDiffSelect1P.Setup))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPrefix]
        public static void UiDiffSelect1P_Setup_Prefix(UiDiffSelect1P __instance, DiffSelect1P model)
        {
            if (model.OldIndex != 3 &&
                model.OldIndex != 4)
            {
                model.OldIndex = 3;
            }
        }
    }
}
