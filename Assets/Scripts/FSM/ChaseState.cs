using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private Transform playerTransform;
    public ChaseState(FSMSystem fsm) : base(fsm)
    {
        id = 状态.追击;
        playerTransform = GameObject.Find("Player").transform;

    }

    public override void 判断是否转换状态(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 15)
        {
            fsmSystem.转变当前状态(转换条件.丢失玩家);
        }
        if (Vector3.Distance(npc.transform.position, playerTransform.position) < 1)
        {
            fsmSystem.转变当前状态(转换条件.得到玩家);
        }
    }

    public override void 状态中需要做的事情(GameObject npc)
    {
        npc.transform.LookAt(playerTransform);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
