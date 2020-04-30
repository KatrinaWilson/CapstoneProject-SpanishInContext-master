using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayScript : MonoBehaviour
{
	public Text playerName;
	public InputField nameOfplayer;
	public InputField minFreq;
	public InputField maxFreq;


	public static string PlayerName;
	public static int freqMin = 1;
	public static int freqMax = 5001;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    public void play()
    {

		PlayerName = playerName.text;
		if (PlayerName != "" && minFreq.text != "" && maxFreq.text != "")
		{
			
			int.TryParse(minFreq.text, out freqMin);
			int.TryParse(maxFreq.text, out freqMax);
			SceneManager.LoadScene("MainLevel");
		}
		



        
    }
}
