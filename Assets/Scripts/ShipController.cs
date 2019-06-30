using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D Shiprb2d;
    public GameObject Explosion;
    private AudioSource Sound;
    

    // Start is called before the first frame update
    void Start()
    {
       
        Shiprb2d = GetComponent<Rigidbody2D>();
        Shiprb2d.AddForce(transform.right * -50f);
        Sound = GetComponent<AudioSource>();
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }

        Sound.Play();




    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            GameController.instance.points += 100;
            GameController.instance.ExtraLifeCounter += 100;
            GameController.instance.UpdatePoints = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
