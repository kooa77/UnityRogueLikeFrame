using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] GameObject _tileObjectPrefabs;

    void Start ()
    {
        Create();
	}
	
	void Update ()
    {
		
	}


    // TileMap

    void Create()
    {
        Sprite[] spriteList = Resources.LoadAll<Sprite>("Map/MapSprite");
        /*
        for (int i = 0; i < spriteList.Length; i++)
        {
            GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
            tileObject.transform.SetParent(transform);
            tileObject.transform.localScale = Vector3.one;
            tileObject.transform.localPosition = Vector3.zero;

            float x = -8 + (i % 16);
            float y = 8 - (i / 16);
            
            //tileObject.GetComponent<SpriteRenderer>().sprite = spriteList[i];
            //tileObject.transform.localPosition = new Vector2(x, y);
            MapTile mapTile = tileObject.GetComponent<MapTile>();
            mapTile.Init(spriteList[i], x, y);
        }
        */

        /*
        int width = 32;
        int height = 16;
        for(int y=0; y<height; y++)
        {
            for(int x=0; x<width; x++)
            {
                GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
                tileObject.transform.SetParent(transform);
                tileObject.transform.localScale = Vector3.one;
                tileObject.transform.localPosition = Vector3.zero;

                int spriteIndex = x + (y * height);
                if (spriteIndex < spriteList.Length)
                {
                    MapTile mapTile = tileObject.GetComponent<MapTile>();
                    mapTile.Init(spriteList[spriteIndex], x - (width / 2), -y + (height / 2));
                }
            }
        }
        */

        // 1층
        int width = 32;
        int height = 16;
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
}
