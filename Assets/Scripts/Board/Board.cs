using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Board : MonoBehaviour
{

    public GameObject boardTilePrefab;
    public float boardTileElevationDelta = 0.1f;
    public Vector3 tileSize = new Vector3(1, 0, 1);

    private BoardTile[,] tiles;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //Lay down tile prefabs -------------------------------
        //Grab bounds

        Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;

        Vector3 boundsSize = bounds.size;
        boundsSize.Scale(transform.localScale);

        Vector3 boundsMin = bounds.min;
        boundsMin.Scale(transform.localScale);
        boundsMin += transform.position;

        //Get offset for board tile
        Bounds btBounds = boardTilePrefab.GetComponent<MeshFilter>().sharedMesh.bounds;
        Vector3 btBoundsMin = btBounds.min;
        boundsMin -= new Vector3(btBoundsMin.x, 0, btBoundsMin.y);

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

        //Generate graph
        for (int i=0; i<tiles.GetLength(0); i++)
        {
            for (int j=0; j<tiles.GetLength(1); j++)
            {
                BoardTile t = tiles[i, j];
                List<BoardTile> neighbors = new List<BoardTile>();

                int xDelta = 1;
                int yDelta = 0;

                //Pass for straight angles (0-3), then diagonals (4-7)
                for (int k=0; k<8; k++)
                {
                    BoardTile nt = getTileAt(i + xDelta, j + yDelta);
                    if (nt != null) neighbors.Add(nt);

                    //Rotate clockwise
                    int temp = xDelta;
                    xDelta = yDelta;
                    yDelta = -temp; //negative to create rotation

                    //Switch on 3 because rotation occurs after the 4th straight is checked.
                    if (k==3)
                    {
                        xDelta = 1;
                        yDelta = 1;
                    }
                }

                foreach (BoardTile nt in neighbors) t.neighbors.Add(nt);
            }
        }
    }

    public BoardTile getTileAt(Vector2Int vi)
    {
        return getTileAt(vi.x, vi.y);
    }

    public BoardTile getTileAt(int x, int y)
    {
        if (x < 0 || x >= tiles.GetLength(0) || y < 0 || y >= tiles.GetLength(1)) return null;

        return tiles[x, y];
    }

    public List<BoardTile> genPath(Vector2Int start, Vector2Int end)
    {
        //Dijkstra's algo

        List<NodeInfo> nodes = new List<NodeInfo>();
        nodes.Add(new NodeInfo(0f, null, start));

        NodeInfo dest = null;

        bool[,] mask = new bool[tiles.GetLength(0),tiles.GetLength(1)];

        while (nodes.Count > 0)
        {
            NodeInfo currN = nodes[0];
            nodes.RemoveAt(0);

            //Grab next nodes
            List<BoardTile> adjT = getTileAt(currN.pos).neighbors;

            //Place nodes into list
            for (int i=0; i<adjT.Count; i++)
            {
                //Generate nodeinfo from tile
                BoardTile nextT = adjT[i];

                //If we've already been here, skip
                Vector2Int nextPos = nextT.pos;
                if (mask[nextPos.x, nextPos.y]) continue;

                float nextDist = currN.dist + Vector2.Distance(currN.pos, nextPos);

                NodeInfo nextN = new NodeInfo(nextDist, currN, nextPos);

                

                //Check if we're there already
                if (nextN.pos.Equals(end))
                {
                    dest = nextN;
                    break;
                }

                //Place node into list based off of distance
                bool inserted = false;
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].dist > nextN.dist)
                    {
                        nodes.Insert(j, nextN);
                        inserted = true;
                        break;
                    }
                }

                //In case the list is empty and the prior loop failed
                if (!inserted) nodes.Add(nextN);

                //Mark that we've already found a way there
                //TODO: I think this means that the algorithm won't be perfect
                mask[nextN.pos.x, nextN.pos.y] = true;

                //Debug
                //Debug.DrawLine(getTileAt(currN.pos).transform.position, getTileAt(nextN.pos).transform.position, Color.white, 5);

            }

            //Destination reached?
            if (dest != null) break;


        }

        Debug.Log(nodes.Count);

        //Failed to find end
        if (dest == null) return null;

        //Create path
        List<BoardTile> o = new List<BoardTile>();
        NodeInfo tracker = dest;
        o.Insert(0, getTileAt(tracker.pos));

        while (tracker.prev != null)
        {
            tracker = tracker.prev;
            o.Insert(0, getTileAt(tracker.pos));
        }

        return o;
    }

    public abstract void OnClick(BoardTile tile);

    class NodeInfo
    {
        public float dist;
        public NodeInfo prev;
        public Vector2Int pos;

        public NodeInfo(float dist, NodeInfo prev, Vector2Int pos)
        {
            this.dist = dist;
            this.prev = prev;
            this.pos = pos;
        }
    }

    public void setTileState(bool state)
    {
        foreach (BoardTile tile in tiles)
        {
            tile.enabled = state;
        }
    }
}
