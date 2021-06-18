using System.Collections;
using UnityEngine;

namespace Assets.Correct.Util
{
    public class GameAssets : MonoBehaviour
    {

        public const int MAX_DODGE_CHANCE = 1000;
        public const int MAX_HIT_CHANCE = 100;


        private static GameAssets _i;

        public static GameAssets i
        {
            get
            {
                if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
                return _i;
            }
        }
        [Header("Popups")]
        public Transform pfDamagePopup;

        [Header("Characters")]
        public GameObject Mage;
        public GameObject Warrior;
    }
}