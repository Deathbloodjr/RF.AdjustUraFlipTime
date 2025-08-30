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
    internal class MyLibraryOrderPatch
    {
        [HarmonyPatch(typeof(SongScroller))]
        [HarmonyPatch(nameof(SongScroller.CreateItemList))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPrefix]
        public static void SongScroller_CreateItemList_Prefix(SongScroller __instance, Il2CppSystem.Collections.Generic.List<MusicDataInterface.MusicInfoAccesser> list)
        {
            //Logger.Log("SongScroller_CreateItemList_Prefix");
            if (__instance.filter == FilterTypes.MyLibrary)
            {
                List<MusicDataInterface.MusicInfoAccesser> newList = new List<MusicDataInterface.MusicInfoAccesser>();
                for (int i = 0; i < list.Count; i++)
                {
                    newList.Add(list[i]);
                }
                newList = newList.OrderBy((x) => x.GenreNo)
                                 .ThenBy((x) => x.Order)
                                 .ToList();
                list.Clear();
                for (int i = 0; i < newList.Count; i++)
                {
                    list.Add(newList[i]);
                }
            }
        }
    }
}
