using Project.Dev.Scripts.PoolSystem;
using Project.Dev.Scripts.UI;
using Project.Dev.Scripts.WayPoint;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Dev.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PoolManager _poolManager;
        [SerializeField] private WayPointManager _wayPointManager;
        [SerializeField] private WindowSwitcher _windowSwitcher;
        [SerializeField] private SceneContexts _sceneContexts;
        
        public PoolManager PoolManager => _poolManager;
        public WayPointManager WayPointManager => _wayPointManager;
        public WindowSwitcher WindowSwitcher => _windowSwitcher;
        public SceneContexts SceneContexts => _sceneContexts;

        private void OnEnable()
        {
            _wayPointManager.End += WayPointManager_End;
        }
        
        private void OnDisable()
        {
            _wayPointManager.End -= WayPointManager_End;
        }

        private void Start()
        {
            _windowSwitcher.Show<StartWindow>();
        }

        private void WayPointManager_End()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}