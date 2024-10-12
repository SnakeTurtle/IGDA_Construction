using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Penguin_Controller : MonoBehaviour
{
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(camera.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
