using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    [SerializeField]GameObject ESC;
    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC.activeSelf == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                ESC.SetActive(true);
            }
            else {
                ESC.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}
