using Leopotam.Ecs;

internal class AsteroidMonoLink : MonoLink<AsteroidLink>
{
    public override void Make(ref EcsEntity entity)
    {
        entity.Get<AsteroidLink>() = new AsteroidLink { pointToMove = PositionCalculator.GetPositionNearViewPort() };
    }
}
