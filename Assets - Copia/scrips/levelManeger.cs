using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManeger : MonoBehaviour
{
    public Button[] bot�es;
    private void update()
    {
        for(int i=0;i < bot�es.Length; i++)
        {
            if (i + 2 >PlayerPrefs.GetInt("faseCompletada"))
            {
                bot�es[i].interactable = false;
            }
        }
    }

   /*public void callLevels()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual") + 1);
    }*/
}