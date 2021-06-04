using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerTest();
        if (canAttack && inRange.Count>0) { Attack(ataque - defesa); }

    }
  
}
