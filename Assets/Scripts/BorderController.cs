using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if going off the right side put back on the left side
       if(transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
       //if going off the left side put back on right side
       else if(transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
       //if going off the top put back on the bottom
       else if(transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        }
       //if going off the bottom put back on the top
       else if(transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
    }
}
