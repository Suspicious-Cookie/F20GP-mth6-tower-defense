using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemy;
    public float waveTime = 5;
    private float timer = 2;
    private int wave = 1;
    public Transform portal;
    private float spawnSpacer = 0.1f;
    public Text waveTimerText;
    public int winBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //coroutine for the wave timer to update
        if (timer <= 0)
        {
            StartCoroutine(StartWave());
            timer = waveTime;
        }

        waveTimerText.text = Mathf.Floor(timer + 1).ToString();
        timer -= Time.deltaTime;
    }

    IEnumerator StartWave()
    {
        //spawnSpacer = wave;
        if (GameStats.GameWin == false && GameStats.GameLose == false)
        {
            for (int i = 0; i < wave; i++)
            {
                if (wave >= winBoundary)
                {
                    GameStats.GameWin = true;
                    //GameStats.GameOver();
                }
                Spawn();
                yield return new WaitForSeconds(spawnSpacer);
                //spawnSpacer -= Time.deltaTime;
            }

            wave++;
        }
        
    }

    //spawns a single monster at the portal
    void Spawn()
    {
        Instantiate(enemy, portal.position, portal.rotation);
    }
}
