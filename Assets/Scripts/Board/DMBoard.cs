using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMBoard : Board
{
    private HotbarManager hotbarManager;

    public void Start()
    {
        base.Start();
        hotbarManager = GameObject.FindGameObjectWithTag("HotbarManager").GetComponent<HotbarManager>();
    }
    
    public override void OnClick(BoardTile tile)
    {
        Instantiate(hotbarManager.activeObj, tile.transform);
    }
}
