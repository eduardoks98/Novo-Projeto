using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Person
{
    public class PlayerController : MonoBehaviour
    {
        public IEntity entity;
        [SerializeField]
        public StatsController stats;

        private void Start()
        {
            entity = new Warrior();
            stats = ScriptableObject.CreateInstance<StatsController>();
            stats.setClass(entity);
        }

        private void Update()
        {
            Debug.Log(stats.Health);
            Debug.Log(stats.Defense);
            Debug.Log(stats.PhysicPower);
            Debug.Log(stats.MagicPower);
            Debug.Log(stats.AttackRate);
            Debug.Log(stats.Speed);
        }
    }
}