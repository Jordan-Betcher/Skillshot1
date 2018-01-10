using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDebug : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.name + " hit: " + collision.transform.name);
    }
}
