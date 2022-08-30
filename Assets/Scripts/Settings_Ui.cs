using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Ui : MonoBehaviour
{
    [Header("Toggles Ui")]
    [SerializeField] private Toggle fullscreenTog;

    [Space]
    [Header("Buttons Ui")]
    [SerializeField] private Button applyGraphicsButton;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        applyGraphicsButton.onClick.RemoveAllListeners();
        applyGraphicsButton.onClick.AddListener(ApplyGraphics);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTog.isOn;
    }
}