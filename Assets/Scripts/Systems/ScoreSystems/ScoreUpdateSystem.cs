using Leopotam.Ecs;


sealed class ScoreUpdateSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;

    private readonly EcsFilter<ScoreIncrementEvent> filter = null;
    private readonly EcsFilter<ScoreComponent> scoreFilter = null;
        
    void IEcsRunSystem.Run () 
    {
        if (filter.IsEmpty())
            return;

        foreach (var index in filter)
        {
            ref var scoreEvent = ref filter.Get1(index);

            foreach (var i in scoreFilter) 
            {
                ref var score = ref scoreFilter.Get1(i);
                score.value += scoreEvent.value;
            }
        }
    }
}
