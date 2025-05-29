using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BodyCount : MonoBehaviour
{
    public SwordAction swordAction;
    public TextMeshProUGUI textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Enemies destroyed: " + swordAction.enemyCount;
        
    }
}
