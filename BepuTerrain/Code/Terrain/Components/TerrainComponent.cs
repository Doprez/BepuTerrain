using Stride.Core;
using Stride.Engine.Design;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Rendering;

namespace BepuTerrain.Code.Terrain.Components;
[DataContract(nameof(TerrainComponent))]
[Display("Terrain", Expand = ExpandRule.Once)]
[DefaultEntityComponentRenderer(typeof(TerrainProcessor))]
[ComponentCategory("Terrain")]
public class TerrainComponent : EntityComponent
{
	[DataMember(0)]
	public Material Material { get; set; }

	/// <summary>
	/// Height map asset, currently only short conversion type is supported. Make sure this is correctly set on the asset or 
	/// you will get a null exception.
	/// </summary>
	[DataMember(10)]
	public Heightmap Heightmap { get; set; }

	[DataMember(20)]
	public float Size { get; set; }

	[DataMember(30)]
	public bool CastShadows { get; set; }
}
