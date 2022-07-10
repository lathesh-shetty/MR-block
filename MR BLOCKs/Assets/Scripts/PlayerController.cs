using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2D;

    public GameObject gameWonPanel;

    public GameObject gameLostPanel;

    public float speed = 5f;

    private bool isGameOver = false;
    
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        if(isGameOver==true)
        {
            return;
            speed=0;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

   
    private void FixedUpdate()
    {
         if(isGameOver==true)
        {
            return;
            speed=0;
        }
        
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish")
        {
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }
        else if(other.tag == "Enemy")
        {
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }
        
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
