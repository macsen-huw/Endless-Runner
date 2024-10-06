using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameLogic : MonoBehaviour
{

    [Header("GameLogic")]
    public float timePerIncrease;
    public float rateOfIncrease;
    private float timeBetweenSpeedIncrease;

    [Header("Player")]
    public Player player;
    public float jumpForce;

    [Header("Camera")]
    public float cameraSpeed;

    [Header("Background")]
    public ParallaxBackground parallaxBackground;
    public float increaseRate;

    [Header("Snowman")]
    public GameObject snowman;
    public float minXValue;
    public float maxXValue;

    //Add a range of time to randomize snowman spawn
    public float minimumSpawnTime;
    public float maximumSpawnTime;

    public float yOffset;
    private float snowmanSpawnTime;


    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move the camera
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);

        //Determine whether to spawn a snowman
        if(Time.time > snowmanSpawnTime)
        {
            SpawnSnowman();
            snowmanSpawnTime = Time.time + Random.Range(minimumSpawnTime, maximumSpawnTime);
        }

        //Check whether it's time to speed up the game
        if(Time.time > timeBetweenSpeedIncrease)
        {

            //If it is, then speed up the game
            cameraSpeed *= rateOfIncrease;
            timeBetweenSpeedIncrease = Time.time + timePerIncrease;

            //Speed up the background too
            parallaxBackground.IncreaseSpeed(increaseRate);
        }

        //Update jump force value (if it's been changed)
        if (player.jumpForce != jumpForce)
            player.setJumpForce(jumpForce);
    }

    private void SpawnSnowman()
    {
        //Get random x position
        float randomX = Random.Range(minXValue, maxXValue);

        //Create a new snowman, a random distance away from the screen
        Instantiate(snowman, transform.position + new Vector3(randomX, yOffset, -5), transform.rotation);
    }
    public void Death()
    {
        print("Died!");
    }



}