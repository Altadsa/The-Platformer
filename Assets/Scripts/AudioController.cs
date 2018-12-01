using UnityEngine;
using Shamrock;

public class AudioController : MonoBehaviour {

    public AudioSource audioSource;

    [SerializeField]
    FloatVariable audioVolume;

    private void Update()
    {
        audioSource.volume = audioVolume.Value;
    }

}
