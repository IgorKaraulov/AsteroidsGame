using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerSpawnSystem : IEcsInitSystem
{
    // auto-injected fields.
    private EcsWorld _world = null;
    private StaticData staticData;
    private EcsFilter<PrefabsFactoryComponent> filter;

    public void Init()
    {
        var spawnData = new SpawnPrefab
        {
            Prefab = staticData.playerPrefab,
            Position = Vector3.zero,
            Rotation = Quaternion.identity,
            Count = 1
        };

        foreach (var index in filter)
        {
            ref var entety = ref filter.GetEntity(index);
            entety.Get<SpawnPrefab>() = spawnData;
        }
    }
}