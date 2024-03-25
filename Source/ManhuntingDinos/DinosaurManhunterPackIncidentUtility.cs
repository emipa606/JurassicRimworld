using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace ManhuntingDinos;

public static class DinosaurManhunterPackIncidentUtility
{
    public static bool TryFindManhunterAnimalKind(float points, int tile, out PawnKindDef animalKind)
    {
        var enumerable = from k in DefDatabase<PawnKindDef>.AllDefs
            where k.RaceProps.Animal &&
                  (tile == -1 ||
                   Find.World.tileTemperatures.SeasonAndOutdoorTemperatureAcceptableFor(tile, k.race)) &&
                  k.combatPower > 89f
            select k;
        return enumerable.TryRandomElement(out animalKind);
    }

    public static List<Pawn> GenerateAnimals(PawnKindDef animalKind, int tile, float points)
    {
        var num = Mathf.Max(Mathf.RoundToInt(points / animalKind.combatPower), 1);
        var list = new List<Pawn>();
        for (var i = 0; i < num; i++)
        {
            var pawnGenerationRequest =
                new PawnGenerationRequest(animalKind, null, PawnGenerationContext.NonPlayer, tile);
            var item = PawnGenerator.GeneratePawn(pawnGenerationRequest);
            list.Add(item);
        }

        return list;
    }
}