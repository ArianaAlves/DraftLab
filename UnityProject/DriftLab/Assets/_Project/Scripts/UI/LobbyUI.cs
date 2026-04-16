using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Text roomNameText;
    [SerializeField] private Text playerCountText;
    [SerializeField] private string roomName = "Sala Twitch";
    [SerializeField] private int currentPlayers = 1;
    [SerializeField] private int maxPlayers = 4;

    private void Start()
    {
        Refresh();
    }

    public void SetRoomName(string newRoomName)
    {
        roomName = string.IsNullOrWhiteSpace(newRoomName) ? roomName : newRoomName;
        Refresh();
    }

    public void SetPlayerCount(int amount)
    {
        currentPlayers = Mathf.Clamp(amount, 1, maxPlayers);
        Refresh();
    }

    public void Refresh()
    {
        if (roomNameText != null)
        {
            roomNameText.text = "Lobby: " + roomName;
        }

        if (playerCountText != null)
        {
            playerCountText.text = "Jogadores: " + currentPlayers + "/" + maxPlayers;
        }
    }
}
