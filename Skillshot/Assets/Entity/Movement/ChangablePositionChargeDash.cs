using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangablePositionChargeDash : Movement
{
    public float chargeSpeed = 0.05f;
    public float maxSpeed = 1f;
    public int mouseButton = 1;
    private Vector2 direction;
    public bool charging = false;
    public float charge = 0.0f;

    void Start()
    {
        direction = new Vector2(0, 0);
    }

    void Update()
    {

        
        if (Input.GetMouseButtonDown(mouseButton) || Input.GetMouseButton(mouseButton)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 distanceBetween = mousePosition - this.transform.position;
            direction = new Vector2(distanceBetween.x, distanceBetween.y);
            charging = true;
        }

        if (Input.GetMouseButtonUp(mouseButton))
        {
            charging = false;
        }
    }

    void FixedUpdate()
    {

        if (charging == false && charge > 0.0f)
        {
            move();
        }
        else if (charging == true)
        {
            charge += chargeSpeed;
        }
    }

    private void move()
    {
        if (charge <= maxSpeed)
        {
            goInDirection(direction, charge);
            charge = 0.0f;
        }
        else
        {
            goInDirection(direction, maxSpeed);
            charge -= maxSpeed;
        }
    }

    private void goInDirection(Vector2 direction, float speed)
    {
        direction.Normalize();
        direction.Scale(new Vector2(speed, speed));
        Vector3 newPosition = getCurrentPosition() + direction;

        setPosition(newPosition);
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

    public override void stopMovement()
    {
        charging = false;
        charge = 0;
        direction = new Vector2();
        this.enabled = false;
    }

    public override void startMovement()
    {
        this.enabled = true;
    }
}
