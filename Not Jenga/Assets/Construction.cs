using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public GameObject crane;
    private Transform craneTransform;

    public bool attatchedToCrane = false;
    public bool hovering = false;
    public string buildingPart = "";
    public float adjustToCrane = 2.5f;

    public bool Moving_Vertically = false;
    public bool Moving_Horizontally = true;

    [Header("List of Parts")]
    public GameObject[] Parts = new GameObject[5];


    [Header("Crane Adjustments")]
    public float Vertical = 1f;
    public float Horizontal = 1f;

    // Start is called before the first frame update
    void Start()
    {
        craneTransform = crane.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && !attatchedToCrane && hovering)
        {
            print("Connect to crane");
            Attach();
            //Vector3 belowCrane = new Vector3(crane.transform.position.x, crane.transform.position.y-adjustToCrane, crane.transform.position.z);
            //linehandler = Instantiate(lineprefab, belowCrane, Quaternion.identity) as GameObject;
            //linehandler.transform.parent = crane.transform;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeDirection();
        }
        if (Moving_Vertically)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x, craneTransform.position.y - Vertical, craneTransform.position.z);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x, craneTransform.position.y + Vertical, craneTransform.position.z);
            }
 
        }
        if (Moving_Horizontally)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x, craneTransform.position.y, craneTransform.position.z - Horizontal);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x, craneTransform.position.y, craneTransform.position.z + Horizontal);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x - Horizontal, craneTransform.position.y, craneTransform.position.z);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                craneTransform.position = new Vector3(craneTransform.position.x + Horizontal, craneTransform.position.y, craneTransform.position.z);
            }
           
        }
    }

    void Attach()
    {
        switch (buildingPart)
        {
            case "Roof":
                Vector3 belowCrane = new Vector3(crane.transform.position.x, crane.transform.position.y - adjustToCrane, crane.transform.position.z);
                GameObject attatched = Instantiate(Parts[0], belowCrane, Quaternion.identity);
                break;
        }
    }

    void ChangeDirection()
    {
        if (Moving_Vertically)
        {
            Moving_Vertically = false;
            Moving_Horizontally = true;
        }
        else if (Moving_Horizontally)
        {
            Moving_Horizontally = false;
            Moving_Vertically = true;
        }
    }
}
