using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    private static Portal1 instance; //portal1�� ��ũ��Ʈ�� ���� ������ ���� �ȳ־���⿡ null��
    private void Start()
    {
        //instance = GetComponent<Portal1>();
        if (null == instance) //instance�� null���̸� ����
        {
            instance = this; //instance�� �ڱ��ڽ��� portal1�� �־��� == instance = getcomponet�� ��������
            DontDestroyOnLoad(this.gameObject);  //���̵����ص� �ı����� �ʰ�����
        }
        else
        {
            DestroyObject(this.gameObject); //instance�� null�� �ƴ϶�� �ش� ������Ʈ�� �ı�(��� ���� ������)
        }
    }

    public bool trig = false;
    int i;
    string portalname;
    public void PortalExcute()
    {
        if (portalname == "Portal" && trig == true)
        {
            i++;
            print(i);
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D COL) // col��������
    {
        print(portalname);
        if (COL.gameObject.layer == 6)
        {
            portalname = COL.gameObject.name;
            trig = true;
        }
        print(portalname);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            trig = false;
            portalname = null;
        }
    }
}
