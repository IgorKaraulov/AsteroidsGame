using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidCollisionSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AsteroidLink, OnCollisionEnterEvent> filter = null;
    private readonly EcsFilter<PrefabsFactoryComponent> prefabFactoryFilter = null;
    private readonly StaticData staticData = null;

    void IEcsRunSystem.Run()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var entity = ref filter.GetEntity(index);
            ref var collisionEvent = ref filter.Get2(index);
            
            entity.Get<ScoreIncrementEvent>() = new ScoreIncrementEvent
            {
                value = staticData.asteroidCost
            };

            if (collisionEvent.collision.gameObject.tag == Constants.bulletTag)
            {
                foreach (var i in prefabFactoryFilter) 
                {
                    ref var factory = ref prefabFactoryFilter.GetEntity(i);
                    var spawnPos = collisionEvent.collision.transform.position;
                    factory.Get<AsteroidShardSpawnEvent>() = new AsteroidShardSpawnEvent
                    {
                        spawnCount = Random.Range(1, staticData.maxShardsSpawnCount),
                        spawnPosition = spawnPos
                    };
                }               
            }
            
            entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
            {
                Value = entity.Get<GameObjectLink>().value
            };
        }
    }
}
