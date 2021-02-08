using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public bool isAtStartup = true;
    NetworkClient myClient;
    int connexions = 0;
    void Update()
    {
        if (isAtStartup)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SetupServer();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                SetupClient();

            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                SetupServer();
                SetupLocalClient();
            }
        }
    }
    void OnGUI()
    {
        connexions = NetworkClient.GetTotalConnectionStats().Count;

            GUI.Label(new Rect(2, 10, 150, 100), "Press W for server");
            GUI.Label(new Rect(2, 30, 150, 100), "Press B for both");
            GUI.Label(new Rect(2, 50, 150, 100), "Press C for client");
            GUI.Label(new Rect(2, 70, 150, 100), $"Nb connections : {connexions}");

        if (isAtStartup)
        {
            
        }
    }

    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        isAtStartup = false;
        connexions++;

    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("127.0.0.1", 4444);
        isAtStartup = false;
        connexions++;
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }

    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}

