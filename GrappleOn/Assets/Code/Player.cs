using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    bool gameOver = false;
    private Rigidbody2D rb;

    public GameObject Canvas;
    public Canvas NewCan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        Canvas = GameObject.Find("Canvas");
        NewCan = Canvas.GetComponent<Canvas>();
        NewCan.enabled = false;
    }
    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main.GetComponent<CameraFollow>().paused == true)
                SceneManager.LoadScene("SampleScene");


        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SoundManager.PlaySound("death");
            Camera.main.GetComponent<CameraFollow>().paused = true;
            this.GetComponent<Grapple>().enabled = false;
            NewCan.enabled = true;

        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        SoundManager.PlaySound("coin");
    }
}
