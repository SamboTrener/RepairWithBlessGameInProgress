using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Нажата левая кнопка мыши
        {
            switch (CursorController.Instance.State)
            {
                case CursorController.CursorState.Rotate:
                    if(RotateManager.Instance.RotatingSubject == null)
                    {
                        RotateManager.Instance.EnterRotationMode();
                    }
                    else
                    {
                        RotateManager.Instance.ExitRotationMode();
                    }
                    break;
                case CursorController.CursorState.Grab:
                    if (DragManager.Instance.TakenSubject == null)
                    {
                        DragManager.Instance.TakeSubject();
                    }
                    else
                    {
                        DragManager.Instance.DropSubject();
                    }
                    break;
            }
        }
    }
}
