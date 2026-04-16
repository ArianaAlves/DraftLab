using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    [SerializeField] private MissionDefinition activeMission;
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private UnlockDatabase unlockDatabase;

    public MissionDefinition ActiveMission => activeMission;

    public bool CanCompleteMission()
    {
        if (activeMission == null || inventorySystem == null)
        {
            return false;
        }

        return inventorySystem.HasItem(activeMission.TargetItemId, activeMission.TargetAmount);
    }

    public void CompleteMission()
    {
        if (!CanCompleteMission())
        {
            Debug.Log("Missao ainda nao concluida.");
            return;
        }

        inventorySystem.RemoveItem(activeMission.TargetItemId, activeMission.TargetAmount);
        if (unlockDatabase != null)
        {
            unlockDatabase.UnlockReward(activeMission.RewardId);
        }

        Debug.Log("Missao concluida! Recompensa liberada: " + activeMission.RewardId);
    }
}
