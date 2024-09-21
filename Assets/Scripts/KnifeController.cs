using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    



    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
       
            //GetComponent<Rigidbody>().isKinematic = true;
            //this.transform.parent = collision.transform;
            //this.transform.position = collision.contacts[0].point;
            //GetComponent<BoxCollider>().enabled = false;

    }
}

        
        
