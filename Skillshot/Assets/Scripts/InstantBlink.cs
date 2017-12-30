using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantBlink : MonoBehaviour
{
    public int mouseButton = 1;
    private Vector2 goalPosition;
    public bool moving = false;

    void Start()
    {
        this.goalPosition = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            goalPosition = new Vector2(mousePosition.x, mousePosition.y);
            moving = true;
        }

    }

    void FixedUpdate()
    {
        Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);

        if (goalPosition.Equals(currentPosition))
        {
            moving = false;
        }
        else if (moving == true)
        {
            move();
        }

    }

    private void move()
    {
        setPosition(goalPosition);
    }

    void setPosition(Vector2 newPosition)
    {
        this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
    }
}
