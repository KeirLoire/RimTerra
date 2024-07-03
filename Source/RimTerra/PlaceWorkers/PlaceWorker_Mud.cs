using RimWorld;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_Mud : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isShallowWater = terrain.defName == "WaterShallow";

            if (!isShallowWater || IsTerrainBlocked(map, loc))
                return "MustPlaceForMud".Translate();

            return true;
        }
    }
}
