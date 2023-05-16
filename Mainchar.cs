using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveLoad;

public class Mainchar : MonoBehaviour
{
    public Transform playerTransform;
    Rigidbody playerRigidbody;
    Animator AnimControl;
    [SerializeField] int MaxHP;
    [SerializeField] int MaxMP;
    [SerializeField] Slider HPvalue;
    [SerializeField] Slider MPvalue;
    [SerializeField] Slider XPvalue;
    public SaveLoadUtillity LoadState;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
        AnimControl = GetComponent<Animator>();
        LoadState = GameObject.Find("GameObject").GetComponent<SaveLoadUtillity>();
        if (LoadState.is_Load)
        {
            NowHP = PlayerPrefs.GetInt("PlayerHP");
            LoadState.is_Load = false;
            playerTransform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
            playerTransform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("PlayerRotX"), PlayerPrefs.GetFloat("PlayerRotY"), PlayerPrefs.GetFloat("PlayerRotZ"));
        }
        else
        {
            NowHP = MaxHP;
        }
        HPvalue.maxValue = MaxHP;
        MPvalue.maxValue = MaxMP;
        XPvalue.maxValue = MaxEXP;
        HPvalue.value = NowHP;
        MPvalue.value = MaxMP;
        XPvalue.value = EXP;
    }
    public int NowHP;
    public int LV = 1;
    public float    MaxEXP = 100;
    public float EXP = 0;
    [SerializeField] float Jump_Power = 1.5f;
    [SerializeField] float m_speed = 6f;
    bool JumpCollider = true;
    public bool Move = true;
    public bool InMsg = false;
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCollider && Move && InMsg == false) {
            playerRigidbody.AddForce(new Vector3(0f,100f,0f)*Jump_Power);
            AnimControl.SetBool("Jump", true);
            JumpCollider = false;
        }
        else{
            AnimControl.SetBool("Jump",false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HumanPlane") {
            JumpCollider = true;
        }
    }
    void LVup() {
        if (XPvalue.value >= MaxEXP) {
            LV = LV + 1;
            EXP = 0;
            XPvalue.value = EXP;
            MaxEXP = MaxEXP * 1.2f;
            XPvalue.maxValue = MaxEXP;
            
        }
    }
    public void addEXP() {
        EXP = EXP + 50;
        XPvalue.value = EXP;
        Debug.Log(EXP);
    }
    public int GetLV() {
        return LV;
    }
    public int GetHP() {
        return NowHP;
    }
    void MainCharTranslate() {
        if (Move && InMsg == false) {
            if (Input.GetKey(KeyCode.A)) {
                AnimControl.SetBool("Lwalk", true);
                this.transform.Translate(Vector3.right * -m_speed * Time.deltaTime);
            }
            else
            {
                AnimControl.SetBool("Lwalk", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                AnimControl.SetBool("Rwalk", true);
                this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
            }
            else
            {
                AnimControl.SetBool("Rwalk", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                AnimControl.SetBool("forward", true);
                this.transform.Translate(Vector3.forward * m_speed * 1.5f * Time.deltaTime);
            }
            else {
                AnimControl.SetBool("forward", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                AnimControl.SetBool("back", true);
                this.transform.Translate(Vector3.forward * -m_speed / 2 * Time.deltaTime);
            }
            else {
                AnimControl.SetBool("back", false);
            }
        }
    }
    void charScreenfollw() {
        float rotationX = Input.GetAxis("Mouse X");
        transform.Rotate(0 , rotationX * 1.5f, 0);
    }
    int AttackStep = 0;
    void Attack() {
        if (Input.GetMouseButtonDown(0))//普攻
        {
            AnimControl.SetTrigger("GenerallyAttack");
            AttackStep++;
        }
        else {
            if (AttackStep > 0 && AttackStep < 3)
            {
                Invoke("Attack_ReTime",3f);
            }
            else if (AttackStep == 3)
                Attack_ReTime();
        }
        if (Input.GetMouseButtonDown(1)) {//衝刺攻擊
            AnimControl.SetTrigger("SkillA");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))//速發大量傷害攻擊
        {
            AnimControl.SetTrigger("SkillE");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))//暈眩破防攻擊
        {
            AnimControl.SetTrigger("DizzyAttack");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))//大絕
        {
            AnimControl.SetTrigger("7combo");
        }
    }
    private void Attack_ReTime() {//攻擊中回到閒置狀態
        AnimControl.SetTrigger("BackIdle");
        AttackStep = 0;
    }
    void MoveJudge() {//判斷是否在動畫中，而限制不能移動
        if (AnimControl.GetCurrentAnimatorStateInfo(0).IsName("Attack_3Combo_1_Inplace") || AnimControl.GetCurrentAnimatorStateInfo(0).IsName("Attack_3Combo_2_Inplace") || AnimControl.GetCurrentAnimatorStateInfo(0).IsName("Attack_3Combo_3_Inplace"))
        {
            Move = false;
        }
        else {
            Move = true;
        }
    }
    public void subHP(int value) {//扣寫
        NowHP = NowHP - value;
        HPvalue.value = NowHP;
    }
    void Update()
    {
        Jump();
        MainCharTranslate();
        charScreenfollw();
        LVup();
        Attack();
        MoveJudge();
    }
}
