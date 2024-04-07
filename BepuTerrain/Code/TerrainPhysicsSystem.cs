using BepuTerrain.Code.Terrain.Interfaces;
using Stride.Core.Collections;
using Stride.Core;
using Stride.Engine;
using Stride.BepuPhysics;
using Stride.BepuPhysics.Definitions.Colliders;

namespace BepuTerrain.Code;
public class TerrainPhysicsSystem : GameSystem
{

	private readonly ITerrainMesh _terrainMesh;

	public TerrainPhysicsSystem(IServiceRegistry registry, ITerrainMesh terrainProcessor) : base(registry)
	{
		_terrainMesh = terrainProcessor;

		_terrainMesh.TerrainModels.CollectionChanged += TerrainModelsOnCollectionChanged;
	}

	private void TerrainModelsOnCollectionChanged(object? sender, TrackingCollectionChangedEventArgs e)
	{
		RemoveColliderFromComponent((ITerrainRenderData)e.Item);
		if (e.Item != null)
		{
			AddColliderToComponent((ITerrainRenderData)e.Item);
		}
	}

	private void AddColliderToComponent(ITerrainRenderData component)
	{
		var staticComponent = new StaticComponent()
		{
			Collider = new MeshCollider()
			{ Model = component.ModelComponent.Model }
		};
		component.ModelComponent.Entity.Add(staticComponent);
	}

	private void RemoveColliderFromComponent(ITerrainRenderData component)
	{
		var collider = component.ModelComponent.Entity.Get<StaticComponent>();
		var entity = component.ModelComponent.Entity;
		if (collider != null)
		{
			entity.Remove(collider);
		}
	}
}

