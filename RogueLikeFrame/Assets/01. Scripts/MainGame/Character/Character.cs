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
    [SerializeField] CharacterHUD _hud;
    protected TileMap _map = GameManager.Instance.GetMap();

    protected bool _isDead = false;

    int _maxHP = 10;
    int _hp = 0;

    public void Init()
    {
        _canMove = false;

        _map = GameManager.Instance.GetMap();
        _hp = _maxHP;

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

        if(null != _hud)
            _hud.UpdateHP(_hp, _maxHP);
    }


    // Event

    public override void Attacked(MapObject senderObject)
    {
        if (true == _isDead)
            return;
        Damage(senderObject);
    }

    void Damage(MapObject senderObject)
    {
        int attackPoint = senderObject.GetAttackPoint();
        int finalAttackPoint = attackPoint - _defensePoint;

        Debug.Log("Damaged : " + finalAttackPoint);

        _hp -= finalAttackPoint;
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

        if(null != _hud)
            _hud.UpdateHP(_hp, _maxHP);
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

    protected virtual void Collide(int x, int y)
    {
        if (true == _isDead)
            return;

        MapObject mapObject = _map.GetMapObject(x, y);
        if (null != mapObject)
        {
            switch(mapObject.GetObjectType())
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


    // Attack/Defense

    [SerializeField] Item _item = null;

    protected void Attack(MapObject target)
    {
        // todo : 공격 애니메이션
        if(null != _item)
            _item.Use();
        target.Attacked(this);
    }

    public override int GetAttackPoint()
    {
        int itemAttack = 0;
        if (null != _item)
            itemAttack = _item.GetAttackPoint();
        return (_attackPoint + itemAttack );
    }


    // Position

    protected int _x = 0;
    protected int _y = 0;

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

    public Vector2 GetPosition()
    {
        return new Vector2(_x, _y);
    }
}
