using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Control : MonoBehaviour
{
    public int maxHealth; // maximum amount of health
    public int health; // amount of health; set to starting value
    public int pipCount;
    public GameObject healthIcon; // the health icon object

    // Start is called before the first frame update
    void Start()
    {
        pipCount = 0;
        while (pipCount < health)
        {
            GameObject pip = Instantiate(healthIcon);
            pip.transform.position = new Vector3(4.0f + pipCount, 4.3f);
            pipCount += 1;
            pip.GetComponent<Health_Pip>().pipNumber = pipCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        while (pipCount < health)
        {
            GameObject pip = Instantiate(healthIcon);
            pip.transform.position = new Vector3(4.0f + pipCount, 4.3f);
            pipCount += 1;
            pip.GetComponent<Health_Pip>().pipNumber = pipCount;
        }

        //if (health <= 0)
        //{
        //    // Game Over Sequence
        //}
    }
}
