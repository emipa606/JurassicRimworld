using System.Collections.Generic;
using Verse;

namespace JurassicRimworld;

public class TraderKindDefExtension : DefModExtension
{
    public readonly bool AddToAllFactions = false;

    public readonly List<string> CarrierTradeTags = [];

    public bool logging = false;
}