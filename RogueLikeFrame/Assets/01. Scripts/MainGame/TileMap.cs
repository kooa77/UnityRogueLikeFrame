using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] GameObject _tileObjectPrefabs;

    void Start ()
    {
        //Create();
	}
	
	void Update ()
    {
		
	}


    // TileMap

    MapTile[,] _mapTileArray;

    // refactoring : 중복 코드 제거
    public void Create()
    {
        Sprite[] spriteList = Resources.LoadAll<Sprite>("Map/MapSprite");
        
        // 1층
        int width = 32;
        int height = 16;

        _mapTileArray = new MapTile[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
                tileObject.transform.SetParent(transform);
                tileObject.transform.localScale = Vector3.one;
                tileObject.transform.localPosition = Vector3.zero;

                int spriteIndex = 17;
                if (spriteIndex < spriteList.Length)
                {
                    MapTile mapTile = tileObject.GetComponent<MapTile>();
                    mapTile.Init(spriteList[spriteIndex], x - (width / 2), -y + (height / 2));

                    _mapTileArray[y, x] = mapTile;
                }
            }
        }

        // 2층
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int isCreate = Random.Range(0, 100);
                if(isCreate < 30)
                {
                    GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
                    tileObject.transform.SetParent(transform);
                    tileObject.transform.localScale = Vector3.one;
                    tileObject.transform.localPosition = Vector3.zero;

                    int spriteIndex = 139;
                    if (spriteIndex < spriteList.Length)
                    {
                        MapTile mapTile = tileObject.GetComponent<MapTile>();
                        mapTile.Init(spriteList[spriteIndex], x - (width / 2), -y + (height / 2));
                    }
                }
            }
        }
    }

    MapTile GetMapTile(int x, int y)
    {
        return _mapTileArray[y, x];
    }


    // Map Objects

    public void SetPlayer(int x, int y, Player player)
    {
        MapTile mapTile = GetMapTile(x, y);
        player.transform.position = mapTile.transform.position;
    }
}
