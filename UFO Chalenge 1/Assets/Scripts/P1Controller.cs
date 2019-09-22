using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P1Controller : MonoBehaviour
{ 
    public float speed;
public Text countText;
public Text winText;
public Text lifeText;
public Text deathText;



    private Rigidbody2D rd2d;
private int count;
private int life;
private int level;


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
        winText.text = "Player 1 died! Player 2 Wins!\nPress 'R' to play again\n Press 'ESCAPE' to quit\nCreated by Randall Forehand";
    }

        //Controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rd2d.AddForce(movement * speed);

        //Level code
        if (level == 1)
    {
        countText.text = "Score: " + count.ToString() + "/12";
        if (count == 12)
        {
            rd2d.velocity = Vector2.zero;
            count = 0;
            transform.position = new Vector2(50.0f, -50.0f);
            level = 2;
            winText.text = "";
            
        }
    }
    if (level == 2)
    {
        countText.text = "Score: " + count.ToString() + "/8";
        if (count == 8)
        {
            rd2d.velocity = Vector2.zero;
            winText.text = "Player 1 wins!\nPress 'R' to play again\nPress 'ESCAPE' to quit\nCreated by Randall Forehand";

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
