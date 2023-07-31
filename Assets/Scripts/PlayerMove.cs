using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    public int score;
    private int scored;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    private float time;
    private bool end;
    public GameObject nextLevelButton;
    public static int numberOfCoins;
    private int scoreAmmount;

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
    
    void Update()
    {
        scoreText.text="SCORE: "+score.ToString();

        if(end==false)
        {
            time+= Time.deltaTime;
            timeText.text="TIME: "+time.ToString("#.0");

        }
        
    }

    public void Addscore()
    {
        scoreAmmount +=10;
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

        if(other.tag=="daily")
        {
            score+=10;
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
