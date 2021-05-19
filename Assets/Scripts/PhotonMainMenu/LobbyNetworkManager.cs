using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomName, playerNickName;
    [SerializeField] private TextMeshProUGUI nickname;
    [SerializeField] private GameObject roomsParent, roomPrefab,roomPopup, joiningLobby;
    [SerializeField] private TouchScreenKeyboard overlayKeyboard;
    //[SerializeField] private Button createRoomButton;
    private void Start()
    {
        joiningLobby.SetActive(true);
        Connect(); 
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
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
        joiningLobby.SetActive(true);
    }
    public override void OnJoinedLobby() {
        Debug.Log("Joined Lobby");
        joiningLobby.SetActive(false);
    }
    public override void OnJoinedRoom()
    {
        roomPopup.SetActive(true);
        var room_UI = roomPopup.GetComponent<VRMuseum_MainMenu.RoomManager>();
        room_UI.room = PhotonNetwork.CurrentRoom;
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        roomPopup.SetActive(false);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }
    private void Update()
    {
        nickname.text = PhotonNetwork.LocalPlayer.NickName;
    }
    public void SetNickName() {
        PhotonNetwork.LocalPlayer.NickName = playerNickName.text;
    }
    public void JoinRoom(string room_name) {
        PhotonNetwork.JoinRoom(room_name);
    }
    public void CreateRoom() {
        if (string.IsNullOrEmpty(roomName.text) == false) {
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions() { IsVisible = true, IsOpen = true }) ;
        }
    }
    public void UpdateRoomList(List<RoomInfo> roomList) {
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room")) {
            Destroy(room);
        }
        foreach (RoomInfo info in roomList) {
            var room = Instantiate(roomPrefab, roomsParent.transform);
            room.SetActive(true);
            room.GetComponent<RoomUI>().SetRoomName(info.Name);
        }
    }
    public void ResetLobby() {
        PhotonNetwork.Disconnect();
        Connect();
    }
    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
    public void GoToMuseum() {
        SceneManager.LoadScene("MuseumScene");
    }
}
