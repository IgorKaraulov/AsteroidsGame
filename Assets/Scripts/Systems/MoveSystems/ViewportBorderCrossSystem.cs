using Leopotam.Ecs;
using UnityEngine;

sealed class ViewportBorderCrossSystem : IEcsRunSystem, IEcsInitSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerLink, GameObjectLink> playerFilter;
    private readonly EcsFilter<BulletLink, GameObjectLink> bulletFilter;

    private Camera mainCamera;
    private float teleportOffset = 0.3f;

    public void Init()
    {
        mainCamera = Camera.main;
    }

    void IEcsRunSystem.Run ()
    {
        var leftBottom = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        var rightTop = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));


        #region PlayerCrossBorder
        foreach (var index in playerFilter)
        {
            ref var gameObject = ref playerFilter.Get2(index).value;         

            bool isLeftBorderCrossed = gameObject.transform.position.x <=leftBottom.x;
            bool isRightBorderCrossed = gameObject.transform.position.x >= rightTop.x;
            bool isTopBorderCrossed = gameObject.transform.position.y >= rightTop.y;
            bool isBottomBorderCrossed = gameObject.transform.position.y <= leftBottom.y;

            if (isLeftBorderCrossed)
            {
                gameObject.transform.position = new Vector2(rightTop.x-teleportOffset,gameObject.transform.position.y);
            }
            if (isRightBorderCrossed)
            {
                gameObject.transform.position = new Vector2(leftBottom.x+teleportOffset, gameObject.transform.position.y);
            }
            if (isTopBorderCrossed) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, leftBottom.y+teleportOffset);
            }
            if (isBottomBorderCrossed) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, rightTop.y-teleportOffset);
            }
        }
        #endregion

        #region BulletCrossBorder
        if (bulletFilter.IsEmpty())
            return;

        foreach (var index in bulletFilter)
        {
            ref var gameObject = ref bulletFilter.Get2(index).value;

            bool isLeftBorderCrossed = gameObject.transform.position.x <= leftBottom.x;
            bool isRightBorderCrossed = gameObject.transform.position.x >= rightTop.x;
            bool isTopBorderCrossed = gameObject.transform.position.y >= rightTop.y;
            bool isBottomBorderCrossed = gameObject.transform.position.y <= leftBottom.y;

            if (isLeftBorderCrossed || isRightBorderCrossed || isTopBorderCrossed || isBottomBorderCrossed) 
            {
                ref var entity = ref bulletFilter.GetEntity(index);
                entity.Get<ObjectDestroyComponent>() = new ObjectDestroyComponent 
                {
                    Value = gameObject
                };
            }
        }
        #endregion
    }
}
