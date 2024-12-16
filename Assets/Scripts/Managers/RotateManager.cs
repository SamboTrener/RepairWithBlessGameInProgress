using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public static RotateManager Instance { get; private set; }

    public Repairable RotatingSubject { get; private set; }

    float takenZPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (RotatingSubject)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                takenZPosition);
            Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition) - RotatingSubject.transform.position;
            RotatingSubject.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

    }

    public void EnterRotationMode()
    {
        Debug.Log("Enter rotation mode");
        RotatingSubject = RepairZone.Instance.CurrentRepairable;
        takenZPosition = RotatingSubject.gameObject.transform.position.z;
    }

    public void ExitRotationMode()
    {
        Debug.Log("Exit rotation mode");
        RotatingSubject = null;
    }
}
