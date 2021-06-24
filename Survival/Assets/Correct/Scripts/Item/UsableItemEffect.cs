using EKS.Characters.Panel;
using System.Collections;
using UnityEngine;

namespace EKS.Items
{
    public abstract class UsableItemEffect : ScriptableObject
    {
        public abstract void ExecuteEffect(UsableItem parentItem, Character character);
        public abstract string GetDescription();
    }
}