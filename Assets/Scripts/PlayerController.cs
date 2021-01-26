using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] rollWheels;
    private bool wheelActive = false;

    public Vector2Int boardPos;

    //Should probably be owned by some animator script instead of this...
    private Queue<Vector2> movementQueue;
    private float moveLerpThresh = 0.5f;

    private void Start()
    {
        movementQueue = new Queue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     if (wheelActive)
        //     {
        //         foreach (GameObject wheel in rollWheels) {
        //             wheel.SetActive(false);
        //         }
        //         wheelActive = false;
        //     }
        //     else
        //     {
        //         rollWheels[0].SetActive(true);
        //         wheelActive = true;
        //     }
        // }

        //Move through movement queue
        if (movementQueue.Count > 0)
        {
            Vector2 nextLoc = movementQueue.Peek();

            float newX = Mathf.Lerp(transform.position.x, nextLoc.x, 0.1f);
            float newZ = Mathf.Lerp(transform.position.z, nextLoc.y, 0.1f);

            transform.position = new Vector3(newX, transform.position.y, newZ);

            //Move on if player has arrived at node location
            if ((new Vector2(transform.position.x, transform.position.z) - nextLoc).magnitude < moveLerpThresh)
            {
                movementQueue.Dequeue();

                //Snap if at end of queue
                if (movementQueue.Count == 0)
                {
                    transform.position = new Vector3(nextLoc.x, transform.position.y, nextLoc.y);
                }
            }
        }
    }

    public void moveToBoardPos(BoardTile bt)
    {
        boardPos = bt.pos;

        enqueue2DMovement(bt.transform.position.x, bt.transform.position.z);
    }

    public void enqueue2DMovement(float x, float z)
    {
        movementQueue.Enqueue(new Vector2(x, z));
    }
}
