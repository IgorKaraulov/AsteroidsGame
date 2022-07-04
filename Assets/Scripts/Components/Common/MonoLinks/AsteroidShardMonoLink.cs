using Leopotam.Ecs;
using UnityEngine;

internal class AsteroidShardMonoLink : MonoLink<AsteroidShardLink>
{
    public override void Make(ref EcsEntity entity)
    {
        entity.Get<AsteroidShardLink>() = new AsteroidShardLink { pointToMove = PositionCalculator.GetPositionNearViewPort()};
    }
}
