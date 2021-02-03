using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    private Color baseCol;
    private MeshRenderer rend;

    public Vector2Int pos;
    private Board parentBoard;

    private PlayerController pcon;

    public List<BoardTile> neighbors;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        baseCol = rend.material.color;
        pcon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void setData(Vector2Int pos, Board parentBoard)
    {
        this.pos = pos;
        this.parentBoard = parentBoard;
    }

    private void OnMouseDown()
    {
        rend.material.color = Color.blue;

        // ensures pcon is referencing an active PlayerController
        if (pcon != null)
        {
            //Request player to move to its position
            pcon.moveToBoardPos(pos);
        }
    }
    
    private void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        rend.material.color = baseCol;
    }

    private void OnMouseUp()
    {
        rend.material.color = baseCol;
    }
}
