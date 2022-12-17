using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SnakeCollider : MonoBehaviour
{
    private GameObject snake;
    private float endX;
    private float endY;


    // Start is called before the first frame update
    void Start()
    {
        snake = GameObject.Find("snake");
        var camera = GameObject.Find("Main Camera");
        var cameraSize = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        endX = cameraSize.x;
        endY = cameraSize.y;
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            respawnFood(col);

            snake.GetComponent<Snake>().setIsAddNew();
        }

        if (col.CompareTag("Player"))
        {
            snake.GetComponent<Snake>().reset();
        }
    }

    private void respawnFood(Collider2D col)
    {
        var padding = 5;
        var x = (float)Math.Round(Random.Range(-endX + padding, endX - padding)) + 0.5f;
        var y = (float)Math.Round(Random.Range(-endY + padding, endY - padding));
        Debug.Log(x);
        Debug.Log(y);
        col.transform.position = new Vector3(x, y, 0);
    }
}