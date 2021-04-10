using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class datatest : MonoBehaviour
{
    public GameObject networkManager;
    public string ip;
    public bool Server_Only;
    public bool Host_VR;
    public bool Host_Spectate;
    public bool Host_Camera;
    public bool Client_Camera;
    public bool Client_Web;
    public bool Client_VR;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool done = false;
    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > 1.5 && !done)
        {
            done = true;

            string name = Server_Only ? "Server Only" : (Host_VR ? "VR Host" : (Host_Spectate ? "Spectator Host" : (Host_Camera ? "Recorder Host" : (Client_Camera ? "Recorder" : (Client_Web ? "Web Client" : "VR Client")))));
            Debug.Log("Starting as " + name);

            if (name == "Web Client" || name == "Recorder")
            {
                networkManager.GetComponent<PlayerOveride>().setMode(name);
            }
            else if (name == "Spectator Host")
            {
                networkManager.GetComponent<PlayerOveride>().setMode("Web Client");
            }
            else if (name == "Recorder Host")
            {
                networkManager.GetComponent<PlayerOveride>().setMode("Recorder");
            }
            else
            {
                networkManager.GetComponent<PlayerOveride>().setMode("VR Client");
            }

            networkManager.GetComponent<NetworkManagerHUD>().StartGame(name, ip);
        }
    }
}
