using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 direction;
    public float moveSpeed;
    public Transform target;
    public bool isWalking;

    void Update()
    {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), moveSpeed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, new Vector2(target.position.x, target.position.y));
        isWalking = distance != 0 ? true : false;
    }
}
