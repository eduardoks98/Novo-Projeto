using EKS.Characters.Panel;
using System.Collections;
using UnityEngine;

namespace EKS.Items
{
    [CreateAssetMenu(menuName = "Item Effects/Heal")]
    public class HealItemEffect : UsableItemEffect
    {
        public int HealthAmount;
        public override void ExecuteEffect(UsableItem parentItem, Character character)
        {
            character.Health += HealthAmount;
        }

        public override string GetDescription()
        {
            return "Heals for " + HealthAmount + " health.";
        }
    }
}