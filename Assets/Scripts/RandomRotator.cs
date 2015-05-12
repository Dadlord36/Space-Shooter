using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
    public float tunble; 

    void Start()
    {

        var rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * tunble;
        
    }
	
}
