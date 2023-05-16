using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public GameObject hpUIPrefab;
    public Transform barTransform;

    Image HPSlider;
    Transform UIBer;
    Transform cam;

    private void OnEnable()
    {
        cam = Camera.main.transform;

        foreach (Canvas canvas in FindObjectsOfType<Canvas>()) {
            if (canvas.renderMode == RenderMode.WorldSpace) {
                UIBer = Instantiate(hpUIPrefab,canvas.transform).transform;
                HPSlider = UIBer.GetChild(0).GetComponent<Image>();
            }
        }
    }
    public void UpdateHPBar(int monsterHP,int maxMonsterHP) {
        if (monsterHP <= 0) 
        {
            Destroy(UIBer.gameObject);
        }
        float sliderPercent = (float)monsterHP / maxMonsterHP;
        HPSlider.fillAmount = sliderPercent;
    }
    private void LateUpdate()
    {
        if (UIBer != null) 
        {
            UIBer.position = barTransform.position;
            UIBer.forward = -cam.forward;
        }
    }
}
