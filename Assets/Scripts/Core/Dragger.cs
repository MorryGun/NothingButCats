using UnityEngine;

public class Dragger : MonoBehaviour
{
    public bool isSelected;

    Camera mainCamera;
    Vector3 offset;

    int minPos = 0;
    int maxPos = 9;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        var pos = GetMousePos() + offset;

        isSelected = true;
        transform.position = new Vector3(ApplyLimits(pos.x), ApplyLimits(pos.y), 0);
    }

    private void OnMouseUp()
    {
        isSelected = false;
        transform.position = RoundPosition(transform.position);
    }

    Vector3 GetMousePos()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }

    float ApplyLimits(float pos)
    {
        if (pos < minPos)
        {
            pos = minPos;
        }
        else if (pos > maxPos)
        {
            pos = maxPos;
        }

        return pos;
    }

    Vector3 RoundPosition(Vector3 pos)
    {
        var x = Mathf.RoundToInt(pos.x);
        var y = Mathf.RoundToInt(pos.y);

        return new Vector3(x, y, 0);
    }
}
