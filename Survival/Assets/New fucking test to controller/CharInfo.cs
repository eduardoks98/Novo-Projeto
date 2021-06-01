using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.New_fucking_test_to_controller
{
    public class CharInfo :MonoBehaviour
    {
        [Header("Base Stats")]
        public float ataque = 10f;
        public float defesa = 2f;
        public float velAtaque = 5f;
        public float velocidade = 2f;
        public float vidaMax = 100f;

        [Header("Current Stats")]
        public float ataqueAtual;
        public float defesaAtual;
        public float velAtaqueAtual;
        public float velocidadeAtual;
        public float vidaAtual;

        [Header("Info Stats")]
        public int KillCount = 0;
        public string type;

        public List<Collider2D> targets;

        public void TakeDamage(float damage)
        {
            vidaAtual -= damage;
        }
        
      

        private void OnDrawGizmos()
        {
            foreach (Collider2D target in targets)
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }
   
}