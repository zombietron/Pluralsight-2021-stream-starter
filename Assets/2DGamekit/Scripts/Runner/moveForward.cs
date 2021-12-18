using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isRunning)
        {
            MoveForward();
        }
        
    }

    public void MoveForward()
    {
        //move the object forward
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
