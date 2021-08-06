using System.Reflection;
using HarmonyLib;
using Verse;

namespace JurassicRimworld
{
    // Token: 0x02000004 RID: 4
    [StaticConstructorOnStartup]
    internal class Main
    {
        // Token: 0x06000004 RID: 4 RVA: 0x000022C0 File Offset: 0x000004C0
        static Main()
        {
            var harmony = new Harmony("com.serpyderpy.rimworld.mod.JurassicRimworld");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}