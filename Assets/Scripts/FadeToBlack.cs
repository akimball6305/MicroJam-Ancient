using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class FadeToBlack : MonoBehaviour
{
    public float fadeSpeed = .25f; 

    [SerializeField] Image fadeImage;

    public void FadeOut()
    { 
        StartCoroutine(FadeCoroutine(1f)); 
    }

    IEnumerator FadeCoroutine(float targetAlpha)
    {
        while (fadeImage.color.a < targetAlpha)
        {

            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + (fadeSpeed * Time.deltaTime));

            yield return null;

        }
    }
}
