using Leopotam.Ecs;
using UnityEngine;

sealed class InitializeSpawnersSystem : IEcsInitSystem
{
    private readonly EcsWorld _world = null;
 
    public void Init() 
    {
       var spawner =  _world.NewEntity();
        spawner.Get<PrefabsFactoryComponent>() = new PrefabsFactoryComponent()
        {
            spawnedObjects = GameObject.Find("SpawnedObjects").transform
        };
    }
}
