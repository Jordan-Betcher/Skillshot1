using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class HitActive : MonoBehaviour
{

    public int ticksPerAttack = 3;
    private int currentTicksLeft = 0;
    private bool activate = false;
    private BoxCollider2D collision;
    private SpriteRenderer sprite;
    public KeyCode key = KeyCode.E;

    private void Start()
    {
        collision = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        disable();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log(key + " pressed");
            activate = true;
        }
    }

    private void FixedUpdate()
    {
        if (activate)
        {
            activate = false;
            enable();
            //Move a little so that the physics engine will check what collides with this
            this.transform.position = new Vector3(this.transform.position.x + 0.001f, this.transform.position.y, this.transform.position.z);
        }
        else if (collision.enabled)
        {
            disable();
            //Reset little movement so that it won't be a problem later
            this.transform.position = new Vector3(this.transform.position.x - 0.001f, this.transform.position.y, this.transform.position.z);
        }

    }

    private void disable()
    {
        collision.enabled = false;
        sprite.enabled = false;
    }

    private void enable()
    {
        collision.enabled = true;
        sprite.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        Debug.Log(this.name + " trigger hit: " + otherCollision.transform.name);
        //otherCollision.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
