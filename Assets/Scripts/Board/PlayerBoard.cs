using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : Board
{
    private PlayerController pcon;

    public override void Start()
    {
        base.Start();
        pcon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void OnClick(BoardTile tile)
    {
        pcon.moveToBoardPos(tile.pos);
    }
}
