using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Person
{[ExecuteInEditMode]
    public class PlayerController : MonoBehaviour
    {
        public IEntity entity;
        [SerializeField]
        public IEntity stats;

        private void Start()
        {
            entity = new Warrior();
            stats = new StatsController(entity);
        }

        private void Update()
        {
          
        }
    }
}