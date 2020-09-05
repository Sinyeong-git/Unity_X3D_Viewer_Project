using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class X3D_Draw : MonoBehaviour
{

    //box,cone,sphere,cylinder, 각각 모양의 게임오브젝트(프리팹)선언
    public GameObject Box;
    public GameObject Cone;
    public GameObject Sphere;
    public GameObject Cylinder;

    public void Draw()
    {
        //중요 변수 초기화
        PSC_rotation = null;
        PSC_scale = null;
        PSC_translation = null;

        //Transform 컴포넌트 값을 바꿔주는 과정
        if (shapeType.Equals("Box") == true)
        {
            //Box 프리팹을 0,0,0 좌표에 회전각 0,0,0 으로 생성
            Instantiate(Box, new Vector3(0, 0, 0), Quaternion.identity);

            //위에서 받은 X Y Z 크기값을 프리팹 컴포넌트에 대입
            Box.transform.localScale = new Vector3(size.x, size.y, size.z);
        }

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


        //SahpeType == Face
        else if (shapeType.Equals("IndexedFaceSet") == true || First_In == true)
        {

            if (First_In == true)
            {
                //Debug.Log("fist in exit");
                First_In = false;
                Key_Draw = false;
                PSC_translation = SC_translation;
                PSC_scale = SC_scale;
                PSC_rotation = SC_rotation;
            }
            else
            {

                //MeshFilter 컴포넌트 가져오기           
                GameObject cGo = new GameObject();
                
                //위치값 변경
                cGo.transform.parent = this.transform;          
                
                //C_DEF의 null 확인
                if (!string.IsNullOrEmpty(C_DEF))
                {
                    cGo.name = C_DEF;
                }

                //Debug.Log("그리기 전 DEF : " + C_DEF);


                //자식설정

                if (GameObject.Find(cGo.name))
                {
                    Transform Parent = GameObject.Find(cGo.name).GetComponent<Transform>();
                    cGo.transform.parent = Parent;
                }
              


                MeshFilter cMeshFilter = cGo.AddComponent<MeshFilter>();
                MeshRenderer cMeshRenderer = cGo.AddComponent<MeshRenderer>();
                Mesh cMesh = new Mesh();

                //mesh translation 루트 요소값 적용
                if (PSC_translation != null)
                {
                    cGo.transform.localPosition = new Vector3(
                    System.Convert.ToSingle(PSC_translation[0]),
                    System.Convert.ToSingle(PSC_translation[1]),
                    System.Convert.ToSingle(PSC_translation[2]));
                }

                if (PSC_scale != null)
                {
                    cGo.transform.localScale = new Vector3(
                    System.Convert.ToSingle(PSC_scale[0]),
                    System.Convert.ToSingle(PSC_scale[1]),
                    System.Convert.ToSingle(PSC_scale[2]));
                }
                if (PSC_rotation != null)
                {
                    cGo.transform.localRotation = Quaternion.Euler(new Vector4(
                    System.Convert.ToSingle(PSC_rotation[0]),
                    System.Convert.ToSingle(PSC_rotation[1]),
                    System.Convert.ToSingle(PSC_rotation[2]),
                    System.Convert.ToSingle(PSC_rotation[3])));
                }


                cMesh.Clear();
                //vertext 데이터 삽입
                cMesh.vertices = _Vertex.ToArray();
                //인접 verrtext 데이터 삽입
                cMesh.triangles = _Tri.ToArray();


                
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
               

                //메쉬 생성
                cMesh.RecalculateBounds();
                cMesh.RecalculateNormals();
           
                //텍스쳐 변수 적용
                Material cMaterial;
                cMeshFilter.mesh = cMesh;
                cMaterial = GameObject.Instantiate(Resources.Load("metal") as Material);
               
                
              
                //texture 처리 로직 (기본값 metal texture)
              if(string.IsNullOrEmpty(C_imagetexture))
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


                //bool형 캐쉬 초기화
                Key_Draw = false;


                //리스트 초기화
                _Tri.Clear();
                _Vertex.Clear();

                //이전 SC값을 PSC에 저장
                PSC_translation = SC_translation;
                PSC_scale = SC_scale;
                PSC_rotation = SC_rotation;
            }
        }
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

*/
