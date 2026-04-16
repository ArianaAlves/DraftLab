using UnityEngine;

[CreateAssetMenu(menuName = "DriftLab/Mission Definition")]
public class MissionDefinition : ScriptableObject
{
    [SerializeField] private string missionId;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private int targetAmount = 1;
    [SerializeField] private string targetItemId = "Water";
    [SerializeField] private string rewardId = "StarterOutfit";

    public string MissionId => missionId;
    public string Title => title;
    public string Description => description;
    public int TargetAmount => targetAmount;
    public string TargetItemId => targetItemId;
    public string RewardId => rewardId;
}
