using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] TileMap _tileMap;

    // Unity

    void Start ()
    {
        _tileMap.Create();
        GameManager.Instance.SetMap(_tileMap);
    }
	
	void Update ()
    {
	}
}
