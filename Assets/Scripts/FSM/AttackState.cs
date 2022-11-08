using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState
{
    private Transform playerTransform;
    public AttackState(FSMSystem fsm) : base(fsm)
    {
        id = ״̬.����;
        playerTransform = GameObject.Find("Player").transform;
    }

    void Attack(GameObject npc)
    {
        //npc.transform.Rotate(Vector3.up * Time.deltaTime*3);
        npc.transform.Rotate(0,Time.deltaTime*500,0);
    }

    public override void ״̬����Ҫ��������(GameObject npc)
    {

        Attack(npc);
    }

    public override void �ж��Ƿ�ת��״̬(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position,playerTransform.position)>2)
        {
            fsmSystem.ת�䵱ǰ״̬(ת������.�������);
        }
        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 15)
        {
            fsmSystem.ת�䵱ǰ״̬(ת������.��ʧ���);
        }
        
    }

 
}
