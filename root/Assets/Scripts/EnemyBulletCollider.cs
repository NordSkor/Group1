using UnityEngine;
using System.Collections;

public class EnemyBulletCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    private int lifetime = 4;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Destroy(col.gameObject);
            GameObject.Destroy(this.gameObject);
            Application.LoadLevel("SI_Lose");
        }
        else if (col.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
