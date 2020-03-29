using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour {

    //jeśli wejdziemy w ten collider, zostanie załadowany nowy poziom
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == ("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
