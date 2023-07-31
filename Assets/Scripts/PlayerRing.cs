using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]

public class PlayerRing : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    public TextMeshProUGUI highScoreText; // Reference to the UI Text component for displaying the high score

    private float currentTime; // Current time in seconds
    private float highScore; // Current high score in seconds

    [SerializeField] private float _moveSpeed;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    private float time;
    private bool end;
    public GameObject nextLevelButton;
    public GameObject gameover;
    public static int numberOfCoins;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if(end==false)
        {

            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }

        }
        
       
        
        
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Load the high score from PlayerPrefs
        UpdateHighScoreText(); // Update the high score text initially
    }

    

    
    void Update()
    {
        scoreText.text="SCORE: "+score.ToString();

        if(end==false)
        {
            time+= Time.deltaTime;
            timeText.text="TIME: "+time.ToString("#.0");

            currentTime += Time.deltaTime; // Increase the current time by the time passed since the last frame

        // Check if the current time surpasses the high score
            if (currentTime > highScore)
            {
                highScore = currentTime; // Update the high score
                PlayerPrefs.SetFloat("HighScore", highScore); // Save the high score to PlayerPrefs
                UpdateHighScoreText(); // Update the high score text
            }


        }

        
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + FormatTime(highScore); // Display the high score in the UI Text component
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
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
            gameover.SetActive(true);
           
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
    private void Awake()
    {
        score=PlayerPrefs.GetInt("SCORE",score);
    }

    public void OnReplay()
    {
        ResetLevel();
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void LoadSceneMenuIG()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void NextLevel(string levelName)
    {
        if(levelName !="")
        {
            SceneManager.LoadScene(levelName);
        }
    }

}
