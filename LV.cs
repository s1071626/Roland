using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LV : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<Mainchar>().GetLV().ToString();
    }
}
