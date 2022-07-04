using Leopotam.Ecs;
using UnityEngine;


sealed class ObjectDestroySystem : IEcsRunSystem {
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ObjectDestroyComponent> filter;
        
    void IEcsRunSystem.Run ()
    {
        foreach (var index in filter) 
        {
            ref var gameObject = ref filter.Get1(index).Value;
            ref EcsEntity entity = ref filter.GetEntity(index);
            GameObject.Destroy(gameObject);            
            entity.Destroy();
        }
    }
}
