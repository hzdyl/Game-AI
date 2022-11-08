using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem 
{
    private Dictionary<状态, FSMState> states = new Dictionary<状态, FSMState>();

    private 状态 当前状态;
    private FSMState 当前状态机;

    /// <summary>
    /// 更新状态信息
    /// </summary>
    public void Update(GameObject npc)
    {
        当前状态机.状态中需要做的事情(npc);
        当前状态机.判断是否转换状态(npc);

    }
    public void 添加状态(FSMState 要添加状态)
    {
        if (要添加状态==null)
        {
            Debug.LogError("FSMState不能为空");return;
        }
        if (当前状态机 == null)
        {
            当前状态机 = 要添加状态;
            当前状态 = 要添加状态.ID;
        }
        if (states.ContainsKey(要添加状态.ID))
        {
            Debug.LogError("状态" + 要添加状态.ID + "已经存在，无法再添加");return;
        }
        states.Add(要添加状态.ID, 要添加状态);
    }

    public void 删除状态(FSMState 要删除的状态)
    {
        if (要删除的状态==null)
        {
            Debug.LogError("不能删除空状态"); return;
        }
        if (states.ContainsKey(要删除的状态.ID)==false)
        {
            Debug.LogError("要删除的状态：" + 要删除的状态 + "不存在"); return;
        }
        states.Remove(要删除的状态.ID);
    }

    public void 转变当前状态(转换条件 条件)
    {
        if (条件==转换条件.NULL)
        {
            Debug.Log("无法执行空的转换条件");return;
        }
        状态 要转换的状态 = 当前状态机.获得要执行的状态(条件);
        if (要转换的状态 == 状态.NULL)
        {
            Debug.Log("当前状态"+当前状态+"无法转换到"+要转换的状态);return;
        }
        if (states.ContainsKey(要转换的状态) == false)
        {
            Debug.LogError("当前状态机内不存在状态" + 要转换的状态 + "无法转换"); return;
        }
        FSMState 即将要转换的状态机 = states[要转换的状态];
        当前状态机.在状态结束后需要做的事情();
        当前状态机 = 即将要转换的状态机;
        当前状态 = 即将要转换的状态机.ID;
        当前状态机.在状态开始前需要做的事情();

    }





}
