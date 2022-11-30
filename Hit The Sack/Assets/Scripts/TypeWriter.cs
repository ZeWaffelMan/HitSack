using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	public GameObject nextText;

	private void Start()
	{
		StartCoroutine(ShowText());
		StartCoroutine(Done());
	}
    private void Update()
    {

    }
    IEnumerator ShowText()
	{
		for (int i = 0; i < fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);

			if (i == fullText.Length - 1)
			{
				StartCoroutine(NextText());
			}
		}
	}

	IEnumerator Done()
	{
		yield return new WaitForSeconds(5f);
	}

	IEnumerator NextText()
    {
		yield return new WaitForSeconds(3);
        nextText.SetActive(true);
		this.gameObject.SetActive(false);
    }
}
