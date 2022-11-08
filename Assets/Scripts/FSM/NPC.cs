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
        patrolState.添加转换条件(转换条件.看到玩家,状态.追击);
        patrolState.添加转换条件(转换条件.得到玩家,状态.攻击);

        FSMState chaseState = new ChaseState(fsm);
        chaseState.添加转换条件(转换条件.丢失玩家, 状态.巡逻);
        chaseState.添加转换条件(转换条件.得到玩家, 状态.攻击);

        FSMState attackState = new AttackState(fsm);
        attackState.添加转换条件(转换条件.看到玩家, 状态.追击);
        attackState.添加转换条件(转换条件.丢失玩家, 状态.巡逻);

        fsm.添加状态(patrolState);
        fsm.添加状态(chaseState);
        fsm.添加状态(attackState);


    }


    // Update is called once per frame
    void Update()
    {
        fsm.Update(npc);
    }
}
