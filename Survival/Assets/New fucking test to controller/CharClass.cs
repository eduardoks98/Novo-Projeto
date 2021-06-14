using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.New_fucking_test_to_controller
{
    public class CharClass : IComparable<CharClass>
    {
        AttackTypes style;
        private CharTypes classe;
        RaceTypes race;
        EntityTypes type;

        float attackPower;
        float defensePower;
        float dodgeChance;
        float attackSpeed;
        float attackRange;
        float moveSpeed;
        float maxHealth;    
        float maxMana;

        string name;
        string description;

        public CharClass(AttackTypes style,
                  CharTypes classe,
                  RaceTypes race,
                  EntityTypes type,
                  string name, 
                  string description,
                  float attackPower,
                  float defensePower,
                  float attackSpeed,
                  float attackRange,
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
            this.attackRange = attackRange;
            this.moveSpeed = moveSpeed;
            this.maxHealth = maxHealth;
            this.maxMana = maxMana;
            this.name = name;
            this.description = description;
        }

        public CharTypes Classe { get => classe; set => classe = value; }
        public AttackTypes Style { get => style; set => style = value; }
        public RaceTypes Race { get => race; set => race = value; }
        public EntityTypes Type { get => type; set => type = value; }
        public float AttackPower { get => attackPower; set => attackPower = value; }
        public float DefensePower { get => defensePower; set => defensePower = value; }
        public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public float MaxHealth { get => maxHealth; set => maxHealth = value; }
        public float MaxMana { get => maxMana; set => maxMana = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float AttackRange { get => attackRange; set => attackRange = value; }

        public int CompareTo(CharClass other)
        {
            if (other == null) { return 1; }

            return (int)(attackPower - other.attackPower);
        }

      
    }
}