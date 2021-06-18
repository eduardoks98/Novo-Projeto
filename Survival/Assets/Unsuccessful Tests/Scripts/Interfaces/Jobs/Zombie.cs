using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : IJobs
{
    private float _maxHealth = 100f;
    private float _currentHealth = 100f;
    private float _attackSpeed = 1f;
    private bool _canMove = true;
    private float _stopMoveWhenAttack = 0.15f;
    public float BaseDamage => 10f;
    public float ExpToLevelUp => 100f;
    public float ModifierDamage => 1f;
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public float StopMoveWhenAttack { get => _stopMoveWhenAttack; set => _stopMoveWhenAttack = value; }
    public float Attack()
    {
        return BaseDamage * ModifierDamage;
    }

    public bool IsAlive()
    {
        return CurrentHealth > 0;
    }

    public void LevelUp(float exp)
    {
    }

    public float TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        return CurrentHealth;
    }
}
