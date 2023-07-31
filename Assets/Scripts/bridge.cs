using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();


        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name.Equals("Player"))
        {

            Invoke("DropPlatform",0.2f);
            Destroy(gameObject,2f);
        }
        
    }

    void DropPlatform()
    {
        rb.isKinematic=false;
    }
}
