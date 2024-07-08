using System.Collections;
using UnityEngine;

public class Blast_Controller : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private float laserRange = 100f, laserDuration = 0.08f;
    [SerializeField] AudioSource audio;
    private Camera cam;
    private LineRenderer lineRenderer;
    private IRayHitHandler rayHitHandler;

    void Start()
    {
        cam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        rayHitHandler = GetComponent<IRayHitHandler>();

        if (rayHitHandler == null)
        {
            Debug.LogError("No se encontró el componente IRayHitHandler en el GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   //llama al Raycast desde el origen dela camara
        {
            RaycastHit hit;
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Ray ray = new Ray(rayOrigin, cam.transform.forward);

            lineRenderer.SetPosition(0, shootPosition.position);

            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(1, hit.point);
                Debug.Log("Raycast hit: " + hit.collider.name);
                rayHitHandler.HandleRayHit(hit);
            }
            else
            {
                lineRenderer.SetPosition(1, shootPosition.position + cam.transform.forward * laserRange);
            }

            StartCoroutine(RenderLine());
        }
    }

    IEnumerator RenderLine()//crea la ilusion de salir de arma
    {
        audio.Play();
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
}
