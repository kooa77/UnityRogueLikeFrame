using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Unity

	void Start ()
    {
        SetPosition(15, 7);
    }
	
	void Update ()
    {
        UpdateInput();
	}


    // Model

    [SerializeField] CharacterModel _model;


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
        _x--;
        UpdatePosition();
    }

    void MoveRight()
    {
        _model.PlayRightWalk();
        _x++;
        UpdatePosition();
    }

    void MoveUp()
    {
        _model.PlayUpWalk();
        _y--;
        UpdatePosition();
    }

    void MoveDown()
    {
        _model.PlayDownWalk();
        _y++;
        UpdatePosition();
    }


    // Position

    int _x = 0;
    int _y = 0;

    void UpdatePosition()
    {
        TileMap map = GameManager.Instance.GetMap();
        map.SetPlayer(_x, _y, this);
    }

    void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
        UpdatePosition();
    }
}
