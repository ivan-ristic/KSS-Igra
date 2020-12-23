using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public static World Instance;

    public bool isPlayerDead;
    public GameObject projektil;

    private bool isWaiting1 = false;
    private bool isWaiting2 = false;

    public Text poeni;
    public Text gameOver;
    private int counter = 0;
    float increase = 0.5f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerDead)
        {
            SpawnProjectiles();
            IncreaseProjectilesPerTime();
        }
        else
        {
            gameOver.gameObject.SetActive(true);
            gameOver.text = $"Final score: {counter} points.";
        }
    }

    private void SpawnProjectiles()
    {
        if (!isWaiting1)
            StartCoroutine(ExecuteAfterDelay1(2 / increase));
        if (!isWaiting2)
            StartCoroutine(ExecuteAfterDelay2(3 / increase));
    }

    private void IncreaseProjectilesPerTime()
    {
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
        isWaiting1 = true;
        yield return new WaitForSeconds(seconds);
        if(!isPlayerDead)
        {
            Instantiate(projektil, new Vector3(Random.Range(-2.7f, 5), 1.7f), new Quaternion());
            isWaiting1 = false;
            poeni.text = $"{counter} points";
            counter++;
        }

    }

    private IEnumerator ExecuteAfterDelay2(float seconds)
    {
        isWaiting2 = true;
        yield return new WaitForSeconds(seconds);
        if (!isPlayerDead)
        {
            isWaiting2 = false;
            var proj = Instantiate(projektil, new Vector3(5, Random.Range(-3.2f, 1.5f)), new Quaternion());
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
            proj.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
            poeni.text = $"{counter} points";
            counter++;
        }
    }
}
