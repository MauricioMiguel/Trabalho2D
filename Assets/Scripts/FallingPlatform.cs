using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime = 0.5f; 
    public int destroyLayer = 9; 

    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    private bool hasFallen = false; 

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasFallen)
        {
            Invoke("Fall", fallingTime);
            hasFallen = true;
        }
    }

    void Fall()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == destroyLayer)
        {
            Destroy(gameObject);
        }
    }
}
