using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRadar : MonoBehaviour
{
    [SerializeField] Transform boat;
    [SerializeField] GameObject radarDot;

    public float radarRange;
    public float radarSize;

    private List<GameObject> dotList = new List<GameObject>();

    private void Start()
    {
        radarRange = 1000f;
        radarSize = 0.01f;
    }

    void Update()
    {
        foreach (GameObject dot in dotList)
        {
            Destroy(dot);
        }
        dotList.Clear();

        GameObject[] targets = GameObject.FindGameObjectsWithTag("RadarObject");

        foreach (GameObject target in targets)
        {
            Vector3 direction = target.transform.position - boat.position;
            float distance = direction.magnitude;

            if (distance < radarRange)
            {
                Vector3 radarPos = direction;
                radarPos = Quaternion.Inverse(boat.rotation) * radarPos;
                radarPos *= radarSize;
                radarPos = Vector3.ClampMagnitude(radarPos, 0.4f);

                GameObject dot = Instantiate(radarDot, transform);
                dot.transform.localPosition = radarPos;
                dot.transform.localRotation = Quaternion.identity;
                dotList.Add(dot);
            }
        }
    }
}
