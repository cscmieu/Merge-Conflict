using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private CanvasGroup blackBackground;
    private int currentBackground = 0;
    public float paralaxSpeed = 0.5f;
    private RectTransform rectTransform;
    
    private bool isChanging = false;
    
    private void Start()
    {
        backgrounds[currentBackground].SetActive(true);
        rectTransform = backgrounds[currentBackground].GetComponent<RectTransform>();
        blackBackground.alpha = 0;
    }
    
    private IEnumerator ChangeBackgroundCoroutine()
    {
        blackBackground.LeanAlpha(1, 0.2f).setOnComplete(OnComplete);
        yield return new WaitForSeconds(0.2f);
        rectTransform.localPosition = Vector3.zero;
        backgrounds[currentBackground].SetActive(false);
        currentBackground = (currentBackground + 1)% backgrounds.Count;
        
        backgrounds[currentBackground].SetActive(true);
        rectTransform = backgrounds[currentBackground].GetComponent<RectTransform>();
        isChanging = false;
        yield return null;
    }
    
    
    void OnComplete()
    {
        blackBackground.LeanAlpha(0, 0.2f);
    }
    
    private void ParalaxBackground()
    {
        rectTransform.localPosition += paralaxSpeed * Vector3.down / 3;
        rectTransform.localPosition += paralaxSpeed * Vector3.left;
    }
    
    private void Update()
    {
        ParalaxBackground();
        if (rectTransform.localPosition.x < -200)
        {
            if (!isChanging)
            {
                isChanging = true;
                StartCoroutine(ChangeBackgroundCoroutine());
            }
        }
    }
    
}
