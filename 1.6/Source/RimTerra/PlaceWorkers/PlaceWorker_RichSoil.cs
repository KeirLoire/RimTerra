using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_RichSoil : PlaceWorkerBase
    {
        // TerrainDefOf is incomplete, so we need to define our own list of terrain def names
        private HashSet<string> _terrainDefs = new HashSet<string> 
        { 
            "Soil", 
            "MossyTerrain" 
        };

        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isTerrain = _terrainDefs.Any(x => x == terrain.defName);

            if (!isTerrain || IsTerrainBlocked(map, loc))
                return "MustPlaceForRichSoil".Translate();

            return true;
        }
    }
}
