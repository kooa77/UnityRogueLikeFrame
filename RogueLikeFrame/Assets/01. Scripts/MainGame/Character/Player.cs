using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Unity

	void Start ()
    {
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
}
