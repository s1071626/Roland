using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour
{
    SphereCollider msgTrigger;
    Text NPCText;
    [SerializeField]GameObject msgText;
    Mainchar Mainchar;
    void Start()
    {
        Mainchar = GameObject.Find("817test").GetComponent<Mainchar>();
        msgTrigger = GetComponent<SphereCollider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))//當主角進入觸發區域，按E會進入對話
        {
            msgText.SetActive(true);
            Mainchar.InMsg = true;
        }
    }
    void Update()
    {
        
    }
}
