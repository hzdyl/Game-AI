using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private FSMSystem fsm;
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
    }


    public void InitFSM()
    {
        fsm = new FSMSystem();

        FSMState patrolState = new PatrolState(fsm);
        patrolState.���ת������(ת������.�������,״̬.׷��);
        patrolState.���ת������(ת������.�õ����,״̬.����);

        FSMState chaseState = new ChaseState(fsm);
        chaseState.���ת������(ת������.��ʧ���, ״̬.Ѳ��);
        chaseState.���ת������(ת������.�õ����, ״̬.����);

        FSMState attackState = new AttackState(fsm);
        attackState.���ת������(ת������.�������, ״̬.׷��);
        attackState.���ת������(ת������.��ʧ���, ״̬.Ѳ��);

        fsm.���״̬(patrolState);
        fsm.���״̬(chaseState);
        fsm.���״̬(attackState);


    }


    // Update is called once per frame
    void Update()
    {
        fsm.Update(npc);
    }
}
