using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : Stats
{

    public Vector3 parentTransform;
    public CharSlot charSlot;
    public CharAnimator charAnimator;
    private EntityColor entityColor;
    public Color color;
    public float TimeFlip;
    public int LastKillCount;

    void Start()
    {
        charSlot = GetComponentInParent<CharSlot>();
        entityColor = GetComponentInChildren<EntityColor>();
        charAnimator = GetComponent<CharAnimator>();
        type = tag;
        vidaAtual = vidaMax;
        SetupUIBar();
        KillCount = 0;
        LastKillCount = 0;
    }

    private void Update()
    {
        isAlive = vidaAtual > 0 ? true : false;
        TimerTest();
        if (canAttack && inRange.Count > 0 && isAlive) { Attack(ataque - defesa); }
        uiBars.SetValue(vidaAtual);
        if (charSlot != null)
        {
            parentTransform = charSlot.currentTransform;
            this.transform.SetParent(charSlot.transform);
            TimeFlip = (charSlot.position - 1) / 10f;
            StartCoroutine(charSlot.teamManager.moveController.needFlip ? FlipRight() : FlipLeft());
        }
        else
        {
            StopAllCoroutines();
        }
        entityColor.color = color;
        charAnimator.IsWalking = charSlot.teamManager.moveController.isRunning;
        charAnimator.TimeToWait = charSlot.position;
        Heal();
        if (charSlot.MainDied && charSlot.cannotRelease)
        {
            charSlot.teamManager.moveController.transform.position = new Vector3(0, 0, 0);
            GameObject nearstSpot = charSlot.teamManager.getNextSpot();
            SpawnSlot[] positions = GetComponentsInChildren<SpawnSlot>();
            List<Vector3> positionToSet = new List<Vector3>();
            foreach (var item in positions)
            {
                positionToSet.Add(item.transform.position);
            }
            charSlot.teamManager.slotManager.lineRenderer.SetPositions(positionToSet.ToArray());
            vidaAtual = vidaMax;
            
        }
    }

    IEnumerator FlipRight()
    {
        StopCoroutine("FlipLeft");
        yield return new WaitForSecondsRealtime(TimeFlip);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    IEnumerator FlipLeft()
    {
        StopCoroutine("FlipRight");
        yield return new WaitForSecondsRealtime(TimeFlip);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void Attack()
    {
        base.Attack(ataque - defesa);

    }

    public void Heal()
    {
        if(LastKillCount < KillCount)
        {
            LastKillCount++;
            float fulled = vidaAtual + 30;
            if (fulled >= vidaMax)
            {
                vidaAtual = vidaMax;
            }
            else
            {

                vidaAtual += 30;
                if (vidaAtual > vidaMax)
                {
                    vidaAtual = vidaMax;

                }
            }
        }
    }
}
