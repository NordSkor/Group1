
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{    
    void Start()
    {
        cooldown = Random.Range(minShootDelay, maxShootDelay);
    }

    void FixedUpdate()
    {
        //decrement the cooldown
        cooldown -= Time.deltaTime;
        cdText.text = Mathf.Round(cooldown).ToString();
        //if the cooldown is up then drop the bomb
        if (cooldown <= 0)
        {
            GameObject bu = Instantiate(bullet, this.transform.position, Quaternion.identity) as GameObject;
            bu.GetComponent<Rigidbody>().useGravity = true;
            bu.GetComponent<Rigidbody>().AddForce(Vector3.down * 200);
            cooldown = Random.Range(minShootDelay, maxShootDelay);
        }
    }
    //public
    public float minShootDelay = 1.0f;
    public float maxShootDelay = 5.0f;
    public GameObject bullet;
    public Text cdText;

    //private
    private float cooldown;

}
