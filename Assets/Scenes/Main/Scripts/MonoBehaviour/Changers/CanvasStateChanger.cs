using UnityEngine;

public class CanvasStateChanger : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public static void Enable(Canvas canvas)
    {
        if (canvas == null) { return; }

        canvas.enabled = true;
    }

    public static void Disable(Canvas canvas)
    {
        if (canvas == null) { return; }

        canvas.enabled = false;
    }

    public void Enable()
    {
        if (_canvas == null) { return; }

        _canvas.enabled = true;
    }

    public void Disable()
    {
        if (_canvas == null) { return; }

        _canvas.enabled = false;
    }
}
