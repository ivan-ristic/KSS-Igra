using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour
{
    public GameObject eksplozija;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var eksplo = Instantiate(eksplozija, gameObject.transform.position, gameObject.transform.rotation);

        if (other.gameObject.name == "Player")
        {
            World.Instance.isPlayerDead = true;
            // End game
        }

        Destroy(gameObject, 1);
        Destroy(eksplo, 2);
    }
}
