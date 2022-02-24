using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    //a class for storing player stats
    public static int Cash;
    public int StartingCash = 200;
    public static int PlayerHealth;
    public int StartingHealth = 10;
    public Text BankText;
    public Text HealthText;
    public static bool GameWin;
    public static bool GameLose;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public static int PlayerScore;
    public Text WinText;
    public Text LoseText;


    // Start is called before the first frame update
    void Start()
    {
        Cash = StartingCash;
        PlayerHealth = StartingHealth;
        GameWin = false;
        GameLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLose)
        {
            LoseText.text += PlayerScore.ToString();
            LoseScreen.SetActive(true);
            this.enabled = false;
        }
        if (GameWin)
        {
            WinText.text += PlayerScore.ToString();
            WinScreen.SetActive(true);
            this.enabled = false;
        }
        //Debug.Log(PlayerScore);
        BankText.text = Cash.ToString();
        HealthText.text = PlayerHealth.ToString();
    }
}
