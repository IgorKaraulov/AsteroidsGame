using Leopotam.Ecs;
using UnityEngine;

internal class PrefabsFactoryMonoLink : MonoLink<PrefabsFactoryComponent>
{
    public override void Make(ref EcsEntity entity)
    {
        entity.Get<PrefabsFactoryComponent>() = new PrefabsFactoryComponent()
        {
            spawnedObjects = EcsStartup.Instance.SpawnedObjects
        };
    }
}
