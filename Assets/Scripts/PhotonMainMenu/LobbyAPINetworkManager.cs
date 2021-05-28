using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LobbyAPINetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomName, roomID;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private RoomList roomList;
    //[SerializeField] private GameObject roomsParent, roomPrefab, roomPopup, joiningLobby;
    //[SerializeField] private Button createRoomButton;
    private void Start()
    {
        //joiningLobby.SetActive(true);
        GetRoomList();
        Connect();
    }
    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
        //joiningLobby.SetActive(true);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        //joiningLobby.SetActive(false);
    }
    public override void OnJoinedRoom()
    {
        //roomPopup.SetActive(true);
        //var room_UI = roomPopup.GetComponent<VRMuseum_MainMenu.RoomManager>();
        //room_UI.room = PhotonNetwork.CurrentRoom;
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        //roomPopup.SetActive(false);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //UpdateRoomList(roomList);
    }
    private void Update()
    {
        userName.text = PhotonNetwork.LocalPlayer.NickName;
    }
    public void JoinRoom(string room_name)
    {
        PhotonNetwork.JoinRoom(room_name);
    }
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomName.text) == false)
        {
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions() { IsVisible = true, IsOpen = true });
        }
    }
    public void JoinOrCreate() {
        PhotonNetwork.JoinOrCreateRoom(roomID.text, new RoomOptions() { IsVisible = true, IsOpen = true }, TypedLobby.Default);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public void GoToMuseum()
    {
        SceneManager.LoadScene("MuseumScene");
    }
    public void GetRoomList() {
        ApiCoroutines.Instance.GetRoomList("", roomList);
    }
}
