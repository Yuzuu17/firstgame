using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                               // UI PANG IMAGES

public class FADE : MonoBehaviour
{
    public Image Fades;                             
    public float FadeDuration = 2f;
    void Start()
    {
        if (Fades != null)
        {
            StartCoroutine(FadeIn());               
        }
    }
    private IEnumerator FadeIn()                   // KASAMA NG COROUTINE NA EEXECUTE NG IENUMATOR PERO SI IENUM NAG EEXECUTE NG SPECIFIC
    {
        float ElapsedTime = 0;
        Color color = Fades.color;
        while (ElapsedTime < FadeDuration)
        {
            ElapsedTime += Time.deltaTime;                                   // FIXED YUNG TDT
            color.a = Mathf.Clamp01(1f - (ElapsedTime / FadeDuration));     //MATHFCLAMP01 - ENSURE THE VALUE WILL STAY 0 AND 1 (TRANSPARENT)
            Fades.color = color;                                           // INULET
            yield return null;                                            // PAUSE COROUTINE UNTILL NEXT FRAME
        }
        color.a = 0f;                                                   // a = alpha
        Fades.color = color;
    }
}
