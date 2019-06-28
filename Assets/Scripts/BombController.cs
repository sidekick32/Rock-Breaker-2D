using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    Rigidbody2D Bomb;
    float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Bomb = GetComponent<Rigidbody2D>();
        Bomb.AddForce(transform.up * speed);
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            if(GameController.instance.lives > 0)
            {
                GameController.instance.lives -= 1;
                GameController.instance.UpDateLives = true;
            }
            
            Destroy(gameObject);
        }
    }
}
