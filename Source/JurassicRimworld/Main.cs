using System.Reflection;
using HarmonyLib;
using Verse;

namespace JurassicRimworld;

[StaticConstructorOnStartup]
internal class Main
{
    static Main()
    {
        new Harmony("com.serpyderpy.rimworld.mod.JurassicRimworld").PatchAll(Assembly.GetExecutingAssembly());
    }
}