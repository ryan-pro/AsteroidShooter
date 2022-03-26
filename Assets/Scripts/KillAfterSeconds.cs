using System.Collections;
using UnityEngine;

namespace Shooter
{
    public class KillAfterSeconds : MonoBehaviour
    {
        [SerializeField]
        private bool disableInstead = true;
        [SerializeField]
        private float timeInSeconds = 3f;

        private float remainingTime;

        private void OnEnable() => StartCoroutine(CountDown());

        private IEnumerator CountDown()
        {
            remainingTime = timeInSeconds;

            while(true)
            {
                remainingTime -= Time.deltaTime;

                if(remainingTime <= 0f)
                {
                    if (disableInstead)
                        gameObject.SetActive(false);
                    else
                        Destroy(gameObject);
                }

                yield return null;
            }
        }
    }
}