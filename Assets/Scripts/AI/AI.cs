using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public Transform target;
    public float speed = 3;
    public float turnSpeed = 3;
    public Vector3 velocity = Vector3.forward;
    [Header("������Ӱ����ٶ�")]
    public float m = 1;
    public Vector3 a;

    public Animation flyAnimation;

    [Tooltip("����")]
    [Header("����")]
    public Vector3 resultantForce = Vector3.zero;
    public float checkInterval = 0.2f;//���ü��
    [Header("�����Ƿ������")]
    public Vector3 separationForce = Vector3.zero;
    public List<GameObject> separationNeighbors = new List<GameObject>();
    public float separationDistance = 6;
    public float separationWeight = 1;

    [Header("�����Ƕ��е���")]
    public Vector3 rankForce = Vector3.zero;
    public List<GameObject> rankNeighbors = new List<GameObject>();
    public float rankDistance = 10;
    public float rankWeight = 1;

    [Header("�����Ǿۼ�����")]
    public Vector3 gatherForce = Vector3.zero;
    public List<GameObject> gatherNeighbors = new List<GameObject>();
    public float gatherDistancce = 6;
    public float gatherWeight = 1;

    /// <summary>
    /// �������
    /// </summary>
    /// <returns></returns>
    private void CalcForce()
    {
        resultantForce = Vector3.zero;
        separationForce = Vector3.zero;
        rankForce = Vector3.zero;
        gatherForce = Vector3.zero;
        separationNeighbors.Clear();
        rankNeighbors.Clear();
        gatherNeighbors.Clear();
        //�������
        Collider[] separationTemp = Physics.OverlapSphere(transform.position, separationDistance);
        foreach (Collider c in separationTemp)
        {
            if (c != null && c.gameObject != this.gameObject)
            {
                separationNeighbors.Add(c.gameObject);
            }
        }
        foreach (GameObject s in separationNeighbors)
        {
            separationForce += (s.transform.position - this.transform.position).normalized / (Vector3.Distance(this.transform.position, s.transform.position));
        }
        if (separationNeighbors.Count > 0)
        {
            separationForce *= separationWeight;
            resultantForce += separationForce;
        }
        //������е���
        Collider[] rankTemp = Physics.OverlapSphere(transform.position, rankDistance);
        foreach (Collider c in separationTemp)
        {
            if (c != null && c.gameObject != this.gameObject)
            {
                rankNeighbors.Add(c.gameObject);
            }
        }
        foreach (GameObject r in rankNeighbors)
        {
            rankForce += r.transform.forward;
        }
        if (rankNeighbors.Count > 0)
        {
            rankForce /= rankNeighbors.Count;
            resultantForce += rankForce * rankWeight;
        }
        //����ۺϵ���
        Collider[] gatherTemp = Physics.OverlapSphere(transform.position, gatherDistancce);
        foreach (Collider g in gatherTemp)
        {
            if (g != null && g.gameObject != this.gameObject)
            {
                gatherNeighbors.Add(g.gameObject);
            }
        }
        foreach (GameObject g in gatherNeighbors)
        {
            gatherForce += g.transform.position - transform.position;
        }
        if (gatherNeighbors.Count > 0)
        {
            gatherForce *= gatherWeight;
            resultantForce += gatherForce;
        }

        //��һ���㶨�ķ���Ŀ�����
        Vector3 tarDir = target.position - transform.position;

        resultantForce += tarDir.normalized * 50;



    }

    private void Start()
    {
        target = GameObject.Find("Target").transform;
        flyAnimation = GetComponentInChildren<Animation>();
        Invoke("RandomFlapping", Random.Range(0, 1.5f));

        InvokeRepeating("CalcForce", 0, checkInterval);

    }
    private void Update()
    {
        a = resultantForce / m;
        velocity += a * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * turnSpeed);
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

    }
    /// <summary>
    /// ��������Ӷ����
    /// </summary>
    private void RandomFlapping()
    {
        flyAnimation.Play();
    }


}
