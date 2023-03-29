using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Networking;

public class StartClient : NetworkManager
{
    public void Start()
    {
        NetworkManager.Singleton.StartClient();
    }
}
