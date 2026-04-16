using UnityEngine;
using UnityEngine.UI;

public class MainMenuStatusUI : MonoBehaviour
{
    [SerializeField] private PlayerProfile playerProfile;
    [SerializeField] private LobbyUI lobbyUI;
    [SerializeField] private Text summaryText;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (summaryText == null)
        {
            return;
        }

        string characterName = playerProfile == null ? "Nenhum" : playerProfile.GetCharacterName();
        string outfitName = playerProfile == null ? "Padrao" : playerProfile.GetOutfitName();
        summaryText.text = "Pronto para jogar\nPersonagem: " + characterName + "\nRoupa: " + outfitName;
    }
}
