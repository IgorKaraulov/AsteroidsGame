using Leopotam.Ecs;
using UnityEngine;

sealed class BulletSpawnSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly StaticData staticData = null;
    private readonly EcsFilter<BulletShotKeyDownTag> filter = null;

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

        foreach (var index in filter)
        {
            ref var entity = ref filter.GetEntity(index);
            ref var gameObject = ref entity.Get<GameObjectLink>().value;

            var bulletPrefab = new SpawnPrefab
            {
                Prefab = staticData.bulletPrefab,
                Position = gameObject.transform.position+gameObject.transform.up/1.5f,
                Rotation = gameObject.transform.rotation,
                Count = 1
            };

            entity.Get<SpawnPrefab>() = bulletPrefab;
            timer = staticData.bulletShotColdown;
        }       
    }
}
