using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float scaleModifer = 1f;
    public bool hasScaled = false;
    public string HousePart = "";

    // Start is called before the first frame update
    void Start()
    {
        HousePart = this.gameObject.tag;
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
            if(other.GetComponent<Construction>() != null)
            {
                Construction con = other.GetComponent<Construction>();
                con.hovering = true;
                con.buildingPart = HousePart;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Crane" && hasScaled)
        {
            hasScaled = false;
            transform.localScale = new Vector3(transform.localScale.x / scaleModifer, transform.localScale.y / scaleModifer, transform.localScale.z / scaleModifer);
            if (other.GetComponent<Construction>() != null)
            {
                Construction con = other.GetComponent<Construction>();
                con.hovering = false;
            }
        }
    }
}
