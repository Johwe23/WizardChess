using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGridController : MonoBehaviour {

    public float hoverHeight;
    public GameObject path;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clearAllPaths();
        }
	}

    public void calculatePaths(GameObject piece)
    {
        clearAllPaths();
        Vector3[] paths = piece.GetComponent<PieceBehavior>().getPaths();
        foreach(Vector3 path in paths)
        {
            if(!piece.GetComponent<PieceBehavior>().isEmpty(path))
            setAPath(path.x, path.z);
        }
    }

    void setAPath(float x, float z)
    {
        this.path.transform.position = new Vector3(x, hoverHeight, z);
        GameObject path = Instantiate(this.path);
        path.transform.parent = gameObject.transform;
    }

    public void clearAllPaths()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
        
    }
}
