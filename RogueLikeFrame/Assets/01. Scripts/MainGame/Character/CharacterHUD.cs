using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // HP

    [SerializeField] Slider _hpSlider;

    public void UpdateHP(int hp, int maxHP)
    {
        float rate = (float)hp / (float)maxHP;
        _hpSlider.value = rate;
    }
}
