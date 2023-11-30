using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToyVerifScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FormTxt;
    [SerializeField] TextMeshProUGUI ColorTxt;
    string[] colorList = {"Green", "Blue", "Red"};
    int checkColor;
    string[] formList = {"Cube", "Sphere", "Capsule"};
    int checkForm;

    void Start(){
        ShuffleTasks();
    }

    void ShuffleTasks(){
        checkColor = Random.Range(0, colorList.Length);
        ColorTxt.SetText(colorList[checkColor]);
        checkForm = Random.Range(0, formList.Length);
        FormTxt.SetText(formList[checkForm]);
    }

    public void checkup(string color, string form){
        int check = 0;
        if(color==colorList[checkColor]){
            check++;
        }
        if(form==formList[checkForm]){
            check++;
        }
        if(check==2){
            Debug.Log("EH C'EST GAGNEEEE");
        }
    }
}
