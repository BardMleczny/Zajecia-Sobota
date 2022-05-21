using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;

    public Doors door;
    public KeyColor myKeyColor;
    bool locked = false;
    Animator key;
    private void Start()
    {
        key = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        door.CloseOpen();
    }
    public bool CheckTheKey()
    {
        if (GameManager.gameManager.redKey > 0 && myKeyColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.redKey > 0 && myKeyColor == KeyColor.Green)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.redKey > 0 && myKeyColor == KeyColor.Gold)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("No key!");
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can use lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You cannot use lock");
        }
    }
}
