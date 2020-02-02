using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject healthControl; // the object controlling the health
    public GameObject gameoverText;
    public GameObject resetText;
    public GameObject ship;
    public bool gameState; // marks if game is still going
    // Start is called before the first frame update
    void Start()
    {
        gameState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((healthControl.GetComponent<Health_Control>().health <= 0) && gameState)
        {
            gameState = false;
            gameoverText.transform.position = new Vector3(0.0f, 0.0f);
            resetText.transform.position = new Vector3(0.0f, -2.0f);
        }

        if (!gameState) { ship.transform.position += new Vector3(0.0f, -0.25f); } 

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
