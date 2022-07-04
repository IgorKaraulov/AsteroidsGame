using Leopotam.Ecs;


sealed class InterfaceUpdateSystem : IEcsRunSystem
{
    // auto-injected fields.
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<InterfaceLink> filter = null;
    private readonly EcsFilter<PlayerLink> playerFilter = null;
        
    void IEcsRunSystem.Run ()
    {
        foreach (var index in filter)
        {
            ref var customInterface = ref filter.Get1(index);

            foreach (var i in playerFilter)
            {
                ref var playerEntety = ref playerFilter.GetEntity(i);

                ref var playerRb = ref playerEntety.Get<RigidbodyLink>().Value;
                ref var laserCharges = ref playerEntety.Get<LaserChargesComponent>();

                customInterface.scoreText.text = $"Score: {playerEntety.Get<ScoreComponent>().value.ToString()}";
                customInterface.positionText.text = $"Position: {playerRb.position.ToString()}";
                customInterface.rotationAngleText.text = $"Rotation: {playerRb.rotation.ToString()}";
                customInterface.momentSpeedText.text = $"Moment speed: {playerRb.velocity.magnitude.ToString()}";
                customInterface.laserChargesText.text = $"Laser charges: {laserCharges.count.ToString()}";
                customInterface.laserColdownText.text = $"Laser coldown: {laserCharges.timer.ToString()}";
            }
        }
    }
}
