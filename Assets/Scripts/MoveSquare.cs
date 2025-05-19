using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    // Start is called before the first frame update
    void Start()
    {
        float speed = GetSpeed();
        SetSpeed(speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if(hori != 0 || vert != 0)
        {
            Vector3 direction = new Vector3(hori, vert, 0);
            transform.position += direction * (_speed * Time.deltaTime);
        }
    }

    public float GetSpeed() => _speed;
    public void SetSpeed(float speed)
    {
        if (speed <= 0)
        {
            _speed = Mathf.Max(10, speed);
            Debug.Log($"Per poter saltare sugli altri livelli, la velocità non può essere 0!");
        }
    }
}
