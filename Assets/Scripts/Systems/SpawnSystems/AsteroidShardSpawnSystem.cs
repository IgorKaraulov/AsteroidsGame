using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidShardSpawnSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly StaticData staticData = null;
    private readonly EcsFilter<AsteroidShardSpawnEvent> filter = null;
        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var spawnEvent = ref filter.Get1(index);
            ref var entity = ref filter.GetEntity(index);
          
            entity.Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = staticData.asteroidShardPrefab,
                Position = spawnEvent.spawnPosition,
                Rotation = Quaternion.identity,
                Count = spawnEvent.spawnCount
            };  
        }
    }
}
