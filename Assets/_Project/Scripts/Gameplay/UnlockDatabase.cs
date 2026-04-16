using System.Collections.Generic;
using UnityEngine;

public class UnlockDatabase : MonoBehaviour
{
    [SerializeField] private CharacterDefinition[] characterCatalog;
    [SerializeField] private CustomizationOption[] outfitCatalog;

    private readonly HashSet<string> unlockedCharacterIds = new HashSet<string>();
    private readonly HashSet<string> unlockedOutfitIds = new HashSet<string>();

    private void Awake()
    {
        InitializeDefaults();
    }

    public bool IsCharacterUnlocked(CharacterDefinition characterDefinition)
    {
        return characterDefinition != null && unlockedCharacterIds.Contains(characterDefinition.CharacterId);
    }

    public bool IsOutfitUnlocked(CustomizationOption customizationOption)
    {
        return customizationOption != null && unlockedOutfitIds.Contains(customizationOption.OptionId);
    }

    public void UnlockReward(string rewardId)
    {
        if (string.IsNullOrWhiteSpace(rewardId))
        {
            return;
        }

        foreach (CharacterDefinition characterDefinition in characterCatalog)
        {
            if (characterDefinition != null && characterDefinition.CharacterId == rewardId)
            {
                unlockedCharacterIds.Add(rewardId);
                Debug.Log("Novo personagem desbloqueado: " + characterDefinition.DisplayName);
                NotifyUI();
                return;
            }
        }

        foreach (CustomizationOption customizationOption in outfitCatalog)
        {
            if (customizationOption != null && customizationOption.OptionId == rewardId)
            {
                unlockedOutfitIds.Add(rewardId);
                Debug.Log("Nova roupa desbloqueada: " + customizationOption.DisplayName);
                NotifyUI();
                return;
            }
        }

        Debug.Log("Recompensa nao encontrada: " + rewardId);
    }

    private void InitializeDefaults()
    {
        foreach (CharacterDefinition characterDefinition in characterCatalog)
        {
            if (characterDefinition != null && characterDefinition.UnlockedByDefault)
            {
                unlockedCharacterIds.Add(characterDefinition.CharacterId);
            }
        }

        foreach (CustomizationOption customizationOption in outfitCatalog)
        {
            if (customizationOption != null && customizationOption.UnlockedByDefault)
            {
                unlockedOutfitIds.Add(customizationOption.OptionId);
            }
        }
    }

    private void NotifyUI()
    {
        PlayerProfileUI playerProfileUI = FindFirstObjectByType<PlayerProfileUI>();
        if (playerProfileUI != null)
        {
            playerProfileUI.Refresh();
        }
    }
}
