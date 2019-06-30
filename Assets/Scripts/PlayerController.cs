using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float rotationSpeed = 100.0f;
    Transform ptransform;
    Rigidbody2D rb2d;
    float thrustForce = 3f;
    public Transform gun;
    public GameObject Explosion;
    //public AudioClip Explode;
    private AudioSource Sound;
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        ptransform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //is player turning left
        //take screenshot
        if(Input.GetKey(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot("Gamepic.png");
        }
        if (Input.GetKey(KeyCode.A))
        {
            ptransform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            //ptransform.Rotate(Vector3.forward * rotationSpeed *Time.deltaTime);


        }
        //is player turning right
        if(Input.GetKey(KeyCode.D))
        {
            ptransform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        //is player going forward
        if(Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Bullet")
        {
            
            GameController.instance.PlayerDead = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            if(GameController.instance.lives > 0)
            {
                GameController.instance.lives -= 1;
            }
            GameController.instance.UpDateLives = true;
            StartCoroutine("PlaySoundAndDestroyAfterwards");
            
        }
    }
    private IEnumerator PlaySoundAndDestroyAfterwards()
    {
        Sound.Play();
        while(Sound.isPlaying)
            {
            yield return null;
            }
        Destroy(gameObject);
    }
}
