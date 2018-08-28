using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{

    protected BoxCollider2D boxCollider2D;
    protected SpriteRenderer spriteRenderer;
    protected new Rigidbody2D rigidbody2D;

    private Vector2 nextVelocity = new Vector2();

    // Use this for initialization
    protected void Awake()
    {
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void addVelocity(Vector2 velocityToAdd)
    {
        this.nextVelocity += velocityToAdd;
    }
}
