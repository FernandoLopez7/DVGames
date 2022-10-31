using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem Bflash;
    public GameObject bullet;
    public Transform mySpawn;
    AudioSource shootA;
    public int cantbalas;
    public Text cantbalasTXT;
    [SerializeField] int cantTotalbalas;
    public Text cantTotalbalasTXT;
    private float shotRateTime = 0;

    public float shotForce = 1500;
    public float shotRate = 0.5f;
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
        Bflash.Play();
        RaycastHit hit;
        GameObject newBullet;
        newBullet = Instantiate(bullet, mySpawn.position, mySpawn.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(mySpawn.forward * shotForce);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * shotForce);
                
            }
        }
        
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
