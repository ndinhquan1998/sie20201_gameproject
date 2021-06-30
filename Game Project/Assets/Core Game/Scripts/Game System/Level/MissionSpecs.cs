using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    [CreateAssetMenu(fileName = "Mission", menuName = "Missions/Create Mission")]
    public class MissionSpecs : ScriptableObject
    {

        #region INSPECTOR
        [SerializeField] protected string _name;
        [SerializeField] [Multiline] protected string _description;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected string _levelToCheck;
        [SerializeField] protected Sprite _image;
        #endregion

        #region PROPERTIES
        public string Name => _name;
        public string Description => _description;
        public string SceneName => _sceneName;
        public string LevelToCheck => _levelToCheck;
        public Sprite Image => _image;
        #endregion
    }
}
