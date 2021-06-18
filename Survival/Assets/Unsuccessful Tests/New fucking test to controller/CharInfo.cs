using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.New_fucking_test_to_controller
{
    public class CharInfo : MonoBehaviour
    {
        [Header("Level Stats")]
        public int level;
        public float cExp;
        public float ExpToNextLevel;

        [Header("Base Stats")]
        [SerializeField] private float attackPower;
        [SerializeField] private float defensePower;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxHealth;
        [SerializeField] private float maxMana;

        [Header("Current Stats")]
        public float cAttackPower;
        public float cDefensePower;
        public float cAttackSpeed;
        public float cMoveSpeed;
        public float cHealth;
        public float cMana;

        [Header("Info Stats")]
        public bool isAlive;
        public int KillCount = 0;
        public LayerMask targetLayer;

        public CharUI charUI;
        public CharTypes classe;
        public CharClass charClasse;
        private void Start()
        {
            
            InitializeStats();
            LevelUp();
            InitializeUI();
        }

        private void FixedUpdate()
        {
            isAlive = cHealth > 0;
            WatchCHealth();
        }

        void LevelUp()
        {
            level++;
            cHealth = maxHealth * level;
            cAttackPower = attackPower * level;
            cDefensePower = defensePower * level;
            cAttackSpeed = attackSpeed * level;
            cMoveSpeed = moveSpeed * level;
            cHealth = maxHealth * level;
            cMana = maxMana * level;
        }

        void InitializeStats()
        {
            charClasse = FindObjectOfType<AllCharacters>().GetClass(classe);
            attackPower = charClasse.AttackPower;
            defensePower = charClasse.DefensePower;
            attackSpeed = charClasse.AttackSpeed;
            moveSpeed = charClasse.MoveSpeed;
            maxHealth = charClasse.MaxHealth;
            maxMana = charClasse.MaxMana;
            level = 0;
        }

        void InitializeUI()
        {

            charUI = GetComponent<CharUI>();
            charUI.healthBar.SetMaxValue(maxHealth * level);
        }

        public void DecreaseHealth(float amount) { cHealth -= amount; }
        public void IncreaseHealth(float amount) { cHealth += amount; }
        public void WatchCHealth() { if (cHealth > maxHealth) cHealth = maxHealth; }
    }

}