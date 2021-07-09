using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    [SerializeField]private Button button;
    [SerializeField] private TextMeshProUGUI text;

    public string TextforView {get; set;}
    private void OnEnable()
    {
        text.text = TextforView;
    }
    public Button GetButton()
    {
        return button;
    }
}
