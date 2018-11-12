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

    MapObject _mapObject = null;
    bool _canMove = true;

    public void Init(Sprite sprite, float x, float y)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.transform.localPosition = new Vector2(x, y);
    }

    public void SetMapObject(MapObject mapObject)
    {
        _mapObject = mapObject;
        _mapObject.transform.position = transform.position;
    }

    public void ResetMapObject()
    {
        _mapObject = null;
    }

    public MapObject GetMaoObject()
    {
        return _mapObject;
    }

    public bool CanMove()
    {
        if(null != _mapObject)
        {
            return _mapObject.CanMove();
        }
        return _canMove;
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }
}
