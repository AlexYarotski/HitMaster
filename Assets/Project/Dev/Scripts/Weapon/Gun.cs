using Project.Dev.Scripts.Bullet;
using Project.Dev.Scripts.PoolSystem;
using UnityEngine;

namespace Project.Dev.Scripts.Weapon
{
    public class Gun : Weapon
    {
        public override WeaponType WeaponType => WeaponType.Gun;

        public override void Shoot(Vector3 position)
        {
            base.Shoot(position);
            
            var bullet = _poolManager.GetObject<BulletGun>(PooledType.BulletGun, _bulletSpawnPosition.position);
            bullet.Shoot(position, _damage);

            StartCoroutine(Reloading());
        }
    }
}