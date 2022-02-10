using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrap : MonoBehaviour
{
    public float speed;
    private float z;
    public GameObject ponto1, ponto2;
    private Vector2 nextPos;


    void Start()
    {
        nextPos = ponto2.transform.position;
    }

    void Update()
    {
        rotationtrap();
        movingT();
    }
    private void rotationtrap()
    {
        z = z + Time.deltaTime * 500;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    private void movingT()
    {
        if (transform.position == ponto1.transform.position)
        {
            nextPos = ponto2.transform.position;
        }
        if(transform.position == ponto2.transform.position)
        {
            nextPos = ponto1.transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
