using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private CharacterDefinition[] availableCharacters;
    [SerializeField] private CustomizationOption[] availableOutfits;
    [SerializeField] private CharacterDefinition selectedCharacter;
    [SerializeField] private CustomizationOption selectedOutfit;
    [SerializeField] private UnlockDatabase unlockDatabase;

    public CharacterDefinition SelectedCharacter => selectedCharacter;
    public CustomizationOption SelectedOutfit => selectedOutfit;
    public CharacterDefinition[] AvailableCharacters => availableCharacters;
    public CustomizationOption[] AvailableOutfits => availableOutfits;

    private void Start()
    {
        if (unlockDatabase == null)
        {
            unlockDatabase = FindFirstObjectByType<UnlockDatabase>();
        }

        EnsureValidSelections();
        RefreshUI();
    }

    public void SelectCharacter(CharacterDefinition characterDefinition)
    {
        if (characterDefinition == null || !IsCharacterUnlocked(characterDefinition))
        {
            Debug.Log("Personagem bloqueado ou invalido.");
            return;
        }

        selectedCharacter = characterDefinition;
        Debug.Log("Personagem selecionado: " + GetCharacterName());
        RefreshUI();
    }

    public void SelectOutfit(CustomizationOption customizationOption)
    {
        if (customizationOption == null || !IsOutfitUnlocked(customizationOption))
        {
            Debug.Log("Roupa bloqueada ou invalida.");
            return;
        }

        selectedOutfit = customizationOption;
        Debug.Log("Roupa selecionada: " + GetOutfitName());
        RefreshUI();
    }

    public void SelectCharacterByIndex(int index)
    {
        if (index < 0 || index >= availableCharacters.Length)
        {
            return;
        }

        SelectCharacter(availableCharacters[index]);
    }

    public void SelectOutfitByIndex(int index)
    {
        if (index < 0 || index >= availableOutfits.Length)
        {
            return;
        }

        SelectOutfit(availableOutfits[index]);
    }

    public bool IsCharacterUnlocked(CharacterDefinition characterDefinition)
    {
        if (characterDefinition == null)
        {
            return false;
        }

        return unlockDatabase == null || unlockDatabase.IsCharacterUnlocked(characterDefinition);
    }

    public bool IsOutfitUnlocked(CustomizationOption customizationOption)
    {
        if (customizationOption == null)
        {
            return false;
        }

        return unlockDatabase == null || unlockDatabase.IsOutfitUnlocked(customizationOption);
    }

    public string GetCharacterName()
    {
        return selectedCharacter == null ? "Nenhum" : selectedCharacter.DisplayName;
    }

    public string GetOutfitName()
    {
        return selectedOutfit == null ? "Padrao" : selectedOutfit.DisplayName;
    }

    private void EnsureValidSelections()
    {
        if (selectedCharacter == null || !IsCharacterUnlocked(selectedCharacter))
        {
            selectedCharacter = FindFirstUnlockedCharacter();
        }

        if (selectedOutfit == null || !IsOutfitUnlocked(selectedOutfit))
        {
            selectedOutfit = FindFirstUnlockedOutfit();
        }
    }

    private CharacterDefinition FindFirstUnlockedCharacter()
    {
        foreach (CharacterDefinition characterDefinition in availableCharacters)
        {
            if (IsCharacterUnlocked(characterDefinition))
            {
                return characterDefinition;
            }
        }

        return null;
    }

    private CustomizationOption FindFirstUnlockedOutfit()
    {
        foreach (CustomizationOption customizationOption in availableOutfits)
        {
            if (IsOutfitUnlocked(customizationOption))
            {
                return customizationOption;
            }
        }

        return null;
    }

    private void RefreshUI()
    {
        PlayerProfileUI playerProfileUI = FindFirstObjectByType<PlayerProfileUI>();
        if (playerProfileUI != null)
        {
            playerProfileUI.Refresh();
        }

        CharacterVisualController visualController = FindFirstObjectByType<CharacterVisualController>();
        if (visualController != null)
        {
            visualController.ApplyCurrentCustomization();
        }
    }
}
