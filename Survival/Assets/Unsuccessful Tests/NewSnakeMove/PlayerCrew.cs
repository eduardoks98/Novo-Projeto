using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrew : MonoBehaviour
{
    public Transform thisRabbit;
    public Transform player;
    bool IsActive = false;
    float speed = 1.0f;
    const float minDistance = 2f;
    Vector3 DistancefromTarget;
    public Transform target;
    public static List<Transform> followers;
    public static int followerCount = 0;
    void Start()
    {
        followers.Add(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            IsActive = true;
            target = followers[followerCount];
            followerCount++;
            followers[followerCount] = thisRabbit;
        }
    }

    void FixedUpdate()
    {

        DistancefromTarget = transform.position - player.position;
    }
    void LateUpdate()
    {
        if (IsActive)
        {
            Follow();
        }
    }

    void Follow()
    {
        transform.LookAt(player);
        if (DistancefromTarget.magnitude > minDistance)
        {
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        }
    }
}
