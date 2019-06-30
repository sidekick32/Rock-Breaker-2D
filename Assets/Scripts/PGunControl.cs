using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGunControl : MonoBehaviour
{
    private AudioSource Sound;
    public GameObject bullet;
    public AudioClip GunSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //is player firing bullet
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            Sound.PlayOneShot(GunSound,0.75f);
        }
    }
}
