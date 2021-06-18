using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public class BaseStats
    {
       
        /// <summary>
        /// Maximum health of the entity
        /// </summary>
        public float Health { get => 100f;}
        public float Defense { get => 5f; }
        public float PhysicPower { get => 10f;}
        public float MagicPower { get => 10f; }
        public float AttackRate { get => 1f;}
        public float Speed { get =>2f;}
        public int Strength { get => 1;}
        public int Constitution { get => 1;}
        public int Dexterity { get => 1;}
        public int Intelligence { get => 1;}
        public int Wisdom { get => 1;}
        public int Charisma { get => 1;}
    }
}