using Leopotam.Ecs;
using UnityEngine;

sealed class InterfaceInitSystem : IEcsInitSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly StaticData staticData = null;
    private readonly EcsStartup startup = null;
        
    public void Init ()
    {     
        var prefab = new SpawnPrefab
        {
            Prefab = staticData.interfacePrefab,
            Position = Vector3.zero,
            Rotation = Quaternion.identity,
            Count = 1
        };
        GameObject gameObject = GameObject.Instantiate(prefab.Prefab, prefab.Position, prefab.Rotation, startup.SpawnedObjects);
        var monoEntity = gameObject.GetComponent<MonoEntity>();
        if (monoEntity == null)
            return;
        EcsEntity ecsEntity = _world.NewEntity();
        monoEntity.Make(ref ecsEntity);
    }
}
