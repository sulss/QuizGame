using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Qmanager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QTxt;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;
    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }
    public void back()
    {
        SceneManager.LoadScene(1);
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<answers2>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<answers2>().startColor;
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<answers2>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QTxt.text = QnA[currentQuestion].Question;

            SetAnswers();

        }
        else
        {
            Debug.Log("Out of question");
            GameOver();
        }

    }
}
