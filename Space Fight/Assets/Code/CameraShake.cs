using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Variables")]
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float currentTimeInLoop = 0f;
        while (shakeDuration > currentTimeInLoop)
        {
            //Move camera by a random amount, additionally note that you can cast a data type into another by using parentheses and typing the type such as `(Vector3)`
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            currentTimeInLoop += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        // Reset the camera
        gameObject.transform.position = initialPosition;
    }
}
