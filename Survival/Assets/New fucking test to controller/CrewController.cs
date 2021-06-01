using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrewController : MonoBehaviour
{

    public List<CrewMember> characters = new List<CrewMember>();
    void Awake()
    {
        characters = GetComponentsInChildren<CrewMember>().ToList();
        OrderByPosition();
    }


   

    // Update is called once per frame
    void LateUpdate()
    {
        OrderByPosition();
    }

    public int GetNextFreePosition()
    {
        foreach (CrewMember charr in characters)
        {
            Debug.Log(charr.isFree);
            if (charr.isFree)
            {
                charr.isFree = false;
                return charr.position;
            }

        }
        Debug.Log("Nenhuma posicao disponivel");
        return -1;
    }

    public Transform GetPositionTarget(int position)
    {
        return characters.Find(x => x.position == position).target;
    }
    public void OrderByPosition()
    {
        characters = characters.OrderBy(x => x.position).ToList();
    }
}
