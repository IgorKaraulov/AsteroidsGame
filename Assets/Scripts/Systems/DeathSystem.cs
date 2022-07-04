using Leopotam.Ecs;
using UnityEngine;

sealed class DeathSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<DeathEvent> filter = null;
        
    void IEcsRunSystem.Run ()
    {
        if (filter.IsEmpty()) 
            return;

        foreach (var index in filter) 
        {
            ref var playerEntity = ref filter.GetEntity(index);

            ref var finalScore = ref playerEntity.Get<ScoreComponent>().value;
           
            Death(finalScore);
        }        
    }

    private void Death(int finalScore)
    {
        EcsStartup.Instance.StopGame(finalScore);
    }
}
