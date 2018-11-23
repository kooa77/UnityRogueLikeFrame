using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] TileMap _tileMap;
    [SerializeField] Character _player;
    [SerializeField] List<GameObject> _itemPrefabList;

    // Unity

    void Start ()
    {
        _tileMap.Create();
        GameManager.Instance.SetMap(_tileMap);

        _player.Init();

        int enemyCount = 5;
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

        int mapItemCount = 10;
        for(int i=0; i<mapItemCount; i++)
        {
            int randItemIdx = Random.Range(0, _itemPrefabList.Count);

            GameObject itemPrefab = _itemPrefabList[randItemIdx];
            GameObject itemObject = GameObject.Instantiate(itemPrefab);
            itemObject.transform.SetParent(transform);
            itemObject.transform.localPosition = Vector3.zero;
            itemObject.transform.localScale = Vector3.one;

            Item item = itemObject.GetComponent<Item>();
            item.Init();

        }
    }
	
	void Update ()
    {
	}
}
