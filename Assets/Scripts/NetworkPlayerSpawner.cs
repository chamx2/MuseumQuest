using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject spawnedPlayerPrefab;
    public Transform[] positions;
    public int counter = 0;
    public override void OnJoinedRoom()
    {
        // rigPrefab = PhotonNetwork.Instantiate("XR Rig", positions[counter].position, positions[counter].rotation);
        
        base.OnJoinedRoom();

    }
    private void Start()
    {
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", positions[0].position, positions[0].rotation);
        counter++;
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
