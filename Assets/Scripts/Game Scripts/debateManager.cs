using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public struct intermissionMode
{
    public string message;
    public int timer;
}

public class debateManager : NetworkBehaviour
{
    public PlayerOveride mainScript;
    public SyncText textSync;

    float timeSpent = 0;
    int mode = 0;

    List<intermissionMode> modes = new List<intermissionMode> { 
        new intermissionMode { message  = "Waiting For Players", timer = 600 },
        new intermissionMode { message  = "Preperation", timer = 20 },
        new intermissionMode { message  = "Debater 1", timer = 60 },
        new intermissionMode { message  = "Intermission", timer = 20 },
        new intermissionMode { message  = "Debater 2", timer = 60 }
    };
    
    void nextMode()
    {
        Debug.Log("Switching modes");
        mode = (mode + 1) % 5;
        timeSpent = 0; //Time.unscaledTime;
        textSync.countdown = modes[mode].timer;
        textSync.stringMode = modes[mode].message;

        if (mode == 2 || mode == 0) // start recording here
        {
            Debug.Log("Start or end recording client");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (mode == 0)
            {
                if (mainScript.players > 0) // should be > 1 but testing rn
                {
                    nextMode();
                }
                else
                {
                    Debug.Log(mainScript.players);
                }
            }
            else
            {
                timeSpent += Time.deltaTime;
                int remaining = modes[mode].timer - (int)timeSpent;
                if (remaining < 1)
                {
                    nextMode();
                }
                else
                {
                    textSync.countdown = remaining;
                }
            }
        }
    }
}
