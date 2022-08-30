using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUiUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiText;

    void Update()
    {
        uiText.text = soInt.value.ToString();
    }
}
