using Leopotam.Ecs;
using UnityEngine;

sealed class InitializeSpawnersSystem : IEcsInitSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsStartup startup = null;
 
    public void Init() 
    {
       var spawner =  _world.NewEntity();
        spawner.Get<PrefabsFactoryComponent>() = new PrefabsFactoryComponent()
        {
            spawnedObjects = startup.SpawnedObjects
        };
    }
}
