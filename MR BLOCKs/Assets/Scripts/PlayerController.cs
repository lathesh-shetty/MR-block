using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2D;

    public GameObject gameWonPanel;

    public float speed;

    private bool isGameWon = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameWon==true)
        {
            return;
            speed=0;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            rb2D.velocity = new Vector2(speed, 0f);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            rb2D.velocity = new Vector2(-speed, 0f);
        }

        else if(Input.GetAxis("Vertical") > 0)
        {
            rb2D.velocity = new Vector2(0f, speed);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            rb2D.velocity = new Vector2(0f, -speed); 
        }
        else if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rb2D.velocity = new Vector2(0f, 0f); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish")
        {
            gameWonPanel.SetActive(true);
            isGameWon = true;
        }
        
    }
}
