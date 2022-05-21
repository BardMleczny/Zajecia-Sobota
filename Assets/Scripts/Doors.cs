using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform door;
    public Transform openPosition;
    public Transform closePosition;
        
    public float closeSpeed = 1f;

    public bool open = false;

    private void Update()
    {
        Open();
    }
    public void Open()
    {
        if (open)
        {
            door.position = Vector3.MoveTowards(
                door.position,
                openPosition.position,
                Time.deltaTime * closeSpeed);
        }
        if (!open)
        {
            door.position = Vector3.MoveTowards(
                door.position,
                closePosition.position,
                Time.deltaTime * closeSpeed);
        }
    }
    public void CloseOpen()
    {
        open = !open;
    }
}
