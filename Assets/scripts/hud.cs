using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hud : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}
