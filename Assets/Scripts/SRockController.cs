using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRockController : MonoBehaviour
{
    Rigidbody2D SRock;
    public GameObject Explosion;
    private AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        SRock = GetComponent<Rigidbody2D>();
        SRock.AddForce(transform.up * Random.Range(-50f, 150f));
        Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            GameController.instance.points += 100;
            GameController.instance.ShipPoints += 100;
            GameController.instance.ExtraLifeCounter += 100;
            GameController.instance.UpdatePoints = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            Sound.Play();
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            GameController.instance.points += 100;
            GameController.instance.ShipPoints += 100;
            GameController.instance.ExtraLifeCounter += 100;
            GameController.instance.UpdatePoints = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            Sound.Play();
            Destroy(gameObject);
        }
    }
}
