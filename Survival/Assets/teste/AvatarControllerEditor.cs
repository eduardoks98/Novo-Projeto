using UnityEditor;
using UnityEngine;

namespace Assets.teste
{
    [CustomEditor(typeof(AvatarController))]
    public class AvatarControllerEditor : Editor
    {
        public override bool RequiresConstantRepaint()
        {
            return true;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            AvatarController ac = (AvatarController)target;
            if (ac.JobController == null) { return; }

            GUILayout.BeginVertical("Actions");
            EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
            EditorGUILayout.EnumFlagsField("Class", ac.JobController.Contract);
            EditorGUILayout.FloatField("Health value", ac.HealthValue);
            EditorGUILayout.Toggle("Alive", ac.IsAlive);
            EditorGUILayout.EnumFlagsField("State", ac.State);
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Atributes");
            EditorGUILayout.LabelField("Atributes", EditorStyles.boldLabel);
            EditorGUILayout.FloatField("Health", ac.JobController.Health);
            EditorGUILayout.FloatField("Defense", ac.JobController.Defense);
            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Attack Rate", ac.JobController.AttackRate);
            EditorGUILayout.FloatField("Attack Speed", 1 / ac.JobController.AttackRate);
            GUILayout.EndHorizontal();
            EditorGUILayout.FloatField("Speed", ac.JobController.Speed);
            EditorGUILayout.FloatField("Physic Power", ac.JobController.PhysicPower);
            EditorGUILayout.FloatField("Magic Power", ac.JobController.MagicPower);
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Stats");
            EditorGUILayout.LabelField("Stats", EditorStyles.boldLabel);

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Strength", ac.JobController.Strength);
            if (GUILayout.Button("+"))
                ac.JobController._strenght += 1;
            if (GUILayout.Button("-"))
                ac.JobController._strenght -= 1;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Constitution", ac.JobController.Constitution);
            if (GUILayout.Button("+"))
                ac.JobController._constitution += 1;
            if (GUILayout.Button("-"))
                ac.JobController._constitution -= 1;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Dexterity", ac.JobController.Dexterity);
            if (GUILayout.Button("+"))
                ac.JobController._dexterity += 1;
            if (GUILayout.Button("-"))
                ac.JobController._dexterity -= 1;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Intelligence", ac.JobController.Intelligence);
            if (GUILayout.Button("+"))
                ac.JobController._intelligence += 1;
            if (GUILayout.Button("-"))
                ac.JobController._intelligence -= 1;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Wisdom", ac.JobController.Wisdom);
            if (GUILayout.Button("+"))
                ac.JobController._wisdom += 1;
            if (GUILayout.Button("-"))
                ac.JobController._wisdom -= 1;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.FloatField("Charisma", ac.JobController.Charisma);
            if (GUILayout.Button("+"))
                ac.JobController._charisma += 1;
            if (GUILayout.Button("-"))
                ac.JobController._charisma -= 1;
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }
    }
}