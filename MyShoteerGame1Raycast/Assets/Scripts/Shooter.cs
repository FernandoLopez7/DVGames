using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    //Teacher
    public GameObject bullet;
    public Transform mySpawn;
    AudioSource shootA;
    public int cantbalas;
    public Text cantbalasTXT;
    [SerializeField] int cantTotalbalas;
    public Text cantTotalbalasTXT;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;
    private void Start() {
        shootA = GetComponent<AudioSource>();
    }
    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            if(Time.time>shotRateTime){
                if (cantbalas > 0)
                {
                    shootA.Play();
                    Shoots();
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Recargar();
        }


        cantbalasTXT.text = cantbalas.ToString();
        cantTotalbalasTXT.text = cantTotalbalas.ToString();
    }

    void Shoots(){
        GameObject newBullet;
        newBullet = Instantiate(bullet, mySpawn.position, mySpawn.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(mySpawn.forward*shotForce);
        shotRateTime = Time.time + shotRate;
        cantbalas -= 1;
        Destroy(newBullet, 2);
    }

    void Recargar(){
        if (cantbalas == 0 )
            {   
                if(cantTotalbalas != 0){
                    cantbalas += 7 ;
                    cantTotalbalas -= 7;
                }
            }
    }

    public void RecargaMax(int cartuchoR){
        cantTotalbalas += cartuchoR;
        cantTotalbalasTXT.text = cantTotalbalas.ToString();
    }
}
