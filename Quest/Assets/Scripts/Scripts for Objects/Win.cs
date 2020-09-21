using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] public AudioClip win;

    [SerializeField] private int delay =5 ;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You are winner!");
            StartCoroutine(Winnner());
        }
    }

    IEnumerator Winnner()
    {
        GetComponent<AudioSource>().PlayOneShot(win);
        yield return new WaitForSeconds(delay);
        LoadMainScene();
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Menu");
    }


}
