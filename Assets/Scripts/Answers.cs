
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Answers : MonoBehaviour
{
	public Texture[] imageAnswers = new Texture[question.VocabItems.Count];

	

	public static bool all = true;
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

	private void Awake()
	{
		// don't destroy this game object when a new scene is loaded
		DontDestroyOnLoad(this.gameObject);
		//answerIndex = question.questionIndex;
		//Debug.Log(answerIndex + " answer index");
	}
	// Start is called before the first frame update
	void Start()
	{
		//DontDestroyOnLoad(this.gameObject);

		answerIndex = question.questionIndex;
		Debug.Log(answerIndex + " answer index");
		Debug.Log(question.PromptCategory[answerIndex] + " is the prompt category at question index");

		//vocabItem = prompt
		//translation = english of prompt
		/*prompt category
		  - MC = translation
		  - PC = picture
		  - other = whatever is in the actual cell
		  */
		// frequecy = how often the words are used in the language
		// Section = answer options should come from the same section as the prompt


		/*
		if (question.PromptCategory[answerIndex] == "MC")
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

			indexOne = Random.Range(0, question.Translation.Count);
			indexTwo = Random.Range(0, question.Translation.Count);
			indexThree = Random.Range(0, question.Translation.Count);
			indexFour = Random.Range(0, question.Translation.Count);
			indexFour = Random.Range(0, question.Translation.Count);
			indexSix = Random.Range(0, question.Translation.Count);

			optionOne.text = question.Translation[indexOne].ToString();
			optionTwo.text = question.Translation[indexTwo].ToString();
			optionThree.text = question.Translation[indexThree].ToString();
			optionFour.text = question.Translation[indexFour].ToString();
			optionFive.text = question.Translation[indexFive].ToString();
			optionSix.text = question.Translation[indexSix].ToString();

			Debug.Log(question.VocabItems[answerIndex] + "is the question");
			int randomAnswer = Random.Range(0, answerOptions.Length);
			answerOptions[randomAnswer].text = question.Translation[answerIndex].ToString();

		} else if (question.PromptCategory[answerIndex] == "picture")
		{
				Debug.Log("ummm");

				optionOneP.gameObject.SetActive(true);
				optionTwoP.gameObject.SetActive(true);
				optionThreeP.gameObject.SetActive(true);
				optionFourP.gameObject.SetActive(true);
				optionFiveP.gameObject.SetActive(true);
				optionSixP.gameObject.SetActive(true);

				indexOne = Random.Range(0, question.Translation.Count);
				indexTwo = Random.Range(0, question.Translation.Count);
				indexThree = Random.Range(0, question.Translation.Count);
				indexFour = Random.Range(0, question.Translation.Count);
				indexFour = Random.Range(0, question.Translation.Count);
				indexSix = Random.Range(0, question.Translation.Count);

			Debug.Log(question.VocabItems[answerIndex] + "is the question");
			// load random pictures
			int randomAnswer = Random.Range(0, answerOptions.Length);
			answerOptions[randomAnswer].text = question.Translation[answerIndex].ToString();




		} else if (question.PromptCategory[answerIndex] != "MC" && question.PromptCategory[answerIndex] != "PC")
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

			indexOne = Random.Range(0, question.Translation.Count);
			indexTwo = Random.Range(0, question.Translation.Count);
			indexThree = Random.Range(0, question.Translation.Count);
			indexFour = Random.Range(0, question.Translation.Count);
			indexFour = Random.Range(0, question.Translation.Count);
			indexSix = Random.Range(0, question.Translation.Count);

			optionOne.text = question.Translation[indexOne].ToString();
			optionTwo.text = question.Translation[indexTwo].ToString();
			optionThree.text = question.Translation[indexThree].ToString();
			optionFour.text = question.Translation[indexFour].ToString();
			optionFive.text = question.Translation[indexFive].ToString();
			optionSix.text = question.Translation[indexSix].ToString();

			Debug.Log(question.VocabItems[answerIndex] + "is the question");
			int randomAnswer = Random.Range(0, answerOptions.Length);
			answerOptions[randomAnswer].text = question.PromptCategory[answerIndex].ToString();
		}
			
		

	
	}

	public void reload()
	{
		//checking option chosen
		Debug.Log(EventSystem.current.currentSelectedGameObject.tag);

		//test answers
		if (EventSystem.current.currentSelectedGameObject.tag == "option1")
		{
			if (optionOne.text == question.Translation[answerIndex] || optionOne.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionOne.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}else
			{
				nextButton.text = "Ay No";
				optionOne.color = Color.red;
				question.missedCount++;
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option2")
		{
			if (optionTwo.text == question.Translation[answerIndex] || optionTwo.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionTwo.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionTwo.color = Color.red;
				question.missedCount++;
			}

			optionOne.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option3")
		{
			if (optionThree.text == question.Translation[answerIndex] || optionThree.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionThree.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionThree.color = Color.red;
				question.missedCount++;
			}

			optionTwo.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option4")
		{
			if (optionFour.text == question.Translation[answerIndex] || optionFour.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionFour.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionFour.color = Color.red;
				question.missedCount++;
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option5")
		{
			if (optionFive.text == question.Translation[answerIndex] || optionFive.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionFive.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionFive.color = Color.red;
				question.missedCount++;
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);
			optionSix.gameObject.SetActive(false);

		}
		else if (EventSystem.current.currentSelectedGameObject.tag == "option6")
		{
			if (optionSix.text == question.Translation[answerIndex] || optionSix.text == question.PromptCategory[answerIndex])
			{
				nextButton.text = "Bien";
				optionSix.color = Color.green;
				question.scoreCount++;
				question.VocabItems.RemoveAt(answerIndex);
			}
			else
			{
				nextButton.text = "Ay No";
				optionSix.color = Color.red;
				question.missedCount++;
			}

			optionTwo.gameObject.SetActive(false);
			optionThree.gameObject.SetActive(false);
			optionFour.gameObject.SetActive(false);
			optionFive.gameObject.SetActive(false);
			optionOne.gameObject.SetActive(false);

		}

		nextButton.gameObject.SetActive(true);
	}

	public void next()
	{

	
		// while the list still has items keep reloading the scene
		if (question.VocabItems.Count > 0)
		{
			//SceneManager.LoadScene("MainLevel");
			question.A_question();
		}
		else
		{
			//when the list is empty the game is over, exit
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}



}
	
*/