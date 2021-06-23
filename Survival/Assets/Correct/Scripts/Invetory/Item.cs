using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        [SerializeField] string id;
        public string ID { get { return id; } }
        public string ItemName;
        public Sprite Icon;

        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
        }
    }
}