using System;
using System.Collections;
using UnityEngine;

namespace Shooter.UI
{
    public class LevelCompleteScreen : MonoBehaviour
    {
        [SerializeField]
        private GameObject contents;

        private void Awake()
        {
            contents.SetActive(false);
        }

        public IEnumerator PresentScreen(Action toContinue)
        {
            contents.SetActive(true);

            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    toContinue.Invoke();
                    yield break;
                }

                yield return null;
            }
        }
    }
}