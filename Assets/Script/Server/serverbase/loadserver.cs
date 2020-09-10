using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class loadserver : MonoBehaviour
{
    #region 맴버 변수 선언
    string FileName = null;
    string testtext;
    int NumberT;
    string cashString;
    string[] cashArrayString;
    public InputField f_input;
    public Text f_text;

    private char sp = ' ';
    string shapeType = null;
    Vector3 size = new Vector3();
    string xyz;

    string point, index;

    List<Vector3> _Vertex = null;
    List<int> _Tri = null;

    private List<X3D_Obj_Transform> X3D_Obj_Transform = new List<X3D_Obj_Transform>();
    #endregion

    //유니티 실행시 한번 실행되는 클래스
    public void StartLoad()
    {
        //데이터베이스에서 값 읽어오기
        StartCoroutine(LoadCo_type("http://localhost/load.php"));
    }

    IEnumerator LoadCo_type(string url)
    {
        Debug.Log("Load co 실행");
        Debug.Log(url);
        NumberT = 1;

        WWWForm form = new WWWForm();

        form.AddField("f_name", FileName);
        form.AddField("numberT", NumberT);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("로딩실패: " + uwr.error);
        }


        //디버깅용
        //shapeType = "Face";


        //세부 사항 로드 시작

        //Primitv 케이스 일때 세부사항 읽어오기
        if (shapeType.Equals("Box") == true || shapeType.Equals("Sphere") == true || shapeType.Equals("Cylinder") == true)
        {
            NumberT = 2;

            Debug.Log("프리미티브 함수 실행");

           

            WWWForm form2 = new WWWForm();

            form2.AddField("f_name", FileName);
            form2.AddField("numberT", NumberT);
            form2.AddField("shapeType", shapeType);

            UnityWebRequest uwr2 = UnityWebRequest.Post(url, form2);


            yield return uwr2.SendWebRequest();

            if (uwr2.isNetworkError)
            {
                Debug.Log("로딩실패: " + uwr2.error);
            }
            else
            {
                Debug.Log("Received: " + uwr2.downloadHandler.text);
            }

            xyz = uwr2.downloadHandler.text;

            Debug.Log("C_xyz : " + xyz);

            string[] SC_xyz = xyz.Split(sp);

            //Box_Size 구조체에 float 형변환 후 대입          
            size.x = System.Convert.ToSingle(SC_xyz[0]);
            size.y = System.Convert.ToSingle(SC_xyz[1]);
            size.z = System.Convert.ToSingle(SC_xyz[2]);

        }



        if (shapeType.Equals("Face"))
        {
            NumberT = 3;

            Debug.Log("폴리곤(페이스) 함수 실행");



            WWWForm form3 = new WWWForm();

            form3.AddField("f_name", FileName);
            form3.AddField("numberT", NumberT);
            form3.AddField("shapeType", shapeType);

            UnityWebRequest uwr3 = UnityWebRequest.Post(url, form3);


            yield return uwr3.SendWebRequest();

            if (uwr3.isNetworkError)
            {
                Debug.Log("로딩실패: " + uwr3.error);
            }
            else
            {
                Debug.Log("Received: " + uwr3.downloadHandler.text);
            }
            cashString = uwr3.downloadHandler.text;
            cashArrayString = cashString.Split('&');


            point = cashArrayString[0];
            index = cashArrayString[1];

            Debug.Log("Indexedface : " + index);
            Debug.Log("coordinatepoint : " + point);

            //_Vertex 리스트에 값 대입
            string[] SC_point = point.Split(sp);
            //Position 값들
            for (int i = 0; i < SC_point.Length; i += 3)
            {

                if (i + 1 >= SC_point.Length ||
                    i + 2 >= SC_point.Length)
                {
                    continue;
                }


                SC_point[i] = SC_point[i].Replace(",", "");
                SC_point[i + 1] = SC_point[i + 1].Replace(",", "");
                SC_point[i + 2] = SC_point[i + 2].Replace(",", "");


                _Vertex.Add(new Vector3(
                            System.Convert.ToSingle(SC_point[i]),
                            System.Convert.ToSingle(SC_point[i + 1]),
                            System.Convert.ToSingle(SC_point[i + 2])));
            }
           


            //_Tri 리스트에 값 대입
            string[] SC_index = index.Split(sp);

            int nResult = 0;
            for (int i = 0; i < SC_index.Length; i++)
            {
                if (int.TryParse(SC_index[i], out nResult) == true)
                {
                    if (int.Parse(SC_index[i]) == -1)
                    {
                        continue;
                    }
                    _Tri.Add(int.Parse(SC_index[i]));
                }
            }

            Debug.Log("_Vertex 값 : " + _Vertex);
            Debug.Log("_Tri 값 : " + _Tri);
        }




    }
    
}


