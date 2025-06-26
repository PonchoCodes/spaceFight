using Unity.VisualScripting;
using UnityEngine;

public class LoadDeathUI : MonoBehaviour
{
    //References
    AudioSource audioSource;
    AudioSource[] audioSourceComponents;
    [Header("DeathEffects")]
    [SerializeField] float musicPitchOnDeath;

    private void Start()
    {
        //Get the audio source component with the game music
        audioSourceComponents = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource auSou in audioSourceComponents)
        {
            if (auSou.GetComponentsInParent<AudioPlayer>() != null)
            {
                audioSource = auSou;
            }
        }
    }

    public void LoadTheDeathUI()
    {
        gameObject.SetActive(true);
        if (audioSource != null) { audioSource.pitch = musicPitchOnDeath; }
        Time.timeScale = 0;
    }

    public void UnloadTheDeathUI()
    {
        gameObject.SetActive(false);
    }
}
