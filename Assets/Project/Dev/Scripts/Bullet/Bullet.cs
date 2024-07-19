using System.Collections;
using Project.Dev.Scripts.Human;
using Project.Dev.Scripts.PoolSystem;
using UnityEngine;

namespace Project.Dev.Scripts.Bullet
{
    public abstract class Bullet : PooledBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _timeToDie;
        [SerializeField] private float _damage;

        public abstract BulletType BulletType { get; }

        private bool _isMoving = false;
        private Vector3 _direction = Vector3.zero;
        private float _weaponDamage;

        private void Update()
        {
            if (_isMoving)
            {
                transform.position += _direction * _speed * Time.deltaTime;
            }
        }

        public void Shoot(Vector3 targetPosition, float damage)
        {
            _weaponDamage = damage;
            _direction = (targetPosition - transform.position).normalized;
            _isMoving = true;

            StartCoroutine(DieTimer());
        }

        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.SetDamage(_damage + _weaponDamage);
            }

            Disable();
        }

        private IEnumerator DieTimer()
        {
            yield return new WaitForSeconds(_timeToDie);
            Disable();
        }

        private void Disable()
        {
            _isMoving = false;
            gameObject.SetActive(false);
        }
    }
}