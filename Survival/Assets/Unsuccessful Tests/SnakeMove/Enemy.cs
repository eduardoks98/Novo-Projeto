using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
    // Start is called before the first frame update
    void Start()
    {
        type = tag;
        vidaAtual = vidaMax;
        SetupUIBar();

    }

    // Update is called once per frame
    void Update()
    {
        isAlive = vidaAtual > 0 ? true : false;
        TimerTest();
        if (canAttack && inRange.Count>0 && isAlive) { Attack(ataque - defesa); }
        uiBars.SetValue(vidaAtual);
    }
  
}
