using Leopotam.Ecs;
using UnityEngine;

sealed class BulletCollisionSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<BulletLink, OnCollisionEnterEvent> filter = null;
        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var collisionEvent = ref filter.Get2(index);
            ref var entity = ref filter.GetEntity(index);

            entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
            {
                Value = collisionEvent.sender
            };             
        }
    }
}
