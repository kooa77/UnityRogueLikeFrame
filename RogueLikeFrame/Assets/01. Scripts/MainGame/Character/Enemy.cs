using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Unity

	void Start ()
    {
        _type = eType.ENEMY;

    }
	
	void Update ()
    {
        UpdateAI();
    }


    // Ai

    float _aiInterval = 1.0f;
    float _aiWaitTime = 0.0f;
    
    void UpdateAI()
    {
        if (true == _isDead)
            return;

        if (_aiWaitTime < _aiInterval)
        {
            _aiWaitTime += Time.deltaTime;
            return;
        }
        _aiWaitTime = 0.0f;

        Character player = GameManager.Instance.GetPlayer();
        Vector2 playerPosition = player.GetPosition();

        // todo : 플레이어의 좌표를 비교해 이동 (무식한 이동. 벽에 끼이면 이동 못한다)
        if (_x < playerPosition.x)
        {
            MoveRight();
        }
        else if (playerPosition.x < _x)
        {
            MoveLeft();
        }
        else if (_y < playerPosition.y)
        {
            MoveDown();
        }
        else if(playerPosition.y < _y)
        {
            MoveUp();
        }
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
                case MapObject.eType.PLAYER:
                    Attack(mapObject);
                    break;
                default:
                    mapObject.Collide(this);
                    break;
            }
        }
    }
}
