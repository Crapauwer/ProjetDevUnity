using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    
    
    [SerializeField] float distance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        
        /*Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = gm.GetPlayerPos();
        int vertexIndex = 1;
        int triangleIndex = 1;
        for (int i = 0; i < 6; i++)
        {
            Vector3 vertex = gm.GetPlayerPos() + GetVEctor(0) * 100f;
            vertices[vertexIndex] = vertex;


            if (i > 0)
            {


                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= 45f;
        }*/
    }

    
    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameManager.Instance;
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        int layerMask = ~(1 << LayerMask.NameToLayer("Default"));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gm.GetPlayerPos2().x, gm.GetPlayerPos2().y) , transform.up, layerMask);
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(-1, 0);
        if (hit.collider != null)
        {
            
            vertices[1] = new Vector3(hit.point.x-1, hit.point.y);
            vertices[2] = new Vector3(hit.point.x+1, hit.point.y);
        }
        else
        {
            vertices[1] = new Vector3(-1, distance);
            vertices[2] = new Vector3(1, distance);
        }

        vertices[3] = new Vector3(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 0;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        

    }

    public Vector3 GetVEctor(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void SetCrossDistance(float dis)
    {
        distance = dis;
    }
}
