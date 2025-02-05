using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpForce;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private AudioSource jumpAudio;

    public float jumpVolume;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpAudio = GetComponent<AudioSource>();

        //Alter audio source volume
        jumpAudio.volume = jumpVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            //Only jump if not already jumping
            if(!isJumping)
            {
                Jump();

                //Player is now jumping
                isJumping = true;
            }
                
        }
            
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpAudio.Play();
    }

    public void setJumpForce(float force)
    {
        jumpForce = force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJumping = false;
    }


}
