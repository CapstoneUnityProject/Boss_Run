using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnAlert : MonoBehaviour
{
    public static TurnAlert instance;

    TextMeshProUGUI text;
    Image backgroundImage;

    public IEnumerator currCoroutine;

    float F_time = 1f;
    float time;
    private void Awake()
    {
        instance = this;
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        backgroundImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void PlayerTurn()
    {
        text.gameObject.SetActive(true);
        text.text = "Player Turn";
        text.fontSize = 32;
        if (currCoroutine != null)
        {
            StopCoroutine(currCoroutine);
        }
        currCoroutine = Turn();
        StartCoroutine(currCoroutine);
    }

    public void EnemyTurn()
    {
        text.gameObject.SetActive(true);
        text.text = "Enemy Turn";
        text.fontSize = 32;
        if (currCoroutine != null)
        {
            StopCoroutine(currCoroutine);
        }
        currCoroutine = Turn();
        StartCoroutine(currCoroutine);
    }

    public void GameOver()
    {
        text.gameObject.SetActive(true);
        backgroundImage.gameObject.SetActive(true);
        text.text = "Game Over";
        text.fontSize = 64;
        if (currCoroutine != null)
        {
            StopCoroutine(currCoroutine);
        }
        currCoroutine = FadeIn();
        StartCoroutine(currCoroutine);
    }

    public IEnumerator FadeIn()
    {
        time = 0;
        text.color = new Color(1, 1, 1, 0);
        Color textColor = text.color;
        Color initImageColor = backgroundImage.color;
        Color imageColor = new Color(0, 0, 0, 0);
        backgroundImage.color = new Color(0, 0, 0, 0);

        while (text.color.a < 1f)
        {
            time += Time.deltaTime / F_time;
            textColor.a = Mathf.Lerp(0, 1, time);
            imageColor.a = Mathf.Lerp(0, initImageColor.a, time);
            text.color = textColor;
            backgroundImage.color = imageColor;

            yield return null;
        }
    }
    public IEnumerator Turn()
    {
        time = 0;
        text.color = new Color(1, 1, 1, 0);
        Color color = text.color;
        text.rectTransform.anchoredPosition = new Vector2(0, 0);

        while (text.color.a < 1f)
        {
            time += Time.deltaTime / F_time;
            text.rectTransform.anchoredPosition = new Vector2(0, Mathf.Lerp(0, 25, time));
            color.a = Mathf.Lerp(0, 1, time);
            text.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        while (text.color.a > 0)
        {
            time -= Time.deltaTime / F_time;
            color.a = Mathf.Lerp(0, 1, time);
            text.color = color;
            yield return null;
        }
        text.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
}