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
        }
        else
        {
            networkManager.GetComponent<PlayerOveride>().setMode("VR Client");
        }

        networkManager.GetComponent<NetworkManagerHUD>().StartGame(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
