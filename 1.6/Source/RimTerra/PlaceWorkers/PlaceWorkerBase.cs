using Verse;

namespace RimTerra.PlaceWorkers
{
    public class PlaceWorkerBase : PlaceWorker
    {
        public bool IsTerrainBlocked(Map map, IntVec3 loc)
        {
            var things = map.thingGrid.ThingsAt(loc);

            foreach (var thing in things)
            {
                if (thing.def.passability == Traversability.Impassable)
                    return true;
            }

            return false;
        }
    }
}
