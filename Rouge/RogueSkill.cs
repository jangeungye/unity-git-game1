using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueSkill : MonoBehaviour
{
    [SerializeField]
    RogueShoot ros;
    [SerializeField]
    RoguePlayerCont rpc;
    public int WindKnifeNum = -1;
 
    public void WindKnife()
    {
        if (WindKnifeNum > 0) //���峪���� 0���� Ŭ ��   
        {
            WindKnifeNum--;

            ros.WindKnifeSkill();
            rpc.WindKnifeCol = 0.5f;
            
        }
        else if(WindKnifeNum == 0) //���峪���� 0�� �� 10�� ��Ÿ�� 
        {
            rpc.WindKnifeCol = 10f;
            WindKnifeNum--;
        }
        else // ���峪���� 0���� ���� �� (������)
        {
            WindKnifeNum = 5;
        }
    }
}
