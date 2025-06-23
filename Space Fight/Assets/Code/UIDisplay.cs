using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshPro scoreText;

    void Awake()
    {
        healthSlider = gameObject.GetComponentInChildren<Slider>();
        scoreText = gameObject.GetComponentInChildren<TextMeshPro>();
    }

    public void UpdateHealthSlider(int currentHealth)
    {
        if (healthSlider != null)
        {
            float sliderHealth = (float)currentHealth / 100;
            healthSlider.value = sliderHealth;
            Debug.Log(healthSlider.value);
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
