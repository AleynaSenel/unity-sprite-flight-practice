using System.IO;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    Rigidbody2D rb;

    public float minSpeed = 50f;
    public float maxSpeed = 150f;
   // public float maxSpinSpeed = 10f;

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize) ;      // aralýktaki deðerlerle rastgele boyut verdi 
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        float randomSpeed = Random.Range(minSpeed , maxSpeed) ;   // aralýktaki deðerlerlerle rastgele hýz verdi
        Vector2 randomDirection = Random.insideUnitCircle;   // rastgele yön verdi

       rb = GetComponent<Rigidbody2D>();
       rb.AddForce(randomDirection * randomSpeed);

       // float randomTorque = Random.Range(-maxSpinSpeed,maxSpinSpeed) ;
       // rb.AddTorque(randomTorque);         tam tur hýzlý spin attýrmak istersek
    }


    void Update()
    {

    }
}
