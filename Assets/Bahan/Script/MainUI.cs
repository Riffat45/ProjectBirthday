using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    Button[] buttons;
    [SerializeField]CanvasGroup[] cgs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedButton(int type)
    {
        IEnumerator T1()
        {
            //transisi button keluar screen
            for (int i = 0; i <= 2; i++)
            {
                buttons[i].GetComponent<Button>().interactable = false;
                if (i == 1)
                {
                    buttons[i].transform.DOMoveY(buttons[i].transform.position.y - 720, 1).SetEase(Ease.InOutCubic);
                }
                else
                {
                    buttons[i].transform.DOMoveY(buttons[i].transform.position.y + 720, 1).SetEase(Ease.InOutCubic);
                }
            }
            yield return new WaitForSeconds(1);
            //action menurut button
            switch (type)
            {
                case 0:
                    cgs[0].gameObject.SetActive(true);

                    break;
                case 1:
                    cgs[1].DOFade(1, 1);
                    cgs[1].blocksRaycasts = true;
                    break;
                case 2:

                    break;
                default:
                    cgs[2].DOFade(1, 1);
                    cgs[2].blocksRaycasts = true;
                    break;
            }

        }
        StartCoroutine(T1());
    }
}
