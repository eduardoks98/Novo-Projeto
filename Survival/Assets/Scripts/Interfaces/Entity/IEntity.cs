using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces.Entity
{
    public interface IEntity
    {

        public float Health { get; }
        public float Defense { get; }
        public float PhysicPower { get; }
        public float MagicPower { get; }
        public float AttackRate { get; }
        public float Speed { get; }
        public int Strength { get; }
        public int Constitution { get; }
        public int Dexterity { get; }
        public int Intelligence { get; }
        public int Wisdom { get; }
        public int Charisma { get; }

    }
}