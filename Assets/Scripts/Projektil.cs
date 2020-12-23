using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour
{
    public GameObject eksplozija;
    // Start is called before the first frame update.
    void Start() { }

    // Update is called once per frame.
    void Update() { }

    // Triggers once our projectile collider hit any other collider present on the game scene.
    void OnCollisionEnter2D(Collision2D other)
    {
        // Create explossion effect (gameObject) when projectile hit collider.
        var eksplozijaGameObject = Instantiate(eksplozija, gameObject.transform.position, gameObject.transform.rotation);

        // When projectile hit the player make player dead and finish the game.
        if (other.gameObject.name == "Player")
        {
            World.Instance.ChangeHealth(-1);
        }

        // Cleanup, remove projectile game object after 1 second of delay.
        Destroy(gameObject, 1);
        // Cleanup, remove explossion game object after 2 seconds of delay.
        Destroy(eksplozijaGameObject, 2);
    }
}
