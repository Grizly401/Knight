using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunnigStateConfig _runnigStateConfig;

    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public RunnigStateConfig RunnigStateConfig => _runnigStateConfig;
}
