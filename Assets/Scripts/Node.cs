using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    /// The basic variant of the clickable nodes
    public float spawnTime; // the amount of time before the node despawns
    private float spawnStart; // starting time limit
    public GameObject gameControl; // the object controlling game systems; is initialized in code

    public int assignMax; // the maximum amount of crew that can be assigned to the node
    public int assignCrew; // the active number of crew members on the object; initialize in code
    public float clearTime; // the amount of time to clear the node;
    private float clearStart; // starting clear time

    public int pipCount; // the number of created workers
    public GameObject workerIcon; // the gameobject for the worker 
    public GameObject progressGauge; // the object for the progress gauge
    private GameObject progressGaugeActive; // the active instance of the gauge
    public GameObject timeGauge; // the object for the time gauge
    private GameObject timeGaugeActive; // the active instance of the gauge

    public GameObject scoreTracker; // the object tracking score
    // Start is called before the first frame update
    void Start()
    {
        assignCrew = 0;
        gameControl = GameObject.FindGameObjectWithTag("GameController");
        scoreTracker = GameObject.FindGameObjectWithTag("Scoring");

        spawnTime = Random.Range(2.0f, Mathf.Max(6.0f - (scoreTracker.GetComponent<ScoreCounter>().score * 0.2f), 4.0f));
        spawnStart = spawnTime;
        timeGaugeActive = Instantiate(timeGauge);
        timeGaugeActive.transform.position = transform.position + new Vector3(0.0f, -0.75f);

        clearStart = clearTime;
        progressGaugeActive = Instantiate(progressGauge);
        progressGaugeActive.transform.position = transform.position + new Vector3(0.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        timeGaugeActive.transform.localScale = new Vector3(spawnTime / spawnStart, timeGaugeActive.transform.localScale.y, 1.0f);
        clearTime -= Time.deltaTime * assignCrew;
        progressGaugeActive.transform.localScale = new Vector3(clearTime / clearStart, progressGaugeActive.transform.localScale.y, 1.0f);
        if (clearTime <= 0.0f)
        {
            // return crew to supply
            if (gameControl.GetComponent<Health_Control>().health > 0)
            {
                scoreTracker.GetComponent<ScoreCounter>().score += 1;
            }
            gameControl.GetComponent<Crew_Control>().crew += assignCrew;
            assignCrew = 0;
            // delete node
            Destroy(timeGaugeActive);
            Destroy(progressGaugeActive);
            Destroy(gameObject);
            Debug.Log("Node Cleared");
        }
        else if (spawnTime <= 0.0f)
        {
            // signal that the node was missed
            gameControl.GetComponent<Health_Control>().health -= 1;
            gameControl.GetComponent<Crew_Control>().crew += assignCrew;
            assignCrew = 0;
            // delete the node
            Destroy(timeGaugeActive);
            Destroy(progressGaugeActive);
            Destroy(gameObject);
            Debug.Log("Node Missed");
        }

        while (pipCount < assignCrew)
        {
            GameObject pip = Instantiate(workerIcon);
            pip.transform.position = transform.position + new Vector3(-1.0f + pipCount, 1.0f);
            pipCount += 1;
            pip.GetComponent<Worker_Pip>().pipNumber = pipCount;
            pip.GetComponent<Worker_Pip>().node = gameObject;
        }

    }

    private void OnMouseDown()
    {
        // we can add events to this part
        //Destroy(gameObject);
        if ((assignCrew < assignMax) && (gameControl.GetComponent<Crew_Control>().crew > 0) && 
            (gameControl.GetComponent<Health_Control>().health > 0))
        {
            // assign a crew to the node, and remove one from the supply
            assignCrew += 1;
            gameControl.GetComponent<Crew_Control>().crew -= 1;
        }
        Debug.Log("Node Clicked");
    }
}
