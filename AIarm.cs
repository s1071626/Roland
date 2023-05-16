using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIarm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Mainchar>().subHP(10);
        }
    }
}
