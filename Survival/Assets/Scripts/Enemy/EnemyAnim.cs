using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public Seeker seeker;
    public AIDestinationSetter aiDestination;
    public AIPath path;
    //public Animator anim;
    public bool isRunning;
    public float viewDistance;
    public GameObject player;
    public bool alreadySeePlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        seeker = GetComponent<Seeker>();
        aiDestination = GetComponent<AIDestinationSetter>();
        //anim = GetComponentInChildren<Animator>();
        path = GetComponent<AIPath>();
        alreadySeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (seePlayer())
        {
            
            aiDestination.target = player.transform;
            animate();
        }
        else
        {

            aiDestination.target = null;
            if (!alreadySeePlayer)
            {
                aiDestination.target = this.transform;
                alreadySeePlayer = true;
            }
            animate();
        }
    }

    void animate()
    {
        //Debug.Log(this.gameObject.name + " Chegou no destino? " + path.reachedEndOfPath);
        if (aiDestination.target == null)
        {
            isRunning = !path.reachedEndOfPath;
        }
        else
        {            
            isRunning = !path.reachedEndOfPath;
        }
       // anim.SetBool("isRunning", !path.reachedEndOfPath);
    }

    bool seePlayer()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist < viewDistance)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }
}
