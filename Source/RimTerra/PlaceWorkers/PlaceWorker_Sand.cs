using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_Sand : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isShallowOceanWater = terrain.defName == "WaterOceanShallow";

            if (!isShallowOceanWater || IsTerrainBlocked(map, loc))
                return "MustPlaceForSand".Translate();

            return true;
        }
    }
}
