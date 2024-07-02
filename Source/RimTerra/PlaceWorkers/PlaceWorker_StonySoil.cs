using RimWorld;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public class PlaceWorker_StonySoil : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var things = map.thingGrid.ThingsAt(loc);
            var isStone = map.terrainGrid.TerrainAt(loc).categoryType == TerrainDef.TerrainCategoryType.Stone;
            var isBlocked = false;
            var isSmoothStone = false;

            foreach (var t in things)
            {
                if (t.def.IsSmoothed)
                {
                    isSmoothStone = true;
                    break;
                }
            }

            foreach (var t in things)
            {
                if (t.def.passability == Traversability.Impassable)
                {
                    isBlocked = true;
                    break;
                }
            }

            if (!(isStone || isSmoothStone) || isBlocked)
                return "MustPlaceOnStone".Translate();

            return true;
        }
    }
}
