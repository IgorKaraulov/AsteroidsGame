using Leopotam.Ecs;
using UnityEngine;

internal class AsteroidMonoLink : MonoLink<AsteroidLink>
{
    [SerializeField]
    private StaticData staticData;
    [SerializeField]
    private AsteroidType asteroidType;

    public override void Make(ref EcsEntity entity)
    {
        switch (asteroidType)
        {
            case AsteroidType.Asteroid:
                entity.Get<AsteroidLink>() = new AsteroidLink
                {
                    pointToMove = PositionCalculator.GetPositionNearViewPort(),
                    asteroidCost = staticData.asteroidCost,
                    asteroidSpeed = staticData.asteroidSpeed                
                };
                break;
            case AsteroidType.AsteroidShard:
                entity.Get<AsteroidLink>() = new AsteroidLink
                {
                    pointToMove = PositionCalculator.GetPositionNearViewPort(),
                    asteroidCost = staticData.asteroidShardCost,
                    asteroidSpeed = staticData.asteroidShardSpeed
                };
                entity.Get<AsteroidShardLink>() = new AsteroidShardLink();
                break;
        } 
    }
}
public enum AsteroidType {Asteroid, AsteroidShard }