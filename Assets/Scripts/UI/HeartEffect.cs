using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class HeartEffect : MonoBehaviour
{

    [SerializeField]
    Image HeartView;



    float max;

    Tween t;


    public void SetHeatlh(float current, float max, bool instant = false)
    {
        this.max = max;
        if (instant)
        {
            UpdateBar(current);
            return;
        }
        var fillAmountCurrent = HeartView.fillAmount;
        t.Stop();
        t = Tween.Custom(fillAmountCurrent, current/max, 0.2f, (x) => UpdateBar(x), ease:Ease.OutCubic);
    }

    void UpdateBar(float value)
    {
        HeartView.fillAmount = value;
    }


}
