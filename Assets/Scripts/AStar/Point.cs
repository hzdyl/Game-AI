using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Point Parent { get; set; }
    public float F { get; set; }//F = G + H；
    public float G { get; set; }//代表从起点A移动到网格上指定方格的移动耗费（可沿斜方向移动）
    public float H { get; set; }//表示从指定的方格移动到终点b的预计耗费（H有很多计算方法，这里我们设定只可以上下左右移动，即计算这个时候不用考虑斜方向）
    //点的坐标
    public int X { get; set; }
    public int Y { get; set; }

    //障碍物标志
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
        F = G + H;//H总是不变，所以不需要更改
    }


}
