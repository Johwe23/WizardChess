using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBehavior : MonoBehaviour {

    protected Vector3 EmptyVector = new Vector3(0, 0, 0);
    protected Vector3[] currentPaths;

    protected Vector3 targetPosition;
    protected Vector3 speedVector;
    protected Vector3 startPosition;
    protected int moveCount = 1;

    public float animationSecondsPerMeter;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    public abstract Vector3[] getPaths();

    protected GameObject[] getPiecesFromTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }


    protected Vector3 createMovement(Transform position, float x, float z)
    {
        return new Vector3(position.position.x + x, position.position.y, position.position.z + z);
    }

    protected bool hasPieceOnPosition(Vector3 pos, string tag)
    {

        GameObject[] pieces = getPiecesFromTag(tag);

        foreach(GameObject piece in pieces)
        {
            if(piece.transform.position == pos)
            {
                return true;
            }
        }

        return false;
    }

    protected Vector3 getPathIfPossible(Transform position, float x, float z, string tag)
    {
        Vector3 path = createMovement(position, x, z);
        if(path.x > 4 || path.x < -4 || path.z > 4 || path.z < -4)
        {
            return EmptyVector;
        }
        else if(hasPieceOnPosition(path, tag))
        {
            return EmptyVector;
        }
        else
        {
            return path;
        }
    }

    protected string invertTag(string tag)
    {
        if (tag == "WhitePiece")
        {
            return "BlackPiece";
        }
        else if (tag == "BlackPiece")
        {
            return "WhitePiece";
        }

        else return null;
    }

    protected int scanLine(Vector3[] paths, int index, int xfactor, int zfactor)
    {
        for (int i = 1; i < 8; i++)
        {
            paths[index] = getPathIfPossible(transform, xfactor * i, zfactor * i, gameObject.tag);
            if (isEmpty(paths[index]))
            {
                break;
            }
            index++;
        }
        return index;
    }

    public void moveTo(float x, float z)
    {
        startPosition = transform.position;
        moveCount = 1;
        targetPosition = new Vector3(x, transform.position.y, z);
        //speedVector = Vector3.Normalize(targetPosition - transform.position) * speed;
    }

    public void move()
    {
        if(transform.position != targetPosition)
        {
            /* if(Vector3.Magnitude(targetPosition - transform.position) > Vector3.Magnitude(targetPosition - (transform.position + speedVector * Time.deltaTime))){
                 //transform.position += speedVector * Time.deltaTime;

             }
             else
             {
                 transform.position = targetPosition;
             } */
            if (transform.position != targetPosition)
            {
                transform.position = startPosition + (targetPosition - startPosition) * pathScale(moveCount);
                if(pathScale(moveCount) == 1)
                {
                    transform.position = targetPosition;
                }
                moveCount++;
            }
        }
    }

    protected float pathScale(int moveCount)
    {
        float distance = (targetPosition - startPosition).magnitude;

        if (movementFunc(moveCount) / (animationSecondsPerMeter * 60 * distance) > 1)
        {
            return 1;
        }
        else return movementFunc(moveCount) / (animationSecondsPerMeter * 60 * distance);
    }

    protected float movementFunc(int x)
    {
        return x + x * x;
    }

    public bool isMoving()
    {
        return transform.position != targetPosition;
    }


    public bool isEmpty(Vector3 vector)
    {
        if (vector == EmptyVector)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public Vector3[] getCurrentPaths()
    {
        return currentPaths;
    }

}
