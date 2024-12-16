using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairZone : MonoBehaviour
{
    public static RepairZone Instance { get; private set; }

    public Repairable CurrentRepairable { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public bool TryPlaceToRepair(GameObject objectToPlace)
    {
        var repairable = objectToPlace.GetComponent<Repairable>();
        if (repairable)
        {
            if (repairable.IsInRepairZone)
            {
                if (CurrentRepairable != null)
                {
                    CurrentRepairable.ReturnToInitialPosition();
                }
                CurrentRepairable = repairable;
                objectToPlace.transform.position = gameObject.transform.position;
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}
