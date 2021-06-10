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

    public List<Collider2D> targets;

    CharInfo charInfo;
    CharUI charUI;

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
        targets.Clear();
        Collider2D[] damage = Physics2D.OverlapCircleAll(transform.position + offsetRange, attackRange, enemies);
        if (damage.Count() > 0)
            targets.Add(Util.ClosestTarget(damage, transform.position + offsetRange));
        ableToAttack = ableToAttack ? !Util.Attack(charInfo.ataque, attackType, targets.ToList(), transform.position + offsetRange) : TimerAttack();

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
        foreach (Collider2D target in targets)
        {
            if (gameObject.layer == 11)
                Gizmos.color = Color.white;
            if (gameObject.layer == 12)
                Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + offsetRange, target.transform.position);
        }

    }

}
