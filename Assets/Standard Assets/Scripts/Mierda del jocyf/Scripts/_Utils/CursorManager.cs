using UnityEngine;

public partial class CursorManager : MonoBehaviour
{
    public bool showCursor = false;
    public bool useUpdate = false;

    private bool showCursorPrev = false;

    private void Start()
    {
        UpdateCursorState ();
    }

    void Update()
    {
        if (!useUpdate) return;

        if(showCursorPrev != showCursor)
            UpdateCursorState ();
    }

    private void UpdateCursorState()
    {
        Cursor.visible = showCursor;
        Cursor.lockState = showCursor ? CursorLockMode.None : CursorLockMode.Locked;
        showCursorPrev = showCursor;
    }
}