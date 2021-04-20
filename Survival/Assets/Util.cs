using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public Vector3 isBehind(List<Collider2D> colliders,Transform currentPosition, Vector3 lastPosition, List<SpriteRenderer> sprites)
    {
        if (colliders.Count == 0) { return lastPosition; }

        var me = currentPosition.position;
        if (me.x == lastPosition.x && me.y == lastPosition.y) { return lastPosition; }

        var entity = getClosest(colliders, currentPosition).position;

        if (me.z == entity.z && me.x == lastPosition.x && me.y == lastPosition.y) { return lastPosition; }
       // Debug.Log("Me: "+me.y +"\n Enity: x-"+ entity.x + " y-"+ entity.y + " z-" + entity.z);
        if (entity.y > me.y)
        {
            currentPosition.position = new Vector3(currentPosition.position.x, currentPosition.position.y, (colliders.Count * currentPosition.position.y));
            lastPosition = me;
            foreach (var item in sprites)
            {

                item.sortingOrder = (colliders.Count * 2);
                if (item.name == "Hair" || item.name == "Face")
                {
                    item.sortingOrder = (colliders.Count * 2) + 1;
                }
            }
        }
        else if(entity.y < me.y)
        {
            currentPosition.position = new Vector3(currentPosition.position.x, currentPosition.position.y, -(colliders.Count * currentPosition.position.y));
            lastPosition = me;
            foreach (var item in sprites)
            {
              
                item.sortingOrder = -(colliders.Count*2);
                if (item.name == "Hair" || item.name == "Face")
                {
                    item.sortingOrder = -(colliders.Count*2) + 1;
                }
            }
        }

        return lastPosition;
    }
    public Transform getClosest(List<Collider2D> list, Transform currentPosition)
    {
        Transform closest = null;
        float lastDistance = Mathf.Infinity;
        Vector3 position = currentPosition.position;
        foreach (var entity in list)
        {
            var transform = entity.gameObject.transform;
            float dist = Vector3.Distance(transform.position, position);
            if (dist < lastDistance)
            {
                closest = transform;
                lastDistance = dist;
            }
        }
        return closest;
    }
}
