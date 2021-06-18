using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Correct.Scripts.Stats
{
    public class CharacterStats : MonoBehaviour
    {
        public List<BaseStat> stats = new List<BaseStat>();

        private void Start()
        {
            stats.Add(new BaseStat(4, "power", "power level"));
            stats[0].AddStatBonus(new StatBonus(1));
            Debug.Log(stats[0].GetCalculatedStatValue());
        }
    }
}