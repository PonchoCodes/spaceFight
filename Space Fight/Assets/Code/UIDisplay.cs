using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text scoreText;

    //References
    [SerializeField] ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        healthSlider = gameObject.GetComponentInChildren<Slider>();
        scoreText = gameObject.GetComponentInChildren<TMP_Text>();
        scoreKeeper.OnSceneReload();
    }


  public void UpdateHealthSlider(int currentHealth)
    {
        if (healthSlider != null)
        {
            float sliderHealth = (float)currentHealth / 100;
            healthSlider.value = sliderHealth;
        }
    }

    public void UpdateScore()
    {
        scoreText.text = scoreKeeper.getScore().ToString();
    }
}
