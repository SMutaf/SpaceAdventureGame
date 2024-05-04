using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject Player;

    public GameObject meteor;
    public int numOfMeteors;

    public GameObject EnemyTypeOne;
    public int numOfEnemyTypeOne;

    public GameObject EnemyTypeTwo;
    public int numOfEnemyTypeTwo;

    public TextMeshProUGUI scoreString;
    public TextMeshProUGUI lastScoreString;
    public TextMeshProUGUI startInformation;

    float score = 0;
    float timer = 0;
    bool countDownToMainMenu = false;

    
    void Start()
    {
        SetMeteors();

        SetPlayer();

        SetEnemyTypeOne();

        SetEnemyTypeTwo();
    }

    
    void Update()
    {
        ScoreCounter();

        DeleteStartInfromation();

        ReturnMainMenu();
    }

    void SetMeteors()
    {
        for(int i = 0; i < numOfMeteors; i++)
        {
            Vector2 RandomPosition = new Vector2(Random.Range(12,60), Random.Range(-8,8));
            Instantiate(meteor, RandomPosition, Quaternion.identity);
        }
    }

    void SetPlayer()
    {
        Player = Instantiate(Player);
    }


    void SetEnemyTypeOne()
    {
        for (int i = 0; i < numOfEnemyTypeOne; i++)
        {
            Vector2 RandomPosition = new Vector2(Random.Range(12, 70), Random.Range(-4f, 5f));
            Instantiate(EnemyTypeOne, RandomPosition, Quaternion.identity);
        }
    }

    void SetEnemyTypeTwo()
    {
        for (int i = 0; i < numOfEnemyTypeTwo; i++)
        {
            Vector2 RandomPosition = new Vector2(Random.Range(12, 70), Random.Range(-4f, 5f));
            Instantiate(EnemyTypeTwo, RandomPosition, Quaternion.identity);
        }
    }

    void ScoreCounter()
    {
        if(Player != null)
        {
            score += Time.deltaTime;
            scoreString.text = "SCORE " + (int)score;
        }
        else
        {
            Destroy(scoreString);
            lastScoreString.text = scoreString.text;

            countDownToMainMenu = true;
        }
    }

    void DeleteStartInfromation()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.K))
            Destroy(startInformation);
    }

    void ReturnMainMenu()
    {
        if(countDownToMainMenu)
        {
            timer += Time.deltaTime;

            if(timer > 3)
            {
                SceneManager.LoadScene("Scene1");
            }
        }
    }

   



}
