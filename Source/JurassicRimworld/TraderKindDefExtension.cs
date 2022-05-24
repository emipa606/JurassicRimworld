using System.Collections.Generic;
using Verse;

namespace JurassicRimworld;

public class TraderKindDefExtension : DefModExtension
{
    public bool AddToAllFactions = false;

    public List<string> CarrierTradeTags = new List<string>();

    public bool logging = false;
}