using System.Xml;
using System.Collections.Generic;
using UnityEngine;





public class X3D_Manager : MonoBehaviour
{
    XmlNode XD;

    X3D_Search X3D_Search;

    X3D_Draw X3D_Draw;

    void Initialize()
    {
        XD = null;

        X3D_Search = gameObject.AddComponent<X3D_Search>();

        X3D_Draw = new X3D_Draw();
    }


    //유니티 실행시 한번 실행되는 클래스
    void Start()
    {
        Initialize();

        //X3D 노드 리스트 저장
        XD = X3D_Load();

        //X3D 파일 탐색 시작
        List<X3D_Obj_Transform> X3D_Obj_Transform = X3D_Search.StartSearch(XD);

        X3D_Draw.Draw(X3D_Obj_Transform);

        //Normalize();
    }

    XmlDocument X3D_Load()
    {
        string FileName = "Meetingroom_withfloor";

        ////////////////////////===========XML파일명=================/////////////////////
        TextAsset textAsset = (TextAsset)Resources.Load(FileName);

        Debug.Log("File Name : " + FileName + ".xml");

        //textAsset의 XmlDocumnet화
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        //firstCreate();
        return xmlDoc;
    }


}


