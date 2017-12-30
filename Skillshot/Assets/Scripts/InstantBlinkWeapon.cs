using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantBlinkWeapon : MonoBehaviour, IWeapon
{
    private Vector2 goalPosition;
    public bool moving = false;

    void Start()
    {
        this.goalPosition = new Vector2(this.transform.position.x, this.transform.position.y);
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

    public void EActive()
    {
        Debug.Log("E was pressed");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        goalPosition = new Vector2(mousePosition.x, mousePosition.y);
        moving = true;
    }
}
