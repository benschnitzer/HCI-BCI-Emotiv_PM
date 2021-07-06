using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public float rotationSpeed = 100f;
    private float rotation;

    [SerializeField] private UIRadarChart uiRadarChart;


    [SerializeField] private GameObject spawnPoint;

    private void Update()
    {
        //Debug.Log(uiRadarChart.stressValue);
        /*rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        transform.Translate(Vector3.forward * Time.deltaTime * speed / uiRadarChart.stressValue);

        transform.Rotate(0, rotation, 0);

        if (transform.position.y < 2)
        {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;
        }*/
    }

    private void FixedUpdate()
    {

        rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        transform.Translate(Vector3.forward * (Time.deltaTime * speed / uiRadarChart.stressValue));

        transform.Rotate(0, rotation, 0);

        if (transform.position.y < 0)
        {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;
        }
    }
}

