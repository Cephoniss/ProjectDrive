using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float carSpeed = 1f;
    [SerializeField] float speedGain = 1f;
    [SerializeField] float turnSpeed  = 100f;
    
    private int steerValue;
    

    void Update()
    {
        CarMovement();
    }

    void CarMovement()
    {
        //Moves car forward automatically per frame
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        //Rotates car using sterrValue and turn speed
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        //Car will gain speed as per vaule in speedGain
        carSpeed += speedGain * Time.deltaTime;
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Obstacles"))
        {
            SceneManager.LoadScene(0);
            Debug.Log("hit");
        }
    }
}
