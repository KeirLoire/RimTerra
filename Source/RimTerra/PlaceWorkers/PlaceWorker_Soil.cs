using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_Soil : PlaceWorkerBase
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);

            if ((terrain != TerrainDefOf.Gravel) || IsTerrainBlocked(map, loc))
                return "MustPlaceOnStonySoil".Translate();

            return true;
        }
    }
}
