using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Ebac.Core.Singleton;

public class EfectsManager : Singleton<EfectsManager>
{
    public PostProcessVolume processVolume;
    [SerializeField] private Vignette _vignette;

    public float duration = 1f;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlasColorVignette());
    }

    IEnumerator FlasColorVignette()
    {
        Vignette temp;

        if (processVolume.profile.TryGetSettings<Vignette>(out temp))
        {
            _vignette = temp;
        }

        ColorParameter c = new ColorParameter();

        float time = 0;
        while (time < duration)
        {
            c.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }

        time = 0;
        while (time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }
    }

}
