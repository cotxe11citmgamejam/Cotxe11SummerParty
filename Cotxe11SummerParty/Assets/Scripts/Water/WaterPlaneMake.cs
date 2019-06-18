using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneMake : MonoBehaviour
{
    private float plane_size = 80.0f;
    private float grid_size = 25.0f;
    private MeshFilter plane_mesh;

    void Start()
    {
        plane_mesh = GetComponent<MeshFilter>();
        plane_mesh.mesh = GenerateMesh();
    }

    void Update()
    {
        
    }

    private Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < grid_size + 1; i++)
        {
            for (int j = 0; j < grid_size + 1; j++)
            {
                float vertex_X = -plane_size * 0.5f + plane_size * (i / grid_size);
                float vertex_Z = -plane_size * 0.5f + plane_size * (j / grid_size);
                vertices.Add(new Vector3(vertex_X, 0, vertex_Z));

                normals.Add(Vector3.up);
                uvs.Add(new Vector2(i / grid_size, j / grid_size));
            }
        }


        List<int> triangles = new List<int>();
        float vert_count = grid_size + 1;

        for(int i = 0; i < vert_count * vert_count - vert_count; i++)
        {
            if ((i + 1) % vert_count == 0)
                continue;

            triangles.AddRange(new List<int>()
            {
                i + 1 + (int)vert_count, i + (int)vert_count, i,
                i, i  + 1, i + (int)vert_count + 1
            });
        }

        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

        return mesh;
    }

}
