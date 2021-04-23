using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivalist : ICharacterJob
{
    private float _maxHealth = 100f;
    public float BaseDamage => 10f;
    public float ExpToLevelUp => 100f;
    public float ModifierDamage => 1.5f;
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float Attack()
    {
        return BaseDamage * ModifierDamage;
    }

    public bool IsAlive(float health)
    {
        return health <= 0;
    }

    public void LevelUp(float exp)
    {
    }

    public float TakeDamage(float damage, float health)
    {
        health -= damage;
        return health;
    }

}

