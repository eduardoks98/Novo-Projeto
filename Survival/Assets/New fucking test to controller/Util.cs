using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.New_fucking_test_to_controller
{
    public class Util
    {

        public List<Collider2D> AttackedEnemies = new List<Collider2D>();
        public bool Attack(float damage, AttackTypes type, List<Collider2D> enemies, Vector3 playerPosition)
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
        public bool SingleMeeleeAttack(float damage, List<Collider2D> enemies, Vector3 playerPosition)
        {
            AttackedEnemies.Clear();
            if (!HasEnemies(enemies)) { return false; }
            var closest = ClosestTarget(enemies, playerPosition);
            if (closest != null)
            {
                AttackedEnemies.Add(closest);
                CharActions charActions = closest.GetComponent<CharActions>();
                charActions.TakeDamage(damage);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool HasEnemies(List<Collider2D> enemies)
        {
            if (enemies.Count > 0)
                return true;
            else
                return false;
        }

        public Collider2D ClosestTarget(List<Collider2D> colliders, Vector3 playerPosition)
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

    public enum CharTypes
    {
        Mage = 1,
        Warrior = 2,
        Healer = 3,
        Necromancer = 4
    }

    public enum RaceTypes
    {
        Human = 1,
        Orc = 2,
        Elf = 3,
        Undead = 4
    }

    public enum EntityTypes
    {
        Player = 1,
        Enemies = 2

    }
}