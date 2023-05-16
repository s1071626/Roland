using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainArm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<Monster01AI>().subHP(20);
        }
    }
}
