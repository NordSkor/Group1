using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    AudioSource audio1;
    public float speed = 3.0f;
    public float score = 0f;

    public void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.green;
        //Display the score
        string text = "Score: " + ScoreManager.instance.Score;
        GUI.Label(new Rect(700, 10, 60, 20), text, myStyle);
    }
       
    private static Player _instance;

    //Collision with player
    void OnTriggerEnter(Collider collision)
    {
        //If player collides with 'Evil', score decreases & enemy is destroyed
        if (collision.gameObject.tag == "evilcloud")
        {
            //score -= 5;
            ScoreManager.instance.Score = score -= 5;
            print("Lost points");
            Destroy(collision.gameObject);
        }
        //If player collides with 'Good', score increases & good is destroyed
        else if (collision.gameObject.tag == "goodcloud")
        {
            //score += 5;
            ScoreManager.instance.Score = score += 5;
            print("Points gained");
            audio1.Play();
            Destroy(collision.gameObject);
        };
    }
 
    // Use this for initialization
    void Start() 
    { 
        audio1 = GetComponent<AudioSource>();
    }

    bool KeyDown = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("SPACE PRESSED");
            Camera.main.GetComponent<Animation>().Play();
        }
        float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
        //print(x);
        float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;

        Vector3 pos = transform.position;
        
        //pos.x = Mathf.Clamp (pos.x + x, -5, 5); // Restrict Player's X to the edge of screen
        //pos.z = Mathf.Clamp (pos.z + y, -5, 5); // Restrict Player's Y to the edge of screen

        //If player reaches the edge, go to the opposite side
        if (pos.x >= 60 || pos.x <= -60) { pos.x = -pos.x; }
        if (pos.z >= 45 || pos.z <= -45) { pos.z = -pos.z; }

        transform.position = pos;
        transform.Translate(x, 0, y, Space.Self);

    }

    
}
