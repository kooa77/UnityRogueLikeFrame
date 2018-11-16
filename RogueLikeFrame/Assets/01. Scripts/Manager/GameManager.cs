using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // Singleton

    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new GameManager();
                _instance.Init();
            }
            return _instance;
        }
    }

    void Init()
    {
    }


    // Map

    TileMap _tileMap;

    public TileMap GetMap()
    {
        return _tileMap;
    }

    public void SetMap(TileMap tileMap)
    {
        _tileMap = tileMap;
    }


    // MapObject

    Character _player = null;

    public void SetPlayer(Character player)
    {
        _player = player;
    }

    public Character GetPlayer()
    {
        return _player;
    }
}
