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
        Vector3 pos = tile.transform.position;
        float yPos = hotbarManager.activeObj.transform.position.y;
        Instantiate(hotbarManager.activeObj, new Vector3(pos.x, yPos, pos.z), hotbarManager.activeObj.transform.rotation);
    }
}
