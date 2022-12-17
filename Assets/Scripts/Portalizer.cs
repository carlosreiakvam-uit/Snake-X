using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalizer : MonoBehaviour
{
    private float endX;

    private float endY;

    // Start is called before the first frame update
    void Start()
    {
        var camera = GameObject.Find("Main Camera");
        var cameraSize = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        endX = cameraSize.x;
        endY = cameraSize.y;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (pos.x > endX)
        {
            transform.position = new Vector3(-endX, pos.y, 0f);
        }

        if (pos.x < -endX)
        {
            transform.position = new Vector3(endX, pos.y, 0f);
        }

        if (pos.y > endY)
        {
            transform.position = new Vector3(pos.x, -endY, 0f);
        }

        if (pos.y < -endY)
        {
            transform.position = new Vector3(pos.x, endY, 0f);
        }
    }
}