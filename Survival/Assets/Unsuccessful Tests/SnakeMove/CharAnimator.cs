using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimator : MonoBehaviour
{
    public Animator animator;
    public bool _isWalking;
    public float TimeToWait = 0f;
    public bool IsWalking { get => _isWalking; set => _isWalking = value; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
       
        StartCoroutine(waiter(TimeToWait/10f));

    }

    IEnumerator waiter(float time)
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(time);
        animator.SetBool("isRunning", IsWalking);
    }
}
