using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public GameObject knifePrefab;
    public Transform knifeSpawnPoint;
    [SerializeField] float knifeSpeed = 15f;
    [SerializeField] float delayBetweenKnife = 0.5f;
    public GameObject knife;
    
    private void Start()
    {
      knife = Instantiate(knifePrefab,Vector3.zero, Quaternion.Euler(-173.163f, 152.009f, -1.610992f),knifeSpawnPoint);
      knife.transform.localPosition = Vector3.zero;

    }


    public void ThrowKnife()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
           
            StartCoroutine(GenerateSecondKnife());

            Vector3 direction = (hit.point - knifeSpawnPoint.position).normalized;
            if (knife != null)
            {
            knife.transform.rotation = Quaternion.LookRotation(direction);
            knife.GetComponent<Rigidbody>().velocity = direction * knifeSpeed * Time.deltaTime;
            knife.transform.SetParent(null);
            }

        }
    }
    IEnumerator GenerateSecondKnife()
    {
        
        yield return new WaitForSeconds(delayBetweenKnife);

        knife = Instantiate(knifePrefab, Vector3.zero, Quaternion.Euler(-173.163f, 152.009f, -1.610992f), knifeSpawnPoint);
        knife.transform.localPosition = Vector3.zero;
       
    }

  


}
