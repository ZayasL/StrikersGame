using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public NetworkManager netManager;

    public void StartHost()
    {
        netManager.StartHost();

    }
    public void StartClient()
    {
        netManager.StartClient();

    }
    public void StartServer()
    {
        netManager.StartServer();
    
    }
}
