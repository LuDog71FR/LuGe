Create Table RawMaterial (
	rmIndex 	VarChar(15)	Primary Key,
	rmText		VarChar(30)	,
	rmWeight 	Real
);

Insert Into RawMaterial Values ('123', 'test 123', 12.4);
Insert Into RawMaterial Values ('456', 'test 456', 68.0);
