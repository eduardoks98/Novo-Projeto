using Assets.Scripts.Interfaces.Entity;
using Assets.Scripts.Person;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors
{
    [CustomEditor(typeof(EnemyController))]
    [CanEditMultipleObjects]
    class StatsEditor : Editor
    {
        

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EnemyController pc = (EnemyController)target;
            if(pc.stats == null) { return; }

            EditorGUILayout.LabelField("Stats");
            EditorGUILayout.FloatField("Max Health", pc.stats.Health);
            EditorGUILayout.FloatField("Defense", pc.stats.Defense);
            EditorGUILayout.FloatField("Attack Speed", pc.stats.AttackRate);
            EditorGUILayout.FloatField("Speed", pc.stats.Speed);
            EditorGUILayout.FloatField("Physic Power", pc.stats.PhysicPower);
            EditorGUILayout.FloatField("Magic Power", pc.stats.MagicPower);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Atributes");
            EditorGUILayout.FloatField("Strength", pc.stats.Strength);
            EditorGUILayout.FloatField("Constitution", pc.stats.Constitution);
            EditorGUILayout.FloatField("Dexterity", pc.stats.Dexterity);
            EditorGUILayout.FloatField("Intelligence", pc.stats.Intelligence);
            EditorGUILayout.FloatField("Wisdom", pc.stats.Wisdom);
            EditorGUILayout.FloatField("Charisma", pc.stats.Charisma);
        }
    }
}
