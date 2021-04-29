using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
namespace VRMuseum_MainMenu { 
    public class RoomManager : MonoBehaviour
    {
        public Room room;
        public TextMeshProUGUI roomName, currentPlayers;
        private void Update()
        {
            roomName.text = room.Name;
            currentPlayers.text = "Current Players: " + room.PlayerCount.ToString();
        }
    }
}
