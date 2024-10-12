using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float scaleModifer = 1f;
    public bool hasScaled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crane" && !hasScaled)
        {
            hasScaled = true;
            transform.localScale = new Vector3(transform.localScale.x * scaleModifer, transform.localScale.y * scaleModifer, transform.localScale.z * scaleModifer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("AAA");
        if (other.gameObject.tag == "Crane" && hasScaled)
        {
            hasScaled = false;
            transform.localScale = new Vector3(transform.localScale.x / scaleModifer, transform.localScale.y / scaleModifer, transform.localScale.z / scaleModifer);
        }
    }
}
