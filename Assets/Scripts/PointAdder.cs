using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : PickUp
{
    public int points = 5;

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        GameManager.gameManager.PlayClip(pickedClip);
        Destroy(this.gameObject);
    }
}
