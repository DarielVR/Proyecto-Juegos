using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    private Transform respawnPoint;

    private void Start() {
        respawnPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player") == null){
            Instantiate(player,respawnPoint.position,respawnPoint.rotation);
        }
    }
}
