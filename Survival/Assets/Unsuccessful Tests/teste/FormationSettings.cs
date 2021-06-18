using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.teste
{

    public class FormationSettings
    {
        private int _position;
        private bool _isEmpty;
        private GameObject _targetPosition;
        private static List<FormationSettings> _formationSettings = new List<FormationSettings>();

        public static readonly FormationSettings Vaga1 = new FormationSettings(1, true, null);
        public static readonly FormationSettings Vaga2 = new FormationSettings(2, true, null);
        public static readonly FormationSettings Vaga3 = new FormationSettings(3, true, null);
        public static readonly FormationSettings Vaga4 = new FormationSettings(4, true, null);
        public static readonly FormationSettings Vaga5 = new FormationSettings(5, true, null);

        public int Position { get => _position; private set => _position = value; }
        public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }
        public GameObject TargetPosition { get => _targetPosition; set => _targetPosition = value; }
        public static IList<FormationSettings> ListFormationSettings
        {
            get { return _formationSettings; }
        }


        public FormationSettings(int position, bool isEmpty, GameObject targetPosition)
        {
            Position = position;
            IsEmpty = isEmpty;
            TargetPosition = targetPosition;
            _formationSettings.Add(this);
        }

        public static void SetPositions(int position, GameObject obj)
        {
            _formationSettings[position].TargetPosition = obj;
        }
        public static FormationSettings nextPosition(bool willOcupe)
        {
            FormationSettings obj = null;
            int index = 0;
            foreach (FormationSettings formationSettings in _formationSettings)
            {
                if (formationSettings.IsEmpty == true)
                {
                    obj = formationSettings;
                    if (willOcupe) { _formationSettings[index].IsEmpty = false; }
                    break;
                }
                index++;
            }
            return obj;
        }




    }
}