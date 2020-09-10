<?php
error_reporting(E_ALL);

ini_set("display_errors", 1);



//유니티에서 값 받아옴
$shape = $_POST['shape'];
$f_name = $_POST['f_name'];

//BOX
$xyz = $_POST['xyz'];

//Cone
$height = $_POST['height'];

//Face
$index = $_POST['index'];
$coordinate = $_POST['coordinate'];




$testString = "test";

//데이터베이스 연결
$con = mysqli_connect("localhost", "root", "610912", "mydb") or die("fail");





//x3d_type 테이블 생성
$Result = mysqli_query($con, " INSERT INTO x3d_type (File_Name,X3D_Type) VALUES ('$f_name','$shape')");
if($Result)
  echo("x3d_type Create Success. \n");
  else
  echo("x3d_type Create error. \n");


//box 일 경우 primitive 테이블 생성
if($shape == 'Box'){
  
  $Result = mysqli_query($con, "INSERT INTO primitive (xyz,X3D_Type_File_Name,TYPE) VALUES ('$xyz' ,'$f_name','$shape')");

  if($Result){
    echo("Primitive Create Success. \n");
    }
	else{
    echo("Primitive Create error. \n");
	}
}

if($shape == 'Cylinder'){
  $Result = mysqli_query($con, "INSERT INTO primitive (xyz,X3D_Type_File_Name,TYPE) VALUES ('$xyz','$f_name','$shape')");

  if($Result){
    echo("Primitive Create Success. \n");
    }
	else{
    echo("오류 발생: " . mysqli_error($con));
	}
}

if($shape == 'Sphere'){
  $Result = mysqli_query($con, "INSERT INTO primitive (xyz,X3D_Type_File_Name,TYPE) VALUES ('$xyz','$f_name','$shape')");

  if($Result){
    echo("Primitive Create Success. \n");
    }
	else{
    echo("오류 발생: " . mysqli_error($con));
	}
}


if($shape == 'Face'){
   
  $Result = mysqli_query($con, "INSERT INTO indexedface VALUES ('$index','$coordinate','$f_name','$shape')");

  if($Result)
    echo("indexed Create Success. \n");
    else
    echo("indexed 오류 발생: " . mysqli_error($con));
}



//translation 테이블 생성
$Result = mysqli_query($con, "INSERT INTO transform (translation,X3D_Type_File_Name,TYPE) VALUES ('0 0 0','$f_name','$shape')");
  if($Result)
  echo("transform Create Success. \n");
    else
    echo("오류 발생: " . mysqli_error($con));
    




die("fin");
?>