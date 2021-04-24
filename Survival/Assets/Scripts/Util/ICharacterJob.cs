using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterJob
{
    float AttackSpeed { get; set; }
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    float TakeDamage(float damage);

    bool IsAlive();

    float BaseDamage { get; }
    float ModifierDamage { get; }
    float Attack();


    float ExpToLevelUp { get; }
    void LevelUp(float exp);

}
