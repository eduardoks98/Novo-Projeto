using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Stats
{
    public class StatBonus
    {  
        public int BonusValue { get; set; }
        public StatBonus(int bonusValue)
        {
            this.BonusValue = bonusValue;
            Debug.Log("new stat bonus");
        }
    }
}