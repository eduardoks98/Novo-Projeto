using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string type;
    public float ataque = 10f;
    public float defesa = 2f;
    public float velAtaque = 5f;
    public float velocidade = 2f;
    public float vidaMax = 100f;
    public float vidaAtual;
    public bool canAttack;
    public float timer;
    public void TimerTest()
    {
        if (timer <= 0)
        {
            timer = velAtaque;
            canAttack = true;
        }
        else if (canAttack == false)
        {
            timer -= Time.deltaTime;
        }
    }
    public List<GameObject> inRange;
    public virtual void Attack(float dano)
    {
        foreach (var item in inRange)
        {
            if (gameObject.CompareTag("Enemy"))
            {

                Char charr = item.GetComponent<Char>();
                charr.TakeDamage(dano);
            }
            else if(!gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = item.GetComponent<Enemy>();
                enemy.TakeDamage(dano);
            }
        }
        canAttack = false;
    }

    public virtual void TakeDamage(float damage)
    {
        vidaAtual -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange.Add(collision.gameObject);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange.Remove(collision.gameObject);
    }
}
