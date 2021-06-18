using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public abstract class Mace : IWeapon
    {
        private float _physicDamage = 20;
        private float _magicDamage = 0;
        private float _attackRate = 1;
        private float _criticalChance = 0;
        public float PhysicDamage { get => _physicDamage; set => _physicDamage = value; }
        public float MagicDamage { get => _magicDamage; set => _magicDamage = value; }
        public float AttackRate { get => _attackRate; set => _attackRate = value; }
        public float CriticalChance { get => _criticalChance; set => _criticalChance = value; }

    }

}