using System.Collections;
using UnityEngine;

namespace Assets.Found_Other_solution_to_snake_walk
{
    public class GameAssets : MonoBehaviour
    {

        private static GameAssets _i;

        public static GameAssets i
        {
            get
            {
                if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
                return _i;
            }
        }

        public Transform pfDamagePopup;

        public GameObject Mage;
    }
}