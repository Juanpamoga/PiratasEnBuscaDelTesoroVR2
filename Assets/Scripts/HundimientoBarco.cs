using Unity.VisualScripting;
using UnityEngine;

public class HundimientoBarco : MonoBehaviour
{
    public float fuerzaFlotacion = 2000f;  // Aumenta la fuerza de flotaci�n para un hundimiento m�s lento
    public float fuerzaInclinacion = 500f; // Aumenta la fuerza de inclinaci�n para una mayor rotaci�n lateral

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

            // Aplicar fuerza de flotaci�n hacia arriba
            barcoRigidbody.AddForce(Vector3.up * fuerzaFlotacion);
        }
    }

    private void FixedUpdate()
    {
        if (hundiendose)
        {
            // Calcular la duraci�n del hundimiento
            float tiempoTranscurrido = Time.time - tiempoInicioHundimiento;

            // Aumentar la fuerza de inclinaci�n a medida que pasa el tiempo para una mayor rotaci�n lateral
            float fuerzaInclinacionActual = fuerzaInclinacion * tiempoTranscurrido;
            barcoRigidbody.AddTorque(Vector3.right * fuerzaInclinacionActual);
        }
    }
}
