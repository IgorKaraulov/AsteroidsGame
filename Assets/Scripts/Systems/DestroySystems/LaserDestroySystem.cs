using Leopotam.Ecs;
using UnityEngine;

sealed class LaserDestroySystem : IEcsRunSystem 
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<LaserLink> filter = null;
    private readonly StaticData staticData = null;

    private float timer = 0;
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var laser = ref filter.Get1(index);

            if (laser.lifeTime > 0)
            {
                laser.lifeTime -= Time.fixedDeltaTime;
                return;
            }

            ref EcsEntity entity = ref filter.GetEntity(index);

            entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
            {
                Value = entity.Get<GameObjectLink>().value
            };
        }
    }
}
