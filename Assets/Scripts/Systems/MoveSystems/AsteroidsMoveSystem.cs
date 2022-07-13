using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidsMoveSystem  : IEcsRunSystem 
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AsteroidLink, GameObjectLink> filter = null;
    private readonly StaticData staticData = null;
        
    void IEcsRunSystem.Run ()
    {
        foreach (var index in filter)
        {
            ref var link =  ref filter.Get1(index);
            ref var gameObject = ref filter.Get2(index).value;
            var point = link.pointToMove;

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, point, link.asteroidSpeed);

            if (gameObject.transform.position == new Vector3(point.x,point.y)) //Удаление астероида при достижении конечной точки
            {
                ref EcsEntity entity = ref filter.GetEntity(index);
                entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent
                {
                    Value = gameObject.gameObject
                };
            }
        }
    }
}
