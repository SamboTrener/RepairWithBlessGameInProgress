using UnityEngine;

public class Draggable : MonoBehaviour
{
    protected Renderer rendererComponent;
    protected Vector3 initialPosition;

    protected virtual void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        initialPosition = transform.position;
    }

    protected virtual void OnMouseEnter()
    {
        rendererComponent.material.color = Color.red;
        //����� ������ ������ ��������
    }

    protected virtual void OnMouseExit()
    {
        rendererComponent.material.color = Color.white;
        //����� ������ ������ ��������
    }

    public void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
