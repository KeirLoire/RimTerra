using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_MarshySoil : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isMarsh = terrain.defName == "Marsh";

            if (!isMarsh || IsTerrainBlocked(map, loc))
                return "MustPlaceForMarshySoil".Translate();

            return true;
        }
    }
}
