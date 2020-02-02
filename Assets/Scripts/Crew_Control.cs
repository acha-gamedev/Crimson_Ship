using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Control : MonoBehaviour
{
    public int maxCrew; // maximum amount of crew
    public int crew; // amount of crew; set to starting value
    public int pipCount;
    public GameObject crewIcon; // the crew icon object
    // Start is called before the first frame update
    void Start()
    {
        pipCount = 0;
        while (pipCount < crew)
        {
            GameObject pip = Instantiate(crewIcon);
            pip.transform.position = new Vector3(-8.0f + pipCount, 4.3f);
            pipCount += 1;
            pip.GetComponent<Crew_Pip>().pipNumber = pipCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (crew > maxCrew)
        {
            crew = maxCrew;
        }

        while (pipCount < crew)
        {
            GameObject pip = Instantiate(crewIcon);
            pip.transform.position = new Vector3(-8.0f + pipCount, 4.3f);
            pipCount += 1;
            pip.GetComponent<Crew_Pip>().pipNumber = pipCount;
        }
    }
}
