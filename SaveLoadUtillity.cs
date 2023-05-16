using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadUtillity : MonoBehaviour
    {
        public bool is_Load = false;
        public Mainchar charData;
        public void SaveUtillity() {
            PlayerPrefs.SetInt("PlayerHP",charData.NowHP);
            PlayerPrefs.SetFloat("PlayerEXP", charData.EXP);
            PlayerPrefs.SetFloat("PlayerEXP", charData.MaxEXP);
            PlayerPrefs.SetFloat("PlayerLV", charData.LV);
            PlayerPrefs.SetFloat("PlayerPosX",charData.playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", charData.playerTransform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", charData.playerTransform.position.z);
            PlayerPrefs.SetFloat("PlayerRotX", charData.playerTransform.rotation.x);
            PlayerPrefs.SetFloat("PlayerRotY", charData.playerTransform.rotation.y);
            PlayerPrefs.SetFloat("PlayerRotZ", charData.playerTransform.rotation.z);
            //Debug.Log("true");
        }
        public void LoadUtillty() 
        {
            is_Load = true;
            //Debug.Log("true");
            //Mainchar.NowHP = PlayerPrefs.GetInt("PlayerHP");
        }
    }
}
