using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Unity

	void Start ()
    {
        _type = eType.PLAYER;
    }
	
	void Update ()
    {
        UpdateInput();
	}


    // Input

    void UpdateInput()
    {
        if (true == _isDead)
            return;

        if (true == Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        if (true == Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
        if (true == Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp();
        if (true == Input.GetKeyDown(KeyCode.DownArrow))
            MoveDown();
    }

    protected override void Collide(int x, int y)
    {
        if (true == _isDead)
            return;

        MapObject mapObject = _map.GetMapObject(x, y);
        if (null != mapObject)
        {
            switch (mapObject.GetObjectType())
            {
                case MapObject.eType.ENEMY:
                    mapObject.Attacked(this);
                    break;
                default:
                    mapObject.Collide(this);
                    break;
            }
        }
    }
}
