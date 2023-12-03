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
    string[] formList = {"Cube", "Sphere", "Pyramid"};
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

    public void checkup(string color, string form, bool isWrapped){
        int check = 0;
        if (isWrapped)
        {
            if(color==colorList[checkColor]){
                check++;
            }
            if(form==formList[checkForm]){
                check++;
            }
        }
        if(check==2){
            MessageGenerator.Instance.ShowMessage("RIGHT GIFT!");
            ScoreManager.instance.AddScore(20);
        }
        else{
            MessageGenerator.Instance.ShowMessage("WRONG GIFT!");
            ScoreManager.instance.RemoveScore(20);
        }
        check = 0;
        ShuffleTasks();
        GameObject.Find("---ScoreManager---").GetComponent<ToySpawner>().SummonToy();
    }
}
