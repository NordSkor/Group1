using UnityEngine;
using System.Collections;

public class BulletCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    private int lifetime = 4;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // gameObject.Find("Main Camera").GetComponent(Stats).current_score += 250;
            Destroy(gameObject);
            Destroy(col.gameObject);
            ScoreManager.instance.Score++;
        }
        else if (col.gameObject.name == "Enemy Bullet")
        {

            Destroy(gameObject);

        }
        else if (col.gameObject.name != "bed1")
        {
            Destroy(gameObject);
        }

        if (ScoreManager.instance.Score == 32)
        {
            Application.LoadLevel("SI_Win");
        }

    }
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
    // Update is called once per frame

}

