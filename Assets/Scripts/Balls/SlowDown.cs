using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.gameObject.GetComponentInParent<PlayerControllerPC>().shieldOn)
        {
            other.GetComponentInParent<PlayerControllerPC>().speedDownTimer = 3; 
            Destroy(this.gameObject);

        }

    }
}
