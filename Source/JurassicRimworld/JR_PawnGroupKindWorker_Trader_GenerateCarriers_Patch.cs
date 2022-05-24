using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace JurassicRimworld;

[HarmonyPatch(typeof(PawnGroupKindWorker_Trader), "GenerateCarriers")]
public static class JR_PawnGroupKindWorker_Trader_GenerateCarriers_Patch
{
    [HarmonyPrefix]
    public static bool Trader_GenerateCarriers_Postfix(ref PawnGroupKindWorker_Trader __instance,
        PawnGroupMakerParms parms, PawnGroupMaker groupMaker, Pawn trader, List<Thing> wares,
        ref List<Pawn> outPawns)
    {
        if (!trader.TraderKind.HasModExtension<TraderKindDefExtension>())
        {
            return true;
        }

        var traderExt = trader.TraderKind.GetModExtension<TraderKindDefExtension>();
        if (traderExt.CarrierTradeTags.NullOrEmpty())
        {
            return true;
        }

        var list = (from x in wares
            where !(x is Pawn)
            select x).ToList();
        var i = 0;
        var num = Mathf.CeilToInt(list.Count / 8f);
        var pawnKindDef = (from y in DefDatabase<PawnKindDef>.AllDefs
            where y.race.race.packAnimal
            select y
            into x
            where x.race.tradeTags.Any(y => traderExt.CarrierTradeTags.Contains(y)) &&
                  trader.TraderKind.defName == "Caravan_Outlander_Carnivore" ||
                  x.race.tradeTags.Contains("HerbivoreDinosaur") &&
                  trader.TraderKind.defName == "Caravan_Outlander_Herbivore"
            select x).RandomElement();
        var list2 = new List<Pawn>();
        for (var j = 0; j < num; j++)
        {
            var faction = parms.faction;
            var tile = parms.tile;
            var pawnGenerationRequest = new PawnGenerationRequest(pawnKindDef, faction,
                PawnGenerationContext.NonPlayer, tile, false, false, false, false, true, false, 1f, false,
                true, true, parms.inhabitants, false, false, false, false, 0f, 0f, null, 0f);
            var pawn = PawnGenerator.GeneratePawn(pawnGenerationRequest);
            if (i < list.Count)
            {
                pawn.inventory.innerContainer.TryAdd(list[i]);
                i++;
            }

            list2.Add(pawn);
            outPawns.Add(pawn);
        }

        while (i < list.Count)
        {
            list2.RandomElement().inventory.innerContainer.TryAdd(list[i]);
            i++;
        }

        return false;
    }
}