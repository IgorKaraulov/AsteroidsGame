using Leopotam.Ecs;


sealed class ScorerInitSystem : IEcsInitSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerLink> filter = null;

        
    public void Init ()
    {
        foreach (var index in filter) 
        {
            ref EcsEntity playerEntity = ref filter.GetEntity(index);

            playerEntity.Get<ScoreComponent>() = new ScoreComponent
            {
                value = 0
            };
        }
    }
}
