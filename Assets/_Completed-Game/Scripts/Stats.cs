using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Stats : NetworkBehaviour
{
    [SyncVar]
    public int count;

    [SyncVar]
    public Vector3 position;
    public void Display()
    {
        if (!isServer)
            return;

        Debug.Log($"count : {count}");
        Debug.Log($"position : {position}");
    }

    private void Update()
    {
        Display();
    }

}
