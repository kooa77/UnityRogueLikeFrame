using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    // Unity Methods

	void Start ()
    {
	}
	
	void Update ()
    {
	}


    // Walk

    public void PlayLeftWalk()
    {
        gameObject.GetComponent<Animator>().SetTrigger("left");
    }

    public void PlayRightWalk()
    {
        gameObject.GetComponent<Animator>().SetTrigger("right");
    }

    public void PlayUpWalk()
    {
        gameObject.GetComponent<Animator>().SetTrigger("up");
    }

    public void PlayDownWalk()
    {
        gameObject.GetComponent<Animator>().SetTrigger("down");
    }


    // State

    public void PlayDamage()
    {
        gameObject.GetComponent<Animator>().SetTrigger("damage");
    }

    public void PlayDead()
    {
        gameObject.GetComponent<Animator>().SetTrigger("dead");
    }
}
