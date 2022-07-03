using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sceneMng : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }
    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void which()
    {
        SceneManager.LoadScene(4);
    }
    public void what()
    {
        SceneManager.LoadScene(3);
    }
    public void trans()
    {
        SceneManager.LoadScene(2);
    }
    public void math()
    {
        SceneManager.LoadScene(5);
    }
    public void geri()
    {
        SceneManager.LoadScene(0);
    }
}
