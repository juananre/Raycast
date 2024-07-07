using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blast_Controller : MonoBehaviour
{
    [SerializeField] private Transform ShootPosition;
    private float LaserRange = 100f, LaserDuration = 0.06f;

    private Camera cam;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Vector3 RayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Ray ray = new Ray(RayOrigin, cam.transform.forward);

            lineRenderer.SetPosition(0, ShootPosition.position);

            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(1, hit.point);
                hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;

            }
            else
            {
                lineRenderer.SetPosition(1, ShootPosition.position + cam.transform.forward * LaserRange);
            }
            StartCoroutine(RenderLine());
        }
    }

    IEnumerator RenderLine()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(LaserDuration);
        lineRenderer.enabled = false;
    }
}
