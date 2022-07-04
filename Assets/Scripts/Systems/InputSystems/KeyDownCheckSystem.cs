using Leopotam.Ecs;
using UnityEngine;

sealed class KeyDownCheckSystem : IEcsRunSystem
{  
    private readonly EcsWorld _world = null;
	private EcsFilter<PlayerLink> _filter = null;
    private InputSettings inputSettings = null;

	void IEcsRunSystem.Run ()
    {	
		if (Input.GetKey(inputSettings.moveForwardKey))
		{
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<MoveKeyDownTag>();
            }
        }

        if (Input.GetKey(inputSettings.rotateLeftKey))
        {
            foreach (var index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<RotateLeftKeyDownTag>();
            }
        }

        if (Input.GetKey(inputSettings.rotateRightKey))
        {
            foreach (var index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<RotateRightKeyDownTag>();
            }
        }
        if (Input.GetKey(inputSettings.bulletShotKey))
        {
            foreach (var index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<BulletShotKeyDownTag>();
            }
        }
        if (Input.GetKey(inputSettings.laserShotKey))
        {
            foreach (var index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<LaserShotKeyDownTag>();
            }
        }
    }
}
