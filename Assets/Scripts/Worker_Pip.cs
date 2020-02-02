using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker_Pip : MonoBehaviour
{
    public int pipNumber; // which pip it is; set by controller
    public GameObject node; // which node created the worker; set by node
    public GameObject crewControl; // the crew controller object
    // Start is called before the first frame update
    void Start()
    {
        crewControl = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (node.GetComponent<Node>().assignCrew < pipNumber)
        {
            node.GetComponent<Node>().pipCount -= 1;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        node.GetComponent<Node>().assignCrew -= 1;
        crewControl.GetComponent<Crew_Control>().crew += 1;
    }
}
