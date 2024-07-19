using Project.Dev.Scripts.UI;
using UnityEngine;

namespace Project.Dev.Scripts.Setting
{
    [CreateAssetMenu(fileName = "SceneWindowSetting", menuName = "Settings/SceneWindowSetting", order = 0)]
    public class SceneWindowSetting : ScriptableObject
    {
        [SerializeField]
        private Window[] _windows = null;

        public Window[] GetWindows()
        {
            return _windows;
        }
    }
}