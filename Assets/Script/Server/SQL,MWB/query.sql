SET SQL_SAFE_UPDATES = 0;
SET FOREIGN_KEY_CHECKS = 0;

describe primitive;
describe x3d_type;
describe transform;
describe indexedface;

show tables;


delete from x3d_type;
delete from primitive;
delete from transform;
delete from indexedface;

select * from x3d_type;
select * from primitive;
select * from transform;
select * from indexedface;

select x3d_type from x3d_type where File_Name="Face";



select xyz from primitive where (X3D_Type_File_Name = 'Box' and TYPE = 'Box');

insert into x3d_type values ('test','test');
INSERT INTO indexedface VALUES ('10 20','30 40', 'test', 'test');


select * from indexedface where X3D_Type_File_Name = 'test';

select * from indexedface;

select * from indexedface where X3D_Type_File_Name = 'test' and TYPE = 'test'

INSERT INTO transform (translation,X3D_Type_File_Name,TYPE) VALUES ('0 0 0','$f_name','$shape');