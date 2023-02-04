using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine.Serialization;

public class SpinBehaviour : MonoBehaviour
{
    [SerializeField] private float durationToFullRotate = 2;
    
    private void Start()
    {
        this.transform.DoRotateAboutZ(360, durationToFullRotate).SetLoops(-1).SetEase(Ease.Linear).SetLink(this.gameObject);
    }
}
