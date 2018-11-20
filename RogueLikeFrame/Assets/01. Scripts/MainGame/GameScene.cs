using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] TileMap _tileMap;
    [SerializeField] Character _player;

    // Unity

    void Start ()
    {
        _tileMap.Create();
        GameManager.Instance.SetMap(_tileMap);

        _player.Init();

        int enemyCount = 10;
        for(int i=0; i< enemyCount; i++)
        {
            GameObject enemyObject = GameObject.Instantiate(_enemyPrefab);
            enemyObject.transform.SetParent(transform);
            enemyObject.transform.localPosition = Vector3.zero;
            enemyObject.transform.localScale = Vector3.one;

            Character character = enemyObject.GetComponent<Character>();
            character.Init();
        }

        GameManager.Instance.SetPlayer(_player);
    }
	
	void Update ()
    {
	}
}
