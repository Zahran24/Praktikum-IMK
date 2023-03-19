using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public string igName = "Calvin";
    public string role = "Gunner";
    public float speed = 10.0f;
    public GameObject pauseMenu;

    private Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        this.cam = GetComponentInChildren<Camera>();
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.Controls();
    }

    void Controls()
    {
        if(Time.timeScale > 0.0f)
        {
            if(Input.GetKey("w"))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
            }
            if(Input.GetKey("s"))
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * this.speed);
            }
            if(Input.GetKey("a"))
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
            }
            if(Input.GetKey("d"))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * this.speed);            
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
