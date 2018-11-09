using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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

    public void Init()
    {
        _map = GameManager.Instance.GetMap();

        // todo : 장애물이 없는 곳에 위치가 되도록 개선
        int x = Random.Range(0, 32);
        int y = Random.Range(0, 16);
        SetPosition(x, y);
    }


    // Move

    protected void MoveLeft()
    {
        _model.PlayLeftWalk();

        int newX = _x - 1;
        SetPosition(newX, _y);
    }

    protected void MoveRight()
    {
        _model.PlayRightWalk();

        int newX = _x + 1;
        SetPosition(newX, _y);
    }

    protected void MoveUp()
    {
        _model.PlayUpWalk();

        int newY = _y - 1;
        SetPosition(_x, newY);
    }

    protected void MoveDown()
    {
        _model.PlayDownWalk();

        int newY = _y + 1;
        SetPosition(_x, newY);
    }


    // Position

    int _x = 0;
    int _y = 0;

    protected void SetPosition(int x, int y)
    {
        if (true == _map.CanMove(x, y))
        {
            _x = x;
            _y = y;
            _map.SetCharacter(_x, _y, this);
        }
    }
}
