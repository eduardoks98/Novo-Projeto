using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public string ItemName;
        public Sprite Icon;
    }
}