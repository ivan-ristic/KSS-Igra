using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    // World class is using Singleton pattern.
    public static World Instance;

    void Awake()
    {
        Instance = this;
    }

    public int currentHealth = 5;
    private int maxHealth = 5;

    // Boolean value which decides when is game over.
    public bool isPlayerDead;
    // Game object prefab representing our projectile.
    public GameObject projektil;
    // UI number of points.
    public Text poeni;
    // UI game over message.
    public Text gameOver;

    public Image healthUI;
    public Sprite healthUI5;
    public Sprite healthUI4;
    public Sprite healthUI3;
    public Sprite healthUI2;
    public Sprite healthUI1;
    public Sprite healthUI0;

    // Game score counter.
    private int counter = 0;
    // Game projectile spawn speed;
    float increase = 0.5f;
    // Decides can we fire another projectile or we should wait.
    private bool isWaiting1 = false;
    private bool isWaiting2 = false;

    // Start is called before the first frame update.
    void Start() { }

    // Update is called once per frame.
    void Update()
    {
        if(!isPlayerDead)
        {
            // Spawn projectiles from top and right wall.
            SpawnProjectiles();
            // As counter grows game is becoming harder.
            IncreaseProjectilesPerTime();
        }
        else
        {
            // If player is dead show game over message.
            gameOver.gameObject.SetActive(true);
            gameOver.text = $"Final score: {counter} points.";
        }
    }

    private void SpawnProjectiles()
    {
        // Pattern which we use to delay something, in this case spawning new projectile.
        if (!isWaiting1)
            // Smaller is value we send in faster the prjectiles spawn. 
            StartCoroutine(ExecuteAfterDelay1(2 / increase));
        if (!isWaiting2)
            // We divide from three here to make right wall projectiles spawn slower.
            StartCoroutine(ExecuteAfterDelay2(3 / increase));
    }

    private void IncreaseProjectilesPerTime()
    {
        // Projectiles will spawn faster as game counter number grows.
        if (counter > 5)
        {
            increase = 1f;
        }
        if (counter > 30)
        {
            increase = 1.1f;
        }
        if (counter > 50)
        {
            increase = 1.2f;
        }
        if (counter > 90)
        {
            increase = 1.5f;
        }
        if (counter > 100)
        {
            increase = 2f;
        }
        if (counter > 200)
        {
            increase = 3f;
        }
    }

    private IEnumerator ExecuteAfterDelay1(float seconds)
    {
        // Signal that projectile is fired and game should wait before firing the new projectile.
        isWaiting1 = true;
        yield return new WaitForSeconds(seconds);
        if(!isPlayerDead)
        {
            // Create new projectile on coordinates we measured on game scene.
            Instantiate(projektil, new Vector3(Random.Range(-2.7f, 5), 1.7f), new Quaternion());
            // Game counter for new projectile can start again.
            isWaiting1 = false;
            // Increase the game points counter.
            counter++;
            // And show counter in UI.
            poeni.text = $"{counter} points";
            
        }
    }

    private IEnumerator ExecuteAfterDelay2(float seconds)
    {
        isWaiting2 = true;
        yield return new WaitForSeconds(seconds);
        if (!isPlayerDead)
        {
            isWaiting2 = false;
            // This time we spawn projectiles from right wall, again measured on game scene.
            var proj = Instantiate(projektil, new Vector3(5, Random.Range(-3.2f, 1.5f)), new Quaternion());
            // Add some speed to projectile, toward left side.
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
            // Reduce gracity for this projectile so that it does not fall to the ground too quickly.
            proj.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
            counter++;
            poeni.text = $"{counter} points";
        }
    }

    public void ChangeHealth(int ammount)
    {
        currentHealth += ammount;

        if(currentHealth < 1)
        {
            isPlayerDead = true;
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        switch (currentHealth)
        {
            case 5: healthUI.sprite = healthUI5; break;
            case 4: healthUI.sprite = healthUI4; break;
            case 3: healthUI.sprite = healthUI3; break;
            case 2: healthUI.sprite = healthUI2; break;
            case 1: healthUI.sprite = healthUI1; break;
            case 0: healthUI.sprite = healthUI0; break;
        }
    }
}
