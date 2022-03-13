using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    public GameObject fade;

    private void OnTriggerEnter(Collider other)
    {
        fade.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("ToBeContinued");
    }
}
