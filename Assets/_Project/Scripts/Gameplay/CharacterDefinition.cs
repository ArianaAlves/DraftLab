using UnityEngine;

[CreateAssetMenu(menuName = "DriftLab/Character Definition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField] private string characterId;
    [SerializeField] private string displayName;
    [SerializeField] private CharacterBodyType bodyType;
    [SerializeField] private bool unlockedByDefault = true;

    public string CharacterId => characterId;
    public string DisplayName => displayName;
    public CharacterBodyType BodyType => bodyType;
    public bool UnlockedByDefault => unlockedByDefault;
}
