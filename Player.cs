using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
  public uint level ;

  [SerializeField]  private uint moveSpeed;
  void Start()
  {
    level = 0;
    moveSpeed = 3;
    
  }
  private void Update() {
    if(Input.GetMouseButton(0))
      {
        Vector3 clickPos = Vector3.one;
        clickPos  = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,1f,0 ));

        //check
        Debug.Log(clickPos);
        
        gameObject.transform.position = clickPos * moveSpeed * Time.deltaTime;
      }

    

    }
}
