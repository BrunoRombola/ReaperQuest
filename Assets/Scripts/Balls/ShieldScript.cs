using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{   

    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.GetComponentInParent<PlayerControllerPC>().shieldTimer = 3;
        Destroy(this.gameObject);
    }

}
