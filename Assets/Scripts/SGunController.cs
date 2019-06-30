using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGunController : MonoBehaviour
{
    private bool CanDrop = true;
    public GameObject Bomb;
    private AudioSource Sound;
    
    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        Sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanDrop)
        {
            StartCoroutine("DropBomb");
            CanDrop = false;

        }
    }

    public IEnumerator DropBomb()
    {
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(Bomb, transform.position, transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }


    }
}
