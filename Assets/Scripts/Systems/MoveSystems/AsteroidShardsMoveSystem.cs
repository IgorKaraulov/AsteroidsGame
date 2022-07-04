using Leopotam.Ecs;
using UnityEngine;

sealed class AsteroidShardsMoveSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AsteroidShardLink, GameObjectLink> filter = null;
    private readonly StaticData staticData = null;

    void IEcsRunSystem.Run()
    {
        foreach (var index in filter)
        {
            ref var point = ref filter.Get1(index).pointToMove;
            ref var gameObject = ref filter.Get2(index).value;

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, point, staticData.asteroidShardSpeed);

            if (gameObject.transform.position == new Vector3(point.x, point.y)) //Удаление астероида при достижении конечной точки
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
