using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optionsilder : MonoBehaviour
{
    private GameObject mycanvas;
    public Slider slideBar;
    public Text my;
    [SerializeField]
    private float val;

    public int myindex;
    // Start is called before the first frame update
    void Start()
    {
        slideBar = slideBar.GetComponent<Slider>();
        mycanvas = UIManager.Instance.Canvasreturn(Canvas_Enum.CANVAS_NUM.start_canvas);
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        val=(int)(slideBar.value*100);
        my.text = val.ToString();
        Apply();
    }

    void Apply()
    {
        if(myindex==0)
        {         
            mycanvas.GetComponent<MainOption>().Backgroundsound = val;
        }
        if (myindex == 1)
        {
            mycanvas.GetComponent<MainOption>().Effectsound = val;
        }
        if (myindex == 2)
        {
            mycanvas.GetComponent<MainOption>().MouseSensetive=val;
        }
        if (myindex == 3)
        {
            Color a=new Color(0,0,0);
            a.r = 0;
            a.g = 0;
            a.b = 0;
            a.r= val *0.01f;
            a.g = val * 0.01f;
            a.b = val * 0.01f;
            mycanvas.GetComponent<MainOption>().Lightcontroll = val;
            mycanvas.GetComponent<MainOption>().mainlight.GetComponent<Light>().color = a;
        }
    }

    void Setup()
    {
        if (myindex == 0)
        {
            slideBar.value = mycanvas.GetComponent<MainOption>().Backgroundsound * 0.01f;
            val = (int)(slideBar.value * 100);
            my.text = val.ToString();
        }
        if (myindex == 1)
        {
            slideBar.value = mycanvas.GetComponent<MainOption>().Effectsound * 0.01f;
            val = (int)(slideBar.value * 100);
            my.text = val.ToString();
        }
        if (myindex == 2)
        {
            slideBar.value = mycanvas.GetComponent<MainOption>().MouseSensetive * 0.01f;
            val = (int)(slideBar.value * 100);
            my.text = val.ToString();
        }
        if (myindex == 3)
        {
            slideBar.value = mycanvas.GetComponent<MainOption>().Lightcontroll * 0.01f;
            val = (int)(slideBar.value * 100);
            my.text = val.ToString();
        }
    }
}
