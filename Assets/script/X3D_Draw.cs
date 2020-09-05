using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class X3D_Draw : MonoBehaviour
{
    //box,cone,sphere,cylinder, 각각 모양의 게임오브젝트(프리팹)선언
    public GameObject Box;
    public GameObject Cone;
    public GameObject Sphere;
    public GameObject Cylinder;

    public void Draw(List<X3D_Obj_Transform> X3D_Obj_Transform)
    {
        //부모 모델 설정
        Transform parentGameObject = GameObject.Find("Model").GetComponent<Transform>();

        for (int i = 0; i < X3D_Obj_Transform.Count ; i++) {

            List<X3D_Obj_Shape> X3D_Obj_Shape = X3D_Obj_Transform[i].Get_X3D_Obj_Shape();

            if (X3D_Obj_Shape != null)
            {
                for (int j = 0; j < X3D_Obj_Shape.Count; j++)
                {

                    Debug.Log("coordinate index : " + X3D_Obj_Shape[j].Get_corrdinateIndex());

                    //Transform 컴포넌트 값을 바꿔주는 과정
                    if (X3D_Obj_Shape[j].Get_shapeType().Equals("Box") == true)
                    {
                        Vector3 spawnPostion = new Vector3();

                        //Box 프리팹을 0,0,0 좌표에 회전각 0,0,0 으로 생성
                        Instantiate(Box, spawnPostion, Quaternion.identity);

                        //위에서 받은 X Y Z 크기값을 프리팹 컴포넌트에 대입
                        //Box.transform.localScale = new Vector3(size.x, size.y, size.z);
                    }



                    //SahpeType == Face
                    else if (X3D_Obj_Shape[j].Get_shapeType().Equals("IndexedFaceSet") == true)
                    {

                        //MeshFilter 컴포넌트 가져오기           
                        GameObject shapeGameObject = new GameObject();

                        //자식화
                        shapeGameObject.transform.parent = parentGameObject;

                        //C_DEF의 null 확인
                        if (!string.IsNullOrEmpty(X3D_Obj_Transform[i].Get_def()))
                        {
                            shapeGameObject.name = X3D_Obj_Transform[i].Get_def();
                        }

                        //자식설정
                        if (GameObject.Find(X3D_Obj_Transform[i].Get_def()))
                        {
                            Transform Parent = GameObject.Find(X3D_Obj_Transform[i].Get_def()).GetComponent<Transform>();
                            shapeGameObject.transform.parent = Parent;
                        }



                        MeshFilter cMeshFilter = shapeGameObject.AddComponent<MeshFilter>();
                        MeshRenderer cMeshRenderer = shapeGameObject.AddComponent<MeshRenderer>();
                        Mesh cMesh = new Mesh();

                        //mesh translation 루트 요소값 적용
                        if (X3D_Obj_Transform[i].Get_translation() != null)
                        {

                            shapeGameObject.transform.localPosition = new Vector3(
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_translation()[0]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_translation()[1]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_translation()[2]));
                        }

                        if (X3D_Obj_Transform[i].Get_scale() != null)
                        {
                            shapeGameObject.transform.localScale = new Vector3(
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_scale()[0]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_scale()[1]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_scale()[2]));
                        }
                        if (X3D_Obj_Transform[i].Get_rotation() != null)
                        {
                            shapeGameObject.transform.localRotation = Quaternion.Euler(new Vector4(
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_rotation()[0]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_rotation()[1]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_rotation()[2]),
                            System.Convert.ToSingle(X3D_Obj_Transform[i].Get_rotation()[3])));
                        }


                        //cMesh.Clear();


                        if (X3D_Obj_Shape[j].Get_corrdinatePoint() != null)
                        {
                            //CoordinatePoint 데이터 삽입
                            cMesh.vertices = X3D_Obj_Shape[j].Get_corrdinatePoint().ToArray();
                            //인접 Coordinaindex 데이터 삽입
                            cMesh.triangles = X3D_Obj_Shape[j].Get_corrdinateIndex().ToArray();
                        }

 
                           

                        /*
                        //텍스쳐 데이터 삽입 부화 관련 주석, 차후 수정, Nullorempty 관련 처리로 바꿔야 할 것으로 예상
                        if (!string.IsNullOrEmpty(C_imagetexture))
                        {
                            List<Vector2> listTemp = new List<Vector2>();
                            for (int j = 0; j < cMesh.vertices.Length; ++j)
                            {
                                if (j < _Texture.Count)
                                {
                                    listTemp.Add(_Texture[j]);
                                }
                            }

                            for (int j = 0; j < cMesh.triangles.Length; ++j)
                            {
                                if (cMesh.triangles[j] < listTemp.Count
                                    && C_index[j] < _Texture.Count)
                                {
                                    listTemp[cMesh.triangles[j]] = _Texture[C_index[j]];
                                }
                            }
                            while (listTemp.Count < cMesh.vertices.Length)
                            {
                                listTemp.Add(new Vector2(0f, 0f));
                            }
                            cMesh.uv = listTemp.ToArray();
                        }
                        */

                        //메쉬 생성
                        cMesh.RecalculateBounds();
                        cMesh.RecalculateNormals();



                        //텍스쳐 변수 적용
                        Material cMaterial;
                        cMeshFilter.mesh = cMesh;
                        cMaterial = GameObject.Instantiate(Resources.Load("metal") as Material);



                        //texture 처리 로직 (기본값 metal texture)
                        if (string.IsNullOrEmpty( null ))
                        {
                            cMaterial = GameObject.Instantiate(Resources.Load("metal") as Material);
                        }
                        else
                        {
                            cMaterial = GameObject.Instantiate(Resources.Load("metal") as Material);
                            //cMaterial = GameObject.Instantiate(Resources.Load(C_imagetexture) as Material);                              
                        }

                        cMeshRenderer.material = cMaterial;

                        Debug.Log("그리기 완료");

                    }
                }

            }



        }











        /*



        //ShapeType == Cone  
        else if (shapeType.Equals("Cone") == true)
        {
            Instantiate(Cone, new Vector3(0, C_V.height, 0), Quaternion.identity);

            Cone.transform.localScale = new Vector3(C_V.bottomRadius, C_V.height, C_V.bottomRadius);

            Cone.transform.localRotation = new Quaternion(90, 0, 0, 0);

        }

        //ShapeType == Sphere
        else if (shapeType.Equals("Sphere") == true)
        {
            Instantiate(Sphere, new Vector3(0, 0, 0), Quaternion.identity);
        }

        //ShapeType == Cylinder
        else if (shapeType.Equals("Cylinder") == true)
        {
            Instantiate(Cylinder, new Vector3(0, 0, 0), Quaternion.identity);

            Cylinder.transform.localScale = new Vector3(Cl_V.radius, Cl_V.radius, Cl_V.radius);
        }




        */
   
    
    }



}


