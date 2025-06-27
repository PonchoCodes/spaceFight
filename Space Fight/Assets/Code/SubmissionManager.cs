using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class SubmissionManager : MonoBehaviour
{
    [Header("Player Submission")]
    [SerializeField] TMP_InputField inputName;
    [SerializeField] TextMeshProUGUI inputScore;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }

}
