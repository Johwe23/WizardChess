using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBehavior : MonoBehaviour {

    public float hoverHeight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveToSelected(GameObject piece)
    {
        this.transform.position = new Vector3(piece.transform.position.x, hoverHeight, piece.transform.position.z);
    }

}
