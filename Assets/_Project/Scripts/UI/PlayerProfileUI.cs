using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUI : MonoBehaviour
{
    [SerializeField] private PlayerProfile playerProfile;
    [SerializeField] private Text characterText;
    [SerializeField] private Text outfitText;
    [SerializeField] private CharacterSelectionUI characterSelectionUI;
    [SerializeField] private OutfitSelectionUI outfitSelectionUI;
    [SerializeField] private MainMenuStatusUI mainMenuStatusUI;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (playerProfile == null)
        {
            return;
        }

        if (characterText != null)
        {
            characterText.text = "Personagem: " + playerProfile.GetCharacterName();
        }

        if (outfitText != null)
        {
            outfitText.text = "Roupa: " + playerProfile.GetOutfitName();
        }

        if (characterSelectionUI != null)
        {
            characterSelectionUI.Refresh();
        }

        if (outfitSelectionUI != null)
        {
            outfitSelectionUI.Refresh();
        }

        if (mainMenuStatusUI != null)
        {
            mainMenuStatusUI.Refresh();
        }
    }
}
