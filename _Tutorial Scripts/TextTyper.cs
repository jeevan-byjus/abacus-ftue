using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class TextTyper : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 1f;
    public float delayBetweenPrompts = 5f;
    [SerializeField] private string[] questionPrompts;
    [SerializeField] private string[] hintPrompts;
    private TextMeshPro textField;

    private float typeDelay
    {
        get
        {
            float delay = Mathf.Abs(1f/typingSpeed);
            delay = Mathf.Clamp(delay, Time.deltaTime, 1f);     // Nobody should be typing slower than 1 alphabet per second, and we cannot type faster than the frame-rate
            return delay;
        }
    }

    private void Awake() 
    {
        textField = GetComponent<TextMeshPro>();
    }

    public void TypeOut(string sentence)
    {
        StartCoroutine(RevealPrompt(sentence));
    }

    public void TypeOutQuestion(int questionNumber)
    {
        TypeOut(questionPrompts[questionNumber]);
    }

    public void TypeOutHint(int hintNumber)
    {
        TypeOut(hintPrompts[hintNumber]);
    }

    private IEnumerator RevealPrompt(string sentence)
    {
        string partialSentence = ""; 
        for(int i=0; i<sentence.Length; i++)
        {
            partialSentence = sentence.Substring(0,i+1);
            yield return new WaitForSeconds(typeDelay);
            textField.text = partialSentence;
        }
        yield return new WaitForSeconds(0f);
    }
}
