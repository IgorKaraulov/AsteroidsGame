using UnityEngine;

[CreateAssetMenu(menuName = "AsteroidsTestWork/StaticData", fileName ="NewStaticData")]
public class StaticData : ScriptableObject
{
    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject asteroidPrefab;
    public GameObject asteroidShardPrefab;
    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public GameObject interfacePrefab;
    public GameObject deathInterfacePrefab;

    [Header("Player Stats")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Asteroid Stats")]
    public float asteroidSpeed;
    public float timeAsteroidSpawn;
    public int asteroidCost;

    [Header("Asteroid Shard Stats")]
    public int asteroidShardCost;
    public int maxShardsSpawnCount;
    public float asteroidShardSpeed;

    [Header("Enemy Stats")]
    public float enemySpeed;
    public float timeEnemySpawn;
    public int enemyCost;

    [Header("Bullet Shots Stats")]
    public float bulletFlightSpeed;
    public float bulletShotColdown;

    [Header("Laser Shots Stats")]
    [Range(1f,10f)]
    public float laserShotColdown;
    public float laserChargeColdown;
    public int laserChargesMaxCount;
}
