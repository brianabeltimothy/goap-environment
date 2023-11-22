using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld {

    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> qubicles;

    private GWorld() {

    }

    static GWorld() {

        world = new WorldStates();
        patients = new Queue<GameObject>();
        qubicles = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
        {
            qubicles.Enqueue(c);
        }

        if(cubes.Length > 0)
        {
            world.ModifyState("FreeCubicle", cubes.Length);
        }

        Time.timeScale = 5;
    }
    public void AddQubicle(GameObject q)
    {
        qubicles.Enqueue(q);
    }

     public GameObject RemoveQubicle()
    {
        if(qubicles.Count == 0) return null;
        return qubicles.Dequeue();
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if(patients.Count == 0) return null;
        return patients.Dequeue();
    }

    public static GWorld Instance {

        get { return instance; }
    }

    public WorldStates GetWorld() {

        return world;
    }
}
