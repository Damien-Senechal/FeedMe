using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float timer = 60f;
    private int score = 0;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = "Score : "+score + " |\n " + Mathf.Round((timer * Mathf.Pow(10.0f, (float)2))) / Mathf.Pow(10.0f, (float)2);
        if (timer < 0)
        {
            if(score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
            SceneManager.LoadScene(0);
        }
    }

    public void addTime(float t)
    {
        timer += t;
    }

    public void addScore(int s)
    {
        score += s;
    }

    public int getScore()
    {
        return score;
    }

    public void returnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
