using Unity.VisualScripting;
using UnityEngine;

public class LoadDeathUI : MonoBehaviour
{
    //References
    AudioSource audioSource;
    AudioSource[] audioSourceComponents;
    [Header("DeathEffects")]
    [SerializeField] float musicPitchOnDeath;

    private void Awake()
    {
        //Get the audio source component with the game music
        audioSourceComponents = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource auSou in audioSourceComponents)
        {
            if (auSou.TryGetComponent<AudioPlayer>(out AudioPlayer audioPlayer ) != false)
            {
                audioSource = auSou;
                Debug.Log(auSou);
                Debug.Log(audioSource);  
            }
        }
    }

    public void LoadTheDeathUI()
    {
        gameObject.SetActive(true);
        if (audioSource != null) { audioSource.pitch = musicPitchOnDeath; Debug.Log(audioSource.pitch); }
        Time.timeScale = 0;
    }

    public void UnloadTheDeathUI()
    {
        gameObject.SetActive(false);
    }
}
