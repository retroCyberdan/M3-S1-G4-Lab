using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    // Creo le variabili private e serializzabili
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startPosition;
    
    //Creao una variabile pubblica float
    public float maxDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        //Richiamo il Getter e il Setter per il controllo della velocità (giusto per fare un refresh)
        float speed = GetSpeed();
        SetSpeed(speed);

        //Assegno alla variabile "_startPosition" il punto di partenza del mio "Square"
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Creo due variabli per determinare le coordinate assiali
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Il ciclo viene eseguito non appena c'è un movimento 
        if(hor != 0 || ver != 0)
        {
            //Creo un Vettore con coordinate "x" il valore di "hor" e per "y" il valore di "ver"
            //("z" sarà "0" poichè è un vettore bidimensionale). Calcolo, quindi, il movimento
            Vector3 direction = new Vector3(hor, ver, 0);

            //sommo ai parametri di "position" il mio vettore, la velocità che imposto
            //e il deltaTime (ovvero il tempo tra un frame e l'altro : 1m/s)
            transform.position += direction * (_speed * Time.deltaTime);

            //un'alternativa può essere:
            //transform.position += new Vector3(hor, ver, 0) * (_speed * Time.deltaTime);
            //dove creao un nuovo vettore direttamente nella linea dove eseguo il calcolo

            //In una variabile float mi calcolo la distanza tra la posizione attuale e quella iniziale
            //tramite la proprietà "Distance" dei Vector2
            float distance = Vector2.Distance(transform.position, _startPosition);

            //La condizione per ripristinare lo "Square" in posizione di partenza (_startPosition) è che
            //il valore di "distance" superi quello che ho scelto come "maxDistance"
            if (distance > maxDistance)
            {
                transform.position = _startPosition;// <- lo riporto al punto di partenza
            }
        }
    }

    //Creo i Get/Set per il controllo della "_speed"
    public float GetSpeed() => _speed;
    public void SetSpeed(float speed)
    {
        if (speed < 10)
        {
            _speed = Mathf.Max(10, speed);
            Debug.Log($"Il valore della la velocità deve essere almeno {_speed}!");
        }
    }
}
