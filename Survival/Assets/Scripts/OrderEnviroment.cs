using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderEnviroment : MonoBehaviour
{
    private Vector3 _savedPosition;
    private Util _util;
    [SerializeField]
    private List<SpriteRenderer> _sprites;

    [SerializeField]
    public int playerPositionY;
    public List<Collider2D> colliders = new List<Collider2D>();


    public Vector3 SavedPosition { get => _savedPosition; set => _savedPosition = value; }
    public Util Util { get => _util; set => _util = value; }
    public List<SpriteRenderer> Sprites { get => _sprites; set => _sprites = value; }

    public List<Collider2D> GetColliders() { return colliders; }

    // Start is called before the first frame update
    void Start()
    {
        Util = new Util();
    }

    // Update is called once per frame
    void Update()
    {
        playerPositionY = (int)GameObject.FindGameObjectWithTag("Player").transform.position.y;
        SavedPosition = Util.isBehind(colliders, this.transform, SavedPosition, Sprites, playerPositionY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        colliders.Add(other);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);

    }
}
