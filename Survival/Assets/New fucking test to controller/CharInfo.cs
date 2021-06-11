using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.New_fucking_test_to_controller
{
    public class CharInfo : MonoBehaviour
    {
        [Header("Level Stats")]
        public int level = 2;
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
        public int KillCount = 0;
        public string type;

        public List<Collider2D> targets;
        public CharUI charUI;
        private AllCharacters characters;
        public CharTypes classe;
        private void Awake()
        {
            level = 2;
            characters = FindObjectOfType<AllCharacters>();
            attackPower = characters.GetClass(classe).AttackPower;
            defensePower = characters.GetClass(classe).DefensePower;
            attackSpeed = characters.GetClass(classe).AttackSpeed;
            moveSpeed = characters.GetClass(classe).MoveSpeed;
            maxHealth = characters.GetClass(classe).MaxHealth;
            maxMana = characters.GetClass(classe).MaxMana;


        }
        private void Start()
        {
            charUI = GetComponent<CharUI>();
            charUI.healthBar.SetMaxValue(maxHealth * level);
            cHealth = maxHealth * level;
            cAttackPower = attackPower * level;
            cDefensePower = defensePower * level;
            cAttackSpeed = attackSpeed * level;
            cMoveSpeed = moveSpeed * level;
            cHealth = maxHealth * level;
            cMana = maxMana * level;
        }

    }

}