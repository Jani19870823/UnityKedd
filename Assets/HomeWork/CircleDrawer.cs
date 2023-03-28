using System;
using System.Collections.Generic;
using UnityEngine;

class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector2 center;
    [SerializeField] float radius;

    [SerializeField, Min(3)] int segmentCount = 60;

   /* void OnDrawGizmos()
    {
        DrawCircleGizmo(center, radius, segmentCount);
    }*/

    void OnValidate()
    {
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
            return;

        List<Vector2> points = GetCirclePoints(center, radius, segmentCount);
        lineRenderer.positionCount = points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
        }
    }

    public static void DrawCircleGizmo(Vector2 center, float radius, int segmentCount)
    {
        List<Vector2> points = GetCirclePoints(center, radius, segmentCount);
        Gizmos.color = Color.yellow;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 point = points[i];
            Vector2 point2 = points[i + 1];

            Gizmos.DrawLine(point, point2);
        }

        Gizmos.DrawLine(points[0], points[^1]);   // nulladik és utulsó elem
    }

    // -------------------------------

    public static List<Vector2> GetCirclePoints(Vector2 center, float radius, int segmentCount)
    {
        List<Vector2> points = new List<Vector2>();

        float segmentAngle = 360f / segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * segmentAngle;
            angle *= Mathf.Deg2Rad;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector2 point = new Vector2(x, y) + center;
            points.Add(point);
        }

        return points;
    }

}
