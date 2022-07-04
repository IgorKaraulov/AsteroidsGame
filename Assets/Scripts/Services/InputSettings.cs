using UnityEngine;
[CreateAssetMenu(fileName ="InputSettingsTemplate", menuName = "AsteroidsTestWork/InputSettingsTemplate")]
public class InputSettings : ScriptableObject
{
    [Header("Move Key Settings")]
    public KeyCode moveForwardKey;
    public KeyCode rotateLeftKey;
    public KeyCode rotateRightKey;

    [Header("Shot Key Settings")]
    public KeyCode bulletShotKey;
    public KeyCode laserShotKey;
}
