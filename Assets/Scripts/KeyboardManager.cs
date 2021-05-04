using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyboardManager : MonoBehaviour
{
    [SerializeField] private GameObject keyboard;
    private TMP_InputField[] inputFields;
    private void Awake()
    {
        inputFields = FindObjectsOfType<TMP_InputField>();
    }
    private void Start()
    {
        keyboard.SetActive(false);
        foreach (TMP_InputField go in inputFields) {
            go.onSelect.AddListener( delegate { OpenKeyboard(go); });
        }
    }

    public void OpenKeyboard(TMP_InputField go) {
        keyboard.GetComponent<TalesFromTheRift.CanvasKeyboard>().inputObject = go.gameObject;
        keyboard.SetActive(true);
    }
    public void CloseKeyboard() {
        keyboard.SetActive(false);
    }
}
