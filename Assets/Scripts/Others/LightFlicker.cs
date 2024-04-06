using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    private Light source;

    private Coroutine flickerCoroutine;

    private void Awake()
    {
        source = GetComponent<Light>();
    }

    private void OnEnable()
    {
        source.enabled = true;
        flickerCoroutine = StartCoroutine(FlickerRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(flickerCoroutine);
        source.enabled = false;
    }

    private System.Collections.IEnumerator FlickerRoutine()
    {
        while (enabled)
        {
            source.enabled = !source.enabled;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }
}
