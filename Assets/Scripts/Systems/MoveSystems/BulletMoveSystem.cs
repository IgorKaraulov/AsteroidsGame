using Leopotam.Ecs;

sealed class BulletMoveSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<BulletLink,RigidbodyLink> filter = null;
    private readonly StaticData staticData = null;

        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty())
            return;
        foreach (var index in filter)
        {
            ref var rb = ref filter.Get2(index).Value;

            rb.AddForce(rb.transform.up*staticData.bulletFlightSpeed);
        }       
    }
}
