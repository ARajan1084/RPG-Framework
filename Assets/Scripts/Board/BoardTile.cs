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

    public List<BoardTile> neighbors;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        baseCol = rend.material.color;
    }

    public void setData(Vector2Int pos, Board parentBoard)
    {
        this.pos = pos;
        this.parentBoard = parentBoard;
    }

    private void OnMouseDown()
    {
        rend.material.color = Color.blue;
        // Requests corresponding board to do the corresponding action
        parentBoard.OnClick(this);
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
