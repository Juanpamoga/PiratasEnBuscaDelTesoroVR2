using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsRotation : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitud del movimiento
    public float frequency = 1f; // Frecuencia del movimiento

    public List<GameObject> targetObjects; // Lista de GameObjects a mover

    private List<Vector3> initialPositions;

    private void Start()
    {
        if (targetObjects == null || targetObjects.Count == 0)
        {
            Debug.LogError("No se han asignado GameObjects objetivo.");
            enabled = false; // Deshabilita el script si no se asigna ningún GameObject
            return;
        }

        initialPositions = new List<Vector3>();
        foreach (GameObject targetObject in targetObjects)
        {
            initialPositions.Add(targetObject.transform.position);
        }
    }

    private void Update()
    {
        if (targetObjects == null || targetObjects.Count == 0)
            return;

        // Calcula la nueva posición en base al tiempo y los parámetros de amplitud y frecuencia
        float offsetX = amplitude * Mathf.Sin(Time.time * frequency);
        float offsetY = amplitude * Mathf.Cos(Time.time * frequency);

        for (int i = 0; i < targetObjects.Count; i++)
        {
            GameObject targetObject = targetObjects[i];
            Vector3 initialPosition = initialPositions[i];

            Vector3 newPosition = new Vector3(initialPosition.x + offsetX, initialPosition.y + offsetY, initialPosition.z);

            // Actualiza la posición del transform del GameObject objetivo
            targetObject.transform.position = newPosition;
        }
    }
}
