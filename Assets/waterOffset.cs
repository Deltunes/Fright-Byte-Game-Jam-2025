using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterOffset : MonoBehaviour
{
    Material material;
    float materialOffset;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        materialOffset = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset = new Vector2(materialOffset, materialOffset);
        materialOffset += 0.02f * Time.deltaTime;
    }
}
