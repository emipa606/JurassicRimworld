using System.Reflection;
using HarmonyLib;
using Verse;

namespace JurassicRimworld;

[StaticConstructorOnStartup]
internal class Main
{
    static Main()
    {
        var harmony = new Harmony("com.serpyderpy.rimworld.mod.JurassicRimworld");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}