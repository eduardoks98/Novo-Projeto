using Assets.New_fucking_test_to_controller;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharActions : MonoBehaviour
{
    [Header("Attack Settings")]
    public float cooldownAttack;
    public bool canAttack;

    [Header("Attack Range Settings")]
    public Transform attackRangePosition;


    CharInfo charInfo;
    CharUI charUI;
    Util util;

    public GameObject projectileAngle;

    public Collider2D[] enemiesAround;
    public GameObject projectile;
    private void Start()
    {
        util = GetComponent<Util>();
        charInfo = GetComponent<CharInfo>();
        charUI = GetComponent<CharUI>();
        canAttack = false;
        cooldownAttack = charInfo.cAttackSpeed;
    }

    void Update()
    {
        enemiesAround = Physics2D.OverlapCircleAll(attackRangePosition.position, charInfo.charClasse.AttackRange, charInfo.targetLayer);
        canAttack = canAttack ? !util.Attack(projectile,
            projectileAngle,
            charInfo.targetLayer,
            charInfo.cAttackPower,
            charInfo.charClasse.Style,
            enemiesAround.ToList(),
            attackRangePosition.position) : TimerAttack();
    }


    public bool TimerAttack()
    {
        if (cooldownAttack <= 0)
        {
            cooldownAttack = charInfo.cAttackSpeed;
            return true;
        }
        else if (!canAttack)
        {
            cooldownAttack -= Time.deltaTime;
            return false;
        }
        return false;
    }
    public void TakeDamage(float damage)
    {
        if (!charInfo.isAlive) { return; }
        charInfo.DecreaseHealth(damage);
        charUI.healthBar.SetValue(charInfo.cHealth);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (charInfo == null) { return; }
        Gizmos.DrawWireSphere(attackRangePosition.position, charInfo.charClasse.AttackRange);
        if (util.AttackedEnemies.Count > 0)
            foreach (Collider2D target in util.AttackedEnemies)
            {
                if (gameObject.layer == 11)
                    Gizmos.color = Color.white;
                if (gameObject.layer == 12)
                    Gizmos.color = Color.green;
                Gizmos.DrawLine(attackRangePosition.position, target.transform.position);
            }

    }

}
