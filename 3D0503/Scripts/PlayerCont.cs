using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;

    Vector3 movevec;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");

        movevec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += movevec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //삼항연산자 쉬프트 누르면 느려짐

        anim.SetBool("isRun", movevec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + movevec); //LookAt 지정된 벡터를 향해서 회전시켜주는 함수
    }
}
