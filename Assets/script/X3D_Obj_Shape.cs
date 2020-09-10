using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X3D_Obj_Shape
{

    string shapeType;
    List<Vector3> corrdinatePoint;
    List<int> corrdinateIndex;

    public void Set_corrdinatePoint() { corrdinatePoint = new List<Vector3>(); }
    public void Add_corrdinatePoint(Vector3 _input) { corrdinatePoint.Add(_input); }
    public List<Vector3> Get_corrdinatePoint() { return corrdinatePoint; }

    public void Set_corrdinateIndex() { corrdinateIndex = new List<int>(); }
    public void Add_corrdinateIndex(int _input) { corrdinateIndex.Add(_input); }
    public List<int> Get_corrdinateIndex() { return corrdinateIndex; }

    public void Set_shapeType(string _input) { shapeType = _input; }
    public string Get_shapeType() { return shapeType; }










    /*
    //mesh 표현을 위한 요소들
    //vertex들의 위치 저장 객체
    [HideInInspector]
    public List<Vector3> _Vertex = new List<Vector3>();
    //다른 인접 vertex의 Index값
    [HideInInspector]
    public List<int> _Tri = new List<int>();
    //텍스쳐매핑 index값
    [HideInInspector]
    public List<Vector2> _Texture = new List<Vector2>();

    //Transform 값들


    //각각의 구조체 선언
    [HideInInspector]
    public struct Box_Size
    {
        public float x, y, z;

        public Box_Size(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public Box_Size size = new Box_Size();

    [HideInInspector]
    public struct Cone_Value
    {
        public float bottomRadius, height;
        public string bottom, side;

        public Cone_Value(string bottom, float bottomRadius, float height, string side)
        {
            this.bottom = bottom;
            this.bottomRadius = bottomRadius;
            this.height = height;
            this.side = side;
        }
    }
   public Cone_Value C_V = new Cone_Value();

    [HideInInspector]
    public struct Sphere_Value
    {
        public float a;

        public Sphere_Value(float a)
        {
            this.a = a;
        }
    }
    public Sphere_Value S_V = new Sphere_Value();

    [HideInInspector]
    public struct Cylinder_Value
    {
        public float radius;
        public string bottom, side, top;

        public Cylinder_Value(string bottom, float radius, string side, string top)
        {
            this.bottom = bottom;
            this.radius = radius;
            this.side = side;
            this.top = top;
        }
    }
    public Cylinder_Value Cl_V = new Cylinder_Value();

    [HideInInspector]
    public struct IndexedFaceSet_Value
    {
        public float indexed;

        public IndexedFaceSet_Value(float indexed)
        {
            this.indexed = indexed;
        }
    }

    [HideInInspector]
    //xml 파일의 모양 값 받는 string 선언
    public string shapeType = "NULL";

    [HideInInspector]
    //xml의 value값을 받아내는 Cache용 string 선언 
    public string C_xyz, C_bottom, C_height, C_bottomRadius, C_sides, C_side, C_radius, C_top,
           C_index, C_point, C_color, C_diffuseColor, C_ambientIntensity, C_shininess, C_specularColor,
           C_emissiveColor, C_imagetexture, C_texturepoint, C_translation, C_rotation, C_scale, C_scaleOrientation, C_DEF;

    //2개이상의 개체경우를 위한 예외적처리 캐쉬
    [HideInInspector]
    public bool First_In = true;
    [HideInInspector]
    public bool Key_Draw = false;

    [HideInInspector]
    //mesh형식 정상화를 위한 변수
    public string[] SC_translation;
    [HideInInspector]
    public string[] SC_scale;
    [HideInInspector]
    public string[] SC_rotation;

    [HideInInspector]
    public string[] PSC_translation;
    [HideInInspector]
    public string[] PSC_scale;
    [HideInInspector]
    public string[] PSC_rotation;

    */



}

