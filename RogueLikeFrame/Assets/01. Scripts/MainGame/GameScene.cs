using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] TileMap _tileMap;
    [SerializeField] Character _player;
    [SerializeField] Character _soldier;

    // Unity

    void Start ()
    {
        _tileMap.Create();
        GameManager.Instance.SetMap(_tileMap);

        _player.Init();
        _soldier.Init();
    }
	
	void Update ()
    {
	}
}
