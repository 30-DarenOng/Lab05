using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    private int score;
    public Text ScoreText;
   
    public Text TimerText;

    public float TimeLeft;
    public float timeRemaining;
    public float timeValue;

    public ParticleSystem whey;
    public AudioClip Supraphysiological;
    public AudioSource SAUCED;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = ("Score: " + score);
        SAUCED = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        Countdowntimer();
        if (score == 100 && TimeLeft <= timeValue)
        {
            SceneManager.LoadScene("GameWinScene");
            Cursor.lockState = CursorLockMode.None;
        }
        if (TimeLeft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }    

    }
    private void Countdowntimer()
    {
       
        TimeLeft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(TimeLeft % 60);
        TimerText.text = "Time Left: " + timeRemaining.ToString();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            score += 10 ;
            ScoreText.text = ("Score: " + score);
            Instantiate(whey, collider.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);

            SAUCED.PlayOneShot(Supraphysiological);

        }
        if (collider.gameObject.layer == 4)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver();
        }

    }
    void gameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameLoseScene");
    }    
   
}
