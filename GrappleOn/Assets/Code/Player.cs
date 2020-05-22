using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TigerForge;

public class Player : MonoBehaviour
{
    EasyFileSave easyFileSave;
    bool gameOver = false;
    private Rigidbody2D rb;
    private int points;
    //private TextMeshProUGUI
    public GameObject Canvas, deadSms,pointsText;
    public Canvas NewCan;
    
    // Start is called before the first frame update
    void Start()
    {
        
        easyFileSave = new EasyFileSave();
        
        
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        Canvas = GameObject.Find("Canvas");
        NewCan = Canvas.GetComponent<Canvas>();
        //NewCan.enabled = false;
        deadSms.SetActive(false);
        pointsText = GameObject.Find("PointsText");
    }
    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main.GetComponent<CameraFollow>().paused == true)
            {
                SaveGame();
                SceneManager.LoadScene("Menu");
            }

        }
    }
    private void FixedUpdate()
    {
        pointsText.GetComponent<TextMeshProUGUI>().text = points.ToString();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SoundManager.PlaySound("death");
            Camera.main.GetComponent<CameraFollow>().paused = true;
            this.GetComponent<Grapple>().enabled = false;
            //NewCan.enabled = true;
            deadSms.SetActive(true);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(points);
        points += 1;
        Destroy(col.gameObject);
        SoundManager.PlaySound("coin");
    }

    private void SaveGame()
    {
        easyFileSave.Add("points", points);
        easyFileSave.Save();
    }
    
}
