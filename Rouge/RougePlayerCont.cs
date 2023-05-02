using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEditorInternal;
using UnityEngine;

public class RoguePlayerCont : MonoBehaviour
{
    public float jumpPower;
    public int jumpCount;
    public bool isPlatform = false;

    [SerializeField]
    SpriteRenderer SR;
    public Rigidbody2D rb;
    Portal1 pol;

    public bool Hide = false;
    //RougeJump rj;
    public bool isATK = false;
    public bool isSkill2 = false;
    public float Maxspeed = 6;
    public float speed = 0f;
    [SerializeField]
    RogueSkill rs;
    [SerializeField]
    NearyMonster neary;
    [SerializeField]
    DamageBox db;

    public float WindKnifeCol = 0;
    public float Skill1Col = 0;
    void Start()
    {
        pol = GetComponent<Portal1>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(speed < 2) //������ ���۽��ǵ� 2����
            {
                speed = 2;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0); //�����ʹ���
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (speed < 2) //���� ���۽��ǵ� 2����
            {
                speed = 2;
            }
            transform.rotation = Quaternion.Euler(0, 180, 0); //���ʹ���
        }
        if (speed > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //transform �⺻ ������ ���ǵ�
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) //DŰ or AŰ
        {
            if(speed < Maxspeed)
            {
                speed += Time.deltaTime;
            }
        }
        else if(speed > 0) //Ű �� ������ ���ǵ� ������ �پ���
        {
            speed -= 3 * Time.deltaTime;
        }
        // ��Ż
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            pol.PortalExcute();
        }
        //�⺻����
        if (Input.GetKey(KeyCode.J) && db.ATKcurTime <= 0) 
        {
            db.ATK();
            Debug.Log("J");
        }
        //��ų1 ���� + �̼�����
        if (Input.GetKeyDown(KeyCode.U)) //isPlatform ������ Hide ��ũ��Ʈ�� �����־� Ʈ���� �ߵ�
        {
            Hide = true;
            print(rb.velocity);
            rb.gravityScale = 0;
        }
        //��ų2 ������[����]
        if (Input.GetKey(KeyCode.I) && db.skill1curTime <= 0)
        {
            db.Skill1();
            Debug.Log("Skill1");
        }
        //��ų3 ���峪����[����]
        if (Input.GetKey(KeyCode.O) && WindKnifeCol <= 0)
        {
            rs.WindKnife();
        }
        //��ų4 ����[����/����]
        if (Input.GetKeyDown(KeyCode.P))
        {
           neary.Skill4();
        }
        WindKnifeCol -= Time.deltaTime; // O bullet�߻� ��Ÿ�� 
    }
    private void FixedUpdate()
    {

        //jump
        if (Input.GetKeyDown(KeyCode.K) && jumpCount < 2) //KŰ and ����ī��Ʈ < 2
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //���� addForce �⺻��
            jumpCount++; //����ī��Ʈ +1
            //anim.SetBool("isJumping", true);
        }
        
    }
}

