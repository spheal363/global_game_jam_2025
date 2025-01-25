using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LongTapIndicator : MonoBehaviour {

    public void SetFillAmount(float amount) {
        this.GetComponent<Image>().fillAmount = amount;
    }
}