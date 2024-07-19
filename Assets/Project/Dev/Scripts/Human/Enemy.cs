using System;
using UnityEngine;

namespace Project.Dev.Scripts.Human
{
    public class Enemy : Human
    {
        public event Action Died = delegate { };

        [SerializeField] private RagdollController _ragdollController;     
        [SerializeField] private Health _health;
        
        private Collider _collider;
        
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            
            _ragdollController.DisableRagdoll();
        }

        public override void SetDamage(float damage)
        {
            base.SetDamage(damage);
            
            _health.SetDamage(damage);

            if (_health.Count <= 0)
            {
                _health.Die();
                
                Die();
            }
        }

        protected override void Die()
        {
            _collider.enabled = false;
            
            _ragdollController.EnableRagdoll();
            
            Died();
        }
    }
}