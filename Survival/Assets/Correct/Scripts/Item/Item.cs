﻿using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Text;

namespace EKS.Items
{
    [CreateAssetMenu(menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] string id;
        public string ID { get { return id; } }
        public string ItemName;
        [Range(1, 999)]
        public int MaximumStacks = 1;
        public Sprite Icon;
        protected static readonly StringBuilder sb = new StringBuilder();

#if UNITY_EDITOR
        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
        }
#endif

        public virtual Item GetCopy()
        {
            return this;
        }

        public virtual void Destroy()
        {

        }

        public virtual string GetItemType()
        {
            return "";
        }

        public virtual string GetDescription()
        {
            return "";
        }
    }
}