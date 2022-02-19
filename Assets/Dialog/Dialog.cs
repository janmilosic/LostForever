using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDispay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDispay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
