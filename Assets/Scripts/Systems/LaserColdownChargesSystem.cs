using Leopotam.Ecs;
using UnityEngine;

sealed class LaserColdownChargesSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly StaticData staticData = null;
    private readonly EcsFilter<PlayerLink, LaserChargesComponent> filter = null;
       
    void IEcsRunSystem.Run ()
    {
        foreach (var index in filter)
        {
            ref var laserCharges = ref filter.Get2(index);

            if (laserCharges.timer > 0)
            {
                laserCharges.timer -= Time.fixedDeltaTime;
                return;
            }  

            if (laserCharges.count < staticData.laserChargesMaxCount)
            {
                laserCharges.count++;
            }

            laserCharges.timer = staticData.laserChargeColdown;          
        }
    }
}