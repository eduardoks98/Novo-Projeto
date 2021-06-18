using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int KillCount = 0;
    public string type;
    public float ataque = 10f;
    public float defesa = 2f;
    public float velAtaque = 5f;
    public float velocidade = 2f;
    public float vidaMax = 100f;
    public float vidaAtual;
    public bool canAttack;
    public float timer;
    public bool isAlive;
    public UIBars uiBars;
    public void SetupUIBar()
    {
        uiBars = GetComponentInChildren<UIBars>();
        uiBars.SetMaxValue(vidaMax);
    }
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
    public void Attack(float dano)
    {
        if (inRange.Count == 0) { return; }
        foreach (var item in inRange.ToArray())
        {
            if (!item.CompareTag("Enemy"))
            {
                
                Char charr = item.GetComponent<Char>();
                if (charr == null) { return; }
                if (charr.isAlive && type!=item.tag)
                {
                    charr.TakeDamage(dano);

                    canAttack = false;
                }
                else if(!charr.isAlive)
                {
                    inRange.Remove(item);
                }
            }
            else if (item.CompareTag("Enemy"))
            {
                Enemy enemy = item.GetComponent<Enemy>();
                if (enemy == null) { return; }
                if (enemy.isAlive)
                {

                    enemy.TakeDamage(dano);

                    canAttack = false;
                }
                else
                {
                    KillCount++;
                    inRange.Remove(item);
                    Destroy(item);
                }
            }
        }
    }

    public void TakeDamage(float damage)
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
