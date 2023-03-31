using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Test_AssetBundle : MonoBehaviour
{
	/***********************************************************************
		 * �뵵 : MenuItem�� ����ϸ� �޴�â�� ���ο� �޴��� �߰��� �� �ֽ��ϴ�.		      
		 * (�Ʒ��� �ڵ忡���� Bundles �׸� ���� �׸����� Build AssetBundles �׸��� �߰�.)  
		 ***********************************************************************/
#if UNITY_EDITOR
	[MenuItem("Bundles/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
		/***********************************************************************
		* �̸� : BuildPipeLine.BuildAssetBundles()
	    * �뵵 : BuildPipeLine Ŭ������ �Լ� BuildAssetBundles()�� ���¹����� ������ݴϴ�.     
	    * �Ű��������� String ���� �ѱ�� �Ǹ�, ����� ���� ������ ������ ����Դϴ�. 
	    * ���� ��� Assets ���� ������ �����Ϸ��� "Assets/AssetBundles"�� �Է��ؾ��մϴ�.
	    ***********************************************************************/
		BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
	}
#endif
}

