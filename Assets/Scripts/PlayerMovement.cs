using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Player movement speed value.
    public int speed = 2;
    // Player jump force value.
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
        // Game can be restarted by pressing the R button on keyboard.
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Move()
    {
        // Get keyboard horizontal axis which are left/right  keys and A/D keys.
        float x = Input.GetAxisRaw("Horizontal");
        // Set speed as combination of pressed axis and custom speed we specified.
        float moveBy = x * speed;
        // Make game object follow speed and direction we defined.
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveBy, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void Jump()
    {
        // Pressing space button will make character jump.
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            // Apply force toward up direction which will make player jump, rigidbody gravity will make player fall down automatically.
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpForce); 
        }
    }
}
