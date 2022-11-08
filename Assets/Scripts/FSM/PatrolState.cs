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
        id = ״̬.Ѳ��;
        playerTransform = GameObject.Find("Player").transform;
        Transform pathTransform = GameObject.Find("·��").transform;
        Transform[] children = pathTransform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child != pathTransform)
            {
                patrolPositions.Add(child);
            }
            
        }
    }

   


    public override void �ж��Ƿ�ת��״̬(GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position,playerTransform.position)<8)
        {
            fsmSystem.ת�䵱ǰ״̬(ת������.�������);
        }
    }

    public override void ״̬����Ҫ��������(GameObject npc)
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
