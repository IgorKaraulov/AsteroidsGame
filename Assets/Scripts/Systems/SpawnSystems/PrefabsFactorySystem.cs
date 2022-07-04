using Leopotam.Ecs;
using UnityEngine;

sealed class PrefabsFactorySystem : IEcsRunSystem
{
    // auto-injected fields.
    readonly EcsWorld _world = null;
    readonly EcsFilter<SpawnPrefab> filter = null;
    readonly EcsFilter<PrefabsFactoryComponent> factoryFilter = null;
        
    void IEcsRunSystem.Run () 
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var prefab = ref filter.Get1(index);
            foreach (var i in factoryFilter)
            {
                ref var spawnedObjects = ref factoryFilter.Get1(i).spawnedObjects;

                for (int j = 1; j <= prefab.Count; j++)
                {
                    GameObject gameObject = GameObject.Instantiate(prefab.Prefab, prefab.Position, prefab.Rotation,spawnedObjects);
                    var monoEntity = gameObject.GetComponent<MonoEntity>();
                    if (monoEntity == null)
                        return;
                    EcsEntity ecsEntity = _world.NewEntity();
                    monoEntity.Make(ref ecsEntity);
                }
            }
                               
        }
    }
}
