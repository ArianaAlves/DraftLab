using UnityEngine;

[CreateAssetMenu(menuName = "DriftLab/Customization Option")]
public class CustomizationOption : ScriptableObject
{
    [SerializeField] private string optionId;
    [SerializeField] private string displayName;
    [SerializeField] private Color primaryColor = Color.white;
    [SerializeField] private Color secondaryColor = Color.gray;
    [SerializeField] private bool unlockedByDefault = true;

    public string OptionId => optionId;
    public string DisplayName => displayName;
    public Color PrimaryColor => primaryColor;
    public Color SecondaryColor => secondaryColor;
    public bool UnlockedByDefault => unlockedByDefault;
}
