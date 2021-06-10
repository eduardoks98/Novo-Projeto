using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.New_fucking_test_to_controller
{
    public class CharClass : IComparable<CharClass>
    {
        AttackTypes style;
        CharTypes classe;
        RaceTypes race;
        EntityTypes type;

        float attackPower;
        float defensePower;
        float attackSpeed;
        float moveSpeed;
        float maxHealth;    
        float maxMana;

        CharClass(AttackTypes style,
                  CharTypes classe,
                  RaceTypes race,
                  EntityTypes type,
                  float attackPower,
                  float defensePower,
                  float attackSpeed,
                  float moveSpeed,
                  float maxHealth,
                  float maxMana
                 )
        {
            this.style = style;
            this.classe = classe;
            this.race = race;
            this.type = type;
            this.attackPower = attackPower;
            this.defensePower = defensePower;
            this.attackSpeed = attackSpeed;
            this.moveSpeed = moveSpeed;
            this.maxHealth = maxHealth;
            this.maxMana = maxMana;
        }

        public int CompareTo(CharClass other)
        {
            if (other == null) { return 1; }

            return (int)(attackPower - other.attackPower);
        }
    }
}