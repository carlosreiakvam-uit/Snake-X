using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Snake : MonoBehaviour
{
    [FormerlySerializedAs("prefab")] public GameObject body;
    public GameObject head;
    private GameObject scoreText;
    private Component increaseScore;

    private float speed = 25f;
    private const int startSize = 6;

    private Color randColor;

    public int x;
    public int y = 1;
    private int score;

    public string dir = "up";
    public string lastMove = "up";

    private float timeNow;


    private bool isFoodEaten;
    private bool isReset;

    private readonly List<GameObject> tails = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.name = "snake";
        scoreText = GameObject.Find("Score");
        // increaseScore = scoreText.GetComponent<increaseScore>();

        randColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        head = Instantiate(head, new Vector3(0.5f, 0.5f, 0), Quaternion.identity);

        for (int i = 1; i < startSize; i++)
        {
            var bodyPart = Instantiate(body, new Vector3(0.5f, -i + 0.5f, 0), Quaternion.identity);
            bodyPart.GetComponent<SpriteRenderer>().color = randColor;
            tails.Add(bodyPart);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && lastMove != "down")
        {
            y = 1;
            x = 0;
            dir = "up";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && lastMove != "up")
        {
            y = -1;
            x = 0;
            dir = "down";
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && lastMove != "right")
        {
            y = 0;
            x = -1;
            dir = "left";
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && lastMove != "left")
        {
            y = 0;
            x = 1;
            dir = "right";
        }

        if (!(Time.time >= timeNow)) return;
        timeNow += 1 / speed;
        move();
    }


    void move()
    {
        if (isReset)
        {
            while (tails.Count > startSize)
            {
                Destroy(tails[0]);
                tails.RemoveAt(0);
            }

            score = 0;
            scoreText.GetComponent<increaseScore>().increase(score);
            isReset = false;
        }

        var currentHeadPos = head.transform.position;
        var tail = tails.Last();
        var lastTailPos = tail.transform.position;
        head.transform.Translate(new Vector3(x, y, 0)); // move head one step
        tail.transform.position = currentHeadPos; // set tail to where head was

        // update tails list
        tails.Insert(0, tail);
        tails.RemoveAt(tails.Count - 1);
        lastMove = dir;

        if (isFoodEaten)
        {
            var b = Instantiate(body, lastTailPos, Quaternion.identity);
            b.GetComponent<SpriteRenderer>().color = randColor;
            tails.Add(b);
            isFoodEaten = false;
        }
    }

    public void setIsAddNew()
    {
        isFoodEaten = true;
        score += 1;
        scoreText.GetComponent<increaseScore>().increase(score);
    }

    public void reset()
    {
        isReset = true;
    }
}