using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public interface IWeapon
    {
        public float PhysicDamage { get; set; }
        public float MagicDamage { get; set; }
        public float AttackRate { get; set; }
        public float CriticalChance { get; set; }

    }
}