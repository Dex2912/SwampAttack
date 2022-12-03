using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward; // награда за смерть врага

    private Player _target; // цель

    public int Reward => _reward;
    public Player Target => _target; //лямба вырожения

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    } 

    public void TakeDamage (int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }


}
