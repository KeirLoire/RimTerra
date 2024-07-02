using RimWorld;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public class PlaceWorker_RichSoil : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var things = map.thingGrid.ThingsAt(loc);
            var isSoil = map.terrainGrid.TerrainAt(loc) == TerrainDefOf.Soil;
            var isBlocked = false;

            foreach (var t in things)
            {
                if (t.def.passability == Traversability.Impassable)
                {
                    isBlocked = true;
                    break;
                }
            }

            if (!isSoil || isBlocked)
                return "MustPlaceOnSoil".Translate();

            return true;
        }
    }
}
