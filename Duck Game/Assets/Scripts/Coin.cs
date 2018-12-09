﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private LevelManager levelManager;

    public int coinValue;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            levelManager.AddCoins(coinValue);

            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
            
    }

}
