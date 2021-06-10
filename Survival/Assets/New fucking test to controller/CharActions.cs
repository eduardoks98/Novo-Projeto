using Assets.New_fucking_test_to_controller;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharActions : MonoBehaviour
{
    [Header("Attack Settings")]
    public float cooldownTimer;
    public float attackSpeed;
    public AttackTypes attackType;
    public bool ableToAttack;
    public LayerMask enemies;
    [Header("Attack Range Settings")]

    public float attackRange;
    public Vector3 offsetRange;


    CharInfo charInfo;
    CharUI charUI;
    Util util = new Util();
    public bool isAlive;
    private void Start()
    {
        charInfo = GetComponent<CharInfo>();
        charUI = GetComponent<CharUI>();
        cooldownTimer = attackSpeed;
        ableToAttack = true;
    }

    void Update()
    {
        Collider2D[] damage = Physics2D.OverlapCircleAll(transform.position + offsetRange, attackRange, enemies);
        ableToAttack = ableToAttack ? !util.Attack(charInfo.ataque, attackType, damage.ToList(), transform.position + offsetRange) : TimerAttack();

        isAlive = charInfo.vidaAtual > 0;
    }


    public bool TimerAttack()
    {
        if (cooldownTimer <= 0)
        {
            cooldownTimer = attackSpeed;
            return true;
        }
        else if (!ableToAttack)
        {
            cooldownTimer -= Time.deltaTime;
            return false;
        }
        return false;
    }
    public void TakeDamage(float damage)
    {
        if (!isAlive) { return; }
        charInfo.vidaAtual -= damage;
        charUI.healthBar.SetValue(charInfo.vidaAtual);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offsetRange, attackRange);
        if (util.AttackedEnemies.Count > 0)
            foreach (Collider2D target in util.AttackedEnemies)
            {
                if (gameObject.layer == 11)
                    Gizmos.color = Color.white;
                if (gameObject.layer == 12)
                    Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position + offsetRange, target.transform.position);
            }

    }

}
