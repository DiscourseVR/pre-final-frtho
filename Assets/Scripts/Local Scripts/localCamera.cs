using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Dissonance;

public class localCamera : NetworkBehaviour
{
    public GameObject part1;
    public GameObject part2;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            part1.SetActive(true);
            part2.SetActive(true);

            GameObject dissonance = GameObject.Find("DissonanceSetup");
            DissonanceComms comms = dissonance.GetComponent<DissonanceComms>();
            comms.IsMuted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
