using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Character_Controller : MonoBehaviour
{
    Rigidbody rb;
    public Camera cam;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private float maxWidth;
    private float maxHight;


    void Update() // обновит блок кода перед обновлением frame(кадра); 
    {
        //Transform shotSpawn;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;

            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;

            GetComponent<AudioSource>().Play();

        }


    }

    public float tilt;
    public float speed;
    public Boundary boundary;
    
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        Renderer rd = GetComponent<Renderer>();
       
        if (cam == null)
        {

            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width,0.0f,Screen.height );
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = rd.bounds.extents.x;
        float hatHight = rd.bounds.extents.z;

        maxWidth = targetWidth.x - hatWidth;
        maxHight = targetWidth.z - hatHight;

    }

    void FixedUpdate()

    {
       

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(h, 0.0f, v);

        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 movement = new Vector3(rawPosition.x, 0.0f, rawPosition.z);
        rb.MovePosition(movement);

        rb.velocity = movement * speed;

        //rb.velocity = movement * speed;

        // сужение поля движения по горизонтали
        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }



}
