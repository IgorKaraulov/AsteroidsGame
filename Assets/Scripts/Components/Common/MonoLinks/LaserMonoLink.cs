using Leopotam.Ecs;

internal class LaserMonoLink :MonoLink<LaserLink>
{
    public override void Make(ref EcsEntity entity)
    {
        entity.Get<LaserLink>() = new LaserLink { lifeTime = 0.05f };
    }
}
