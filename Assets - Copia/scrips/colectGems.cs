using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colectGems : MonoBehaviour
{
    public static bool save;
    private int score;
    public Text scoretxt;

    void Start()
    {
        save = false;
        score = PlayerPrefs.GetInt("totalScore");
    }


    void Update()
    {
        scoretxt.text = score.ToString();
        saveScore();

    }
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.CompareTag("gemas") == true)
        {
            score = score +1;
            Destroy(col.gameObject);
        }
    }
    private void saveScore()
    {
        if(save==true)
        {
            PlayerPrefs.SetInt("totalScore", score);
            PlayerPrefs.Save();
        }
    }
 }