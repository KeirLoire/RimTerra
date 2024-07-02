using RimWorld;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public class PlaceWorker_OnStonySoil : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var things = map.thingGrid.ThingsAt(loc);
            var isGravel = map.terrainGrid.TerrainAt(loc) == TerrainDefOf.Gravel;
            var isBlocked = false;

            foreach (var t in things)
            {
                if (t.def.passability == Traversability.Impassable)
                {
                    isBlocked = true;
                    break;
                }
            }

            if (!isGravel || isBlocked)
                return "MustPlaceOnStonySoil".Translate();

            return true;
        }
    }
}
