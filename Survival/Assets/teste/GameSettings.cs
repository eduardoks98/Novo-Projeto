using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.teste
{
    public class GameSettings : MonoBehaviour
    {

        public GameObject[] formation;
        public bool loaded;
        // Use this for initialization
        void Awake()
        {
            loaded = false;
            SetupFormation();
        }

        void SetupFormation()
        {
            formation = GameObject.FindGameObjectsWithTag("Vaga");
            int index = 0;
            foreach (GameObject obj in formation)
            {
                FormationSettings.SetPositions(index, obj);
                index++;
            }
            loaded = true;
        }
    }
}