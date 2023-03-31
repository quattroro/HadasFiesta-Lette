using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Canvas_Enum;

public class EnemyHpbar : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera uiCamera; //UI 카메라를 담을 변수
    public Camera main;
    [SerializeField]
    private Canvas canvas; //캔버스를 담을 변수
    private RectTransform rectParent; //부모의 rectTransform 변수를 저장할 변수
    private RectTransform rectHp; //자신의 rectTransform 저장할 변수
    public Canvas enemyHpBarCanvas;
    //HideInInspector는 해당 변수 숨기기, 굳이 보여줄 필요가 없을 때 
    public Vector3 offset = Vector3.zero; //HpBar 위치 조절용, offset은 어디에 HpBar를 위치 출력할지
    public Transform enemyTr; //적 캐릭터의 위치
    
    public Image myhp;
    public Image Backgroundmyhp;
    public float Curhp;
    public float Maxhp;

    public Vector3 hpBarOffset = new Vector3(0.5f, 3f, 0);
    public EnemyHpbar MyHpbar;
    public Battle_Character battle_Character;

    public GameObject hpBar;
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = GetComponent<RectTransform>();
        //asd
    }

    private void Update()
    {
        if (battle_Character == null || battle_Character.cur_HP <=0 )
        {
            //    Destroy(hpBar);
            Destroy(this.gameObject);
        }
        else if (battle_Character.cur_Target != null)
        {
            myhp.enabled = true;
            Backgroundmyhp.enabled = true;
        }
     
        PlayableCharacter a= FindObjectOfType<PlayableCharacter>();
        if (a == null)
            return;
        
        main = PlayableCharacter.Instance.GetCamera();     
        
        //main = CameraManager.Instance.Playercamera.GetComponent<Camera>();
        var screenPos = main.WorldToScreenPoint(enemyTr.position + offset); // 몬스터의 월드 3d좌표를 스크린좌표로 변환
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }

        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos); // 스크린 좌표를 다시 체력바 UI 캔버스 좌표로 변환
        
        Debug.Log(main.name);
        rectHp.localPosition = localPos; // 체력바 위치조정

        myhp.GetComponent<Image>().fillAmount = battle_Character.cur_HP / Maxhp;
    }
    public void hit()
    {
        Curhp -= 0.1f;
        myhp.GetComponent<Image>().fillAmount =Curhp/Maxhp; 
       // myhp.value = (float)Curhp / (float)Maxhp;
    }

    public EnemyHpbar SetHpBar(float HP, Transform trans , Battle_Character battle_obj)
    {
         hpBar = UIManager.Instance.Prefabsload("Hpbar", CANVAS_NUM.enemy_canvas);
       // my = hpBar;
        var _hpbar = hpBar.GetComponent<EnemyHpbar>();
        //  hpBar.transform.SetParent(enemyHpBarCanvas.transform);
        _hpbar.enemyTr = trans;
        _hpbar.offset = new Vector3(0, 1.7f, 0); ;
        _hpbar.Maxhp = HP;
        _hpbar.Curhp = HP;
        _hpbar.battle_Character = battle_obj;
        var _test = hpBar.GetComponent<Image>();
        _hpbar.myhp = _test;
        MyHpbar = _hpbar;

        myhp.enabled = false;
        Backgroundmyhp.enabled = false;
        // Destroyo(battle_Character);
        //  Debug.Log(battle_Character.name);
        // Debug.Log(this.gameObject.name);
        return MyHpbar;
    }
}
