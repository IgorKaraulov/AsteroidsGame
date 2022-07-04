using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidSpawnSystem : IEcsRunSystem , IEcsInitSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private StaticData staticData = null;
    private EcsFilter<PrefabsFactoryComponent> filter = null;
    private float timer;

    public void Init()
    {
        timer = staticData.timeAsteroidSpawn;
    }

    void IEcsRunSystem.Run ()
    {
        timer -= Time.fixedDeltaTime;
        if (timer > 0)
            return;

        SpawnPrefab asteroidPrefab = new SpawnPrefab
        {
            Prefab = staticData.asteroidPrefab,
            Position = PositionCalculator.GetPositionNearViewPort(),
            Rotation = Quaternion.identity,
            Count = 1
        };

        foreach (var index in filter)        
        {
            ref var entety = ref filter.GetEntity(index);
            entety.Get<SpawnPrefab>() = asteroidPrefab;   
        }
        timer = staticData.timeAsteroidSpawn;
    } 
}
