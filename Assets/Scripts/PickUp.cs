using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public AudioClip pickedClip;

    private void Update()
    {
        Rotation();
    }
    public virtual void Picked()
    {
        Debug.Log("Picked");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 0f, 0.3f));
        
    }
}