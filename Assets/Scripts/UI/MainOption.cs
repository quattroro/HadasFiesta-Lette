using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainOption : MonoBehaviour
{

    public GameObject Canvas_;
    public Light mainlight;
    public float Backgroundsound;
    public float Effectsound;
    public float Lightcontroll;

//    public bool Reversemouse;

    public bool GameStart;
    public bool ShowOption;
    public bool mainoption;

    public delegate void Reversemouse(bool val);
    public delegate void Autoevade(bool val);
    public delegate void Lookon(bool val);
    public delegate void Mousesensetive(float val);


    public Reversemouse r_invoker;
    public Autoevade a_invoker;
    public Lookon l_invoker;
    public Mousesensetive m_invoker;

    public bool _reversemouse;
    public bool _autoevad;
    public bool _lookon;
    public float _mousesensetive;

    public bool ReverseMouse
    {
        get
        {
            return _reversemouse;
        }
        set
        {
            _reversemouse = value;
            if (r_invoker != null)
            {
                r_invoker(value);
            }
        }
    }
    public bool AutoeVade
    {
        get
        {
            return _autoevad;
        }
        set
        {
            _autoevad = value;
            if (a_invoker != null)
            {
                a_invoker(value);
            }
        }
    }
    public bool LooKon
    {
        get
        {
            return _lookon;
        }
        set
        {
            _lookon = value;
            if (l_invoker != null)
            {
                l_invoker(value);
            }
        }
    }
    public float MouseSensetive
    {
        get
        {
            return _mousesensetive;
        }
        set
        {
            _mousesensetive = value;
            if (m_invoker != null)
            {
                m_invoker(value);
            }
        }
    }

    private void Update()
    {
        if (mainoption)
        {
            Canvas_.GetComponent<TestOnoff>().ShowImage(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Ingame();
        }
      //  mainlight.GetComponent<Light>().shadowStrength = 1 - (Lightcontroll * 0.01f);
    }

    public void Ingame()
    {
        if (ShowOption)
        {
            UIManager.Instance.Hide("IngameOption");
            UIManager.Instance.Show("Inven");
            UIManager.Instance.Show("Minimap");
            ShowOption = false;
           UIManager.Instance.CursorOff();
            return;
        }
        if(GameStart)
        {
            if (UIManager.Instance.Findobjbool("IngameOption"))
            {
                UIManager.Instance.Show("IngameOption");
                ShowOption = true;
            }
            else
            {
                UIManager.Instance.Prefabsload("IngameOption", Canvas_Enum.CANVAS_NUM.start_canvas);
                ShowOption = true;
            }
            UIManager.Instance.Hide("Minimap");
            UIManager.Instance.Hide("Inven");
            UIManager.Instance.CursorOn();
        }
    }
    private void Start()
    {
       StartCoroutine("UI");
    }
    IEnumerator UI()
    {
        SoundManager.Instance.bgmSource.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Remove("Inven");
        if (UIManager.Instance.Findobjbool("StartUI"))
        {
            UIManager.Instance.Show("StartUI");
        }
        else
        {
            UIManager.Instance.Prefabsload("StartUI", Canvas_Enum.CANVAS_NUM.start_canvas);
        }
        SoundManager.Instance.bgmSource.GetComponent<AudioSource>().clip=(SoundManager.Instance.Bgm[0]);
        SoundManager.Instance.bgmSource.Play();
        SoundManager.Instance.bgmSource.GetComponent<AudioSource>().loop=true;
        GameMG.Instance.Loading_screen(false);
    }
}
