using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public FixedJoystick LeftJoystick;

    static public Hero SingleHero;

    public float speed = 30f;
    public float rollMult = -45f;
    public float pitchMult = 30f;

    public float shielLevel = 1;

    public GameObject projectillePrefab;
    public float projectilleSpeed = 40f;
    public List<GameObject> pointShut;

    private void Awake()
    {
        if (SingleHero == null)
        {
            SingleHero = this;
        }
        else
        {
            Debug.LogError("Error Hero Awake");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

   public void Move()
    {
        float horInput = LeftJoystick.inputVector.x;
        float vertInput = LeftJoystick.inputVector.y;
        if (horInput != 0 || vertInput != 0)
        {
            Vector3 position = transform.position;
            position.x += horInput * speed * Time.deltaTime;
            position.y += vertInput * speed * Time.deltaTime;

            transform.position = position;

            transform.rotation = Quaternion.Euler(vertInput * pitchMult, horInput * rollMult, 0);
        }
    }


    public void onClickFire()
    {
        GameObject[] projectille = { Instantiate<GameObject>(projectillePrefab), Instantiate<GameObject>(projectillePrefab) };

        for(int i=0;i< pointShut.Count;i++) {
        projectille[i].transform.position = pointShut[i].transform.position;

        Rigidbody rigidbody = projectille[i].GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.up * projectilleSpeed; 
        }
    }
}
