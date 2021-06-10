using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.New_fucking_test_to_controller
{
    public struct Util
    {

        public static bool Attack(float damage, AttackTypes type, List<Collider2D> enemies, Vector3 playerPosition)
        {
            switch (type)
            {
                case AttackTypes.SingleMelee:
                    return SingleMeeleeAttack(damage, enemies, playerPosition);

                case AttackTypes.MultiMelee:
                    return SingleMeeleeAttack(damage, enemies, playerPosition);

                case AttackTypes.SingleRanged:
                    return SingleMeeleeAttack(damage, enemies, playerPosition);

                case AttackTypes.MultiRanged:
                    return SingleMeeleeAttack(damage, enemies, playerPosition);

                default:
                    return SingleMeeleeAttack(damage, enemies, playerPosition);
            }
        }
        public static bool SingleMeeleeAttack(float damage, List<Collider2D> enemies, Vector3 playerPosition)
        {
            if (!HasEnemies(enemies)) { return false; }
            Debug.Log(enemies.Count);
            foreach (Collider2D enemy in enemies)
            {
                CharActions charActions = enemy.GetComponent<CharActions>();
                charActions.TakeDamage(damage);

            }

            return true;
        }
        private static bool HasEnemies(List<Collider2D> enemies)
        {
            if (enemies.Count > 0)
                return true;
            else
                return false;
        }

        public static Collider2D ClosestTarget(Collider2D[] colliders, Vector3 playerPosition)
        {
            Collider2D closest = null;
            float minDist = Mathf.Infinity;
            foreach (Collider2D collider in colliders)
            {
                float dist = Vector3.Distance(collider.transform.position, playerPosition);
                if (dist < minDist)
                {
                    closest = collider;
                    minDist = dist;
                }
            }
            return closest;
        }
    }

    public enum AttackTypes
    {
        SingleMelee = 1,
        SingleRanged = 2,
        MultiMelee = 3,
        MultiRanged = 4
    }
}