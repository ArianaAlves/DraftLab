using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    [SerializeField] private PlayerProfile playerProfile;
    [SerializeField] private Text optionsText;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (playerProfile == null || optionsText == null)
        {
            return;
        }

        string textValue = "Personagens:\n";
        CharacterDefinition[] characters = playerProfile.AvailableCharacters;

        for (int i = 0; i < characters.Length; i++)
        {
            CharacterDefinition character = characters[i];
            if (character == null)
            {
                continue;
            }

            string status = playerProfile.IsCharacterUnlocked(character) ? "Desbloqueado" : "Bloqueado";
            textValue += i + " - " + character.DisplayName + " (" + status + ")\n";
        }

        optionsText.text = textValue.TrimEnd();
    }

    public void SelectCharacterByIndex(int index)
    {
        if (playerProfile == null)
        {
            return;
        }

        playerProfile.SelectCharacterByIndex(index);
        Refresh();
    }
}
