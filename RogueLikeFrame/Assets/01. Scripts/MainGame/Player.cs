using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Unity

	void Start ()
    {
        _map = GameManager.Instance.GetMap();
        SetPosition(15, 7);
    }
	
	void Update ()
    {
        UpdateInput();
	}


    // Attr

    [SerializeField] CharacterModel _model;
    TileMap _map = GameManager.Instance.GetMap();


    // Input

    void UpdateInput()
    {
        if (true == Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        if (true == Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
        if (true == Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp();
        if (true == Input.GetKeyDown(KeyCode.DownArrow))
            MoveDown();
    }


    // Move

    void MoveLeft()
    {
        _model.PlayLeftWalk();

        int newX = _x - 1;
        SetPosition(newX, _y);
    }

    void MoveRight()
    {
        _model.PlayRightWalk();

        int newX = _x + 1;
        SetPosition(newX, _y);
    }

    void MoveUp()
    {
        _model.PlayUpWalk();

        int newY = _y - 1;
        SetPosition(_x, newY);
    }

    void MoveDown()
    {
        _model.PlayDownWalk();

        int newY = _y + 1;
        SetPosition(_x, newY);
    }


    // Position

    int _x = 0;
    int _y = 0;

    void SetPosition(int x, int y)
    {
        if(true == _map.CanMove(x, y))
        {
            _x = x;
            _y = y;
            _map.SetPlayer(_x, _y, this);
        }
    }
}
