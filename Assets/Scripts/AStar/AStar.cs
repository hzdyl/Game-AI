using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private const int mapWith = 6;
    private const int mapHeight = 6;

    private Point[,] map = new Point[mapWith, mapHeight];

    private void Start()
    {
        InitMap();
        Point start = map[1, 2];
        Point end = map[5, 2];
        //开始寻路
        FindPath(start, end);
        ShowPath(start, end);
    }
    /// <summary>
    /// 展示路径
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    private void ShowPath(Point start, Point end)
    {
        Point temp = end;
        while (true)
        {
            //Debug.Log(temp.X + "," + temp.Y);
            Color c = Color.red;
            if (temp == start)
            {
                c = Color.green;
            }
            if (temp == end)
            {
                c = Color.black;
            }
            CreateCube(temp.X, temp.Y, c);
            if (temp.Parent == null)
            {
                break;
            }
            temp = temp.Parent;
        }
        for (int x = 0; x < mapWith; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (map[x, y].IsWall)
                {
                    CreateCube(x, y, Color.grey);
                }
            }
        }
    }
    /// <summary>
    /// 创建立方体
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    private void CreateCube(int x, int y, Color color)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = new Vector3(x, y, 0);
        go.GetComponent<Renderer>().material.color = color;
    }

    void FindPath(Point start, Point end)
    {
        List<Point> openList = new List<Point>();
        List<Point> closeList = new List<Point>();
        openList.Add(start);
        while (openList.Count > 0)
        {
            Point point = FindMinFOfPoint(openList);
            openList.Remove(point);
            closeList.Add(point);
            List<Point> surroundPoints = GetSurroundPoints(point);
            PointsFilter(surroundPoints, closeList);
            foreach (Point surroundPoint in surroundPoints)
            {
                if (openList.IndexOf(surroundPoint) > -1)
                {
                    float nowG = CalcG(surroundPoint, point);
                    if (nowG < surroundPoint.G)
                    {
                        surroundPoint.UpdateParent(point, nowG);
                    }
                }
                else
                {
                    surroundPoint.Parent = point;
                    CalcF(surroundPoint, end);
                    openList.Add(surroundPoint);
                }
            }
            if (openList.IndexOf(end) > -1)//当终点在开启列表里面时候，停止计算
            {
                break;
            }
            
        }
        if (openList.Count==0)
        {
            Debug.Log("无法到达指定位置:" + end.X + "-" + end.Y);

        }
    }

    /// <summary>
    /// 计算当前点的F值
    /// </summary>
    /// <param name="now"></param>
    /// <param name="end"></param>
    private void CalcF(Point now, Point end)
    {
        //F=G+H
        float h = Mathf.Abs(end.X - now.X) + Mathf.Abs(end.Y - now.Y);
        float g = 0;
        if (now.Parent == null)
        {
            g = 0;
        }
        else
        {
            g = Vector2.Distance(new Vector2(now.X, now.Y), new Vector2(now.Parent.X, now.Parent.Y)) + now.Parent.G;
        }
        float f = g + h;
        now.F = f;
        now.G = g;
        now.H = h;
    }

    /// <summary>
    /// 计算G值
    /// </summary>
    /// <param name="now"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    private float CalcG(Point now, Point parent)
    {
        return Vector2.Distance(new Vector2(now.X, now.Y), new Vector2(parent.X, parent.Y)) + parent.G;

    }

    private void PointsFilter(List<Point>src,List<Point> closePoint)
    {
        foreach (Point s in closePoint)
        {
            if (src.IndexOf(s)>-1)
            {
                src.Remove(s);
            }
        }
    }

    List<Point> GetSurroundPoints(Point point)
    {
        Point up = null, down = null, left = null, right = null;
        Point lu = null, ru = null, ld = null, rd = null;

        if (point.Y < mapHeight - 1)
        {
            up = map[point.X, point.Y + 1];
        }
        if (point.Y > 0)
        {
            down = map[point.X, point.Y - 1];
        }
        if (point.X > 0)
        {
            left = map[point.X - 1, point.Y];
        }
        if (point.X < mapWith - 1)
        {
            right = map[point.X + 1, point.Y];
        }
        if (up != null && left != null)
        {
            lu = map[point.X - 1, point.Y + 1];
        }
        if (up != null && right != null)
        {
            ru = map[point.X + 1, point.Y + 1];
        }
        if (down != null && left != null)
        {
            ld = map[point.X - 1, point.Y - 1];
        }
        if (down != null && right != null)
        {
            rd = map[point.X + 1, point.Y - 1];
        }

        List<Point> surroundPoints = new List<Point>();
        if (down != null && down.IsWall == false)
        {
            surroundPoints.Add(down);
        }
        if (up != null && up.IsWall == false)
        {
            surroundPoints.Add(up);
        }
        if (left != null && left.IsWall == false)
        {
            surroundPoints.Add(left);
        }
        if (right != null && right.IsWall == false)
        {
            surroundPoints.Add(right);
        }
        if (lu != null && lu.IsWall == false && left.IsWall == false && up.IsWall == false)
        {
            surroundPoints.Add(lu);
        }
        if (ld != null && ld.IsWall == false && left.IsWall == false && down.IsWall == false)
        {
            surroundPoints.Add(ld);
        }
        if (ru != null && ru.IsWall == false && right.IsWall == false && up.IsWall == false)
        {
            surroundPoints.Add(ru);
        }
        if (rd != null && rd.IsWall == false && right.IsWall == false && down.IsWall == false)
        {
            surroundPoints.Add(rd);
        }
        return surroundPoints;

    }


    Point FindMinFOfPoint(List<Point> openList)
    {
        float f = float.MaxValue;
        Point minFPoint = null;
        foreach (Point p in openList)
        {
            if (p.F < f)
            {
                minFPoint = p;
                f = p.F;
            }
        }
        return minFPoint;
    }



    /// <summary>
    /// 初始化地图
    /// </summary>
    void InitMap()
    {
        for (int x = 0; x < mapWith; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = new Point(x, y);
            }
        }
        map[2, 1].IsWall = true;
        map[2, 2].IsWall = true;
        map[2, 3].IsWall = true;
       
    }


}
