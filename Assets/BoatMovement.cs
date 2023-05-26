using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
   public Transform startPoint;  // Punto de partida
    public Transform endPoint;    // Punto de destino
    public Transform controlPoint;    // Punto de control
    public float speed = 1.0f;    // Velocidad de movimiento
    public float floatAmplitude = 0.5f;    // Amplitud de oscilación vertical
    public float floatFrequency = 1.0f;    // Frecuencia de oscilación vertical

    private float startTime;
    private float journeyLength;
    private bool isMoving = false;

    private void Start()
    {
        // Calcula la distancia total del movimiento
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }

    private void Update()
    {
        if (isMoving)
        {
            // Calcula la distancia recorrida en base al tiempo transcurrido
            float distanceCovered = (Time.time - startTime) * speed;

            // Calcula el porcentaje de distancia recorrida
            float fractionOfJourney = distanceCovered / journeyLength;

            // Calcula la posición a lo largo de la curva de Bezier
            Vector3 position = BezierCurve(startPoint.position, controlPoint.position, endPoint.position, fractionOfJourney);

            // Aplica la oscilación vertical
            float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            position += new Vector3(0f, floatOffset, 0f);

            // Mueve el objeto a la posición calculada
            transform.position = position;

            // Si alcanza el punto de destino, detiene el movimiento
            if (fractionOfJourney >= 1.0f)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Inicia el movimiento del objeto cuando el jugador entra en colisión
            startTime = Time.time;
            isMoving = true;
        }
    }

    private Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // Calcula una posición en la curva de Bezier en base a los puntos de control y el parámetro t
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 position = uuu * p0; // (1-t)^3 * p0
        position += 3 * uu * t * p1; // 3 * (1-t)^2 * t * p1
        position += 3 * u * tt * p2; // 3 * (1-t) * t^2 * p2
        position += ttt * endPoint.position; // t^3 * p3

        return position;
    }

}
