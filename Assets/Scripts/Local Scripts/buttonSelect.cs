using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class buttonSelect : MonoBehaviour
{
    public GameObject networkManager;
    public Button parent;

    // Start is called before the first frame update
    void Start()
    {
        parent.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string name = parent.name;
        if (name == "Web Client" || name == "Recorder")
        {
            networkManager.GetComponent<PlayerOveride>().setMode(name);
        }else if (name == "Spectator Host")
        {
            networkManager.GetComponent<PlayerOveride>().setMode("Web Client");
        }
        else
        {
            networkManager.GetComponent<PlayerOveride>().setMode("VR Client");
        }

        networkManager.GetComponent<NetworkManagerHUD>().StartGame(name);
        Debug.Log("Task completed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
