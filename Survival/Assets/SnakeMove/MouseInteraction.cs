using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteraction : MonoBehaviour, IPointerClickHandler
{
    public int position;
    public TeamManager teamManager;
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI textMesh;

    public void OnPointerClick(PointerEventData eventData)
    {
        int nextIndex = teamManager.nextPosition();
        bool isEqual = teamManager.isInArray(position);


        if (isEqual)
        {
            Debug.Log("Posicao igual no array a selecionada");
            var indexOfArrayEqual = teamManager.getPositionIndex(position);
            teamManager.positionsToChange[indexOfArrayEqual] = 0;
            spriteRenderer.color = Color.white;
        }
        else if (nextIndex != -1)
        {
            Debug.Log("Posicao livre");
            teamManager.positionsToChange[nextIndex] = position;
            spriteRenderer.color = Color.red;
        }
    }

    void Start()
    {
        teamManager = GameObject.FindGameObjectWithTag("Formation").GetComponent<TeamManager>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        textMesh = this.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = position.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = position.ToString();
    }
}
