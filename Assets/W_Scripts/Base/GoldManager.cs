using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        public static int LeveIndex;

        private void Awake()
        {
            LeveIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}