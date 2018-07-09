using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBehavior : PieceBehavior {
    

    public override Vector3[] getPaths()
    {
        currentPaths = new Vector3[8];

        currentPaths[0] = getPathIfPossible(transform, 2, 1, gameObject.tag);
        currentPaths[1] = getPathIfPossible(transform, 2, -1, gameObject.tag);
        currentPaths[2] = getPathIfPossible(transform, -2, 1, gameObject.tag);
        currentPaths[3] = getPathIfPossible(transform, -2, -1, gameObject.tag);
        currentPaths[4] = getPathIfPossible(transform, 1, 2, gameObject.tag);
        currentPaths[5] = getPathIfPossible(transform, -1, 2, gameObject.tag);
        currentPaths[6] = getPathIfPossible(transform, 1, -2, gameObject.tag);
        currentPaths[7] = getPathIfPossible(transform, -1, -2, gameObject.tag);

        return currentPaths;
    }
}
