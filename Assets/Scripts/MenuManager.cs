using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "BEST\r\n" + PlayerPrefs.GetInt("BestScore", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }

    public void HowToPlay()
    {
        return;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
