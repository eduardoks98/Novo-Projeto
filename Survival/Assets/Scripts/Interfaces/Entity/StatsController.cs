using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public class StatsController : IEntity
    {

        private IEntity job;
        [SerializeField] private float _currentHealth;

        [SerializeField] private int _strength;
        [SerializeField] private int _constitution;
        [SerializeField] private int _dexterity;
        [SerializeField] private int _intelligence;
        [SerializeField] private int _wisdom;
        [SerializeField] private int _charisma;
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
        [SerializeField] public float Health { get { return job.Constitution * job.Health; } }
        [SerializeField] public float Defense { get { return job.Constitution * job.Defense; } }
        [SerializeField] public float PhysicPower { get { return job.Strength * job.PhysicPower; } }
        [SerializeField] public float MagicPower { get { return job.Intelligence * job.MagicPower; } }
        [SerializeField] public float AttackRate { get { return job.Dexterity * job.AttackRate; } }
        [SerializeField] public float Speed { get { return (job.Speed / job.Dexterity)+job.Speed; } }
        public int Strength { get => _strength; set => _strength = value; }
        public int Constitution { get => _constitution; set => _constitution = value; }
        public int Dexterity { get => _dexterity; set => _dexterity = value; }
        public int Intelligence { get => _intelligence; set => _intelligence = value; }
        public int Wisdom { get => _wisdom; set => _wisdom = value; }
        public int Charisma { get => _charisma; set => _charisma = value; }


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