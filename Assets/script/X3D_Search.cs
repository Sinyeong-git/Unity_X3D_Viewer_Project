using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class X3D_Search : MonoBehaviour
{
    #region 맴버 변수 선언
    //공백 자르기용
    private char sp;
    private List<X3D_Obj_Transform> X3D_Obj_Transform;
    #endregion

    #region 이니셜라이저
    public void Initialize()
    {
        X3D_Obj_Transform = new List<X3D_Obj_Transform>();
        sp = ' ';
    }
    #endregion

    public void Start()
    {
        Initialize();
    }

    public List<X3D_Obj_Transform> StartSearch(XmlNode _xmlNode)
    {
        if (_xmlNode != null)
        {
            Search(_xmlNode);
        }

        return X3D_Obj_Transform;
    }

    private void Search(XmlNode _parentNode)
    {

        //Debug.Log("노드 : " + _parentNode.Name);


        //<Transform> root의 transform 값 받아오는 처리
        if (_parentNode.Name.Equals("Transform") == true)
        {
            X3D_Obj_Transform.Add(new X3D_Obj_Transform());

            for (int i = 0; i < _parentNode.Attributes.Count; ++i)
            {
                if (_parentNode.Attributes[i].Name.Equals("translation") == true)
                {
                    string temp = _parentNode.Attributes[i].Value;
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Set_translation(temp.Split(sp));
                    //Debug.Log("translation : " + temp);
                }

                if (_parentNode.Attributes[i].Name.Equals("scaleOrientation") == true)
                {
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Set_scaleOrientation(_parentNode.Attributes[i].Value);
                    Debug.Log("scaleOreintation : " + X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_scaleOrientation());
                }

                if (_parentNode.Attributes[i].Name.Equals("scale") == true)
                {
                    string temp  = _parentNode.Attributes[i].Value;
                    Debug.Log("scale : " + temp);
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Set_scale(temp.Split(sp));
                }

                if (_parentNode.Attributes[i].Name.Equals("rotation") == true)
                {
                    string temp = _parentNode.Attributes[i].Value;
                    Debug.Log("rotation : " + temp);
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Set_rotation(temp.Split(sp));
                }

                if (_parentNode.Attributes[i].Name.Equals("DEF") == true)
                {
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Set_def(_parentNode.Attributes[i].Value);

                    //Debug.Log("DEF : " + X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_def());
                }
            }
        }


        if (_parentNode.Name.Equals("Shape") == true)
        {
            X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape().Add(new X3D_Obj_Shape());
        }



        //<Coorrinate> root경우의 속성값 받아오는 처리                 
        if (_parentNode.Name.Equals("Coordinate") == true)
        {
            for (int i = 0; i < _parentNode.Attributes.Count; ++i)
            {
                if (_parentNode.Attributes[i].Name.Equals("point") == true)
                {
                    string[] temp = (_parentNode.Attributes[i].Value.Split)(sp);
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape()[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape_Count() - 1].Set_corrdinatePoint();

                    //_Vertex 리스트에 값 대입
                    for (int j = 0; j < temp.Length; j += 3)
                    {
                        //아웃 어레이 예외
                        if (j + 1 >= temp.Length ||
                            j + 2 >= temp.Length)
                        {
                            continue;
                        }

                        // ',' 를 공백으로
                        temp[j] = temp[j].Replace(",", "");
                        temp[j + 1] = temp[j + 1].Replace(",", "");
                        temp[j + 2] = temp[j + 2].Replace(",", "");

                        X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape()[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape_Count() - 1].Add_corrdinatePoint(
                               new Vector3(
                                            System.Convert.ToSingle(temp[j]),
                                            System.Convert.ToSingle(temp[j + 1]),
                                            System.Convert.ToSingle(temp[j + 2]))
                                          );                    
                    }
                   
                    //Debug.Log("Vertex 값 : " + X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].X3D_Obj_Shape[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].X3D_Obj_Shape.Count - 1].Get_corrdinatePoint());              
                }         
            }
        }




        //<IndexedFaceSet> root경우의 속성값 받아오는 처리                    
        if (_parentNode.Name.Equals("IndexedFaceSet") == true)
        {
            X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape()[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape_Count() - 1].Set_shapeType("IndexedFaceSet");

            //Debug.Log("Type : IndexedFaceSet ");

            for (int i = 0; i < _parentNode.Attributes.Count; ++i)
            {
                if (_parentNode.Attributes[i].Name.Equals("coordIndex") == true)
                {
                    X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape()[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape_Count() - 1].Set_corrdinateIndex();

                    string[] temp = _parentNode.Attributes[i].Value.Split(sp);

                    int nResult = 0;

                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (int.TryParse(temp[j], out nResult) == true)
                        {
                            if (int.Parse(temp[j]) == -1)
                            {
                                continue;
                            }
                            X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape()[X3D_Obj_Transform[X3D_Obj_Transform.Count - 1].Get_X3D_Obj_Shape_Count() - 1].Add_corrdinateIndex(int.Parse(temp[j]));
                        }
                    }
                }
            }





        }








        //자식 노드가 있다면
        if (_parentNode.HasChildNodes)
        {
            //자식 노드를 기준으로
            foreach (XmlNode childNode in _parentNode)
            {
                Search(childNode);
            }
        }
    }

}
