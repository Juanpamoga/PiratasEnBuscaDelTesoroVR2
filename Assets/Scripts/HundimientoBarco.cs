using Unity.VisualScripting;
using UnityEngine;

public class HundimientoBarco : MonoBehaviour
{
    public float fuerzaFlotacion = 2000f;  // Aumenta la fuerza de flotación para un hundimiento más lento
    public float fuerzaInclinacion = 500f; // Aumenta la fuerza de inclinación para una mayor rotación lateral

    private Rigidbody barcoRigidbody;
    private float tiempoInicioHundimiento;
    private bool hundiendose = false;
    //public bool isDie;

    private void Awake()
    {
        barcoRigidbody = GetComponent<Rigidbody>();
    }

    

    private void Die()
    {
        //isDie = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agua") && !hundiendose)
        {
            //Debug.Log("sz");
            tiempoInicioHundimiento = Time.time;
            hundiendose = true;

            // Aplicar fuerza de flotación hacia arriba
            barcoRigidbody.AddForce(Vector3.up * fuerzaFlotacion);
        }
    }

    private void FixedUpdate()
    {
        if (hundiendose)
        {
            // Calcular la duración del hundimiento
            float tiempoTranscurrido = Time.time - tiempoInicioHundimiento;

            // Aumentar la fuerza de inclinación a medida que pasa el tiempo para una mayor rotación lateral
            float fuerzaInclinacionActual = fuerzaInclinacion * tiempoTranscurrido;
            barcoRigidbody.AddTorque(Vector3.right * fuerzaInclinacionActual);
        }
    }
}
