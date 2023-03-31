using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class AddrTestScripts : MonoBehaviour
{


    public Canvas canvas;
    SceneInstance m_LoadedScene;

    public GameObject tempOBJ_;
    public GameObject pos;

    public List<GameObject> tempList = new List<GameObject>();

    public delegate void Complete_delegate(AsyncOperationHandle<GameObject> comp);
    public Action<AsyncOperationHandle<GameObject>> Complete_Aciton;

    public  Dictionary<string, List<string>> AssetList = new Dictionary<string, List<string>>();

    public GameObject tempHPbar;
    // Start is called before the first frame update
    public GameObject te;
     void Start()
    {
        pos = new GameObject();
        // tempHPbar = new GameObject();
        pos.transform.position = new Vector3(0f, 0f, 0f);

        //예외처리 테스트
        //StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial("Hpbar"));
        //StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial("Hpbar"));

        //델리게이트 테스트

        //StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial("Susu_", handle => Debug.Log("델리게이트"+handle.Result.name)));
        //StartCoroutine( temp());

        //  StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial("Demo"));

        // AddressablesLoader.InitAssets_name<SceneInstance>("Demo", handle => m_LoadedScene = handle.Result);

        // AddressablesLoader.InitAssets_name<GameObject>("Susu_", handle => tempHPbar = handle.Result);

        // StartCoroutine(AddressablesController.Instance.Load_Name("Susu_", pos.transform));

        //델리게이트 동기 로드 테스트
        //await Loder("susu",tempAction);

        //te = await AddressablesLoader.InitAssets_Instantiate<GameObject>("susu", AddressablesLoader.Instantiate_Obj_List);
        //Debug.Log("끝나야되는데?");


        // StartCoroutine(tempCheck());

        //GameObject tem=  await  AddressablesLoader.InitAssets_Instantiate<GameObject>("susu",AddressablesLoader.tempobj);


        // await AddressablesLoader.InitAssets_name_<GameObject>("susu");

        //object find = AddressablesLoader.Find_Asset_In_AllList("susu");
        //if (find != null)
        //{
        //    Debug.Log("찾았당");
        //    Instantiate((GameObject)find, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //}

        //AddressablesLoader.tempCheckList_delete<UnityEngine.Object>((UnityEngine.Object)find);

        //AddressablesController.Instance.gg();

        //TestAddressablesLoader<GameObject> temp = new TestAddressablesLoader<GameObject>();
        //// //testaddressablesloader<gameobject> temp3 = new testaddressablesloader<gameobject>();
        //   temp.InitAssets_label("susu");
        //GameObject te = temp.FindLoadAsset("susu");
        //GameObject aa = Instantiate(te, new Vector3(10f, 10f, 10f), Quaternion.identity);
        //// destroy(aa);

        // temp.delete_object(te);
        // Pool<GameObject> pool = new Pool<GameObject>();
        // AddressablesLoadManager.Instance.SingleAsset_Load<GameObject>("susu");
        // GameObject te = AddressablesLoadManager.Instance.FindLoadAsset<GameObject>("susu");

        //에러 나중에 생각...ㅋ큐ㅠ 
        //   pool.Init(te);
        //var a= GameMG.Instance.Resource.Instantiate<GameObject>("Boss_Arrow");
        // StartCoroutine(ee(a));

        // GameMG.Instance.startGame("Demo");



        // GameMG.Instance.startGame("Demo");



        // StartCoroutine(tempch());

        // await temp.InitAssets_label("Monster");
        // await temp.InitAssets_label("Monster");


        //List<string> t = new List<string>();
        //t.Add("susu");
        //t.Add("Susu_");
        //t.Add("Appoint");
        //GameObject temp = null;

        //TestAddressablesLoader.Instance.Single_Load<GameObject>("susu", false, Act
        //TestAddressablesLoader.Instance.Single_Instantiate<GameObject>("susu", false, Act1);
        // TestAddressablesLoader.Instance.Multi_Lable_Instantiate<GameObject>("Monster", false, tete);
        //TestAddressablesLoader.Instance.Multi_Lable_Instantiate<GameObject>("Monster", false, tete);


        //StartCoroutine( temp.Load_Key_List(t, handl=>Debug.Log("gg")));
        //Debug.Log("물론 이거 비동기");

        //TestAddressablesLoader<Sprite> temp1 = new TestAddressablesLoader<Sprite>();

        // await temp.InitAssets_Instantiate("Susu_", tempList);

        //foreach (var t in tempList)
        //{
        //    Debug.Log("tempList확인" + t.name);

        //}
        //AddressablesLoadManager.Instance.SingleAsset_Load<GameObject>("susu");
        //var a=AddressablesLoadManager.Instance.Instantiate_LoadObject<GameObject>("susu");
        //AddressablesLoadManager.Instance.Delete_Object<GameObject>(a);
        // StartCoroutine(Tq());

        // TestAddressablesLoader.Instance.Single_Load_Task_Test<GameObject>("susu", false, true, com => temp = com);  //동기,생성 x
        //TestAddressablesLoader.Instance.Single_Load_Task_Test<GameObject>("susu", true, true, com => temp = com);  //비동기,생성 x
        //TestAddressablesLoader.Instance.Single_Load_Task_Test<GameObject>("susu", false, false, com => temp = com);  //동기,생성 o
        // TestAddressablesLoader.Instance.Single_Load_Task_Test<GameObject>("susu", true, false, com => temp = com);  //비동기,생성 o
        //  Debug.Log("???");
        //  Debug.Log("temp로드" + temp);


        //TestAddressablesLoader.Instance.Delete_Object<GameObject>(a);

        //TestAddressablesLoader.Instance.Multi_Load_Task_Test<GameObject>(t, false, () => Debug.Log("gg"));  //동기,생성 x
        // TestAddressablesLoader.Instance.Multi_Load_Task_Test<GameObject>(t,false, () => Debug.Log("gg"));  //동기,생성 x

        //생성한 것을 반환받는 작업.
        // var a = TestAddressablesLoader.Instance.Instantiate_LoadObject<GameObject>("susu");

        //Debug.Log(a);
        //foreach(var name in a)
        //{
        //    Debug.Log("생성해서 가져온 리스트" + name);
        //}

        //바깥에서 원본 지울때 (핸들만...ㅠㅠ)
        //StartCoroutine( TestAddressablesLoader.Instance.Delete_Object<GameObject>(t));
        // Debug.Log("메인");

        //StartCoroutine(TestAddressablesLoader.Instance.Load_Name<GameObject>("susu", pos.transform));


        //testJG();
        // StartCoroutine(tAe());

        //TestAddressablesLoader.Instance.Multi_Lable_Instantiate<GameObject>("Monster",true,tete);

       // StartCoroutine(qeq());

        // await temp1.InitAssets_name_("Estus");

        //Debug.Log("temp");
        //temp.tempAllAsset();
        //Debug.Log("temp1");

        //temp1.tempAllAsset();
        //Debug.Log("temp3");
        //temp3.tempAllAsset();

        // tempch();

        // GameObject temp111 = temp.FindLoadAsset("susu");
        // temp111.transform.position = new Vector3(50f, 0f, 0f);
        //Instantiate(temp111, new Vector3(10f, 10f, 10f), Quaternion.identity);

        // TestAddressablesLoader<Sprite>.Instance.tempAllAsset();

        // Debug.Log("gg");


        // AddressablesLoadManager.Instance.tempchekc();

        //label로 다수 로딩
        //StartCoroutine(AddressablesLoader.LoadAndStoreResult("Monster"));

        //  StartCoroutine(AddressablesLoader.LoadAndAssociateResultWithKey("Monster"));

        //리스트로 다수 로딩
        //StartCoroutine(AddressablesLoader.Load_Key_List(new List<object>() { "susu", "Susu_" }));


        //TaskRun();
        //TaskFromResult();

    }

    //IEnumerator ee<T>(T a)
    //    where T : UnityEngine.Object
    //{
    //    yield return new WaitForSeconds(2f);
    //    GameMG.Instance.Resource.Destroy<T>(a);
    //    yield return new WaitForSeconds(3f);

    //    GameMG.Instance.Resource.Instantiate<T>("susu");

    //}
    IEnumerator qqq()
    {

        List<string> t = new List<string>();
        t.Add("susu");
        t.Add("Susu_");
        t.Add("Appoint");

        AddressablesLoadManager.Instance.MultiAsset_Load<GameObject>(t, true);  //동기,생성 x
        var s= AddressablesLoadManager.Instance.Find_InstantiateObj<GameObject>("susu");
       // AddressablesLoadManager.Instance.tempchekc();

        AddressablesLoadManager.Instance.MultiAsset_Load<GameObject>(t, true);  //동기,생성 x

        yield return new WaitForSeconds(2f);
        Debug.Log("삭제하러감");
        yield return StartCoroutine( AddressablesLoadManager.Instance.Delete_Object<GameObject>(t));
        yield return new WaitForSeconds(5f);
        Debug.Log("삭제완료하고 다시 로드");

        AddressablesLoadManager.Instance.MultiAsset_Load<GameObject>(t, true);  //동기,생성 x


    }
    public void testJG()
    {
        AddressablesLoadManager.Instance.Single_Instantiate<GameObject>("susu",false);
        Debug.Log("어디볼까");
    }
   

    IEnumerator Tq()
    {
        yield return StartCoroutine(AddressablesLoadManager.Instance.Load_Name<GameObject>("susu", pos.transform));
        GameObject t= AddressablesLoadManager.Instance.Find_InstantiateObj<GameObject>("susu");
        yield return new WaitForSeconds(2f);
        AddressablesLoadManager.Instance.Delete_Object<GameObject>(t);
        yield return new WaitForSeconds(2f);
       // GameObject a = TestAddressablesLoader.Instance.FindLoadAsset<GameObject>("susu");
        Debug.Log("삭제 ㄱ");
       // TestAddressablesLoader.Instance.Delete_Object<GameObject>(a);
    }

    void Act<T>(T action)
     where T : UnityEngine.Object

    {
        T temp = action;
        Debug.Log(temp);
        T t= Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("아 일단 생성");

        AddressablesLoadManager.Instance.Delete_Object(temp);
        Debug.Log("삭제 호출끝");
        AddressablesLoadManager.Instance.tempListCheck();
        AddressablesLoadManager.Instance.Delete_Object(t);
    }

    void Act1<T>(T action)
   where T : UnityEngine.Object

    {
        T temp = action;
        Debug.Log(temp);

        GameObject t = temp as GameObject;
        t.transform.position = new Vector3(10f, 10f, 10f);
        
        Debug.Log("아 일단 생성");

       // TestAddressablesLoader.Instance.Delete_Object(temp);
        Debug.Log("삭제 호출끝");
        AddressablesLoadManager.Instance.tempListCheck();
       // TestAddressablesLoader.Instance.Delete_Object(t);

    }

    IEnumerator tAe()
    {
        GameObject te = null;
        yield return StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("susu", handle => { te = handle; }));
        Debug.Log(te);
        Instantiate(te, new Vector3(0, 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(2f);
        AddressablesLoadManager.Instance.Delete_Object<GameObject>(te);
    }
    void tete()
    {
       // var temp = TestAddressablesLoader.Instance.FindLoadAsset<GameObject>("susu");
        Debug.Log("삭제?");
      //  TestAddressablesLoader.Instance.Delete_Object<GameObject>(temp);
    }


    void tempListchec()
    {
        List<string> temp = new List<string>();
        temp.Add("temp a");
        temp.Add("temp b");
        temp.Add("temp c");
        List<string> temp1 = new List<string>();
        temp1.Add("temp1 a");
        temp1.Add("temp1 b");
        temp1.Add("temp1 c");
        List<string> temp2 = new List<string>();
        temp1.Add("temp2 a");
        temp1.Add("temp2 b");
        temp1.Add("temp2 c");
        AssetList.Add("1", temp);
        AssetList.Add("2", temp1);
      //  AssetList.Add("1", temp2);


        if (AssetList.ContainsKey("2"))
        {
           foreach(var t in AssetList["2"])
            {
                Debug.Log(t);
            }
        }

    }

    IEnumerator tempCheck1()
    {

       

         yield return StartCoroutine(AddressablesLoader.LoadAndStoreResult<GameObject>("susu",handle=> Debug.Log("dd"))); 

        object find = AddressablesLoader.Find_Asset_In_AllList("susu");

        if (find != null)

        {
            Debug.Log("find있엉");
           // Addressables.Release(find);
        }

        yield return new WaitForSeconds(2f);

        AddressablesLoader.tempCheckList_delete((GameObject)find);

    }

    IEnumerator tempCheck()
    {
        yield return StartCoroutine(AddressablesLoader.LoadAndStoreResult("susu"));
        AddressablesLoader.tempCheckList();

        yield return new WaitForSeconds(2f);
        Debug.Log("2초 지남");
       object tempObj= AddressablesLoader.Find_Asset_In_AllList("susu");
       GameObject t= Instantiate(tempObj as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);

        yield return new WaitForSeconds(2f);
        Debug.Log("2초 지남");


        if (tempObj!=null)
        {
            Debug.Log("삭제하러 들어옴");
            AddressablesLoader.tempCheckList_delete<UnityEngine.Object>((UnityEngine.Object)tempObj);
            Destroy(t);
           
        }
        Debug.Log("끝남");
    }

    //동기 로드 후 델리게이트 사용
    public async Task Loder(string obj_name,Action action)
    {

        await AddressablesLoader.InitAssets_name_<GameObject>(obj_name);

       Debug.Log("다녀왔음");

        action();
      //  Instantiate(tempHPbar, pos.transform);
      //Debug.Log("생성함"+pos.name );
    }

    void tempAction()
    {
        Debug.Log("다녀왔음 다음에 실행되면 되겠다.");
    }

    //델리게이트 예시
    IEnumerator temp()
    {
        //yield return StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial("Hpbar", handle => tempHPbar = handle.Result));
        //Debug.Log("다녀왔음" + tempHPbar);

        yield return StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial<GameObject>("Susu_", handle => tempOBJ_ = handle.Result));
        Debug.Log("다녀왔음" + tempOBJ_);
        Instantiate(tempOBJ_, pos.transform);
    }


    async void TaskRun()
    {
        var task = Task.Run(() => TaskRunMethod(3));
        int count = await task;
        Debug.Log("Count : " + task.Result); // 출력 : Count : 3  
    }

    private int TaskRunMethod(int limit)
    {
        int count = 0;
        for (int i = 0; i < limit; i++)
        {
            ++count;
            Thread.Sleep(1000);
        }

        return count;
    }

    async void TaskFromResult()
    {
        int sum = await Task.FromResult(Add(1, 2));
        Debug.Log(sum+"sum"); // 출력 : 3  
    }

    private int Add(int a, int b)
    {
        return a + b;
    }



    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            AddressablesLoader.Destroy_Obj(te);
        }
        
    }
}
