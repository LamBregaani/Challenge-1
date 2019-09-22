using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    public Text lifeText;
    public Text deathText;



    private Rigidbody2D rd2d;
    private int count;
    private int life;
    private int level;
    private GameObject Player;

    void Start()
            
    {
        
        rd2d = GetComponent<Rigidbody2D>();
        count = 0;
        life = 3;
        level = 1;
        winText.text = "";
        deathText.text = "";
        countText.text = "Score: " + count.ToString() + "/12";
        

    }
    void FixedUpdate()
    {

        //Death code
        if (life == 0)
        {
            Destroy(gameObject);
            deathText.text = "YOU DIED\nPress 'R' to try again\n Press 'ESCAPE' to quit";
        }

        //Controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal2 = Input.GetAxis("Horizontal2");
        float moveVertical2 = Input.GetAxis("Vertical2");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 movement2 = new Vector2(moveHorizontal2, moveVertical2);
        rd2d.AddForce(movement * speed);
        rd2d.AddForce(movement2 * speed);

        //Level code
        if (level == 1)
        {
            countText.text = "Score: " + count.ToString() + "/12";
            if (count == 12)
            {
                rd2d.velocity = Vector2.zero;

                winText.text = "Level 1 complete press 'ENTER' to go to level 2!";
                if ((Input.GetKey("return")))
                {
                    
                    count = 0;
                    transform.position = new Vector2(50.0f, -50.0f);
                    level = 2;
                    winText.text = "";
                }
            }
        }
        if (level == 2)
        {
            countText.text = "Score: " + count.ToString() + "/8";
            if (count == 8)
            {
                rd2d.velocity = Vector2.zero;
                winText.text = "You have won the game!\nPress 'R' to play again\nPress 'ESCAPE' to quit\nCreated by Randall Forehand";

            }
        }

    }
    
    

    //Pickup and enemy code
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
        }
        else if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            lifeText.text = "Lives: " + life.ToString() + "/3";
 
            
        }
    }
}
