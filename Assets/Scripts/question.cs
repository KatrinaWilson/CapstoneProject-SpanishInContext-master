using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class question : MonoBehaviour
{

	public Sprite[] picNames;

	public static bool all = false;
	public static bool zero = false;
	public static bool one = false;
	public static bool two = false;
	public static bool three = false;
	public static bool four = false;
	public static bool five = false;
	public static bool six = false;
	public static bool seven = false;
	public static bool eight = false;
	public static bool nine = false;
	public static bool ten = false;
	public static TextAsset dataText;
	

	public Text playerName;
	public Text score;
	public Text missed;
	public Text freq;
	public Text prompt;
	

	public static int freqMax = PlayScript.freqMax;
	public static int freqMin = PlayScript.freqMin;
	public static int scoreCount = 0;
	public static int missedCount = 0;
	public static int questionIndex;
	public static int outOf;

	public int chapter;
	public string section;
	public string vocabItem;
	public string translation;
	public string promptCategory;
	public string pictureName;
	public int frequency;

	public static List<int> Chapter = new List<int>();
	public static List<string> Section = new List<string>();
	public static List<string> VocabItems = new List<string>();
	public static List<string> Translation = new List<string>();
	public static List<string> PromptCategory = new List<string>();
	public static List<string> PictureName = new List<string>();
	public static List<int> Frequency = new List<int>();


	public Text optionOne;
	public Text optionTwo;
	public Text optionThree;
	public Text optionFour;
	public Text optionFive;
	public Text optionSix;
	public Text nextButton;
	public Text[] answerOptions = new Text[6];

	public Image optionOneP;
	public Image optionTwoP;
	public Image optionThreeP;
	public Image optionFourP;
	public Image optionFiveP;
	public Image optionSixP;
	public Image[] answerImages = new Image[6];
	
	public int indexOne;
	public int indexTwo;
	public int indexThree;
	public int indexFour;
	public int indexFive;
	public int indexSix;

	public static int answerIndex;


	public void Start()
	{
		picNames = Resources.LoadAll<Sprite>("");

		string[] data = dataText.text.Split(new char[] { '\n' });
		for (int i = 1; i < data.Length; i++)
		{
			string[] row = data[i].Split(new char[] { ',' });
			if (row[1] != "")
			{


				int.TryParse(row[0], out chapter);
				section = row[1];
				vocabItem = row[2];
				translation = row[3];
				promptCategory = row[4];
				int.TryParse(row[5], out frequency);
				pictureName = row[6];

				Chapter.Add(chapter);
				Section.Add(section);
				VocabItems.Add(vocabItem);
				Translation.Add(translation);
				PromptCategory.Add(promptCategory);
				Frequency.Add(frequency);
				PictureName.Add(pictureName);
			}
		}


		Debug.Log(VocabItems.Count);
		Debug.Log(Chapter.Count);
		Debug.Log(Section.Count);
		Debug.Log(Translation.Count);
		Debug.Log(PromptCategory.Count);
		Debug.Log(Frequency.Count);
		Debug.Log(PictureName.Count);
		

		for ( int k = 0; k < Frequency.Count; k++)
		{
			
			int number;
			int anumber;
			number = Frequency[k];
			anumber = Frequency[k];
			if (number > freqMax || anumber < freqMin)
			{
				VocabItems.RemoveAt(number);
				Chapter.RemoveAt(number);
				Section.RemoveAt(number);
				PromptCategory.RemoveAt(number);
				PictureName.RemoveAt(number);
				Frequency.RemoveAt(number);
				Translation.RemoveAt(number);
				
			}
		}
		Debug.Log(" " + VocabItems.Count);
		Debug.Log(" " + Chapter.Count);
		Debug.Log(" " + Section.Count);
		Debug.Log(" " + Translation.Count);
		Debug.Log(" " + PromptCategory.Count);
		Debug.Log(" " + Frequency.Count);
		Debug.Log(" " + PictureName.Count);
		outOf = VocabItems.Count;
		A_question();
	}


	public void A_question()
	{
		questionIndex = Random.Range(0, VocabItems.Count);
		nextButton.gameObject.SetActive(false);


		prompt.text = VocabItems[questionIndex].ToString();
		playerName.text = "Player: " + PlayScript.PlayerName; //"Player Name: Katrina Wilson";
		score.text = "Score: " + scoreCount; // + " / "; // + outOf;
		missed.text = "Missed: " + missedCount;
		freq.text = "Frequency: " + PlayScript.freqMin + " - " + PlayScript.freqMax;
		Answers();

	}

	public void Answers()
	{
		answerIndex = questionIndex;

		optionOne.color = Color.white;
		optionTwo.color = Color.white;
		optionThree.color = Color.white;
		optionFive.color = Color.white;
		optionFour.color = Color.white;
		optionSix.color = Color.white;

		optionOneP.color = Color.white;
		optionTwoP.color = Color.white;
		optionThreeP.color = Color.white;
		optionFiveP.color = Color.white;
		optionFourP.color = Color.white;
		optionSixP.color = Color.white;


		if (PromptCategory[answerIndex] == "MC")
		{
			optionOneP.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

			optionOne.gameObject.SetActive(true);
			optionTwo.gameObject.SetActive(true);
			optionThree.gameObject.SetActive(true);
			optionFour.gameObject.SetActive(true);
			optionFive.gameObject.SetActive(true);
			optionSix.gameObject.SetActive(true);

			indexOne = Random.Range(0, Translation.Count);
			indexTwo = Random.Range(0, Translation.Count);
			indexThree = Random.Range(0, Translation.Count);
			indexFour = Random.Range(0, Translation.Count);
			indexFive = Random.Range(0, Translation.Count);
			indexSix = Random.Range(0, Translation.Count);

			optionOne.text = Translation[indexOne].ToString();
			optionTwo.text = Translation[indexTwo].ToString();
			optionThree.text = Translation[indexThree].ToString();
			optionFour.text = Translation[indexFour].ToString();
			optionFive.text = Translation[indexFive].ToString();
			optionSix.text = Translation[indexSix].ToString();

			int randomAnswer = Random.Range(0, answerOptions.Length);
			answerOptions[randomAnswer].text = Translation[answerIndex].ToString();

		}
		else if (PromptCategory[answerIndex] == "picture")
		{
			
			optionOne.gameObject.SetActive(false);
			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

			optionOneP.gameObject.SetActive(true);
			optionTwoP.gameObject.SetActive(true);
			optionThreeP.gameObject.SetActive(true);
			optionFourP.gameObject.SetActive(true);
			optionFiveP.gameObject.SetActive(true);
			optionSixP.gameObject.SetActive(true);


			indexOne = Random.Range(0, picNames.Length);
			indexTwo = Random.Range(0, picNames.Length);
			indexThree = Random.Range(0, picNames.Length);
			indexFour = Random.Range(0, picNames.Length);
			indexFive = Random.Range(0, picNames.Length);
			indexSix = Random.Range(0, picNames.Length);

			string str = PictureName[answerIndex];
			
			int answer = System.Array.IndexOf(picNames, str);
			

			optionOneP.GetComponent<Image>().sprite = picNames[indexOne];
			optionTwoP.GetComponent<Image>().sprite = picNames[indexTwo];
			optionThreeP.GetComponent<Image>().sprite = picNames[indexThree];
			optionFourP.GetComponent<Image>().sprite = picNames[indexFour];
			optionFiveP.GetComponent<Image>().sprite = picNames[indexFive];
			optionSixP.GetComponent<Image>().sprite = picNames[indexSix];

			int randomAnswer = Random.Range(0, answerImages.Length);
			answerImages[randomAnswer].GetComponent<Image>().sprite = Resources.Load<Sprite>(str); 
	
		}
		else if (PromptCategory[answerIndex] != "MC" && PromptCategory[answerIndex] != "PC")
		{
			optionOneP.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

			optionOne.gameObject.SetActive(true);
			optionTwo.gameObject.SetActive(true);
			optionThree.gameObject.SetActive(true);
			optionFour.gameObject.SetActive(true);
			optionFive.gameObject.SetActive(true);
			optionSix.gameObject.SetActive(true);

			indexOne = Random.Range(0, Translation.Count);
			indexTwo = Random.Range(0, Translation.Count);
			indexThree = Random.Range(0, Translation.Count);
			indexFour = Random.Range(0, Translation.Count);
			indexFive = Random.Range(0, Translation.Count);
			indexSix = Random.Range(0, Translation.Count);

			optionOne.text = VocabItems[indexOne].ToString();
			optionTwo.text = VocabItems[indexTwo].ToString();
			optionThree.text = VocabItems[indexThree].ToString();
			optionFour.text = VocabItems[indexFour].ToString();
			optionFive.text = VocabItems[indexFive].ToString();
			optionSix.text = VocabItems[indexSix].ToString();

			int randomAnswer = Random.Range(0, answerOptions.Length);
			answerOptions[randomAnswer].text = PromptCategory[answerIndex].ToString();
		}
	}

	public void reload()
	{
		//checking option chosen
		//Debug.Log(EventSystem.current.currentSelectedGameObject.tag);

		//test answers
		if (EventSystem.current.currentSelectedGameObject.tag == "option1")
		{
			if (optionOne.text == Translation[answerIndex] || optionOne.text == PromptCategory[answerIndex] || optionOneP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[answerIndex]))
			{
				nextButton.text = "Bien";
				optionOne.color = Color.green;
				optionOneP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionOne.color = Color.red;
				optionOneP.color = Color.red;
				missedCount++;
				
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option2")
		{
			if (optionTwo.text == Translation[answerIndex] || optionTwo.text == PromptCategory[answerIndex] || optionTwoP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[answerIndex]))
			{
				nextButton.text = "Bien";
				optionTwo.color = Color.green;
				optionTwoP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionTwo.color = Color.red;
				optionTwoP.color = Color.red;
				missedCount++;
				
			}

			optionOne.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);
			optionOneP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option3")
		{
			if (optionThree.text == Translation[answerIndex] || optionThree.text == PromptCategory[answerIndex] || optionThreeP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[answerIndex]))
			{
				nextButton.text = "Bien";
				optionThree.color = Color.green;
				optionThreeP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionThree.color = Color.green;
				optionThreeP.color = Color.green;
				missedCount++;
				
			}

			optionTwo.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionOneP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option4")
		{
			if (optionFour.text == Translation[answerIndex] || optionFour.text == PromptCategory[answerIndex] || optionFourP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[answerIndex]))
			{
				nextButton.text = "Bien";
				optionFour.color = Color.green;
				optionFourP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionFour.color = Color.red;
				optionFourP.color = Color.red;
				missedCount++;
				
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionOneP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);
		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option5")
		{
			if (optionFive.text == Translation[answerIndex] || optionFive.text == PromptCategory[answerIndex] || optionFiveP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[indexTwo]))
			{
				nextButton.text = "Bien";
				optionFive.color = Color.green;
				optionFiveP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionFive.color = Color.red;
				optionFiveP.color = Color.red;
				missedCount++;
				
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionOneP.gameObject.SetActive(false);
			optionSixP.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option6")
		{
			if (optionSix.text == Translation[answerIndex] || optionSix.text == PromptCategory[answerIndex] || optionSixP.GetComponent<Image>().sprite == Resources.Load<Sprite>(PictureName[answerIndex]))
			{
				nextButton.text = "Bien";
				optionSix.color = Color.green;
				optionSixP.color = Color.green;
				scoreCount++;
				VocabItems.RemoveAt(answerIndex);
				Chapter.RemoveAt(questionIndex);
				Section.RemoveAt(questionIndex);
				PromptCategory.RemoveAt(questionIndex);
				Frequency.RemoveAt(questionIndex);
				Translation.RemoveAt(questionIndex);
				PictureName.RemoveAt(questionIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionSix.color = Color.red;
				optionSixP.color = Color.red;
				missedCount++;
				
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionTwoP.gameObject.SetActive(false);
			optionThreeP.gameObject.SetActive(false);
			optionFourP.gameObject.SetActive(false);
			optionFiveP.gameObject.SetActive(false);
			optionOneP.gameObject.SetActive(false);

		}

		nextButton.gameObject.SetActive(true);
	}

	public void next()
	{


		// while the list still has items keep reloading the scene
		if (VocabItems.Count > 0)
		{
			
			A_question();
		}
		else
		{
			SceneManager.LoadScene("Close");
		}
	}








}






