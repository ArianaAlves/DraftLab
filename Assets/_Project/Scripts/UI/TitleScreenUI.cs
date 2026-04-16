using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject customizationPanel;

    private void Start()
    {
        ShowTitle();
    }

    public void ShowTitle()
    {
        SetActivePanel(titlePanel);
    }

    public void ShowLobby()
    {
        SetActivePanel(lobbyPanel);
    }

    public void ShowCustomization()
    {
        SetActivePanel(customizationPanel);
    }

    private void SetActivePanel(GameObject activePanel)
    {
        if (titlePanel != null)
        {
            titlePanel.SetActive(activePanel == titlePanel);
        }

        if (lobbyPanel != null)
        {
            lobbyPanel.SetActive(activePanel == lobbyPanel);
        }

        if (customizationPanel != null)
        {
            customizationPanel.SetActive(activePanel == customizationPanel);
        }
    }
}
