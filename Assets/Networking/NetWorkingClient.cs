using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

using NativeWebSocket;

namespace Project.Networking
{
    public class NetWorkingClient : MonoBehaviour
    {
        WebSocket websocket;

        async void Start()
        {
            websocket = new WebSocket("ws://purgatorio.ddns.net:28015");

            websocket.OnOpen += () => {
                // Debug.Log("Connection open!");
            };

            websocket.OnError += (e) => {
                // Debug.Log("Error! " + e);
            };

            websocket.OnClose += (e) => {
                // Debug.Log("Connection closed!");
            };

            websocket.OnMessage += (bytes) => {
                // Debug.Log("OnMessage!");
                // Debug.Log(bytes);

                // getting the message as a string
                // var message = System.Text.Encoding.UTF8.GetString(bytes);
                // Debug.Log("OnMessage! " + message);
            };

            // Keep sending messages at every 0.3s
            // InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

            // waiting for messages
            await websocket.Connect();
        }

        void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            websocket.DispatchMessageQueue();
#endif

            if (Input.GetKeyDown("space"))
            {
                SendWebSocketMessage();
            }
        }

        async void SendWebSocketMessage()
        {
            if (websocket.State == WebSocketState.Open)
            {
                // await websocket.Send(new byte[] { 10, 20, 30 });
                await websocket.SendText("Space bar pressed");
            }
        }

        private async void OnApplicationQuit()
        {
            await websocket.Close();
        }
    }
}
