using UnityEngine;
using System.Collections;
namespace cowsins {
public class SoundManager :MonoBehaviour
{
    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null; 
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this.gameObject); 
    }

    public void PlaySound(AudioClip clip,float delay, float pitch, bool randomPitch, float spatialBlend)
    {
        StartCoroutine(Play(clip,delay,pitch,randomPitch,spatialBlend)); 
    }

    private IEnumerator Play(AudioClip clip, float delay, float pitch,bool randomPitch, float spatialBlend)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().spatialBlend = spatialBlend;
        float pitchAdded = randomPitch ? Random.Range(-pitch, pitch) : pitch; 
        GetComponent<AudioSource>().pitch = 1 + pitchAdded;
        GetComponent<AudioSource>().PlayOneShot(clip); 
        yield return null; 
    }
}
}