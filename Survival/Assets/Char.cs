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


    void Start()
    {
        charSlot = GetComponentInParent<CharSlot>();
        entityColor = GetComponentInChildren<EntityColor>();
        charAnimator = GetComponent<CharAnimator>();
        type = tag;
        vidaAtual = vidaMax;
    }

    private void Update()
    {
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
        TimerTest();
        if (canAttack && inRange.Count > 0) { Attack(ataque - defesa); }
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

}
