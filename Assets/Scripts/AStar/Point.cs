using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Point Parent { get; set; }
    public float F { get; set; }//F = G + H��
    public float G { get; set; }//��������A�ƶ���������ָ��������ƶ��ķѣ�����б�����ƶ���
    public float H { get; set; }//��ʾ��ָ���ķ����ƶ����յ�b��Ԥ�ƺķѣ�H�кܶ���㷽�������������趨ֻ�������������ƶ������������ʱ���ÿ���б����
    //�������
    public int X { get; set; }
    public int Y { get; set; }

    //�ϰ����־
    public bool IsWall { get; set; }

    public Point (int x,int y,Point parent = null)
    {
        this.X = x;
        this.Y = y;
        this.Parent = parent;
        this.IsWall = false;
    }

    public void UpdateParent(Point parent,float g)
    {
        this.Parent = parent;
        this.G = g;
        F = G + H;//H���ǲ��䣬���Բ���Ҫ����
    }


}
