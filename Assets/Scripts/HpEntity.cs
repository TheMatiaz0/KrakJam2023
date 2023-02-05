using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEntity : MonoBehaviour
{
    public static event Action<HpEntity> OnEnemyDied;
    public static event Action OnPlayerDied;
    public static event Action<HpEntity> OnHurt;
    
    [SerializeField] private float maxHp = 100;
    [SerializeField] private float startHp = 10;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip deathSound;

    private bool isDead;

    private float _hp;
    public float Hp
    {
        get => _hp;
        set
        {
            #if UNITY_EDITOR
            //Debug.Log($"{this.gameObject.name} has now <color=red>{value} HP</color>", this.gameObject);
            #endif
            if (value == _hp)
            {
                return;
            }
            if (value < _hp)
            {
                OnHurt?.Invoke(this);
            }
            _hp = Mathf.Clamp(value, 0, maxHp);
            if (_hp <= 0 || _hp >= 100)
            {
                Death();
            }
        }
    }

    public float HpMax
    {
        get => maxHp;
    }

    private void Start()
    {
        Hp = startHp;
    }

    private void Death()
    {
        if (PlayerInstance.Current != null && !isDead)
        {
            if (PlayerInstance.Current.gameObject != this.gameObject)
            {
                OnEnemyDied?.Invoke(this);
            }
            else
            {
                OnPlayerDied?.Invoke();
            }
            isDead = true;
        }

        if (deathSound != null)
        {
            soundSource.PlayOneShot(deathSound);
        }
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (transform.position.y < -50)
        {
            Death();
        }
    }
}
