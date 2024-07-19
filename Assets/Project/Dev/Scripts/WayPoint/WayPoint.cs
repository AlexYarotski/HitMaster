using System;
using System.Collections.Generic;
using Project.Dev.Scripts.Human;
using UnityEngine;

namespace Project.Dev.Scripts.WayPoint
{
    public class WayPoint : MonoBehaviour
    {
        public static event Action Passed = delegate { };

        private readonly List<Enemy> EnemyList = new List<Enemy>();

        [SerializeField] private Transform _finishTransform;

        public Transform FinishTransform => _finishTransform;
        
        public bool IsEmpty => EnemyList.Count <= 0;

        private Player _player;
        
        private void Awake()
        {
            var enemyArray = GetComponentsInChildren<Enemy>();

            foreach (var enemy in enemyArray)
            {
                EnemyList.Add(enemy);
            }
        }

        private void OnEnable()
        {
            foreach (var enemy in EnemyList)
            {
                enemy.Died += Enemy_Died;
            }
        }


        private void OnDisable()
        {
            foreach (var enemy in EnemyList)
            {
                enemy.Died -= Enemy_Died;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_player != null) return;
            
            _player = other.gameObject.GetComponent<Player>();
            
            if (_player != null && CheckEmpty())
            {
                Passed();
            }
        }

        private void Enemy_Died()
        {
            EnemyList.RemoveAt(0);

            if (CheckEmpty())
            {
                Passed();
            }
        }

        private bool CheckEmpty()
        {
            return EnemyList.Count <= 0;
        }
    }
}