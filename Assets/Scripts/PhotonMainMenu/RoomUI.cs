using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoomUI : MonoBehaviour
{
    public LobbyNetworkManager lobbynetwork;
    [SerializeField] private TextMeshProUGUI roomName;

    public void SetRoomName(string room_name) {
        roomName.text = room_name;
    }
    public void OnJoinRoom() {
        lobbynetwork.JoinRoom(roomName.text);
    }
}
