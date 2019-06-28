using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float speed = 400f;
    // Start is called before the first frame update
    Rigidbody2D bullet2d;
    void Start()
    {
        bullet2d = GetComponent<Rigidbody2D>();
        bullet2d.AddForce(transform.up * speed);
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
