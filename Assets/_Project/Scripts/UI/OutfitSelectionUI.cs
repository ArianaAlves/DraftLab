using UnityEngine;
using UnityEngine.UI;

public class OutfitSelectionUI : MonoBehaviour
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

        string textValue = "Roupas:\n";
        CustomizationOption[] outfits = playerProfile.AvailableOutfits;

        for (int i = 0; i < outfits.Length; i++)
        {
            CustomizationOption outfit = outfits[i];
            if (outfit == null)
            {
                continue;
            }

            string status = playerProfile.IsOutfitUnlocked(outfit) ? "Desbloqueado" : "Bloqueado";
            textValue += i + " - " + outfit.DisplayName + " (" + status + ")\n";
        }

        optionsText.text = textValue.TrimEnd();
    }

    public void SelectOutfitByIndex(int index)
    {
        if (playerProfile == null)
        {
            return;
        }

        playerProfile.SelectOutfitByIndex(index);
        Refresh();
    }
}
