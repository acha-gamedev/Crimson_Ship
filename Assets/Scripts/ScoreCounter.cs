using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // contains the components for UI

public class ScoreCounter : MonoBehaviour
{
    public int score; // player's score
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //GetComponent<RectTransform>().position = new Vector3(0, 390);
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
        
    }
}
