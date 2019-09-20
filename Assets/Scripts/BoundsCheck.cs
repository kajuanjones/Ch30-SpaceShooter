using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dyanmically")]
    public bool isOnscreen = true;
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnscreen = true;
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            isOnscreen = false;
        }

        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnscreen = false;
        }

        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            isOnscreen = false;
        }

        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            isOnscreen = false;
        }

        if(keepOnScreen && !isOnscreen)
        {
            transform.position = pos;
            isOnscreen = true;
        }

        transform.position = pos;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}

