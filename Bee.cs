using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{

    public Vector2 force;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        force.x = Random.Range(-0.25f, 0.25f);
        force.y = Random.Range(-0.25f, 0.25f);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
