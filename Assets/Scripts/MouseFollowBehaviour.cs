using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private void Update()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (rotZ < -90  || rotZ > 90)
        {
            if (player.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            }  
            else if (player.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }
    }
}
