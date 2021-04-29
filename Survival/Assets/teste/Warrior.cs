using System.Collections;
using UnityEngine;

namespace Assets.teste
{
    public class Warrior : IStats
    {
        public float Health => BaseStats.Health + 100f;

        public float Defense => BaseStats.Defense + 10F;

        public float PhysicPower => BaseStats.PhysicPower + 10f;

        public float MagicPower => BaseStats.MagicPower + 0f;

        public float AttackRate => BaseStats.AttackRate + 1f;

        public float Speed => BaseStats.Speed + 2f;

        public int Strength => BaseStats.Strength + 5;

        public int Constitution => BaseStats.Constitution + 3;

        public int Dexterity => BaseStats.Dexterity + 2;

        public int Intelligence => BaseStats.Intelligence + 0;

        public int Wisdom => BaseStats.Wisdom + 0;

        public int Charisma => BaseStats.Charisma + 1;

    }
}