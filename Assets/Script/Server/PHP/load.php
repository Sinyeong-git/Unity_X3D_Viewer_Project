<?php


error_reporting(E_ALL);
ini_set("display_errors", 0);


//유니티에서 값 받아옴
$f_name = $_POST['f_name'];
$numberT = $_POST['numberT'];
$shapeType = $_POST['shapeType'];

//데이터베이스 연결
$con = mysqli_connect("localhost", "root", "610912", "mydb") or die("fail");

if($numberT == 1){
	//echo("type 읽어내기 실행");

	$Result = mysqli_query($con, "select x3d_type from x3d_type where (File_Name = '$f_name')");


		while($row = mysqli_fetch_array($Result)){
	
			echo($row[x3d_type]);

		}

	if(!$Result) echo("타입 읽기 오류 : " . mysqli_error($con));
}

if($numberT == 2){
	//echo("Primitive Type 읽어내기 실행");
	//echo(f_name+shapeType);

	$Result = mysqli_query($con, "select xyz from primitive where X3D_Type_File_Name = '$f_name' and TYPE = '$shapeType'");


		while($row = mysqli_fetch_array($Result)){
			echo($row[xyz]);
		}

	if(!$Result) echo("Primitive 세부타입 읽기 오류 : " . mysqli_error($con));
}

if($numberT == 3){

	//echo("폴리곤 데이터 읽어내기 실행");

	$Result = mysqli_query($con, "select * from indexedface where (X3D_Type_File_Name = '$f_name' and TYPE = '$shapeType')");

	while($row = mysqli_fetch_array($Result)){
			echo($row[index]);
			echo("&");
			echo($row[coordinate]);
		}
		
	if(!$Result) echo("폴리곤 세부타입 읽기 오류 : " . mysqli_error($con));
}



die();
?>