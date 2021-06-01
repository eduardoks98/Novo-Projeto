using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.New_fucking_test_to_controller
{
    public struct Util
    {

        public static bool Attack(AttackTypes type, List<Collider2D> enemies, Vector3 playerPosition)
        {
            switch (type)
            {
                case AttackTypes.SingleMelee:
                    return SingleMeeleeAttack(enemies,playerPosition);

                case AttackTypes.MultiMelee:
                    return SingleMeeleeAttack(enemies, playerPosition);

                case AttackTypes.SingleRanged:
                    return SingleMeeleeAttack(enemies, playerPosition);

                case AttackTypes.MultiRanged:
                    return SingleMeeleeAttack(enemies, playerPosition);

                default:
                    return SingleMeeleeAttack(enemies, playerPosition);
            }
        }
        public static bool SingleMeeleeAttack(List<Collider2D> enemies, Vector3 playerPosition)
        {
            if (!HasEnemies(enemies)) { return false; }

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