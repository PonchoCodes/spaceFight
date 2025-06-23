using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text scoreText;

    void Awake()
    {
        healthSlider = gameObject.GetComponentInChildren<Slider>();
        scoreText = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void UpdateHealthSlider(int currentHealth)
    {
        if (healthSlider != null)
        {
            float sliderHealth = (float)currentHealth / 100;
            healthSlider.value = sliderHealth;
        }
    }
    
    public void UpdateScore(int currentScore)
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
