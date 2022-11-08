using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ״̬
{
    NULL,
    Ѳ��,
    ׷��,
    ����
}
public enum ת������
{
    NULL,
    �������,
    ��ʧ���,
    �õ����
}


public abstract class FSMState
{
    protected ״̬ id;
    public ״̬ ID { get { return id; } }
    protected Dictionary<ת������, ״̬> map = new Dictionary<ת������, ״̬>();

    protected FSMSystem fsmSystem;
    public FSMState(FSMSystem fsm)
    {
        this.fsmSystem = fsm;
    }

    public void ���ת������(ת������ ����,״̬ Ҫת����״̬)
    {
        if (����== ת������.NULL)
        {
            Debug.LogError("��������ӿ�����");return;
        }
        if (Ҫת����״̬ == ״̬.NULL)
        {
            Debug.LogError("��������ӿյ�״̬"); return;
        }
        if (map.ContainsKey(����))
        {
            Debug.LogError("�Ѿ�����˸�����"); return;
        }
        map.Add(����, Ҫת����״̬);
    }
    public void �Ƴ�ת������(ת������ ����)
    {
        if (���� == ת������.NULL)
        {
            Debug.LogError("�������Ƴ�������"); return;
        }
        if (map.ContainsKey(����)==false)
        {
            Debug.LogError("Ҫ�Ƴ�������������"); return;
        }
        map.Remove(����);
    }

    public ״̬ ���Ҫִ�е�״̬(ת������ ����)
    {
        if (map.ContainsKey(����) == false)
        {
            Debug.LogError("��ǰ״̬������:"+����+"�޷�ת��"); return ״̬.NULL;
        }
        return map[����];
    }

    public virtual void ��״̬��ʼǰ��Ҫ��������()
    {

    }
    public virtual void ��״̬��������Ҫ��������()
    {

    }

    public abstract void ״̬����Ҫ��������(GameObject npc);
    public abstract void �ж��Ƿ�ת��״̬(GameObject npc);
    

}
