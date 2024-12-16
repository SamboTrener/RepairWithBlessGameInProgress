using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController Instance { get; private set; }

    public enum CursorState
    {
        Rotate,
        Grab
    }

    [SerializeField] Texture2D rotateCursorSprite;
    [SerializeField] Texture2D grabCursorSprite;
    [SerializeField] LayerMask bgMask;

    public CursorState State { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (1 << hitInfo.collider.gameObject.layer == bgMask) 
            {
                State = CursorState.Rotate;
                Cursor.SetCursor(rotateCursorSprite, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                State = CursorState.Grab;
                Cursor.SetCursor(grabCursorSprite, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
