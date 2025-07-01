using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour, IMover
{
    //raio de visao
    public float viewRadius = 5;
    //angulo de visao
    public float viewAngle = 115;

    //переменные для определения того, что является препятствием и что следует обнаружить соответственно
    public LayerMask obstacleMask, detectionMask;

    //вектор возможных целей в нашем радиусе обзора
    public Collider2D[] targetsInRadius;

    //список возможных видимых целевых позиций
    public List<Transform> visibleTargets = new List<Transform>();

    public void Update()
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        //создает круг с центром в держателе этого скрипта, с радиусом, определенным разработчиком и возвращающим значение
        //сколько коллайдеров, которые входят в этот круг, находятся в слое обнаружения и размещают эти коллайдеры
        // в векторе, переданном в качестве третьего параметра
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position,
            viewRadius,
            detectionMask,
            -Mathf.Infinity,
            Mathf.Infinity);

        //очищает вектор от видимых целей
        visibleTargets.Clear();

        //Debug.Log(targetsInRadius.Length);
        //обходим весь вектор целей в радиусе обзора
        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            //присваивает преобразование объекта в вектор переменной для облегчения манипуляций/сравнения
            Transform target = targetsInRadius[i].transform;

            //расчет для определения вектора направления от владельца этого скрипта к цели
            Vector2 dirTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

            //transform.right всегда указывает на положительную ось X
            //если угол между вектором направления между игроком и целью и положительным вектором 
            //угол обзора делённый на 2
            Vector2 dir = new Vector2();
            dir = transform.right;

            if (Vector2.Angle(dirTarget, dir) < viewAngle / 2)
            {
                //хранит расстояние между держателем этого скрипта и целью
                float distanceTarget = Vector2.Distance(transform.position, target.position);

                //Если мы запускаем луч в направлении цели и на расстоянии от цели и он не сталкивается ни с одним объектом,
                //добавим эту цель в вектор видимых целей
                if (!Physics2D.Raycast(transform.position, dirTarget, distanceTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        // если углы не глобальные, преобразуем их в глобальные
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

    public void StartMove()
    {
       
    }

    public void StopMove()
    {
     
    }

}
