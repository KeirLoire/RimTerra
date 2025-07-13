using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_LichenCoveredSoil : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isFungalGravel = terrain.defName == "FungalGravel";

            if (!isFungalGravel || IsTerrainBlocked(map, loc))
                return "MustPlaceForLichenCoveredSoil".Translate();

            return true;
        }
    }
}
