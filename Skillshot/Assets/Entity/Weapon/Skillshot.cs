using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillshot : Entity
{
    private bool activated = false;
    public float speed = 10;
    public float chargeTimer = 0.5f;
    private float currentTimer;


    protected new void Awake()
    {
        base.Awake();

        currentTimer = chargeTimer;
        this.boxCollider2D.enabled = false;
        this.spriteRenderer.enabled = false;
    }

    protected new void FixedUpdate()
    {
        if(currentTimer > 0)
        {

            currentTimer -= Time.deltaTime;
            Color newColor = this.spriteRenderer.color;

            float percentageCharged = ((chargeTimer - currentTimer) / chargeTimer);

            newColor.a = (1f / 2f) + (percentageCharged / 2f);

            this.spriteRenderer.color = newColor;
        }
        else if (activated && currentTimer <= 0)
        {
            //this.addVelocity(transform.up * speed);
            this.rigidbody2D.velocity = transform.up * speed;
        }
    }

    public void Launch()
    {
        this.boxCollider2D.enabled = true;
        this.spriteRenderer.enabled = true;
        activated = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
