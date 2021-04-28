using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomName, playerNickName;
    [SerializeField] private GameObject roomsParent, roomPrefab;
    //[SerializeField] private Button createRoomButton;
    private void Start()
    {
        Connect();
    }
    private void Connect() {
        //PhotonNetwork.NickName = "Player" + Random.Range(0, 5000);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause) {
        Debug.Log("Disconnected");
    }
    public override void OnJoinedLobby() {
        Debug.Log("Joined Lobby");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }
    public void SetNickName() {
        PhotonNetwork.NickName = playerNickName.text;
        Debug.Log(PhotonNetwork.NickName);
    }
    public void JoinRoom(string room_name) {
        PhotonNetwork.JoinRoom(room_name);
    }
    public void CreateRoom() {
        if (string.IsNullOrEmpty(roomName.text) == false) { 
            PhotonNetwork.CreateRoom(roomName.text);
        }
    }
    public void UpdateRoomList(List<RoomInfo> roomList) {
        Debug.Log("HERE");
        foreach (RoomInfo info in roomList) {
            var room = Instantiate(roomPrefab, roomsParent.transform);
            room.SetActive(true);
            room.GetComponent<RoomUI>().SetRoomName(info.Name);
        }
    }
}
