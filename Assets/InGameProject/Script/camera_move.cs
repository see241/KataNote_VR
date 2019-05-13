using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float moveSpeed = 3.0f;
    public Camera camera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
            camera.transform.Rotate(-v, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
