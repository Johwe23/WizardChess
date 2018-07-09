using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBehavior : PieceBehavior{

    public override Vector3[] getPaths()
    {
        currentPaths = new Vector3[27];
        int index = 0;
        index = scanLine(currentPaths, index, 0, 1);
        index = scanLine(currentPaths, index, 0, -1);
        index = scanLine(currentPaths, index, 1, 0);
        index = scanLine(currentPaths, index, -1, 0);

        index = scanLine(currentPaths, index, 1, 1);
        index = scanLine(currentPaths, index, 1, -1);
        index = scanLine(currentPaths, index, -1, 1);
        index = scanLine(currentPaths, index, -1, -1);

        return currentPaths;
    }
}
