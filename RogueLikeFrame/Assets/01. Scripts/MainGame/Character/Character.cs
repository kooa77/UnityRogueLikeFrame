using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MapObject
{
    // Unity
	
	void Start ()
    {
	}
	
	void Update ()
    {
	}


    // Attr

    [SerializeField] protected CharacterModel _model;
    protected TileMap _map = GameManager.Instance.GetMap();

    bool _isDead = false;
    int _hp = 0;

    public void Init()
    {
        _canMove = false;

        _map = GameManager.Instance.GetMap();
        _hp = 10;

        int x = 0;
        int y = 0;
        while (true)
        {
            x = Random.Range(0, 32);
            y = Random.Range(0, 16);
            if (true == _map.CanMove(x, y))
                break;

        }
        SetPosition(x, y);
    }


    // Event

    public override void Attack(MapObject senderObject)
    {
        if (true == _isDead)
            return;

        Debug.Log("Character Attack : " + senderObject);
        Damage();
    }

    void Damage()
    {
        _hp -= 1;
        if (_hp <= 0)
        {
            _hp = 0;
            Dead();
            _model.PlayDead();
        }
        else
        {
            _model.PlayDamage();
        }
    }

    void Dead()
    {
        if (true == _isDead)
            return;

        Debug.Log("Dead");
        _isDead = true;
    }


    // Move

    protected void MoveLeft()
    {
        _model.PlayLeftWalk();

        int newX = _x - 1;
        if (true == _map.CanMove(newX, _y))
        {
            Move(newX, _y);
        }
        else
        {
            Collide(newX, _y);
        }
            
    }

    protected void MoveRight()
    {
        _model.PlayRightWalk();

        int newX = _x + 1;
        if (true == _map.CanMove(newX, _y))
        {
            Move(newX, _y);
        }
        else
        {
            Collide(newX, _y);
        }
    }

    protected void MoveUp()
    {
        _model.PlayUpWalk();

        int newY = _y - 1;
        if (true == _map.CanMove(_x, newY))
        {
            Move(_x, newY);
        }
        else
        {
            Collide(_x, newY);
        }
            
    }

    protected void MoveDown()
    {
        _model.PlayDownWalk();

        int newY = _y + 1;
        if (true == _map.CanMove(_x, newY))
        {
            Move(_x, newY);
        }
        else
        {
            Collide(_x, newY);
        }
    }

    void Move(int newX, int newY)
    {
        if (true == _isDead)
            return;

        ResetPosition(_x, _y);
        SetPosition(newX, newY);
    }

    void Collide(int x, int y)
    {
        if (true == _isDead)
            return;

        MapObject mapObject = _map.GetMapObject(x, y);
        if (null != mapObject)
        {
            switch(mapObject.GetObjectType())
            {
                case MapObject.eType.ENEMY:
                    mapObject.Attack(this);
                    break;
                default:
                    mapObject.Collide(this);
                    break;
            }
        }
    }


    // Position

    int _x = 0;
    int _y = 0;

    protected void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
        _map.SetMapObject(_x, _y, this);
    }

    void ResetPosition(int x, int y)
    {
        _map.ResetMapObject(_x, _y);
    }
}
