using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetTime : NetworkBehaviour
{
    private NetworkVariable<float> ServerTime = new NetworkVariable<float>(100f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ServerTime.Value > 0f)
        {
            ServerTime.Value -= Time.deltaTime;
            Debug.Log(ServerTime.Value);
        }
        else
        {
            ServerTime.Value = 0f;
        }
    }
}
