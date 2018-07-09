using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopBehavior : PieceBehavior {


    public override Vector3[] getPaths()
    {
        currentPaths = new Vector3[13];
        int index = 0;
        index = scanLine(currentPaths, index, 1, 1);
        index = scanLine(currentPaths, index, -1, 1);
        index = scanLine(currentPaths, index, 1, -1);
        index = scanLine(currentPaths, index, -1, -1);

        return currentPaths;
    }

}
