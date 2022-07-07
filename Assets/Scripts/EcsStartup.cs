using Leopotam.Ecs;
using UnityEngine;

 sealed class EcsStartup : MonoBehaviour
 {
    private EcsWorld _world;
    private EcsSystems updateSystems;

    private EcsSystems moveSystems;
    private EcsSystems spawnSystems;
    private EcsSystems collisionSystems;
    private EcsSystems otherSystems;

    [SerializeField]
    private StaticData staticData;
    [SerializeField]
    private InputSettings inputSettings;
    [SerializeField]
    private Transform spawnedObjects;

    public Transform SpawnedObjects
    {
        get { return spawnedObjects; }
    }

    private void Start ()
    {          
        _world = new EcsWorld ();
        updateSystems = new EcsSystems(_world);
        moveSystems = new EcsSystems(_world);
        collisionSystems = new EcsSystems(_world);
        spawnSystems = new EcsSystems(_world);
        otherSystems = new EcsSystems(_world);

#if UNITY_EDITOR
        CreateObservers();
#endif
        InitSpawnSystems();
        InitOtherSystems();
        InitMoveSystems();
        InitCollisionSystems();
        InitUpdateSystems();
    }

    private void Update ()
    {
       updateSystems?.Run ();
    }

    private void FixedUpdate()
    {
        spawnSystems?.Run();
        otherSystems?.Run();
        moveSystems?.Run();
        collisionSystems?.Run();
    }

    private void OnDestroy ()
    {
        DestroyUpdateSystems();
        DestroyCollisionSystems();
        DestroyMoveSystems();
        DestroyOtherSystems();
        DestroySpawnSystems();
        DestroyWorld();
    }

    #region Destroy All Systems And World

    private void DestroyWorld()
    {
        if (_world != null) 
        {
            _world.Destroy();
            _world = null;
        }
    }
    private void DestroyUpdateSystems()
    {
        if (updateSystems != null) 
        {
            updateSystems.Destroy();
            updateSystems = null;
        }
    }
    private void DestroyMoveSystems() 
    {
        if (moveSystems != null)
        {
            moveSystems.Destroy();
            moveSystems = null;
        }
    }
    private void DestroyCollisionSystems()
    {
        if (collisionSystems != null)
        {
            collisionSystems.Destroy();
            collisionSystems = null;
        }
    }
    private void DestroySpawnSystems()
    {
        if (spawnSystems != null)
        {
            spawnSystems.Destroy();
            spawnSystems = null;
        }
    }
    private void DestroyOtherSystems()   
    {
        if (otherSystems != null)
        {
            otherSystems.Destroy();
            otherSystems = null;
        }
    }

    #endregion


    #region Init All Systems
    private void CreateObservers()
    {
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(spawnSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(updateSystems);   
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(moveSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(collisionSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(otherSystems);
    }
    private void InitUpdateSystems()
    {
        updateSystems
            .OneFrame<MoveKeyDownTag>()
            .OneFrame<RotateLeftKeyDownTag>()
            .OneFrame<RotateRightKeyDownTag>()
            .OneFrame<BulletShotKeyDownTag>()
            .OneFrame<LaserShotKeyDownTag>()

            .Add(new KeyDownCheckSystem())
            .Add(new ViewportBorderCrossSystem())

            .Inject(inputSettings)
            .Init();
    }
    private void InitMoveSystems()
    {
        moveSystems
            .Add(new PlayerMoveSystem())
            .Add(new BulletMoveSystem())
            .Add(new AsteroidShardsMoveSystem())
            .Add(new AsteroidsMoveSystem())
            .Add(new EnemyMoveSystem())
            .Inject(staticData).

            Init();
    }
    private void InitCollisionSystems()
    { 
        collisionSystems
        .Add(new AsteroidCollisionSystem())
        .Add(new BulletCollisionSystem())
        .Add(new EnemyCollisionSystem())
        .Add(new AsteroidShardCollisionSystem())
        .Add(new PlayerTriggerSystem())

        .OneFrame<OnTriggerEnterEvent>()
        .OneFrame<OnCollisionEnterEvent>()
        .Inject(staticData)
        .Init();
    }
    private void InitSpawnSystems()
    {
        spawnSystems         
         .Add(new InitializeSpawnersSystem())
         .Add(new PrefabsFactorySystem())
         .Add(new PlayerSpawnSystem())

         .OneFrame<SpawnPrefab>()
         .Add(new AsteroidSpawnSystem())
         .Add(new AsteroidShardSpawnSystem())
         .Add(new EnemySpawnSystem())
         .Add(new BulletSpawnSystem())
         .Add(new LaserSpawnSystem())

         .OneFrame<AsteroidShardSpawnEvent>()

         .Inject(this)
         .Inject(staticData)
         .Init();
    }
    private void InitOtherSystems()
    {
        otherSystems
        .Add(new ScorerInitSystem())
        .Add(new InterfaceInitSystem())
        .Add(new LaserColdownChargesSystem())
        .Add(new InterfaceUpdateSystem())
        .Add(new ScoreUpdateSystem())
        .Add(new ObjectDestroySystem())
        .Add(new DeathSystem())
        .Add(new LaserDestroySystem())

        .Inject(this)
        .Inject(staticData)
        .Init();
    }
    #endregion
}
