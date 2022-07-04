using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

internal class InterfaceMonoLink : MonoLink<InterfaceLink>
{
    [SerializeField]
    private Text positionText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text rotationAngleText;
    [SerializeField]
    private Text momentSpeedText;
    [SerializeField]
    private Text laserChargesText;
    [SerializeField]
    private Text laserColdownText;


    public override void Make(ref EcsEntity entity)
    {
        entity.Get<InterfaceLink>() = new InterfaceLink
        {
            positionText = this.positionText,
            scoreText = this.scoreText,
            rotationAngleText = this.rotationAngleText,
            momentSpeedText = this.momentSpeedText,
            laserChargesText = this.laserChargesText,
            laserColdownText = this.laserColdownText
        };
    }
}
