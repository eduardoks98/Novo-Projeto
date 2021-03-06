using Assets.Correct.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Snake move;
    private void Start()
    {
        move = FindObjectOfType<Snake>();
    }
    // Update is called once per frame
    void Update()
    {
        target = move.Leader.transform;
        if (target)
        {
            /*
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = (target.position+Input.mousePosition.normalized) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            */

            /* if want to use mouse to view over the board
            float maxScreenPoint = 0.2f;
            Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);

            Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
            Vector3 destination = new Vector3(position.x, position.y, -10);
            */
            Vector3 destination = new Vector3(target.position.x, target.position.y, -10);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }



    }


}
