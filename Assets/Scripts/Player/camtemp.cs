using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camtemp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Rotate(Vector3.right, -50*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Rotate(Vector3.right, 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * -50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(Vector3.forward, -50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
        }
    }
}
