using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBehavior : PieceBehavior {
    

    public override Vector3[] getPaths()
    {
        int sideFactor;
        if(gameObject.tag == "WhitePiece")
        {
            sideFactor = -1;
        }
        else
        {
            sideFactor = 1;
        }

        currentPaths = new Vector3[3];

        currentPaths[0] = createMovement(transform, sideFactor, 0); //Only white pawns
        currentPaths[1] = getDiagonalIfPossible(transform, sideFactor, 1, gameObject.tag);
        currentPaths[2] = getDiagonalIfPossible(transform, sideFactor, -1, gameObject.tag);

        return currentPaths;
    }

    private Vector3 getDiagonalIfPossible(Transform position, float x, float z, string tag)
    {
        if (hasPieceOnPosition(createMovement(position, x, z), invertTag(tag)))
        {
            return getPathIfPossible(position, x, z, tag);
        }
        else return EmptyVector;
    }
}
