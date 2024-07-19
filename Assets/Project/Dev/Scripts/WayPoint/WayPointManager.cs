using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Dev.Scripts.WayPoint
{
    public class WayPointManager : MonoBehaviour
    {
        public event Action End = delegate { };

        private readonly List<WayPoint> WayPointList = new List<WayPoint>();

        private int _numberWayPoint = 0;
        
        private void Awake()
        {
            var wayPoints = GetComponentsInChildren<WayPoint>();

            foreach (var wayPoint in wayPoints)
            {
                WayPointList.Add(wayPoint);
            }
        }

        public Vector3 GetNewWayPointPosition()
        {
            if (!WayPointList[_numberWayPoint].IsEmpty)
            {
                return WayPointList[_numberWayPoint].FinishTransform.position;
            }
            
            _numberWayPoint++;
            
            if (_numberWayPoint >= WayPointList.Count)
            {
                End();
                
                return WayPointList[^1].FinishTransform.position;
            }

            return WayPointList[_numberWayPoint].FinishTransform.position;
        }
    }
}