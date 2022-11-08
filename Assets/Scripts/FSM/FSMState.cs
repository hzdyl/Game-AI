using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum 状态
{
    NULL,
    巡逻,
    追击,
    攻击
}
public enum 转换条件
{
    NULL,
    看到玩家,
    丢失玩家,
    得到玩家
}


public abstract class FSMState
{
    protected 状态 id;
    public 状态 ID { get { return id; } }
    protected Dictionary<转换条件, 状态> map = new Dictionary<转换条件, 状态>();

    protected FSMSystem fsmSystem;
    public FSMState(FSMSystem fsm)
    {
        this.fsmSystem = fsm;
    }

    public void 添加转换条件(转换条件 条件,状态 要转换的状态)
    {
        if (条件== 转换条件.NULL)
        {
            Debug.LogError("不允许添加空条件");return;
        }
        if (要转换的状态 == 状态.NULL)
        {
            Debug.LogError("不允许添加空的状态"); return;
        }
        if (map.ContainsKey(条件))
        {
            Debug.LogError("已经添加了改条件"); return;
        }
        map.Add(条件, 要转换的状态);
    }
    public void 移除转换条件(转换条件 条件)
    {
        if (条件 == 转换条件.NULL)
        {
            Debug.LogError("不允许移除空条件"); return;
        }
        if (map.ContainsKey(条件)==false)
        {
            Debug.LogError("要移除的条件不存在"); return;
        }
        map.Remove(条件);
    }

    public 状态 获得要执行的状态(转换条件 条件)
    {
        if (map.ContainsKey(条件) == false)
        {
            Debug.LogError("当前状态不包含:"+条件+"无法转换"); return 状态.NULL;
        }
        return map[条件];
    }

    public virtual void 在状态开始前需要做的事情()
    {

    }
    public virtual void 在状态结束后需要做的事情()
    {

    }

    public abstract void 状态中需要做的事情(GameObject npc);
    public abstract void 判断是否转换状态(GameObject npc);
    

}
