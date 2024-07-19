using Project.Dev.Scripts.Setting;
using UnityEngine;

namespace Project.Dev.Scripts
{
    public class SceneContexts : MonoBehaviour
    {
        [field: SerializeField]
        public SceneWindowSetting SceneWindowSetting
        {
            get;
            private set;
        }
    }
}