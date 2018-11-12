using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Info

    protected bool _canMove = false;

    public bool CanMove()
    {
        return _canMove;
    }


    // Event

    public void Collide(MapObject senderObject)
    {
        Debug.Log("Collide : " + senderObject);
    }
}
