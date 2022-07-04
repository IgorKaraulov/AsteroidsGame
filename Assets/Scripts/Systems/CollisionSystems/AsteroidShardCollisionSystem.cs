using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidShardCollisionSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AsteroidShardLink, OnCollisionEnterEvent> filter = null;
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
            
            entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
            {
                Value = entity.Get<GameObjectLink>().value
            };
        }
    }
}
