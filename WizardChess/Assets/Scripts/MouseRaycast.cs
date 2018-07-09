using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour {

    public float rayDistance;

    public SelectBehavior select;
    public BoardGridController pathManager;
    private bool whiteTurn = true;

    private GameObject selectedPiece;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if ((hit.collider.tag == "WhitePiece" && whiteTurn) || (hit.collider.tag == "BlackPiece" && !whiteTurn))
                {
                    selectPiece(hit.transform.gameObject);
                }
                else if (hit.collider.tag == "Board" && selectedPiece == null)
                {
                    clearSelect();
                }
                else if(hit.collider.tag == "Board" && selectedPiece != null)
                {
                    tryMovePiece(hit);
                }
            }
            
        }
        else if(Input.GetMouseButtonDown(0))
        {
            clearSelect();
        }


    }

    private void tryMovePiece(RaycastHit hit)
    {
        float z = Mathf.Floor(hit.point.z) + 0.5f;
        float x = Mathf.Floor(hit.point.x) + 0.5f;

        Vector3[] paths = selectedPiece.GetComponent<PieceBehavior>().getCurrentPaths();
        //Debug.Log(x + "  " + z);
        foreach (Vector3 path in paths)
        {
            if (path.x == x && path.z == z)
            {
                selectedPiece.GetComponent<PieceBehavior>().moveTo(x, z);
                clearSelect();
                //whiteTurn = !whiteTurn;
                break;
            }
        }
    }

    private void selectPiece(GameObject piece)
    {
        selectedPiece = piece;
        select.gameObject.SetActive(true);
        select.moveToSelected(selectedPiece);
        pathManager.calculatePaths(selectedPiece);
    }

    private void clearSelect()
    {
        selectedPiece = null;
        select.gameObject.SetActive(false);
        pathManager.clearAllPaths();
    }

    public GameObject getSelectedPiece()
    {
        return selectedPiece;
    }

    public bool isWhiteTurn()
    {
        return whiteTurn;
    }
}
