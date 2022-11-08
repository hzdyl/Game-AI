using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState
{
    private Transform playerTransform;
    public AttackState(FSMSystem fsm) : base(fsm)
    {
        id = 状态.攻击;
        playerTransform = GameObject.Find("Player").transform;
    }

    void Attack(GameObject npc)
    {
        //npc.transform.Rotate(Vector3.up * Time.deltaTime*3);
        npc.transform.Rotate(0,Time.deltaTime*500,0);
    }

    public override void 状态中需要做的事情(GameObject npc)
    {

        Attack(npc);
    }

    public override void 判断是否转换状态(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position,playerTransform.position)>2)
        {
            fsmSystem.转变当前状态(转换条件.看到玩家);
        }
        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 15)
        {
            fsmSystem.转变当前状态(转换条件.丢失玩家);
        }
        
    }

 
}
