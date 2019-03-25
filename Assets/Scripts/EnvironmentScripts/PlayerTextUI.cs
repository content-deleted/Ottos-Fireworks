using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayerTextUI : MonoBehaviour
{
    public static PlayerTextUI singleton;
    private Text textRender;

    private Image image;
    public List<string> helpMessages = new List<string>();

    public float textSpeed;
    void Awake()
    {
        textRender = GetComponent<Text>();
        image = transform.parent.GetComponent<Image>();
        singleton = this;
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;
        transform.parent.gameObject.SetActive(false);
    }

    public void startPush(){
        if(!gameObject.activeInHierarchy){
            transform.parent.gameObject.SetActive(true);
            StartCoroutine(push());
        }
    }
    public int waitBetweenMessages = 200;
    IEnumerator push()
    {
        while (image.color.a < 1)
        {

            var temp = image.color;
            temp.a += 0.01f;
            image.color = temp;
            yield return new WaitForEndOfFrame();
        }
        while (helpMessages.Any())
            foreach (string text in helpMessages.ToList())
            {
                foreach (char c in text.ToCharArray())
                {
                    textRender.text = textRender.text + c;
                    yield return new WaitForSeconds(textSpeed);
                }
                if (!text.Equals(helpMessages.Last()))
                {
                    yield return new WaitForSeconds(textSpeed * 50);
                    textRender.text = "";
                }
            }

        while (image.color.a > 0)
        {

            var temp = image.color;
            temp.a -= 0.01f;
            image.color = temp;
            yield return new WaitForEndOfFrame();
        }

        transform.parent.gameObject.SetActive(false);
    }
}