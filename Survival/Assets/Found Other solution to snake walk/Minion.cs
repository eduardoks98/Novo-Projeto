using System.Collections;
using UnityEngine;

namespace Assets.Found_Other_solution_to_snake_walk
{
    public class Minion : MonoBehaviour
    {
        public int index;
        public Transform posicao;
        public void Init(int index)
        {
            this.index = index;
        }

        // Move the minion along the path
        public void MoveOnPath(Path path, float dist)
        {
            Vector2 prev = path.Head(-index);
            Vector2 next = path.Head(-index + 1);

            // Interpolate the position of the minion between the previous and the next point within the path. 'dist' is the distance between the 'head' of the path and the leader
            this.transform.position = Vector2.Lerp(prev, next, dist);
        }

        // Push the minion to avoid minions stepping on each other
        public void Push(Vector2 dir)
        {
            this.transform.position += (Vector3)dir;
        }
    }
}