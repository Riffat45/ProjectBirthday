using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public static MainUI instance { get; private set; }
    Button[] buttons;
    [SerializeField]CanvasGroup[] cgs;
    [SerializeField] SuratOpener SuratParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
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
                    cgs[0].DOFade(1, 1);
                    break;
                case 1:
                    cgs[1].DOFade(1, 1);
                    cgs[1].blocksRaycasts = true;
                    break;
                case 2:
                    SuratParent.Read = true;
                    break;
                default:

                    break;
            }

        }
        StartCoroutine(T1());
    }

    public void RecoverUI(int type)
    {
        IEnumerator T1()
        {
            
            //action menurut button
            switch (type)
            {
                case 0:
                    cgs[0].DOFade(0, 1).OnComplete(() =>
                    {
                        cgs[0].gameObject.SetActive(false);
                    });

                    break;
                case 1:
                    cgs[1].DOFade(0, 1);
                    cgs[1].blocksRaycasts = false;
                    break;
                case 2:
                    SuratParent.Read = false;
                    break;
                default:

                    break;
            }
            yield return new WaitForSeconds(1);
            //transisi button keluar screen
            for (int i = 0; i <= 2; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;
                if (i == 1)
                {
                    buttons[i].transform.DOMoveY(buttons[i].transform.position.y + 720, 1).SetEase(Ease.InOutCubic);
                }
                else
                {
                    buttons[i].transform.DOMoveY(buttons[i].transform.position.y - 720, 1).SetEase(Ease.InOutCubic);
                }
            }

        }
        StartCoroutine(T1());
    }

    public void Recover()
    {
        for (int i = 0; i <= 2; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            if (i == 1)
            {
                buttons[i].transform.DOMoveY(buttons[i].transform.position.y + 720, 1).SetEase(Ease.InOutCubic);
            }
            else
            {
                buttons[i].transform.DOMoveY(buttons[i].transform.position.y - 720, 1).SetEase(Ease.InOutCubic);
            }
        }
        
    }
}
