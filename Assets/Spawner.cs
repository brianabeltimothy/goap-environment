using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject patient;
    public int patientsNum;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < patientsNum; i++){
            Instantiate(patient, this.transform.position, Quaternion.identity);
        }

        Invoke("SpawnPatient", 5f);
    }

    void SpawnPatient()
    {
        Instantiate(patient, this.transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(5, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
