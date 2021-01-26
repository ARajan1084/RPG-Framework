using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject boardTilePrefab;
    public float boardTileElevationDelta = 0.1f;
    public Vector3 tileSize = new Vector3(1, 0, 1);

    private BoardTile[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        //Lay down tile prefabs -------------------------------
        //Grab bounds

        Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;

        Vector3 boundsSize = bounds.size;
        boundsSize.Scale(transform.localScale);

        Vector3 boundsMin = bounds.min;
        boundsMin.Scale(transform.localScale);
        boundsMin += transform.position;

        int xCount = (int) (boundsSize.x / tileSize.x);
        int zCount = (int) (boundsSize.z / tileSize.z);

        tiles = new BoardTile[xCount, zCount];

        //2d traversal to lay down tiles
        for (int x=0; x<xCount; x++)
        {
            for (int z=0; z<zCount; z++)
            {
                Vector3 tilePos = new Vector3(x * tileSize.x, boardTileElevationDelta, z * tileSize.z) + boundsMin;

                //Not a clue why it's pointing down, quaternions are stupid
                GameObject boardTile = Instantiate(boardTilePrefab, tilePos, Quaternion.LookRotation(Vector3.down));

                //Parent, boardTile will have a strange localScale.
                boardTile.transform.parent = transform;

                //Enqueue some data to the boardTile
                BoardTile btc = boardTile.GetComponent<BoardTile>();
                btc.setData(new Vector2Int(x, z), this);

                //Place into tile array
                tiles[x, z] = btc;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
