using Leopotam.Ecs;
using UnityEngine;

sealed class LaserSpawnSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<LaserShotKeyDownTag> filter = null;
    private readonly EcsFilter<PlayerLink,LaserChargesComponent> chargesFilter = null;
    private readonly StaticData staticData = null;

    private float timer = 0;

    void IEcsRunSystem.Run ()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            return;
        }

        if (filter.IsEmpty())
            return;
        foreach (var i in chargesFilter)
        {
            ref var charges = ref chargesFilter.Get2(i);

            if (charges.count > 0)
            {
                foreach (var index in filter)
                {
                    ref var entity = ref filter.GetEntity(index);
                    ref var gameObject = ref entity.Get<GameObjectLink>().value;

                    var bulletPrefab = new SpawnPrefab
                    {
                        Prefab = staticData.laserPrefab,
                        Position = gameObject.transform.position + gameObject.transform.up * 5,
                        Rotation = gameObject.transform.rotation,
                        Count = 1
                    };

                    entity.Get<SpawnPrefab>() = bulletPrefab;
                    timer = staticData.laserShotColdown;
                }
                charges.count--;
            }
        }  
    }
}
