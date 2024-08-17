using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meshes = this.GetComponentsInChildren<Mesh>();
        if (meshes == null || meshes.Length == 0)
            return;

        foreach (var mesh in meshes)
        {
            foreach (var vector in mesh.vertices)
            {
                if (!float.IsFinite(vector.x) || !float.IsFinite(vector.y) || !float.IsFinite(vector.z))
                {

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
