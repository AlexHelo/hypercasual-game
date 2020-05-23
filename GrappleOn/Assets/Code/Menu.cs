using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TigerForge;
using TMPro;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, storeUI, storeMoney;
    private EasyFileSave SaveGame;
    private int points;
    private void Start()
    {
        SaveGame = new EasyFileSave();
        storeUI.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenStore()
    {
        storeUI.SetActive(true);
        mainMenu.SetActive(false);


    }
    public void CloseStore()
    {
        storeUI.SetActive(false);
        mainMenu.SetActive(true);

    }
    private void SetMoney()
    {
        if (SaveGame.Load())
        {
            points = SaveGame.GetInt("points");
            storeMoney.GetComponent<TextMeshProUGUI>().text = points.ToString();
        }
        else
        {
            points = 0;
        }

    }
    private void FixedUpdate()
    {
        SetMoney();
    }


}
