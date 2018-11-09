using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Interface

    bool _canMove = true;

    public void Init(Sprite sprite, float x, float y)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.transform.localPosition = new Vector2(x, y);
    }

    public bool CanMove()
    {
        return _canMove;
    }

    public void SetMove(bool canMove)
    {
        _canMove = canMove;
    }
}
