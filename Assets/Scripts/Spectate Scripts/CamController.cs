using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float minX = -60f;
    public float maxX = 60f;
    public float minY = -360f;
    public float maxY = 360f;

    public float sensX = 15f;
    public float sensY = 15f;

    public Camera cam;
    public GameObject spectator, panel;
    float rotationY = 0f;
    float rotationX = 30f;
    bool curserLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        curserLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            Cursor.lockState = CursorLockMode.Locked; 
            curserLocked = true;
        } else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            curserLocked = false;
        }
        if (curserLocked)
        {
            rotationY += Input.GetAxis("Mouse X") * sensX;
            rotationX += Input.GetAxis("Mouse Y") * sensY;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            spectator.transform.localEulerAngles = new Vector3(0, rotationY, 0);
            cam.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);
        }

    }
}

