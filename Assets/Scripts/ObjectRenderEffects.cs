using System.Collections;
using UnityEngine;

namespace Shooter
{
    public class ObjectRenderEffects : MonoBehaviour
    {
        [SerializeField]
        private Renderer rendererComp;

        [Header("Damage Flash")]
        [SerializeField]
        private float flashTime = 0.2f;
        [SerializeField]
        private int numFlashes = 2;
        [SerializeField]
        private Color flashColor = Color.red;

        private Color defaultColor;
        private Coroutine flashCoroutine;

        private void Awake()
        {
            defaultColor = rendererComp.material.color;
        }

        private void OnDisable()
        {
            rendererComp.material.color = defaultColor;
        }

        public void TriggerDamageFlash()
        {
            if (flashCoroutine != null)
                StopCoroutine(flashCoroutine);

            flashCoroutine = StartCoroutine(DamageFlash());
        }

        public void CancellAll() => StopAllCoroutines();

        #region Coroutines

        private IEnumerator DamageFlash()
        {
            var halfTime = flashTime / 2;

            for (int i = 0; i < numFlashes; i++)
            {
                var elapsed = 0f;
                while (elapsed < halfTime)
                {
                    elapsed += Time.deltaTime;
                    rendererComp.material.color = Color.Lerp(defaultColor, flashColor, elapsed / halfTime);
                    yield return null;
                }

                elapsed = 0f;
                while (elapsed < halfTime)
                {
                    elapsed += Time.deltaTime;
                    rendererComp.material.color = Color.Lerp(flashColor, defaultColor, elapsed / halfTime);
                    yield return null;
                }
            }
        }

        #endregion
    }
}