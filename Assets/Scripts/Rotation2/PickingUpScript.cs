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
    bool canWrap = false;
    bool isWrapped = false;
    bool cd = false;
    string whatColor;
    string whatForm;
    GameObject heldObj;
    ToyScriptValues toyScriptValues;
    GameObject ObjectList;

    [SerializeField] GameObject WrappedGift;
    [SerializeField] GameObject Pyramid;
    Mesh PyramidMesh;
    [SerializeField] GameObject Sphere;
    Mesh SphereMesh;
    [SerializeField] GameObject Cube;
    Mesh CubeMesh;
    GameObject verificator;

    [SerializeField] Material MaterialBlue;
    [SerializeField] Material MaterialRed;
    [SerializeField] Material MaterialGreen;


    void Start(){
        PyramidMesh = Pyramid.GetComponent<MeshFilter>().mesh;
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

            if(canColor && !isWrapped)
            {
                if(Input.GetKeyDown(KeyCode.E) && !cd){
                    StartCoroutine(Cooldown());
                    if(whatColor == "Green"){
                        heldObj.GetComponent<MeshRenderer>().material = MaterialGreen;
                        toyScriptValues.Color = "Green";
                    }else if(whatColor == "Red"){
                        heldObj.GetComponent<MeshRenderer>().material = MaterialRed;
                        toyScriptValues.Color = "Red";
                    }else if(whatColor == "Blue"){
                        heldObj.GetComponent<MeshRenderer>().material = MaterialBlue;
                        toyScriptValues.Color = "Blue";
                    }
                }
            }
            if(canForm && !isWrapped)
            {
                if(Input.GetKeyDown(KeyCode.E) && !cd){
                    StartCoroutine(Cooldown());
                    if(whatForm == "Pyramid"){
                        heldObj.GetComponent<MeshFilter>().mesh = PyramidMesh;
                        //heldObj.transform.localScale = new Vector3(50,50,50);
                        toyScriptValues.Form = "Pyramid";
                    }else if(whatForm == "Cube"){
                        heldObj.GetComponent<MeshFilter>().mesh = CubeMesh;
                        //heldObj.transform.localScale = Vector3.one;
                        toyScriptValues.Form = "Cube";
                    }else if(whatForm == "Sphere"){
                        heldObj.GetComponent<MeshFilter>().mesh = SphereMesh;
                        //heldObj.transform.localScale = Vector3.one;
                        toyScriptValues.Form = "Sphere";
                    }
                }
            }
            if (canWrap)
            {
                if (Input.GetKeyDown(KeyCode.E) && !cd)
                {
                    StartCoroutine(Cooldown());
                    Destroy(heldObj);
                    heldObj = Instantiate(WrappedGift, transform);
                    isWrapped = true;
                }
            }
            if(isCheckable){
                if(Input.GetKeyDown(KeyCode.E) && !cd){
                    StartCoroutine(Cooldown());
                    verificator.GetComponent<ToyVerifScript>().checkup(toyScriptValues.Color, toyScriptValues.Form, isWrapped);
                    Destroy(heldObj);
                    isHoldingObj = false;
                    isWrapped = false;
                }
            }
        }
    }


    void OnTriggerEnter(Collider col){
        Debug.Log(col.tag + isHoldingObj);
        if(col.tag == "Toy" && !isHoldingObj){
            heldObj = col.gameObject;
            isPickable=true;
        }else{
            isPickable=false;
        }

        if (isHoldingObj)
        {
            if (col.tag == "GreenPaint")
            {
                whatColor = "Green";
                canColor = true;
            }
            else if (col.tag == "RedPaint")
            {
                whatColor = "Red";
                canColor = true;
            }
            else if (col.tag == "BluePaint")
            {
                whatColor = "Blue";
                canColor = true;
            }
            else
            {
                canColor = false;
            }

            if (col.tag == "Capsule")
            {
                whatForm = "Pyramid";
                canForm = true;
            }
            else if (col.tag == "Cube")
            {
                whatForm = "Cube";
                canForm = true;
            }
            else if (col.tag == "Sphere")
            {
                whatForm = "Sphere";
                canForm = true;
            }
            else
            {
                canForm = false;
            }

            if (col.tag == "Wrap")
            {
                canWrap = true;
            }

            if (col.tag == "Verificator")
            {
                isCheckable = true;
            }
        }
    }
        
    void OnTriggerExit(Collider col){
        if (col.tag == "Wrap")
        {
            canWrap = false;
        }
        if (col.tag == "Toy" && !isHoldingObj){
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
        if(col.tag == "Verificator"){
            isCheckable=false;
        }
    }

    IEnumerator Cooldown(){
        cd = true;
        yield return new WaitForSeconds(.2f);
        cd = false;
    }
}
