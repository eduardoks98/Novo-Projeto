using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Correct.Scripts.Stats
{
    public class BaseStat
    {
        public List<StatBonus> StatBonus { get; set; }
        public int BaseValue { get; set; }
        public string StatName { get; set; }
        public string StatDescription { get; set; }
        public int FinalValue { get; set; }

        public BaseStat(int baseValue, string statName, string statDescription)
        {
            this.StatBonus = new List<StatBonus>();

            this.BaseValue = baseValue;
            this.StatName = statName;
            this.StatDescription = statDescription;
        }


        public void AddStatBonus(StatBonus statBonus)
        {
            this.StatBonus.Add(statBonus);
        }

        public void RemoveStatBonus(StatBonus statBonus)
        {
            this.StatBonus.Remove(statBonus);
        }

        public int GetCalculatedStatValue()
        {
            this.StatBonus.ForEach(x => this.FinalValue += x.BonusValue);
            FinalValue += BaseValue;

            return FinalValue;
        }






    }
}