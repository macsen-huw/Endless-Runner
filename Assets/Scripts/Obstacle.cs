using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Obstacle : MonoBehaviour
{
    private GameLogic gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameLogic>();
    }


    //Detect collision 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check whether the obstacle has hit the player
        //If so, the game is over
        if (collision.tag == "Player")
            gameManager.Death();
        

        //If it's hit the outer border, despawn
        if (collision.tag == "Offscreen")
        {
            Destroy(this.gameObject);
        }
    }
}
