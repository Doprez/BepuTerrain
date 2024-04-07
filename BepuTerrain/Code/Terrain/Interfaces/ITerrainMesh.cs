using Stride.Core.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepuTerrain.Code.Terrain.Interfaces;
public interface ITerrainMesh
{
	public TrackingCollection<ITerrainRenderData> TerrainModels { get; }
}
