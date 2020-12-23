using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 2;
    public int jumpForce = 2;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!World.Instance.isPlayerDead)
        {
            Move();
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveBy, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpForce); 
        }


    }
}
