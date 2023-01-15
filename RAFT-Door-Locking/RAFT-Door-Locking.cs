using Modding;
using UnityEngine;
using HarmonyLib;
using RMLLibrary; 

[Mod]
public class DoorLockingMod : Mod
{
    public override string GetVersion()
    {
        return "1.0.0";
    }

    public override void OnLoad()
    {
        // Apply the patch to the door class
        Harmony.HarmonyInstance.Create("com.example.doorlockingmod").PatchAll(typeof(DoorLockingMod).Assembly);
    }

    public override void OnUnload()
    {
        // Unapply the patch
        Harmony.HarmonyInstance.Create("com.example.doorlockingmod").UnpatchAll("com.example.doorlockingmod");
    }
}

[HarmonyPatch(typeof(Door), "OpenClose")]
public static class DoorLockingPatch
{
    public static bool Prefix(Door __instance)
    {
        if (__instance.isLocked)
        {
            // Display message or perform other action for locked door
            return false;
        }
        return true;
    }
}
