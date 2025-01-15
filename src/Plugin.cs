using System;
using System.Reflection;

using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

#if BEPINEX

using BepInEx;

namespace NoCabinGoat {
    [BepInPlugin("com.github.Kaden5480.poy-no-cabin-goat", "NoCabinGoat", PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        public void Awake() {
            Harmony.CreateAndPatchAll(typeof(Plugin.PatchCabinGoat));
        }

#elif MELONLOADER

using MelonLoader;

[assembly: MelonInfo(typeof(NoCabinGoat.Plugin), "NoCabinGoat", PluginInfo.PLUGIN_VERSION, "Kaden5480")]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

namespace NoCabinGoat {
    public class Plugin: MelonMod {

#endif

        [HarmonyPatch(typeof(CabinGoatReact), "StartEvent")]
        static class PatchCabinGoat {
            static bool Prefix(CabinGoatReact __instance) {
                __instance.gameObject.SetActive(false);
                return false;
            }
        }

    }
}
