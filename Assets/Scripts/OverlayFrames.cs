using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayFrames : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] public int index;

    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.material.SetTexture("_Overlay", frames[index].texture);
    }
}
