using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance { get; private set; }

    [SerializeField] float takenZOffset;
    float takenZPosition;

    public Draggable TakenSubject { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(TakenSubject)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                takenZPosition);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            TakenSubject.gameObject.transform.position = objPosition;
        }
    }

    public void TakeSubject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            TakenSubject = hitInfo.collider.gameObject.GetComponent<Draggable>();
            takenZPosition = TakenSubject.gameObject.transform.position.z - takenZOffset;
        }
    }

    public void DropSubject()
    {
        if (RepairZone.Instance.TryPlaceToRepair(TakenSubject.gameObject)) //Пытаемся положить объект на общий стол
        {
            Debug.Log("Repair zone"); //Положили объект на стол
        }
        else
        {
            Debug.Log("Non repair zone");
            TakenSubject.ReturnToInitialPosition();
        }
        TakenSubject = null; //Сброс объекта из рук
    }
}

