using UnityEngine;

public class Mover : MonoBehaviour 
{
    public float laserSpeed;
    	
	void Start () 
    {
        
        var rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * laserSpeed;
	}
	
}
