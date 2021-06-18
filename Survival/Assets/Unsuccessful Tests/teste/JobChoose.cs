using System.Collections;
using UnityEngine;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public class JobChoose : IAtributes, IStat
    {
        public JobChoose(Contract job)
        {

            Job = SwitchJob(job);
            Contract = job;
        }
        private IStat _job;
        private Contract _contract;
        public int _strenght = 0;
        public int _constitution = 0;
        public int _dexterity = 0;
        public int _intelligence = 0;
        public int _wisdom = 0;
        public int _charisma = 0;

        public float Health => BaseStats.Health * Constitution;

        public float Defense => BaseStats.Defense * Constitution;

        public float PhysicPower => BaseStats.PhysicPower * Strength;

        public float MagicPower => BaseStats.MagicPower * Intelligence;

        public float AttackRate => BaseStats.AttackRate -(Dexterity / 100f) - (Strength / 100f) + (Constitution / 100f);

        public float Speed => (float)BaseStats.Speed + ((Dexterity / 100f) + (Strength / 100f) + (Constitution / 100f));


        public int Strength { get => BaseStats.Strength + Job.Strength + _strenght; set => _strenght = value; }
        public int Constitution { get => BaseStats.Constitution + Job.Constitution + _constitution; set => _constitution = value; }
        public int Dexterity { get => BaseStats.Dexterity + Job.Dexterity + _dexterity; set => _dexterity = value; }
        public int Intelligence { get => BaseStats.Intelligence + Job.Intelligence + _intelligence; set => _intelligence = value; }
        public int Wisdom { get => BaseStats.Wisdom + Job.Wisdom + _wisdom; set => _wisdom = value; }
        public int Charisma { get => BaseStats.Charisma + Job.Charisma + _charisma; set => _charisma = value; }
        public IStat Job { get => _job; set => _job = value; }
        public Contract Contract { get => _contract; set => _contract = value; }

        public IStat SwitchJob(Contract job)
        {
            Contract = job;
            switch (job)
            {
                case Contract.Mage:
                    return new Mage();
                case Contract.Warrior:
                    return new Warrior();
                default:
                    return new Warrior();
            }

           

        }

    }
}