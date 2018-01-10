using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDebug : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.name + " collided with: " + collision.transform.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.name + " trigger hit: " + collision.transform.name);
    }
}
