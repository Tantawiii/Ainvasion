using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject Portal;

    public AudioSource Ele;

    void Start()
    {
        P1.SetActive(true);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        P5.SetActive(false);
        P6.SetActive(false);
        P7.SetActive(false);
        Portal.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            P1.SetActive(false);
            P2.SetActive(true);
            Ele.Play();
        }


        if (other.CompareTag("P2"))
        {
            P2.SetActive(false);
            P3.SetActive(true);
             Ele.Play();
        }


        if (other.CompareTag("P3"))
        {
            P3.SetActive(false);
            P4.SetActive(true);
             Ele.Play();
        }

        if (other.CompareTag("P4"))
        {
            P4.SetActive(false);
            P5.SetActive(true);
             Ele.Play();
        }

        if (other.CompareTag("P5"))
        {
            P5.SetActive(false);
            P6.SetActive(true);
             Ele.Play();
        }

        if (other.CompareTag("P6"))
        {
            P6.SetActive(false);
            P7.SetActive(true);
             Ele.Play();
        }

        if (other.CompareTag("P7"))
        {
            P7.SetActive(false);
            Portal.SetActive(true);
             Ele.Play();
        }
    }
    void Update(){
        var scenename = SceneManager.GetActiveScene();
        if(Portal.activeSelf){
            if(scenename.name == "Level1"){
                SceneManager.LoadScene("Level 3");
            }
            else if(scenename.name == "Level 3"){
                SceneManager.LoadScene("Level 2");
            }
            else if(scenename.name == "Level 3"){
                Application.Quit();
            }
}
    }}
