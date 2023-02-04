using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private int zindex;
    [SerializeField] private float strenght = 1;

    private Vector2 initPos;
    private float initCamPos;

    private void Start()
    {
        initPos = transform.position;
        initCamPos = Camera.main.transform.position.x;
        foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.sortingOrder = zindex;
        }
    }

    void Update()
    {
        var camX = Camera.main.transform.position.x;
        transform.position = new Vector3(initPos.x - (camX - initCamPos) * strenght, initPos.y);

    }
}
