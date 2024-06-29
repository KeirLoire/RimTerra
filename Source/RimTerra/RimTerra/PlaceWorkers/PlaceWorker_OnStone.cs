using Verse;

namespace RimTerra.PlaceWorkers
{
    public class PlaceWorker_OnStone : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var things = map.thingGrid.ThingsAt(loc);
            var isBlocked = false;

            foreach (var t in things)
            {
                if (t.def.passability == Traversability.Impassable)
                {
                    isBlocked = true;
                    break;
                }
            }

            if (map.terrainGrid.TerrainAt(loc).categoryType != TerrainDef.TerrainCategoryType.Stone || isBlocked)
                return "MustPlaceOnStone".Translate();

            return true;
        }
    }
}
