using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItem : MonoBehaviour
{
   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Barrier")
        {
            other.gameObject.SetActive(false);
            PlayerStats.Healt--;
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            collision.gameObject.SetActive(false);
            PlayerStats.Healt--;
        }
    }*/
}
