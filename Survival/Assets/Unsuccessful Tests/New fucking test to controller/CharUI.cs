using System.Collections;
using UnityEngine;

namespace Assets.New_fucking_test_to_controller
{
    public class CharUI : MonoBehaviour
    {
        public UIBars healthBar;
        public Animation baseAttack;
        private void Awake()
        {
            healthBar = GetComponentInChildren<UIBars>();
        }
    }
}