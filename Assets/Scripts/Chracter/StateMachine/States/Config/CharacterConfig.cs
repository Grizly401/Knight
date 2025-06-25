using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunnigStateConfig _runnigStateConfig;

    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    [SerializeField] private ClimbingConfig _climbingConfig;

    public ClimbingConfig ClimbingConfig => _climbingConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public RunnigStateConfig RunnigStateConfig => _runnigStateConfig;
}
