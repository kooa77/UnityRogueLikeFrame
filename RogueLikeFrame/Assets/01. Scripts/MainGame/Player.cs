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
    }

    void MoveRight()
    {
        _model.PlayRightWalk();
    }

    void MoveUp()
    {
        _model.PlayUpWalk();
    }

    void MoveDown()
    {
        _model.PlayDownWalk();
    }


    // Position

    void SetPosition(int x, int y)
    {
        TileMap map = GameManager.Instance.GetMap();
        map.SetPlayer(x, y, this);
    }
}
