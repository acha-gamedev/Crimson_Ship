using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Pip : MonoBehaviour
{
    public int pipNumber; // which pip it is; set by crew controller
    public GameObject crewControl; // the crew controller object
    // Start is called before the first frame update
    void Start()
    {
        crewControl = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (crewControl.GetComponent<Crew_Control>().crew < pipNumber)
        {
            crewControl.GetComponent<Crew_Control>().pipCount -= 1;
            Destroy(gameObject);
        }
    }
}
