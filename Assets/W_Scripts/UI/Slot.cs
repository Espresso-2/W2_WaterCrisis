using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace W_Scripts.UI
{
    public class Slot : MonoBehaviour
    {
        [NonSerialized]
        public SlotState CurrentState=SlotState.UnLock;
        private GameObject Has;
        private GameObject Lock;

        private void Start()
        {
            Has = transform.GetChild(0).gameObject;
            Lock = transform.GetChild(1).gameObject;
        }

        private void Update()
        {
          
            switch (CurrentState)
            {
                case SlotState.Has:
                    Has.gameObject.SetActive(true);
                    Lock.gameObject.SetActive(false);
                    break;
                case SlotState.Lock:
                    Has.gameObject.SetActive(false);
                    Lock.gameObject.SetActive(true);
                  //  Lock.gameObject.AddComponent<Button>().onClick.AddListener(() => { });
                    break;
                case SlotState.UnLock:
                    Has.gameObject.SetActive(false);
                    Lock.gameObject.SetActive(false);
                    break;
            }
        }
    }
}