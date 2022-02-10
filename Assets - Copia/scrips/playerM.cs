using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerM : MonoBehaviour
{
    private Rigidbody2D player;
    private float movePlayer;
    public float speed, jumpForce, alturaCamera, speedWin;
    private bool jump, isgrounded, restartPlayer, win;
    private GameObject cameraPos, inicialPos;
    public GameObject panelWin;

    private Vector3 facingRight, facingLeft;
    void Start()
    {
        //ControlerdireitaEesquerda
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x *  -1;

        player = GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera");
        inicialPos = GameObject.Find("inicialPos");
        win = false;
    }

    void Update()
    {
        //ControlerdireitaEesquerda
        if (movePlayer  < 0)
        {
            transform.localScale = facingRight;
        }
        if (movePlayer > 0)
        {
            transform.localScale = facingLeft;
        }
        //
        movePlayer = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        cameraPos.transform.position = new Vector3(cameraPos.transform.position.x, player.transform.position.y + alturaCamera, cameraPos.transform.position.z);
        player.velocity = new Vector2(movePlayer * speed, player.velocity.y);
        if (jump == true && isgrounded==true)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isgrounded = false;
        }
        Restart();
        winGame();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            isgrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
          if (col.CompareTag("armadilha") == true)
        {
            restartPlayer = true;
        }
          if(col.CompareTag("win") == true)
        {
            win = true;
        }
    }
    private void Restart()
    {
        if (restartPlayer==true)
        {
            player.transform.position = new Vector2 (inicialPos.transform.position.x, inicialPos.transform.position.y);
            restartPlayer = false;
        }
    }
    private void winGame()
    {
        if (win == true)
        {
            colectGems.save = true;
            player.velocity = new Vector2 (0, player.velocity.y);
            panelWin.transform.position = Vector2.MoveTowards(panelWin.transform.position, cameraPos.transform.position, speedWin * Time.deltaTime);
            /*PlayerPrefs.SetInt("faseAtual", SceneManager.GetActiveScene().buildIndex);*/
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("faseCompletada"))
            {
                PlayerPrefs.SetInt("faseCompletada", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }
        }
    }
}

