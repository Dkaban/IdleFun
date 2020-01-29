using UnityEngine;

namespace IdleFun
{
    public class IdleHandler : MonoBehaviour
    {
        #region SINGLETON SETUP
        public static IdleHandler Instance = null;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }
        #endregion

        private void Start()
        {

        }

        public void ButtonTapped()
        {

        }
    }
}
