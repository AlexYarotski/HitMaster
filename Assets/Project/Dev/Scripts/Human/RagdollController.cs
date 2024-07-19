using UnityEngine;

namespace Project.Dev.Scripts.Human
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private Collider[] _ragdollColliders;
        [SerializeField] private Rigidbody[] _ragdollRigidbodies;
    
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            SetRagdollState(false);
        }

        private void SetRagdollState(bool state)
        {
            foreach (var rb in _ragdollRigidbodies)
            {
                rb.isKinematic = !state;
            }

            foreach (var col in _ragdollColliders)
            {
                col.enabled = state;
            }

            _animator.enabled = !state;
        }

        public void EnableRagdoll()
        {
            SetRagdollState(true);
        }

        public void DisableRagdoll()
        {
            SetRagdollState(false);
        }
    }
}