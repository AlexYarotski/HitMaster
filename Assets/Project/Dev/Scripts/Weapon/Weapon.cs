using System.Collections;
using Project.Dev.Scripts.PoolSystem;
using UnityEngine;

namespace Project.Dev.Scripts.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float _timeToReloading;
        [SerializeField] protected float _damage;
        [SerializeField] protected Transform _bulletSpawnPosition;

        protected PoolManager _poolManager;
        
        private bool _canShoot;

        public abstract WeaponType WeaponType { get; }

        private void Awake()
        {
            _poolManager = GameManager.Instance.PoolManager;
            _canShoot = true;
        }

        public virtual void Shoot(Vector3 position)
        {
            if (!_canShoot) return;

            _canShoot = false;
        }

        protected IEnumerator Reloading()
        {
            yield return new WaitForSeconds(_timeToReloading);
            
            _canShoot = true;
        }
    }
}