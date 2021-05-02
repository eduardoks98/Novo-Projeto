using System.Collections;
using UnityEngine;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public class JobChoose : IAtributes
    {
        private Job _job;
        private int _strenght;
        private int _constitution;
        private int _dexterity;
        private int _intelligence;
        private int _wisdom;
        private int _charisma;

        public float Health => BaseStats.Health * Constitution;

        public float Defense => BaseStats.Defense * Constitution;

        public float PhysicPower => BaseStats.PhysicPower * Strength;

        public float MagicPower => BaseStats.MagicPower * Intelligence;

        public float AttackRate => BaseStats.AttackRate * Dexterity;

        public float Speed => BaseStats.Speed * ((Dexterity / 100) + (Strength / 100) + (Constitution / 100));

        public Job Job { get => _job; set => _job = value; }

        public int Strength { get => BaseStats.Strength + _strenght; set => _strenght = value; }
        public int Constitution { get => BaseStats.Constitution + _constitution; set => _constitution = value; }
        public int Dexterity { get => BaseStats.Dexterity + _dexterity; set => _dexterity = value; }
        public int Intelligence { get => BaseStats.Intelligence + _intelligence; set => _intelligence = value; }
        public int Wisdom { get => BaseStats.Wisdom + _wisdom; set => _wisdom = value; }
        public int Charisma { get => BaseStats.Charisma + _charisma; set => _charisma = value; }

        void ChangeAtributes(int str, int cnt,int dex, int intl, int wis, int cha)
        {
            Strength = str;
            Constitution = cnt;
            Dexterity = dex;
            Intelligence = intl;
            Wisdom = wis;
            Charisma = cha;
        }

        public void SwitchJob()
        {

        }

    }
}