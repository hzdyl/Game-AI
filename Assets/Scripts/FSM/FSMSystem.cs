using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem 
{
    private Dictionary<״̬, FSMState> states = new Dictionary<״̬, FSMState>();

    private ״̬ ��ǰ״̬;
    private FSMState ��ǰ״̬��;

    /// <summary>
    /// ����״̬��Ϣ
    /// </summary>
    public void Update(GameObject npc)
    {
        ��ǰ״̬��.״̬����Ҫ��������(npc);
        ��ǰ״̬��.�ж��Ƿ�ת��״̬(npc);

    }
    public void ���״̬(FSMState Ҫ���״̬)
    {
        if (Ҫ���״̬==null)
        {
            Debug.LogError("FSMState����Ϊ��");return;
        }
        if (��ǰ״̬�� == null)
        {
            ��ǰ״̬�� = Ҫ���״̬;
            ��ǰ״̬ = Ҫ���״̬.ID;
        }
        if (states.ContainsKey(Ҫ���״̬.ID))
        {
            Debug.LogError("״̬" + Ҫ���״̬.ID + "�Ѿ����ڣ��޷������");return;
        }
        states.Add(Ҫ���״̬.ID, Ҫ���״̬);
    }

    public void ɾ��״̬(FSMState Ҫɾ����״̬)
    {
        if (Ҫɾ����״̬==null)
        {
            Debug.LogError("����ɾ����״̬"); return;
        }
        if (states.ContainsKey(Ҫɾ����״̬.ID)==false)
        {
            Debug.LogError("Ҫɾ����״̬��" + Ҫɾ����״̬ + "������"); return;
        }
        states.Remove(Ҫɾ����״̬.ID);
    }

    public void ת�䵱ǰ״̬(ת������ ����)
    {
        if (����==ת������.NULL)
        {
            Debug.Log("�޷�ִ�пյ�ת������");return;
        }
        ״̬ Ҫת����״̬ = ��ǰ״̬��.���Ҫִ�е�״̬(����);
        if (Ҫת����״̬ == ״̬.NULL)
        {
            Debug.Log("��ǰ״̬"+��ǰ״̬+"�޷�ת����"+Ҫת����״̬);return;
        }
        if (states.ContainsKey(Ҫת����״̬) == false)
        {
            Debug.LogError("��ǰ״̬���ڲ�����״̬" + Ҫת����״̬ + "�޷�ת��"); return;
        }
        FSMState ����Ҫת����״̬�� = states[Ҫת����״̬];
        ��ǰ״̬��.��״̬��������Ҫ��������();
        ��ǰ״̬�� = ����Ҫת����״̬��;
        ��ǰ״̬ = ����Ҫת����״̬��.ID;
        ��ǰ״̬��.��״̬��ʼǰ��Ҫ��������();

    }





}
