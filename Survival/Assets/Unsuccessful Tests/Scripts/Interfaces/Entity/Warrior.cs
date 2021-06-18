using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public class Warrior : IEntity
    {
        private static readonly BaseStats stat = new BaseStats();
        /// <summary>
        /// Maximum health of the entity
        /// </summary>
        public float Health { get => stat.Health + 100f; }
        public float Defense { get => stat.Defense + 20f; }
        public float PhysicPower { get => stat.PhysicPower + 10f; }
        public float MagicPower { get => stat.MagicPower; }
        public float AttackRate { get => stat.AttackRate; }
        public float Speed { get => stat.Speed + 0.05f; }
        public int Strength { get => stat.Strength + 5; }
        public int Constitution { get => stat.Constitution + 3; }
        public int Dexterity { get => stat.Dexterity + 2; }
        public int Intelligence { get => stat.Intelligence + 1; }
        public int Wisdom { get => stat.Wisdom + 1; }
        public int Charisma { get => stat.Charisma + 2; }

        public void AddDexterity(int value)
        {
            return;
        }
    }
}