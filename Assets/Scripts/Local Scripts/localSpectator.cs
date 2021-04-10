using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class localSpectator : NetworkBehaviour
{
    public GameObject rig;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            ((Camera)camera.GetComponent<Camera>()).enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        }
    }
}
