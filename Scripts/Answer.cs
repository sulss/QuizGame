using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;
    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    IEnumerator ChangeColorGreen()
    {
        GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().color = startColor;
        StopCoroutine(ChangeColorGreen());
    }
    public void Answers()
    {
        if (isCorrect)
        {
            StartCoroutine(ChangeColorGreen());
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
