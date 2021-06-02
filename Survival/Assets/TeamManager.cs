using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public int[] positionsToChange;
    public SelectToChangeOrder[] mouseInteractionsList;
    public CharSlot[] bodys;

    public Button btnChangeOrder;

    public GameObject toInstantiate;

    void Start()
    {
        this.positionsToChange = new int[2];
        mouseInteractionsList = GameObject.FindObjectsOfType<SelectToChangeOrder>();
        bodys = GameObject.FindObjectsOfType<CharSlot>();
    }
    private void Update()
    {

        btnChangeOrder.enabled = !(hasEmpty());


    }

    public bool hasEmpty()
    {
        if (positionsToChange[0] != 0 && positionsToChange[1] != 0)
        {
            return false;
        }
        return positionsToChange.Distinct().Count() != positionsToChange.Length + 1;
    }
    public bool isInArray(int position)
    {
        return positionsToChange.Contains(position);
    }
    public int getPositionIndex(int position)
    {
        return Array.IndexOf(positionsToChange, position);
    }
    public int getMouseInteractionIndex(int position)
    {
        SelectToChangeOrder teste = mouseInteractionsList.Where(x => x.position == position).First();
        return Array.IndexOf(mouseInteractionsList, teste);
    }
    public int getBodysIndex(int position)
    {
        CharSlot teste = bodys.Where(x => x.position == position).First();
        return Array.IndexOf(bodys, teste);
    }
    public int nextPosition()
    {
        for (int i = 0; i < positionsToChange.Length; i++)
        {
            if (positionsToChange[i] == 0)
            {
                return i;
            }

        }

        return -1;
    }


    public void changeOrder()
    {
        Debug.Log("change");
        int pos1 = positionsToChange[0];
        int pos2 = positionsToChange[1];


        int MIST = getMouseInteractionIndex(pos1);
        int MISD = getMouseInteractionIndex(pos2);

        int BST = getBodysIndex(pos1);
        int BSD = getBodysIndex(pos2);

        mouseInteractionsList[MIST].position = pos2;
        mouseInteractionsList[MISD].position = pos1;

        bodys[BST].position = pos2;
        bodys[BSD].position = pos1;

        positionsToChange[0] = pos2;
        positionsToChange[1] = pos1;
        Debug.Log("MIST: " + MIST + "   MISD: " + MISD);
    }

    public void addMember()
    {
        int freeSlot = getNextFreeSlot();
        Debug.Log("freeslot: " + freeSlot);
        if (freeSlot != -1)
        {
            GameObject bodyFreeSlot = bodys[freeSlot].gameObject;
            Vector3 position = new Vector3(bodyFreeSlot.transform.position.x, bodyFreeSlot.transform.position.y, bodyFreeSlot.transform.position.z);

            GameObject obj = Instantiate(toInstantiate, position, Quaternion.identity);
            obj.transform.SetParent(bodyFreeSlot.transform);
        }
    }

    public void removeMember()
    {

        int pos1 = positionsToChange[0];
        int pos2 = positionsToChange[1];
        if (pos1 != 0)
        {
            int BST = getBodysIndex(pos1);
            if (!bodys[BST].isFree && !bodys[BST].cannotRelease)
                Destroy(bodys[BST]);
        }

        if (pos2 != 0)
        {
            int BSD = getBodysIndex(pos2);
            if (!bodys[BSD].isFree && !bodys[BSD].cannotRelease)
                Destroy(bodys[BSD]);
        }
    }

    int getNextFreeSlot()
    {
        for (int i = 1; i < bodys.Length + 1; i++)
        {
            int index = getBodysIndex(i);

            if (bodys[index].isFree == true)
            {
                return index;
            }
        }
        //Nenhuma posicao livre;
        return -1;
    }
}
