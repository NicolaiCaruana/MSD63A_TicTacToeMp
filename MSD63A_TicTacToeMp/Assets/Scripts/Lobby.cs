using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Lobby : MonoBehaviourPunCallbacks
{
    [Tooltip("Content Object")]
    public GameObject ScrollViewContent;

    [Tooltip("UI Row Room Prefab")]
    public GameObject RowRoom;

    [Tooltip("Input Player Name")]
    public GameObject InputPlayerName;

    [Tooltip("Input Room Name")]
    public GameObject InputRoomName;

    [Tooltip("Status Label")]
    public GameObject Status;

    [Tooltip("Button Create Room")]
    public GameObject BtnCreateRoom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
