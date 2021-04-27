using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public class StatsController : IEntity
    {

        private IEntity job;
         private float _currentHealth;

         private int _strength;
         private int _constitution;
         private int _dexterity;
         private int _intelligence;
         private int _wisdom;
         private int _charisma;
        public StatsController(IEntity entity)
        {
            job = entity;
            CurrentHealth = Health;
            Strength = job.Strength;
            Constitution = job.Constitution;
            Dexterity = job.Dexterity;
            Intelligence = job.Intelligence;
            Wisdom = job.Wisdom;
            Charisma = job.Charisma;
        }
         public float Health { get { return Constitution * job.Health; } }
         public float Defense { get { return Constitution * job.Defense; } }
         public float PhysicPower { get { return Strength * job.PhysicPower; } }
         public float MagicPower { get { return Intelligence * job.MagicPower; } }
         public float AttackRate { get { return Dexterity * job.AttackRate; } }
         public float Speed { get { return (job.Speed * Dexterity/100)+job.Speed; } }
        public int Strength { get => _strength; set => _strength = value; }
        public int Constitution { get => _constitution; set => _constitution = value; }
        public int Dexterity { get => _dexterity; set => _dexterity = value; }
        public int Intelligence { get => _intelligence; set => _intelligence = value; }
        public int Wisdom { get => _wisdom; set => _wisdom = value; }
        public int Charisma { get => _charisma; set => _charisma = value; }


        public void AddDexterity(int value)
        {
            _dexterity += value;
        }
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public bool IsAlive { get => !(CurrentHealth <= 0); }

        public void Heal(float amount)
        {
            if (!IsAlive || CurrentHealth >= Health) { return; }

            this.CurrentHealth += amount;
        }
        public void TakeDamage(float amount)
        {
            if (!IsAlive) { return; }

            float damage = amount - Defense;

            if (damage < 0) { return; }

            this.CurrentHealth -= damage;
        }
    }
}