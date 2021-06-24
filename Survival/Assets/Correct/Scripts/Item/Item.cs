using System.Collections;
using UnityEditor;
using UnityEngine;

namespace EKS.Items
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        [SerializeField] string id;
        public string ID { get { return id; } }
        public string ItemName;
        [Range(1,999)]
        public int MaximumStacks = 1;
        public Sprite Icon;

        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
        }

        public virtual Item GetCopy()
        {
            return this;
        }

        public virtual void Destroy()
        {

        }
    }
}