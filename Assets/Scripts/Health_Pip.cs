using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pip : MonoBehaviour
{
    public int pipNumber; // which pip it is; set by health controller
    public GameObject healthControl; // the health controller
    // Start is called before the first frame update
    void Start()
    {
        healthControl = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthControl.GetComponent<Health_Control>().health < pipNumber)
        {
            healthControl.GetComponent<Health_Control>().pipCount -= 1;
            Destroy(gameObject);
        }
    }
}
