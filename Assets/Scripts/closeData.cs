using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeData : MonoBehaviour
{
	public Text playername;
	public Text score;
	public Text missed;
	public Text freq;

	public static int scorenumber = question.scoreCount;
	public static int missednumber = question.missedCount;
    // Start is called before the first frame update
    void Start()
    {
		playername.text = "Name: " + PlayScript.PlayerName;
		score.text = "Score: " + scorenumber;
		missed.text = "Missed: " + missednumber;
		freq.text = "Frequency: " + PlayScript.freqMin + " - " + PlayScript.freqMax;
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
