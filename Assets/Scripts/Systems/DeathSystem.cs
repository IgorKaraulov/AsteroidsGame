using Leopotam.Ecs;
using UnityEngine;

sealed class DeathSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<DeathEvent> filter = null;
    private readonly EcsStartup startup = null;
    private readonly StaticData staticData = null;
        
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
        var deathInterface = GameObject.Instantiate(staticData.deathInterfacePrefab);
        deathInterface.GetComponent<DeathInterface>().AddScore(finalScore);
        GameObject.Destroy(startup.SpawnedObjects.gameObject);
        GameObject.Destroy(startup.gameObject); // TODO Здесь лучше сделать не уничтожение объекта startup, а отключение конкретных систем
    }
}
