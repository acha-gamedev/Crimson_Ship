using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Node : MonoBehaviour
{
    /// Generates the nodes at random
    public GameObject node; // the node gameobject to use
    public float spawnDelay; // the delay between spawns, in seconds; set randomly
    public GameObject score; // holds the scoring object
    public GameObject health; // holds the health controller

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Scoring");
        health = GameObject.FindGameObjectWithTag("GameController");
        spawnDelay = Random.Range(2.0f, Mathf.Max(10.0f - (score.GetComponent<ScoreCounter>().score * 0.4f), 6.0f)); // sets the delay in seconds
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if ((spawnDelay <= 0.0f) && (health.GetComponent<Health_Control>().health > 0))
        {
            GameObject spawn = Instantiate(node);
            spawn.transform.position = new Vector3(Random.Range(-7.0f, 5.0f), Random.Range(-3.0f, 3.0f));
            // Range is (left, right), (bottom, top)
            spawnDelay = Random.Range(1.0f, Mathf.Max(10.0f - (score.GetComponent<ScoreCounter>().score * 0.4f), 2.0f)); // resets the delay in seconds
        }
    }
}
