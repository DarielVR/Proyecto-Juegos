using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{   
    public float rangeX;
    public float rangeY;

    public float frequency = 1;
    Transform platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rangeX != 0) {
            platform.position = Vector3.right * rangeX * Mathf.Sin(frequency * Time.time);
        }

        if(rangeY != 0) {
            platform.position = Vector3.up * rangeY * Mathf.Sin(frequency * Time.time);
        }
    }
}
