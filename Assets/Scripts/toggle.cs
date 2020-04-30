using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{
    public void toggleAll()
	{
		question.all = true;
		question.dataText = Resources.Load<TextAsset>("all");
	}
	public void toggleZero()
	{
		question.zero = true;
		question.dataText = Resources.Load<TextAsset>("zero");
	}
	public void toggleOne()
	{
		question.one = true;
		question.dataText = Resources.Load<TextAsset>("one");
	}
	public void toggleTwo()
	{
		question.two = true;
		question.dataText = Resources.Load<TextAsset>("two");
	}
	public void toggleThree()
	{
		question.three = true;
		question.dataText = Resources.Load<TextAsset>("three");
	}
	public void toggleFour()
	{
		question.four = true;
		question.dataText = Resources.Load<TextAsset>("four");
	}
	public void toggleFive()
	{
		question.five = true;
		question.dataText = Resources.Load<TextAsset>("five");
	}
	public void toggleSix()
	{
		question.six = true;
		question.dataText = Resources.Load<TextAsset>("six");
	}
	public void toggleSeven()
	{
		question.seven = true;
		question.dataText = Resources.Load<TextAsset>("seven");
	}
	public void toggleEight()
	{
		question.eight = true;
		question.dataText = Resources.Load<TextAsset>("eight");
	}
	public void toggleNine()
	{
		question.nine = true;
		question.dataText = Resources.Load<TextAsset>("nine");
	}
	public void toggleTen()
	{
		question.ten = true;
		question.dataText = Resources.Load<TextAsset>("ten");
	}
}
