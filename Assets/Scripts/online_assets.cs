using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class online_assets : MonoBehaviour
{

    
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    private float time;
    private bool end;
    public GameObject nextLevelButton;
    public GameObject TextNext;
    public static int numberOfCoins;


    void Update()
    {
        scoreText.text="SCORE: "+score.ToString();

        if(end==false)
        {
            time+= Time.deltaTime;
            timeText.text="TIME: "+time.ToString("#.0");

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("SCORE",score);
        if(end==false)
        {
            if(other.tag=="Flag")
        {
            end=true;
            nextLevelButton.SetActive(true);
            TextNext.SetActive(true);
           
        }

        if(other.tag=="Kill Zone")
        {
            ResetLevel();
        }

        if(other.tag=="Spikes")
        {
            ResetLevel();
        }

        if(other.tag=="Coin")
        {
            score++;
            scoreText.text= "SCORE "+ score;
            GameObject.Destroy(other.gameObject);
            Debug.Log("Score: "+score);
        }

         

        }
        
        
        
    }
    
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }




    private void Awake()
    {
        score=PlayerPrefs.GetInt("SCORE",score);
    }
}
