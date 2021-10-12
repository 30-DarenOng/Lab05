using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    private int score;
    public Text ScoreText;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = ("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            score += 10 ;
            ScoreText.text = ("Score: " + score);
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.layer == 4)
        {
            SceneManager.LoadScene("GameLoseScene");
        }

    }
   
}
