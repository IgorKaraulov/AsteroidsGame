using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerMoveSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private EcsFilter<PlayerLink, RigidbodyLink, MoveKeyDownTag> moveFilter = null;
    private EcsFilter<PlayerLink, RigidbodyLink, RotateLeftKeyDownTag> rotateLeftFilter = null;
    private EcsFilter<PlayerLink, RigidbodyLink, RotateRightKeyDownTag> rotateRightFilter = null;
    private StaticData staticData = null;

   
        
    void IEcsRunSystem.Run ()
    {
        Move();
        RotateLeft();
        RotateRight();
    }


    private void Move()
    {
        if (moveFilter.IsEmpty())
            return;

        foreach (var index in moveFilter)
        {
            ref var rigidBody2D = ref moveFilter.Get2(index).Value;

            rigidBody2D.AddForce(rigidBody2D.transform.up * staticData.moveSpeed);
        }
    }
    private void RotateLeft()
    {
        if (rotateLeftFilter.IsEmpty())
            return;

        foreach (var index in rotateLeftFilter)
        {
            ref var rigidBody2D = ref rotateLeftFilter.Get2(index).Value;

            rigidBody2D.transform.Rotate(new Vector3(0, 0, 1) * staticData.rotateSpeed);
        }
    }
    private void RotateRight()
    {
        if (rotateRightFilter.IsEmpty())
            return;

        foreach (var index in rotateRightFilter)
        {
            ref var rigidBody2D = ref rotateRightFilter.Get2(index).Value;

            rigidBody2D.transform.Rotate(new Vector3(0, 0, -1) * staticData.rotateSpeed);
        }
    }
}

