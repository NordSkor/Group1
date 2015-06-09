
#pragma strict
private var movement : Vector3 = Vector3.zero;
private var controller : CharacterController;

var bullet : GameObject;
var fireRate = 0.5;
var nextFire = 0;
var lives : int;
var lifetime = 2.0;
var fire : AudioClip;
var bump : AudioClip;
RequireComponent(AudioSource);




function Start () 
{
    controller = GetComponent(CharacterController);
}


function OnTriggerEnter(col : Collider)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(col.gameObject);
            GameObject.Destroy(this.gameObject);
            Application.LoadLevel("SI_Lose");
        }
    }

    function OnCollisionEnter(collision : Collision)
        {
            if(collision.gameObject.name == "left")
            {
                GetComponent.<AudioSource>().PlayOneShot(bump);
            }
            else if(collision.gameObject.name == "right")
            {
                GetComponent.<AudioSource>().PlayOneShot(bump);
            }
        }
    /*function OnCollisionEnter(collision : Collision)
        {
          //  if(collision)
            //  GetComponent.<AudioSource>().PlayOneShot(bump);
            GetComponent.<AudioSource>().PlayOneShot(fire);
        }*/


    /*function OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameLose>();
    }*/

    function Update () 
    {
        movement = Vector3(Input.GetAxis("Horizontal"), 0, 0);
	
        movement = transform.TransformDirection(movement);
	
        movement *= 7;
	
        controller.Move(movement * Time.deltaTime);

      //  print(GameObject.FindGameObjectsWithTag("Enemy").Length);
     /*   if(GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
        {
            Application.LoadLevel("SI_Win");
        }
        */
        

    //print(GameObject.FindGameObjectsWithTag("Enemy"));
    /*if(GameObject.FindGameObjectsWithTag("Enemy") == 0);
    {
        Application.LoadLevel(0);
    }*/

   


    if (Input.GetKeyUp("space") || Input.GetKeyUp("up") && Time.time > nextFire)
        {
            var spawn_bullet = Instantiate (bullet, transform.position, Quaternion.identity);
            spawn_bullet.GetComponent.<Rigidbody>().AddForce(Vector3.up * 155);//115
            nextFire = Time.time + fireRate;
            GetComponent.<AudioSource>().PlayOneShot(fire);
           // var clone = Instantiate (bullet, transform.position, transform.rotation);

    }
  
    
}