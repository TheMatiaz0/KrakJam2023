using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowBehaviour : MonoBehaviour
{
    private Camera currentCamera;

    void Start()
    {
        currentCamera = Camera.current;
    }

    void Update()
    {
        var mousePos = currentCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rot = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
