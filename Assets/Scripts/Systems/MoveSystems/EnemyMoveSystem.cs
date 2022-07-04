using Leopotam.Ecs;
using UnityEngine;

sealed class EnemyMoveSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<EnemyLink, GameObjectLink> filter = null;
    private readonly EcsFilter<PlayerLink> playerFilter = null;
    private readonly StaticData staticData = null;

    void IEcsRunSystem.Run()
    {
        foreach (var index in filter)
        {
            ref var gameObject = ref filter.Get2(index).value;
            Vector2 playerPosition;
            foreach (var i in playerFilter)
            {
                ref var playerEntity = ref playerFilter.GetEntity(i);

                playerPosition = playerEntity.Get<GameObjectLink>().value.transform.position;
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerPosition, staticData.enemySpeed);
            }
        }
    }
}
