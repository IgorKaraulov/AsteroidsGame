using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerTriggerSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerLink, OnTriggerEnterEvent> filter = null;
        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
           ref var triggerEvent = ref filter.Get2(index);

            if (triggerEvent.Collider.tag != Constants.bulletTag && triggerEvent.Collider.tag != Constants.laserTag)
            {
                ref var entity = ref filter.GetEntity(index);

                entity.Get<DeathEvent>() = new DeathEvent();
            }
        }   
    }
}
