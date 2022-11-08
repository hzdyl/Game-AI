using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private List<Transform> patrolPositions = new List<Transform>();
    private int index = 0;
    private Transform playerTransform;

    public PatrolState(FSMSystem fsm) : base(fsm)
    {
        id = 状态.巡逻;
        playerTransform = GameObject.Find("Player").transform;
        Transform pathTransform = GameObject.Find("路径").transform;
        Transform[] children = pathTransform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child != pathTransform)
            {
                patrolPositions.Add(child);
            }
            
        }
    }

   


    public override void 判断是否转换状态(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position,playerTransform.position)<8)
        {
            fsmSystem.转变当前状态(转换条件.看到玩家);
        }
    }

    public override void 状态中需要做的事情(GameObject npc)
    {
        npc.transform.LookAt(patrolPositions[index]);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * 5);
        if (Vector3.Distance(npc.transform.position, patrolPositions[index].position)<1)
        {
            index++;
            index %= patrolPositions.Count;
        }
        
    }
}
