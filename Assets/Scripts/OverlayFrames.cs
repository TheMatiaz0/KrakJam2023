using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayFrames : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] private List<Sprite> framesOverlaid;
    [SerializeField] public int index;

    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.material.SetTexture("_BaseTexture", frames[index].texture);
        sprite.material.SetTexture("_Overlay", framesOverlaid[index].texture);
    }
}
