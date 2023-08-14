using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    
    public GameObject nota;
    public Transform[] noteSpawnPoints;
    public float noteSpawnDistance = 10.0f;
    public float noteSpawnInterval = 1.0f;
    public float altura = 10;
    public float noteSpeed = 10;
    public float noteLifetime = 10;

    private Transform playerTransform;
    private float nextNoteSpawnTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextNoteSpawnTime = Time.time + noteSpawnInterval;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextNoteSpawnTime)
        {
            CreateNote();
            nextNoteSpawnTime = Time.time + noteSpawnInterval;
        }

        MoveNotes();
    }

    private void CreateNote()
    {
        int randonSpawnIndex = Random.Range(0, noteSpawnPoints.Length);
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * noteSpawnDistance + noteSpawnPoints[randonSpawnIndex].position;
        spawnPosition.y = altura;
        GameObject newNote = Instantiate(nota , spawnPosition, Quaternion.identity);
        Destroy(newNote, noteLifetime);
    } 

    private void MoveNotes()
    {
        GameObject[] nota = GameObject.FindGameObjectsWithTag("Note");
        foreach (var note in nota)
        {
            note.transform.Translate(Vector3.forward * -noteSpeed * Time.deltaTime);
        }

    }
}






