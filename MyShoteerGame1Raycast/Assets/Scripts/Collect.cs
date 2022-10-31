using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // AudioSource source;
    GameObject source;
    private void Start() {
        source = GameObject.Find("Reload");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            source.GetComponent<AudioSource>().Play();
            other.GetComponent<Shooter>().RecargaMax(7);
            Destroy(this.gameObject);
        }
    }
}
