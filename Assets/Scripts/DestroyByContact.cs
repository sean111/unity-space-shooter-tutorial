﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (null != gameControllerObject)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (null == gameController)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Boundry") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (null != explosion)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
