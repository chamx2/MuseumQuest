using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Room List",menuName = "Data/Room List")]
public class RoomList : ScriptableObject
{
    [System.Serializable]
    public class Room
    {
        public int room_id;
        public bool room_has_password;
        public string room_name;
    }

    public bool success;
    public Room[] rooms;
}
