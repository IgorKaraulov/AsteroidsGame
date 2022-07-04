using Leopotam.Ecs;
using UnityEngine;

 sealed class EcsStartup : MonoBehaviour
 {
    private EcsWorld _world;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;

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

    public static EcsStartup Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public void StopGame(int finalScore)     
    {
        var deathInterface = GameObject.Instantiate(staticData.deathInterfacePrefab);
        deathInterface.GetComponent<DeathInterface>().AddScore(finalScore);
        Destroy(spawnedObjects.gameObject);
        Destroy(this.gameObject);
    }


    private void Start ()
    {          
        _world = new EcsWorld ();
        updateSystems = new EcsSystems (_world);
        fixedUpdateSystems = new EcsSystems (_world);

#if UNITY_EDITOR
       CreateObservers ();
#endif
        InitUpdateSystems ();
        InitFixedUpdateSystems ();
    }

    private void Update ()
    {
       updateSystems?.Run ();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run ();
    }

    private void OnDestroy ()
    {
        DeleteUpdateSystems();
        DeleteFixedUpdateSystems();
        DeleteWorld();
    }

    private void DeleteWorld()
    {
        if (_world != null) 
        {
            _world.Destroy ();
            _world = null;
        }
    }
    private void DeleteUpdateSystems()
    {
        if (updateSystems != null) 
        {
            updateSystems.Destroy();
            updateSystems = null;
        }
    }
    private void DeleteFixedUpdateSystems() 
    {
        if (fixedUpdateSystems != null)
        {
            fixedUpdateSystems.Destroy();
            fixedUpdateSystems = null;
        }
    }


    private void CreateObservers()
    {
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(updateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(fixedUpdateSystems);
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
            .Add(new DeathSystem())

            .Inject(inputSettings)
            .Init();
    }

    private void InitFixedUpdateSystems()
    {
        fixedUpdateSystems
            .Add(new InitializeSpawnersSystem())
            .Add(new PrefabsFactorySystem())


            .Add(new PlayerSpawnSystem())
            .OneFrame<SpawnPrefab>()
            .Add(new ScorerInitSystem())


            .Add(new AsteroidSpawnSystem())
            .Add(new InterfaceInitSystem())
            .Add(new EnemySpawnSystem())
            .Add(new PlayerMoveSystem())
            .Add(new AsteroidsMoveSystem())
            .Add(new EnemyMoveSystem())
            .Add(new BulletSpawnSystem())
            .Add(new BulletMoveSystem())
            .Add(new LaserSpawnSystem())
            .Add(new LaserDestroySystem())
            .Add(new LaserColdownChargesSystem())
            .Add(new BulletCollisionSystem())
            .Add(new EnemyCollisionSystem())
            .Add(new AsteroidCollisionSystem())
            .Add(new PlayerTriggerSystem())
            .Add(new AsteroidShardSpawnSystem())
            .Add(new AsteroidShardCollisionSystem())
            .Add(new AsteroidShardsMoveSystem())
            .Add(new InterfaceUpdateSystem())
            .Add(new ScoreUpdateSystem())
            .Add(new ObjectDestroySystem())




            .OneFrame<AsteroidShardSpawnEvent>()
            .OneFrame<OnTriggerEnterEvent>()
            .OneFrame<OnCollisionEnterEvent>()

            .Inject(staticData)
            .Init();
    }
 }
