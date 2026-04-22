using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDraw : MonoBehaviour
{
    public LineRenderer line;
    public Camera cam;

    public float minDistance = 0.05f;
    public float surfaceOffset = 0.02f;

    private List<Vector3> points = new List<Vector3>();

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            points.Clear();
            line.positionCount = 0;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 drawPoint = hit.point + hit.normal * surfaceOffset;

                if (points.Count == 0 || Vector3.Distance(points[^1], drawPoint) > minDistance)
                {
                    points.Add(drawPoint);
                    line.positionCount = points.Count;
                    line.SetPositions(points.ToArray());
                }
            }
        }
    }
}