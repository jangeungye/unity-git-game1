using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    Vector3 movevec;
    Vector3 doDodgevec;

    Animator anim;
    Rigidbody rigid;

    bool isJump;
    bool isDodge;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
    }
    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        
    }
    void Move()
    {
        movevec = new Vector3(hAxis, 0, vAxis).normalized;
        if (isDodge)
        {
            movevec = doDodgevec;
        }
        transform.position += movevec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //삼항연산자 쉬프트 누르면 느려짐

        anim.SetBool("isRun", movevec != Vector3.zero); //움직일 때
        anim.SetBool("isWalk", wDown);

        
    }
    void Turn()
    {
        transform.LookAt(transform.position + movevec); //LookAt 지정된 벡터를 향해서 회전시켜주는 함수
    }

    void Jump()
    {
        if (jDown && movevec == Vector3.zero && !isJump && !isDodge) //움직이지 않을 때(액션X) 점프 
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse); //Impulse 즉각적인 힘 주기
            anim.SetBool("isJump", true);
            anim.SetTrigger("DoJump");
            isJump = true;
        }
    }
    void Dodge()
    {
        if (jDown && movevec != Vector3.zero && !isJump && !isDodge) //움직이고 있을 때 회피
        {
            doDodgevec = movevec; // 회피할 때 방향벡터로 바꾸기
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.5f); //Invoke로 시간차 함수 호출
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
    
}
