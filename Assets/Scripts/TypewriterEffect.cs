using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField]
    private float writingSpeed, startTime;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
       return StartCoroutine(TypeText(textToType, textLabel));
    }   
    
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;

        textLabel.text = string.Empty;

        //yield return new WaitForSeconds(startTime);

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
