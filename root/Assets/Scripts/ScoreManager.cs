using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
   
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this.gameObject.GetComponent<ScoreManager>();
            
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }

        if (spaceGame)
         winScore = gameObject.GetComponent<SpawningEnemies>().numberOfEnemies;
    }
    
    //private score.
    //this is the score that is local to the scoremanager
    private float _score = 0;

    //this is the score that we expose to everyone.
    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (usingTimer)
        {
            if (fTimer.timerDone)
            {
                print("using timer");
                //iwin
                if (_score >= winScore)
                {
                    //tell gameman u won or something
                    Application.LoadLevel(winLvl);
                }
                //u suck :(
                else
                    Application.LoadLevel(loseLvl);
            }
        }
        else if(!usingTimer)
        {
            //iwin
            if (_score >= winScore)
            {
                print("u win");
                //tell gameman u won or something
                Application.LoadLevel(winLvl);
            }
            
        }
    }

    public Timer fTimer;
    private static ScoreManager _instance;
    public string winLvl = "FallingEnd";
    public string loseLvl = "FallingLose";
    public int winScore = 15;
    public bool usingTimer = true;
    public bool spaceGame = false;
    
}
