﻿using Assets.Correct.Scripts.Stats2;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class StatTooltip : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI StatNameText;
        [SerializeField] TextMeshProUGUI StatModifiersLabelText;
        [SerializeField] TextMeshProUGUI StatModifiersText;

        private StringBuilder sb = new StringBuilder();

        public void ShowTooltip(CharacterStat stat, string statName)
        {
            StatNameText.text = GetStatTopText(stat, statName);
            StatModifiersText.text = GetStatModifiersText(stat);
            gameObject.SetActive(true);
        }
        public void HideTooltip()
        {
            gameObject.SetActive(false);

        }

        public string GetStatTopText(CharacterStat stat, string statName)
        {
            sb.Length = 0;
            sb.Append(statName);
            sb.Append(" ");
            sb.Append(stat.Value);

            if (stat.Value != stat.BaseValue)
            {
                sb.Append(" (");
                sb.Append(stat.BaseValue);
                if (stat.Value > stat.BaseValue)
                {
                    sb.Append("+");
                }

                sb.Append(System.Math.Round(stat.Value - stat.BaseValue, 4));
                sb.Append(")");
            }
 
            return sb.ToString();
        }

        public string GetStatModifiersText(CharacterStat stat)
        {
            sb.Length = 0;
            foreach (StatModifier mod in stat.StatModifers)
            {
                if (sb.Length > 0)
                    sb.AppendLine();

                if (mod.Value > 0)
                {
                    sb.Append("+");
                }
                if (mod.Type == StatModType.Flat)
                {

                    sb.Append(mod.Value);
                }
                else
                {
                    sb.Append(mod.Value * 100);
                    sb.Append("%");
                }

                EquippableItem item = mod.Source as EquippableItem;

                if (item != null)
                {
                    sb.Append(" ");
                    sb.Append(item.ItemName);
                }
                else
                {
                    Debug.LogError("Modifier is not EquippableItem!");
                }
            }
            return sb.ToString();
        }
    }
}