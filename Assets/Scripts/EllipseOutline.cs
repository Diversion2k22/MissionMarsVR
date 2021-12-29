using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseOutline : MonoBehaviour
{
    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;
    private Material material;
   
    [SerializeField] Transform greenball = null;
    [SerializeField] Vector3 center = Vector3.zero;
    [SerializeField] float timeScale = 10;
    const float tau = Mathf.PI * 2f;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        material = new Material(Shader.Find("Unlit/Color"));
        material.color = Color.white;
        line.material = material;
        CreatePoints();
    }

    void Update()
    {
        float alpha = (Time.time * timeScale) % tau;

        Vector2 localPosition2d = new Vector2
        {
            x = Mathf.Sin(alpha) * yradius,
            y = Mathf.Cos(alpha) * xradius
        };
        greenball.position = center + new Vector3 { x = localPosition2d.x, z = localPosition2d.y };
    }
    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
     
    }
}
