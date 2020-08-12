using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusListener : MonoBehaviour
{
    private Abacus abacus;
    private TextTyper typer;

    [SerializeField] private int[] answers;
    private int questionIndex;

    private void Awake() 
    {
        abacus = FindObjectOfType<Abacus>();
        typer = FindObjectOfType<TextTyper>();

        abacus.OnValueChanged += CheckAnswer;
        questionIndex =0;
        
    }

    private void CheckAnswer(object sender, EventArgs e)
    {
        if(abacus.Total == answers[questionIndex])
        {
            typer.TypeOutHint(questionIndex);
            questionIndex++;

            Invoke("ShowNextQuestion",typer.delayBetweenPrompts);


        }
    }

    void ShowNextQuestion()
    {
        typer.TypeOutQuestion(questionIndex);
    }
}
