using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTowardMouse : MonoBehaviour
{

    public float speed = 0.05f;
    public int mouseButton = 1;
    private Vector2 goalPosition;
    public bool moving = false;

    void Start()
    {
        goalPosition = this.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton) || Input.GetMouseButton(mouseButton))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            goalPosition = new Vector2(mousePosition.x, mousePosition.y);
            moving = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 currentPosition = getCurrentPosition();
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
        Vector2 currentPosition = getCurrentPosition();
        Vector2 distanceBetween = goalPosition - currentPosition;

        if (distanceBetween.magnitude <= speed)
        {
            setPosition(goalPosition);
        }
        else
        {
            distanceBetween.Normalize();
            distanceBetween.Scale(new Vector2(speed, speed));
            Vector3 newPosition = currentPosition + distanceBetween;

            setPosition(newPosition);
        }
    }

    private Vector2 getCurrentPosition()
    {
        Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        return currentPosition;
    }

    private void setPosition(Vector2 newPosition)
    {
        this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
    }
}
