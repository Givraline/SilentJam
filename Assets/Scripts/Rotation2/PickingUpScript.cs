using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpScript : MonoBehaviour
{
    bool isHoldingObj = false;
    bool isPickable = false;
    bool isCheckable = false;
    bool canColor = false;
    bool canForm = false;
    bool cd = false;
    string whatColor;
    string whatForm;
    GameObject heldObj;
    ToyScriptValues toyScriptValues;
    GameObject ObjectList;

    [SerializeField] GameObject Capsule;
    Mesh CapsuleMesh;
    [SerializeField] GameObject Sphere;
    Mesh SphereMesh;
    [SerializeField] GameObject Cube;
    Mesh CubeMesh;
    GameObject verificator;


    void Start(){
        CapsuleMesh = Capsule.GetComponent<MeshFilter>().mesh;
        SphereMesh = Sphere.GetComponent<MeshFilter>().mesh;
        CubeMesh = Cube.GetComponent<MeshFilter>().mesh;
        ObjectList = transform.parent.transform.parent.gameObject;
        verificator = GameObject.Find("Verificator");
    }

    void Update(){
        if(isPickable&&Input.GetKeyDown(KeyCode.Space)&& !cd){
                isHoldingObj=true;
                StartCoroutine(Cooldown());
                heldObj.GetComponent<Rigidbody>().isKinematic = true;
                heldObj.transform.position = transform.position;
                heldObj.transform.parent = transform;
                toyScriptValues = heldObj.GetComponent<ToyScriptValues>();
                isPickable=false;
            }
        if(isHoldingObj){
            if(Input.GetKeyDown(KeyCode.Space)&& !cd && !canColor && !canForm){
                isHoldingObj=false;
                StartCoroutine(Cooldown());
                Debug.Log(heldObj);
                heldObj.GetComponent<Rigidbody>().isKinematic = false;
                heldObj.transform.parent = ObjectList.transform;
            }

            if(canColor){
                if(Input.GetKeyDown(KeyCode.E)&& !cd){
                    StartCoroutine(Cooldown());
                    if(whatColor == "Green"){
                        heldObj.GetComponent<MeshRenderer>().material.color = Color.green;
                        toyScriptValues.Color = "Green";
                    }else if(whatColor == "Red"){
                        heldObj.GetComponent<MeshRenderer>().material.color = Color.red;
                        toyScriptValues.Color = "Red";
                    }else if(whatColor == "Blue"){
                        heldObj.GetComponent<MeshRenderer>().material.color = Color.blue;
                        toyScriptValues.Color = "Blue";
                    }
                }
            }
            if(canForm){
                if(Input.GetKeyDown(KeyCode.E)&& !cd){
                    StartCoroutine(Cooldown());
                    if(whatForm == "Capsule"){
                        heldObj.GetComponent<MeshFilter>().mesh = CapsuleMesh;
                        toyScriptValues.Form = "Capsule";
                    }else if(whatForm == "Cube"){
                        heldObj.GetComponent<MeshFilter>().mesh = CubeMesh;
                        toyScriptValues.Form = "Cube";
                    }else if(whatForm == "Sphere"){
                        heldObj.GetComponent<MeshFilter>().mesh = SphereMesh;
                        toyScriptValues.Form = "Sphere";
                    }
                }
            }
            if(isCheckable){
                Debug.Log("tt");
                if(Input.GetKeyDown(KeyCode.E)&& !cd){
                    Debug.Log("ttt");
                    StartCoroutine(Cooldown());
                    verificator.GetComponent<ToyVerifScript>().checkup(toyScriptValues.Color, toyScriptValues.Form);
                    Destroy(heldObj);
                    isHoldingObj = false;
                }
            }
        }
    }


    void OnTriggerEnter(Collider col){
        if(col.tag == "Toy" && !isHoldingObj){
            heldObj = col.gameObject;
            isPickable=true;
        }else{
            isPickable=false;
        }

        if(isHoldingObj){
            if(col.tag == "GreenPaint"){
                whatColor="Green";
                canColor=true;
            }else if(col.tag == "RedPaint"){
                whatColor="Red";
                canColor=true;
            }else if(col.tag == "BluePaint"){
                whatColor="Blue";
                canColor=true;
            }else{
                canColor=false;
            }

            if(col.tag == "Capsule"){
                whatForm="Capsule";
                canForm=true;
            }else if(col.tag == "Cube"){
                whatForm="Cube";
                canForm=true;
            }else if(col.tag == "Sphere"){
                whatForm="Sphere";
                canForm=true;
            }else{
                canForm=false;
            }
        }
        
        if(col.tag == "Verificator" && isHoldingObj){
            isCheckable=true;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Toy" && !isHoldingObj){
            isPickable=false;
        }
        if(isHoldingObj){
            if(col.tag == "GreenPaint" || col.tag == "RedPaint" || col.tag == "BluePaint"){
                canColor=false;
            }
            if(col.tag == "Capsule" || col.tag == "Sphere" || col.tag == "Cube"){
                canForm=false;
            }
        }
        if(col.tag == "Verificator" && isHoldingObj){
            isCheckable=false;
        }
    }

    IEnumerator Cooldown(){
        cd = true;
        yield return new WaitForSeconds(.2f);
        cd = false;
    }
}
