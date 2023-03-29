using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Networking;

public class StartServer : NetworkManager
{
    public void Start()
    {
        NetworkManager.Singleton.StartServer();
    }
}
