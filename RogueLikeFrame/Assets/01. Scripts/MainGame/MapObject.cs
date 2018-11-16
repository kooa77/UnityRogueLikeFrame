using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Info

    public enum eType
    {
        ENEMY,
    }

    protected eType _type;
    protected bool _canMove = false;

    public eType GetObjectType()
    {
        return _type;
    }

    public bool CanMove()
    {
        return _canMove;
    }


    // Event

    public void Collide(MapObject senderObject)
    {
        Debug.Log("MapObject Collide : " + senderObject);
    }

    public virtual void Attack(MapObject senderObject)
    {
        Debug.Log("MapObject Attack : " + senderObject);
    }
}
