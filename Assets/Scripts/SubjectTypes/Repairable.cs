using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairable : Draggable
{
    public bool IsInRepairZone { get ; private set; }

    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter trigger");
        IsInRepairZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit trigger");
        IsInRepairZone = false;
    }
}
