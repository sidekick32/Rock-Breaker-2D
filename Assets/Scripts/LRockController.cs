using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRockController : MonoBehaviour
{
    public GameObject Srock;
    public GameObject Explosion;
    private AudioSource Sound;
    Rigidbody2D LRrb2d;
    //Start is called before the first frame update
    void Start()
    {
        LRrb2d = GetComponent<Rigidbody2D>();
        LRrb2d.AddForce(transform.up * Random.Range(-50.0f, 150.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            GameController.instance.points += 20;
            GameController.instance.ShipPoints += 20;
            GameController.instance.UpdatePoints = true;

            //instantiate small rocks
            Instantiate(Srock, new Vector3(transform.position.x - .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(Srock, new Vector3(transform.position.x + .5f, transform.position.y + 0f, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(Srock, new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 0));

            GameController.instance.LrocksRemaining -= 1;
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            GameController.instance.points += 20;
            GameController.instance.ShipPoints += 20;
            GameController.instance.ExtraLifeCounter += 20;
            GameController.instance.UpdatePoints = true;

            //instantiate small rocks
            Instantiate(Srock, new Vector3(transform.position.x - .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(Srock, new Vector3(transform.position.x + .5f, transform.position.y + 0f, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(Srock, new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 0));

            GameController.instance.LrocksRemaining -= 1;
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
