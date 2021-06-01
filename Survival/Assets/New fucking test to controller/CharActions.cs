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

    private void Start()
    {
        cooldownTimer = attackSpeed;
        ableToAttack = true;
    }

    void Update()
    {
        Collider2D[] damage = Physics2D.OverlapCircleAll(transform.position + offsetRange, attackRange, enemies);
        List<Collider2D> teste = new List<Collider2D>();
        teste.Add(Util.ClosestTarget(damage, transform.position + offsetRange));
        ableToAttack = ableToAttack ? !Util.Attack(attackType, teste.ToList(), transform.position + offsetRange) : TimerAttack();
        


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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offsetRange, attackRange);
    }

}
