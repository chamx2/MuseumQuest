using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DisplayUI : MonoBehaviour {

public GameObject resultCanvas;
public TextMeshProUGUI result;
public void Result(string value){
	resultCanvas.SetActive(true);
	result.text = value;
}
}
