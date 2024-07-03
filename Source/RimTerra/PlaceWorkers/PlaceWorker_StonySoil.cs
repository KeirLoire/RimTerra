using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RimTerra.PlaceWorkers
{
    public sealed class PlaceWorker_StonySoil : PlaceWorkerBase
    {
        // TerrainDefOf is incomplete, so we need to define our own list of terrain def names
        private HashSet<string> _terrainDefs = new HashSet<string>
        { 
            "Sand", 
            "SoftSand", 
            "Mud",
            "PackedDirt" 
        };

        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            var terrain = map.terrainGrid.TerrainAt(loc);
            var isStone = terrain.categoryType == TerrainDef.TerrainCategoryType.Stone;
            var isTerrain = _terrainDefs.Any(x => x == terrain.defName);

            if (!(isStone || isTerrain) || IsTerrainBlocked(map, loc))
                return "MustPlaceForStonySoil".Translate();

            return true;
        }
    }
}
