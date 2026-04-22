using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class MouseDraw : MonoBehaviour
{
    public Camera cam; 

    public float minDistance = 0.05f;
    public float surfaceOffset = 0.02f;

    private LineRenderer line;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        
        if (cam == null)
            cam = Camera.main;

        line = GetComponent<LineRenderer>();
        line.positionCount = 0;

        Debug.Log("Using Camera: " + cam.name);
    }

    void Update()
    {
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            points.Clear();
            line.positionCount = 0;
        }

        
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            
            Ray ray = cam.ScreenPointToRay(mousePos);

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