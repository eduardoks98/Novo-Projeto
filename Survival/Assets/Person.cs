using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private Vector3 _savedPosition;



    [SerializeField]
    public List<Collider2D> colliders = new List<Collider2D>();

    public Vector3 SavedPosition { get => _savedPosition; set => _savedPosition = value; }

    public List<Collider2D> GetColliders() { return colliders; }

    private void Update()
    {
        
        changePositionZ();
   }

    void changePositionZ()
    {
        if (colliders.Count == 0) { return; }

        var me = this.transform.position;
        if (me.x == SavedPosition.x && me.y == SavedPosition.y) { return; }

        var entity = getClosestObject(colliders).position;
        // if (me.z == entity.z) { return; }
        if (me.z == entity.z && me.x == SavedPosition.x && me.y == SavedPosition.y) { return; }
        if (entity.y> me.y )
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (-colliders.Count * -this.transform.position.y));
            this.SavedPosition = me;
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (colliders.Count * this.transform.position.y));
            this.SavedPosition = me;
        }
    }
    Transform getClosestObject(List<Collider2D> list)
    {
        Transform closest = null;
        float lastDistance = Mathf.Infinity;
        Vector3 position = transform.position;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        colliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
    }

}
