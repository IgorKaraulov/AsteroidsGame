using Leopotam.Ecs;
using UnityEngine;

sealed class EnemyCollisionSystem : IEcsRunSystem 
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<EnemyLink, OnCollisionEnterEvent> filter = null;
    private readonly StaticData staticData = null;
        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var entity = ref filter.GetEntity(index);

            entity.Get<ScoreIncrementEvent>() = new ScoreIncrementEvent
            {
                value = staticData.enemyCost
            };

            entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
            {
                Value = entity.Get<GameObjectLink>().value
            };
        }
    }
}
