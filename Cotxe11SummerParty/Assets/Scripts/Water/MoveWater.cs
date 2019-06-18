using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    private float vertex_inclination = 0.3f;
    private float force = 0.8f;
    private float time_to_wave = 0.5f;

    private float offsetX;
    private float offsetY;
    private MeshFilter planeMesh;
    
    void Start()
    {
        planeMesh = GetComponent<MeshFilter>();
        Move();
    }

    void Update()
    {
        Move();
        offsetX += Time.deltaTime * time_to_wave;
        offsetY += Time.deltaTime * time_to_wave;
    }



    void Move()
    {
        Vector3[] vertices = planeMesh.mesh.vertices;

        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * force;

        }
        planeMesh.mesh.vertices = vertices;

    }

    float CalculateHeight(float x, float y)
    {

        float X_coord = x * vertex_inclination + offsetX;
        float Y_coord = y * vertex_inclination + offsetY;


        return Mathf.PerlinNoise(X_coord, Y_coord);
    }

}
