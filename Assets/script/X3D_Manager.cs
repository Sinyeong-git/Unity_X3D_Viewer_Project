using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using System.IO;




public class X3D_Manager : MonoBehaviour
{
    [Header("파일 이름")]
    [SerializeField] string FileName = "Meetingroom_withfloor";

    XmlNode XD;

    X3D_Search X3D_Search;

    X3D_Draw X3D_Draw;

    void Initialize()
    {
        XD = null;

        X3D_Search = gameObject.AddComponent<X3D_Search>();
        X3D_Search.Initialize();

        X3D_Draw = gameObject.AddComponent<X3D_Draw>();
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
        StreamReader sr = new StreamReader("Assets/X3D_File/" + FileName + ".x3d");

        //textAsset의 XmlDocumnet화
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(sr.ReadToEnd());  
        return xmlDoc;
    }


}


