using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Util : MonoBehaviour
{
    public Vector3 isBehind(List<Collider2D> colliders, Transform currentPosition, Vector3 lastPosition, List<SpriteRenderer> sprites, [Optional]int playerPositionY)
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
            if (sprites != null)
            {
                orderSprites(sprites.Count > 1, true, sprites, colliders.Count, (int)currentPosition.transform.position.y, playerPositionY);
            }
        }
        else if (entity.y < me.y)
        {
            currentPosition.position = new Vector3(currentPosition.position.x, currentPosition.position.y, -(colliders.Count * currentPosition.position.y));
            lastPosition = me;
            if (sprites != null)
            {
                orderSprites(sprites.Count > 1, false, sprites, colliders.Count, (int)currentPosition.transform.position.y, playerPositionY);
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

    private void orderSprites(bool isPerson, bool isBehind, List<SpriteRenderer> sprites, int count, int objectPosition, int playerPosition)
    {

        if (!isBehind)
        {
            Debug.Log("ATRAS");
            foreach (var item in sprites)
            {
                
                item.sortingOrder = objectPosition;
                if (playerPosition < objectPosition)
                {
                    item.sortingOrder = playerPosition+1;
                }
                if (isPerson)
                {
                    if (item.name == "Hair" || item.name == "Face")
                    {
                        item.sortingOrder = objectPosition + 1;
                    }
                }
            }

        }
        else
        {
            Debug.Log("FRENTE");
            foreach (var item in sprites)
            {


                item.sortingOrder = -(objectPosition);
                if (playerPosition > objectPosition)
                {
                    item.sortingOrder = playerPosition -1;
                }
                if (isPerson)
                {
                    if (item.name == "Hair" || item.name == "Face")
                    {
                        item.sortingOrder = -(objectPosition) + 1;
                    }
                }
            }
        }
    }
}
