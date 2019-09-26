using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningController : MonoBehaviour
{
    public GameObject dangerObject;
    public float ActivationDistance;
    
    void Start()
    {
        //playerObject = FindObjectOfType<player>;
        dangerObject.SetActive(false);
        //StartCoroutine(Spawn());
    }

    private void Update()
    {
        //Debug.Log("progress: " + PlayerController.progress + " , " + dangerObject.transform.position.z);
       if (dangerObject.transform.position.z - PlayerController.progress < ActivationDistance)
        {
            //Debug.Log(PlayerController.progress - dangerObject.transform.position.z);
            dangerObject.SetActive(true);
        }
           
    }

    IEnumerator Spawn()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
        dangerObject.SetActive(true);
    }


}
