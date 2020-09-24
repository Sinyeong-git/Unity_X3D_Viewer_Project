using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X3D_Obj_Transform 
{

    //Obj_Shape 리스트
    private List<X3D_Obj_Shape> X3D_Obj_Shape = new List<X3D_Obj_Shape>();

    //mesh 자료값 변수들
    string[] translation;
    string[] scale;
    string scaleOrientation;
    string[] rotation;
    string def;


    public List<X3D_Obj_Shape> Get_X3D_Obj_Shape() { return X3D_Obj_Shape; }

    public int Get_X3D_Obj_Shape_Count() { return X3D_Obj_Shape.Count; }

    public void Set_translation(string[] _input) { translation = _input; }
    public string[] Get_translation() { return translation; }

    public void Set_scale(string[] _input) { scale = _input; }
    public string[] Get_scale() { return scale; }

    public void Set_scaleOrientation(string _input) { scaleOrientation = _input; }
    public string Get_scaleOrientation() { return scaleOrientation; }


    public void Set_rotation(string[] _input) { rotation = _input; }
    public string[] Get_rotation() { return rotation; }



    public void Set_def(string _input) { def = _input; }
    public string Get_def() { return def; }




    /*

    public int ShapeCount = -1;





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

    private void Start()
    {
        ShapeCount = -1;
    }


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

    */


    //xml의 value값을 받아내는 Cache용 string 선언 
    /*
    public string C_xyz, C_bottom, C_height, C_bottomRadius, C_sides, C_side, C_radius, C_top,
           C_index, C_point, C_color, C_diffuseColor, C_ambientIntensity, C_shininess, C_specularColor,
           C_emissiveColor, C_imagetexture, C_texturepoint, C_translation, , C_scale, ;
    */
    /*
    //2개이상의 개체경우를 위한 예외적처리 캐쉬
    [HideInInspector]
    public bool First_In = true;
    [HideInInspector]
    public bool Key_Draw = false;

  

    [HideInInspector]
    public string[] PSC_translation;
    [HideInInspector]
    public string[] PSC_scale;
    [HideInInspector]
    public string[] PSC_rotation;
    */



}

