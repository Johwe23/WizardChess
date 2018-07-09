using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBehavior : PieceBehavior {

    public override Vector3[] getPaths()
    {
        currentPaths = new Vector3[8];
        int i = 0;
        for(int z = -1; z <= 1; z++)
        {
            for(int x = -1; x <= 1; x++)
            {
                if(x == 0 && z == 0)
                {
                    continue;
                }
                currentPaths[i] = getPathIfPossible(transform, x, z, gameObject.tag);
                i++;
            }
        }

        return currentPaths;
    }

}
