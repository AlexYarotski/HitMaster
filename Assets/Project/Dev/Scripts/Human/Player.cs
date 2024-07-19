using Project.Dev.Scripts.UI;
using Project.Dev.Scripts.WayPoint;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Dev.Scripts.Human
{
    public class Player : Human
    {
        private const string CanRun = "CanRun";
    
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private WayPointManager _wayPointManager;
        private Rigidbody _rigidbody;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            TouchController.Touched += TouchController_Touched;
            WayPoint.WayPoint.Passed += WayPoint_Passed;
        }

        private void OnDisable()
        {
            TouchController.Touched -= TouchController_Touched;
            WayPoint.WayPoint.Passed -= WayPoint_Passed;
        }

        private void Start()
        {
            _wayPointManager = GameManager.Instance.WayPointManager;
        
            _navMeshAgent.speed = _speed;
        }

        private void TouchController_Touched(Vector3 targetPosition)
        {
            _weapon.Shoot(targetPosition);
        }
    
        private void WayPoint_Passed()
        {
            SetRun(true);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var wayPoint = other.gameObject.GetComponent<WayPoint.WayPoint>();

            if (wayPoint && !wayPoint.IsEmpty)
            {
                SetRun(false);
            }
        }

        private void SetRun(bool canRun)
        {
            if (canRun)
            {
                _navMeshAgent.isStopped = false;
                _navMeshAgent.updateRotation = true;
        
                _navMeshAgent.SetDestination(_wayPointManager.GetNewWayPointPosition());

                _rigidbody.isKinematic = false;
                _animator.SetBool(CanRun, true);
            }
            else
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.updateRotation = false;
            
                _rigidbody.isKinematic = true;
                _animator.SetBool(CanRun, false);
            }
        }
    }
}