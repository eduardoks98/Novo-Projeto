using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterJob
{
    float MaxHealth { get; set; }
    float TakeDamage(float damage, float health);

    bool IsAlive(float health);

    float BaseDamage { get; }
    float ModifierDamage { get; }
    float Attack();


    float ExpToLevelUp { get; }
    void LevelUp(float exp);

}
