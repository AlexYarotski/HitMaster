using UnityEngine;

namespace Project.Dev.Scripts.Human
{
    public abstract class Human : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        [SerializeField] protected Animator _animator;
        [SerializeField] protected Weapon.Weapon _weapon;
        
        public virtual void SetDamage(float damage)
        {
            
        }
       
        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}