using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{

    public enum _State { Idle, Walk, Global }
    Player player = new Player();

    private bool isPlayerOn = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOn = false;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

}
