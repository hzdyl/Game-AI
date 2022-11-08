using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private Transform playerTransform;
    public ChaseState(FSMSystem fsm) : base(fsm)
    {
        id = ״̬.׷��;
        playerTransform = GameObject.Find("Player").transform;

    }

    public override void �ж��Ƿ�ת��״̬(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 15)
        {
            fsmSystem.ת�䵱ǰ״̬(ת������.��ʧ���);
        }
        if (Vector3.Distance(npc.transform.position, playerTransform.position) < 1)
        {
            fsmSystem.ת�䵱ǰ״̬(ת������.�õ����);
        }
    }

    public override void ״̬����Ҫ��������(GameObject npc)
    {
        npc.transform.LookAt(playerTransform);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
