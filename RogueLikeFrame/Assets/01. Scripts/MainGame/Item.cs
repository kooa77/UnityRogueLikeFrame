using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MapObject
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Init

    protected TileMap _map = GameManager.Instance.GetMap();

    public void Init()
    {
        _canMove = true;

        _map = GameManager.Instance.GetMap();
        
        int x = 0;
        int y = 0;
        while (true)
        {
            x = Random.Range(0, 32);
            y = Random.Range(0, 16);
            if (true == _map.CanMove(x, y))
                break;

        }
        _map.SetMapObject(x, y, this);
    }


    // Use

    public void Use()
    {
        // todo : Use Animation
    }

    public int GetAttackPoint()
    {
        return 2;
    }
}
