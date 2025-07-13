using RimWorld;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_Soil : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isGravel = terrain.defName == "Gravel";

            if (!isGravel || IsTerrainBlocked(map, loc))
                return "MustPlaceForSoil".Translate();

            return true;
        }
    }
}
