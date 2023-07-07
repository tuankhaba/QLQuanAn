CREATE DATABASE QL_QUANAN999
go
USE QL_QUANAN999
go
CREATE TABLE NHACUNGCAP
(
	MANCC int identity,
	TENNCC NVARCHAR(50) NOT NULL,
	DIAC NVARCHAR(50) NOT NULL,
	SDT CHAR(11) NOT NULL,
	CONSTRAINT PK_MANCC PRIMARY KEY(MANCC)
)

CREATE TABLE NHANVIEN
(
	MANV int identity ,
	HOT NVARCHAR(50) NOT NULL,
	NGAYS DATE NOT NULL,
	GIOIT NVARCHAR(5) NOT NULL,
	SDT CHAR(11) NOT NULL,
	TRANGTHAI BIT NOT NULL,
	CONSTRAINT PK_MANV PRIMARY KEY(MANV)
)
SET DATEFORMAT DMY
INSERT INTO NHANVIEN VALUES(N'TUẤN KHA','21/09/2002','NAM','032555',1)
INSERT INTO NHANVIEN VALUES(N'TUẤN KHANG','21/09/2002','NAM','032555',1)
CREATE TABLE BANAN
(
	MABA int identity,
	TENB NVARCHAR(50),
	TRANGTHAI INT,
	CONSTRAINT PK_MABA PRIMARY KEY(MABA)
)
CREATE TABLE KHACHHANG
(
	MAKH int identity,
	TENKH NVARCHAR(50),
	DIAC NVARCHAR(50),
	SDT int,
	CONSTRAINT PK_MAKH PRIMARY KEY(MAKH)
)
CREATE TABLE LOAI
(
	MAL int identity,
	TENL NVARCHAR(50),
	CONSTRAINT PK_MAL PRIMARY KEY(MAL)
)
CREATE TABLE MONAN
(
	MAMA int identity,
	TENMA NVARCHAR(50) NOT NULL,
	GIA FLOAT NOT NULL,
	MAL INT,
	CONSTRAINT PK_MAMA PRIMARY KEY(MAMA)
)
ALTER TABLE MONAN
ADD CONSTRAINT FK_MA_ML FOREIGN KEY(MAL) REFERENCES LOAI(MAL)
CREATE TABLE HOADON
(
	MAHD int identity,
	GIOV datetime,
	GIOR datetime ,
	TRANGTHAI INT NOT NULL,
	NGAYL DATETIME NOT NULL,
	TONGTT float,
	MABA INT NOT NULL,
	MANV int NOT NULL,
	MAKH int NOT NULL,
	GIAMGIA int,
	CONSTRAINT PK_MAHD PRIMARY KEY(MAHD)
)
ALTER TABLE HOADON
ADD CONSTRAINT FK_BANVKH FOREIGN KEY(MABA) REFERENCES BANAN(MABA)
ALTER TABLE HOADON
ADD CONSTRAINT FK_BANVKH2 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
ALTER TABLE HOADON
ADD CONSTRAINT FK_BANVKH3 FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
CREATE TABLE CHITIETMONAN
(
	MACT int identity,
	MAMA int,
	MAHD int,
	SOL INT NOT NULL,
	CONSTRAINT PK_MAMA_MAHD PRIMARY KEY(MAHD,MAMA,MACT)
)
ALTER TABLE CHITIETMONAN 
ADD CONSTRAINT FK_MAMA FOREIGN KEY(MAMA) REFERENCES MONAN(MAMA)
ALTER TABLE CHITIETMONAN 
ADD CONSTRAINT FK_MAHD FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD)

CREATE TABLE THUCPHAM
(
	MATP int identity,
	TENTP NVARCHAR(50) NOT NULL,
	SOL INT NOT NULL,
	DONV nvarchar(50) NOT NULL,
	CONSTRAINT PK_MATP PRIMARY KEY(MATP)
)
CREATE TABLE NGUYENLIEU
(
	MATP int,
	MAMA int,
	HAML int NOT NULL,
	CONSTRAINT PK_MATP_MAMA PRIMARY KEY(MATP,MAMA)
)
ALTER TABLE NGUYENLIEU 
ADD CONSTRAINT FK_MATP FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
ALTER TABLE NGUYENLIEU 
ADD CONSTRAINT FK_MAMA2 FOREIGN KEY(MAMA) REFERENCES MONAN(MAMA)
CREATE TABLE PHIEUDAT
(
	MAPD int identity,
	MANCC int NOT NULL,
	NGAYD DATETIME NOT NULL,
	TONGSL INT NOT NULL ,
	CONSTRAINT PK_MAPD PRIMARY KEY(MAPD)
)
alter table PHIEUDAT
add constraint fk_mapd_mannc foreign key(MANCC) REFERENCES NHACUNGCAP(MANCC)
CREATE TABLE PHIEUGIAO
(
	MAPG int identity,
	MAPD int NOT NULL,
	NGAYG DATETIME NOT NULL,
	TONGSL INT NOT NULL,
	THANHTIEN FLOAT NOT NULL,
	LANGIAO INT NOT NULL,
	CONSTRAINT PK_MAPG PRIMARY KEY(MAPG)
)
ALTER TABLE PHIEUGIAO
ADD CONSTRAINT FK_PD FOREIGN KEY(MAPD) REFERENCES PHIEUDAT(MAPD)
CREATE TABLE CHITIETPHIEUDAT
(
	MAPD int,
	MATP int,
	SOL INT NOT NULL ,
	CONSTRAINT PK_MAPD_MATP PRIMARY KEY(MAPD,MATP)
)
ALTER TABLE CHITIETPHIEUDAT 
ADD CONSTRAINT FK_MAPD FOREIGN KEY(MAPD) REFERENCES PHIEUDAT(MAPD)
ALTER TABLE CHITIETPHIEUDAT 
ADD CONSTRAINT FK_MATP1 FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
CREATE TABLE CHITIETPHIEUGIAO
(
	MAPG int,
	MATP int,
	SOL INT NOT NULL,
	CONSTRAINT PK_MAPG_MATP PRIMARY KEY(MAPG,MATP)
)
ALTER TABLE CHITIETPHIEUGIAO 
ADD CONSTRAINT FK_MAPG1 FOREIGN KEY(MAPG) REFERENCES PHIEUGIAO(MAPG)
ALTER TABLE CHITIETPHIEUGIAO 
ADD CONSTRAINT FK_MATP2 FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
CREATE TABLE NGUONCUNG
(
	MANCC int,
	MATP int,
	GIA FLOAT NOT NULL,
	CONSTRAINT PK_MANCC_MATP PRIMARY KEY(MANCC,MATP)
)
ALTER TABLE NGUONCUNG 
ADD CONSTRAINT FK_MANCC1 FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)
ALTER TABLE NGUONCUNG 
ADD CONSTRAINT FK_MATP3 FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
-------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------TAO RANG BUOC--------------------------------------------
---------------------------RANG BUOC CHO BANG NHAN VIEN------------------------------------------------------------------
--ALTER TABLE NHANVIEN
--ADD CONSTRAINT CK_GT CHECK(GIOIT IN (N'NAM',N'NỮ'))
--ALTER TABLE NHANVIEN
--ADD CONSTRAINT CK_TUOI CHECK((YEAR(GETDATE())-YEAR(NGAYS))>=18)
--ALTER TABLE NHANVIEN 
--ADD CONSTRAINT CK_TT CHECK(TRANGTHAI IN (0,1))
-----------------------------RANG BUOC CHO BANG BAN AN--------------------------------------------------------------------------
--ALTER TABLE BANAN 
--ADD CONSTRAINT CK_TTB CHECK(TRANGTHAI IN (0,1))
-----------------------------RANG BUOC CHO MON AN---------------------------------------------------------------------------
--ALTER TABLE MONAN 
--ADD CONSTRAINT CK_GIAMA CHECK(GIA >0)
-----------------------------RANG BUOC CHO DO UONG---------------------------------------------------------------------------------
--ALTER TABLE DOUONG 
--ADD CONSTRAINT CK_GIADU CHECK(GIA >0)
--ALTER TABLE DOUONG 
--ADD CONSTRAINT CK_HANGTON CHECK(HANGTON >0)
-----------------------------RANG BUOC CHO HOA DON----------------------------------------------
--ALTER TABLE HOADON
--ADD CONSTRAINT CK_NGAYVR CHECK(GIOR>GIOV)
--ALTER TABLE HOADON
--ADD CONSTRAINT CK_TTHD CHECK(TRANGTHAI IN (0,1))
--ALTER TABLE HOADON
--ADD CONSTRAINT CK_TTT CHECK(TONGTT>0)
------------------------------ RANG BUOC CHI TIET MON AN--------------------------------------------------------------
--ALTER TABLE CHITIETMONAN
--ADD CONSTRAINT CK_SL CHECK(SOL>0)
--------------------------------RANG BUOC CHI TIET DO UONG---------------------------------------------
--ALTER TABLE CHITIETDOUONG
--ADD CONSTRAINT CK_SL1 CHECK(SOL>0)
-------------------------------RANG BUOC THUC PHAM------------------------------------------------------
ALTER TABLE THUCPHAM
ADD CONSTRAINT CK_SL3 CHECK(SOL>=0)

--ALTER TABLE THUCPHAM
--ADD CONSTRAINT CK_DV CHECK(DONV IN('Kg','G',N'TẤN'))
---------------------------------RANG BUOC PHIEU DAT-------------------------------------------------------
--ALTER TABLE PHIEUDAT 
--ADD CONSTRAINT CK_TONGSL2 CHECK(TONGSL>0)
---------------------------------RANG BUOC PHIEU GIAO
--ALTER TABLE PHIEUGIAO
--ADD CONSTRAINT CK_TONGSL1 CHECK(TONGSL>0)
--ALTER TABLE PHIEUGIAO
--ADD CONSTRAINT CK_THANHTIEN CHECK(THANHTIEN>0)
--ALTER TABLE PHIEUGIAO
--ADD CONSTRAINT CK_LG CHECK(LANGIAO BETWEEN 1 AND 3)
-----------------------------------RANG BUOC CHI TIET PHIEU GIAO VA CHI TIET PHIEU DAT ----------------------------
--ALTER TABLE CHITIETPHIEUDAT
--ADD CONSTRAINT CK_SL22 CHECK(SOL>0)
--ALTER TABLE CHITIETPHIEUGIAO
--ADD CONSTRAINT CK_SL23 CHECK(SOL>0)

----------------------------------RANG BUOC NGUON CUNG----------------------------------------------------------------
--ALTER TABLE MGUONCUNG
--ADD CONSTRAINT CK_NC CHECK(GIA>0)
-----------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------TRIGGER SU LY THEM XOA SUA -------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------------
--CREATE TRIGGER KIEMTRANGAYDAT_GIAOHANG
--ON PHIEUGIAO
--FOR INSERT,UPDATE
--AS
--	BEGIN
--		DECLARE @TAM1 DATE,@MAPG int,@TAM2 DATE
--		SELECT @TAM1 =  inserted.NGAYG,@MAPG=inserted.MAPD FROM inserted
--		SELECT @TAM2=PHIEUDAT.NGAYD FROM PHIEUDAT WHERE PHIEUDAT.MAPD=@MAPG
--		IF(@TAM1>@TAM1)
--			BEGIN 
--				COMMIT TRAN
--			END
--		ELSE
--			BEGIN
--				PRINT'THAO TAC THAT BAI'
--				ROLLBACK TRAN
--			END
--	END



go
	------------------------------------------------------------------------------
create table account
(
	MANV INT ,
	displayname nvarchar(100),
	pass varchar(100),
	chucv int ,
	CONSTRAINT PK_MATK PRIMARY KEY(MANV,displayname)
)
ALTER TABLE account
ADD CONSTRAINT FK_MANV_ACC FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
insert into account values(1,N'Đô Tuấn Kha','21092002',1)
insert into account values(2,N'Khoa Đặng Trần','21092002',1)
go
create proc longin
@user nvarchar(50),@pass nvarchar(50)
as
begin
	select*from account where MANV=@user and pass=@pass
end

go
create proc gettable
as select*from BANAN ORDER BY MABA
go
exec gettable


--insert into BANAN values('B01',N'Bàn 1','1')
--insert into BANAN values('B02',N'Bàn 2','1')
--insert into BANAN values('B03',N'Bàn 3','0')
--insert into BANAN values('B04',N'Bàn 4','0')
--insert into BANAN values('B05',N'Bàn 5','1')
go
declare @i int =1

while @i<=10
begin
		insert into BANAN values(N'Bàn'+CONVERT(nvarchar(5),@i),'0')
		set @i=@i+1
end
------------------------------------NHA CUNG CAP
insert into NHACUNGCAP values(N'Nước Ngọt Tân Bình', N'140 Lê Trọng Tấn','0868380792')
insert into NHACUNGCAP values(N'Hải Sản VŨng Tàu', N'140 Lê Trọng Tấn','0868380792')
insert into NHACUNGCAP values(N'Bò CITY', N'140 Lê Trọng Tấn','0868380792')
insert into NHACUNGCAP values(N'Bò Mỹ', N'140 Lê Trọng Tấn','0868380792')
insert into NHACUNGCAP values(N'Hải Sản Phú Quốc', N'140 Lê Trọng Tấn','0868380792')

go
alter table THUCPHAM
alter column DONV nvarchar(50)
go
insert into THUCPHAM values(N'Bò Né', '10', 'kg')
insert into THUCPHAM values(N'Bò Tái', '4', 'kg')
insert into THUCPHAM values(N'Bò Úc', '10', 'kg')
insert into THUCPHAM values(N'Pate', '4', 'kg')
insert into THUCPHAM values(N'Nem nướng', '2', 'kg')
insert into THUCPHAM values(N'Chả', '1', 'kg')
insert into THUCPHAM values(N'Xúc xích né', '5', 'kg')
insert into THUCPHAM values(N'Jambon', '1', 'kg')
insert into THUCPHAM values(N'Phô Mai', '5', 'kg')
insert into THUCPHAM values(N'Sốt đỏ', '3', 'kg')
insert into THUCPHAM values(N'Caron', '5', 'kg')
insert into THUCPHAM values(N'Dưa leo', '5', 'kg')
insert into THUCPHAM values(N'Xú Tím', '3', 'kg')
insert into THUCPHAM values(N'Tôm', '4', 'kg')
insert into THUCPHAM values(N'Mực', '2', 'kg')
insert into THUCPHAM values(N'cá viên', '5', 'kg')
insert into THUCPHAM values(N'Trứng', '1200', 'Trái')

-----------------------------------NGUON CUNG
insert into NGUONCUNG values(3, 1, '3000000')
insert into NGUONCUNG values(3, 2, '200000')
insert into NGUONCUNG values(4, 3, '3000000')
insert into NGUONCUNG values(4, 4, '280000')
insert into NGUONCUNG values(3, 5, '310000')
insert into NGUONCUNG values(3, 6, '300000')
insert into NGUONCUNG values(5, 7, '500000')
insert into NGUONCUNG values(5, 8, '270000')
insert into NGUONCUNG values(3, 9, '370000')
insert into NGUONCUNG values(3, 10, '450000')
insert into NGUONCUNG values(2, 14, '1000000')
insert into NGUONCUNG values(2, 15, '2000000')
insert into NGUONCUNG values(1, 14, '1000000')
insert into NGUONCUNG values(1, 15, '2000000')
go

-----------------------------------------------LOAI---------------------------
--declare @ma int =1
--while @ma<=10
--begin
--	insert into LOAI values(@ma,N'chua co ten')
--	set @ma=@ma+1
--end
go
SELECT*FROM LOAI
-----------------------------------------------LOAI---------------------------
insert into LOAI values(N'Bò Né')
insert into LOAI values(N'Mỳ Cay')
insert into LOAI values(N'Bò Hàu')
insert into LOAI values(N'Lẩu')
insert into LOAI values(N'Giải Khát')
insert into LOAI values(N'Thêm Bò Né')
insert into LOAI values(N'Thêm Mỳ Cay')
insert into LOAI values(N'Thêm Bò Hàu')
insert into LOAI values(N'Thêm Lẩu')

----------------------------------THUC PHAM




--------------------------------------------MON AN
insert into MONAN values(N'Bò Né', '49000',1)
insert into MONAN values(N'Bò Không', '59000',1)
insert into MONAN values(N'Beefsteak Truyền Thống', '59000',1)
insert into MONAN values(N'Beefsteak Đặc Biệt', '79000',1)
insert into MONAN values(N'Né Quanh Lửa Hồng', '69000',1)
insert into MONAN values(N'Mỳ Cay Hải Sản', '50000',2)
insert into MONAN values(N'Mỳ Cay Bò', '50000',2)
insert into MONAN values(N'Mỳ Cay Đặc Biệt', '55000',2)
insert into MONAN values(N'Bò Hàu 169k', '169000',3)
insert into MONAN values(N'Bò Hàu 249k', '249000',3)
insert into MONAN values(N'Bò Hàu 299k', '299000',3)
insert into MONAN values(N'Lẩu Thái Nhỏ', '199000',4)
insert into MONAN values(N'Lẩu Thái Lớn', '299000',4)
insert into MONAN values(N'Lẩu Kim Chi Nhỏ', '199000',4)
insert into MONAN values(N'Lẩu Kim Chi Lớn', '299000',4)
insert into MONAN values(N'Coca', '15000',5)
insert into MONAN values(N'Nước Suối', '15000',5)
insert into MONAN values(N'Sting', '15000',5)
insert into MONAN values(N'7 up', '15000',5)
insert into MONAN values(N'Trà Đào', '25000',5)
insert into MONAN values(N'Trà Vải', '25000',5)
insert into MONAN values(N'salad', '10000',6)
insert into MONAN values(N'Bánh Mì', '5000',6)
insert into MONAN values(N'Pate', '5000',6)
insert into MONAN values(N'Trứng', '5000',6)
insert into MONAN values(N'Nem', '10000',6)
insert into MONAN values(N'Chả', '10000',6)
insert into MONAN values(N'Xúc Xích', '10000',6)
insert into MONAN values(N'Chén Bò', '35000',6)
insert into MONAN values(N'Thêm Mỳ', '15000',7)
insert into MONAN values(N'100g Tôm', '40000',7)
insert into MONAN values(N'100g Mực', '40000',7)
insert into MONAN values(N'Xúc Xích Đức', '20000',7)
insert into MONAN values(N'Cá Viên', '20000',7)
insert into MONAN values(N'100g Bò Úc', '60000',8)
insert into MONAN values(N'100g Hàu', '50000',8)
insert into MONAN values(N'Rau Bò Hàu', '20000',8)
insert into MONAN values(N'Nước Lẩu', '20000',9)
insert into MONAN values(N'100g Bò Mỹ', '60000',9)
insert into MONAN values(N'Vây Cá Hồi', '40000',9)
insert into MONAN values(N'Bánh Bao Trứng Cá', '20000',9)
insert into MONAN values(N'Kim Chi', '20000',9)

--------------------------------------------MON AN

--declare @ma1 int =1
--while @ma1<=10
--begin
--	insert into MONAN(MAMA,TENMA,GIA,MAL) values(@ma1,N'chua co ten',100000,@ma1)
--	set @ma1=@ma1+1
--end
--select*from MONAN
----------------------------------------------KHACH HANG
--declare @ma2 int =1
--while @ma2<=10
--begin
--	insert into KHACHHANG(TENKH,DIAC,SDT) 
--	values(N'Nguyễn Văn A',N'140 Lê Trọng Tấn','012345678'),
--	(N'Nguyễn Văn B',N'140 Lê Trọng Tấn','062345678'),
--	(N'Nguyễn Văn C',N'141 Lê Trọng Tấn','022345678'),
--	(N'Nguyễn Thị D',N'142 Lê Trọng Tấn','032345678'),
--	(N'Nguyễn Văn E',N'140 Lê Trọng Tấn','042345678'),
--	(N'Nguyễn Văn F',N'140 Lê Trọng Tấn','052345678')
--	set @ma2=@ma2+1
--end
SELECT*FROM KHACHHANG

insert into KHACHHANG values(N'Nguyễn Văn A',N'140 Lê Trọng Tấn','012345678')
insert into KHACHHANG values(N'Nguyễn Văn B',N'141 Lê Trọng Tấn','022345678')
insert into KHACHHANG values(N'Nguyễn Văn C',N'142 Lê Trọng Tấn','032345678')
insert into KHACHHANG values(N'Nguyễn Văn D',N'143 Lê Trọng Tấn','042345678')
insert into KHACHHANG values(N'Nguyễn Văn E',N'144 Lê Trọng Tấn','052345678')
insert into KHACHHANG values(N'Nguyễn Văn F',N'145 Lê Trọng Tấn','062345678')
insert into KHACHHANG values(N'Nguyễn Văn G',N'146 Lê Trọng Tấn','072345678')
insert into KHACHHANG values(N'Nguyễn Văn H',N'147 Lê Trọng Tấn','082345678')
--------------------------------------------------NHAN VIEN

--SET DATEFORMAT DMY
--declare @ma3 int =3
--while @ma3<=10
--begin
--	insert into NHANVIEN(MANV,HOT,NGAYS,GIOIT,SDT,TRANGTHAI) values(@ma3,N'chua co ten','21/09/2002',N'CHUA','0000',1)
--	set @ma3=@ma3+1
--end
SELECT*FROM NHANVIEN

insert into NHANVIEN values(N'Đỗ Tuấn Kha','21/09/2002',N'Nam','012345678',0)
insert into NHANVIEN values(N'Đỗ Tuấn E','21/09/2002',N'Nam','022345678',0)
insert into NHANVIEN values(N'Đỗ Tuấn Em','21/09/2002',N'Nam','032345678',0)
insert into NHANVIEN values(N'Đỗ Tuấn Anh','21/09/2002',N'Nam','042345678',0)
insert into NHANVIEN values(N'Đỗ Tuấn Khang','21/09/2002',N'Nam','052345678',0)
------------------------------------------------HOA DON


--CREATE TABLE THUCPHAM
--(
--	MATP int identity,
--	TENTP NVARCHAR(50) NOT NULL,
--	SOL INT NOT NULL,
--	DONV int NOT NULL,
--	CONSTRAINT PK_MATP PRIMARY KEY(MATP)
--)

--CREATE TABLE NGUYENLIEU
--(
--	MATP int,
--	MAMA int,
--	HAML int NOT NULL,
--	CONSTRAINT PK_MATP_MAMA PRIMARY KEY(MATP,MAMA)
--)
select*from NGUYENLIEU
select*from THUCPHAM
select*from MONAN
go
insert into NGUYENLIEU values(1,1,1)
insert into NGUYENLIEU values(12,1,2)
insert into NGUYENLIEU values(1,4,1)
insert into NGUYENLIEU values(1,17,2)
insert into NGUYENLIEU values(2,1,3)
insert into NGUYENLIEU values(2,4,1)
insert into NGUYENLIEU values(2,5,1)
insert into NGUYENLIEU values(2,6,1)
insert into NGUYENLIEU values(2,7,2)
insert into NGUYENLIEU values(2,8,4)
insert into NGUYENLIEU values(2,17,1)
insert into NGUYENLIEU values(3,1,1)
insert into NGUYENLIEU values(3,4,1)
insert into NGUYENLIEU values(3,17,2)
insert into NGUYENLIEU values(3,5,1)
insert into NGUYENLIEU values(3,7,1)

insert into NGUYENLIEU values(1,44,1)
insert into NGUYENLIEU values(17,22,2)
insert into NGUYENLIEU values(15,33,1)
insert into NGUYENLIEU values(10,17,2)
insert into NGUYENLIEU values(9,18,3)
insert into NGUYENLIEU values(5,21,1)
insert into NGUYENLIEU values(3,39,1)
insert into NGUYENLIEU values(16,30,1)
insert into NGUYENLIEU values(14,25,2)
insert into NGUYENLIEU values(6,7,4)
insert into NGUYENLIEU values(8,17,1)
insert into NGUYENLIEU values(7,18,1)
insert into NGUYENLIEU values(11,26,1)
insert into NGUYENLIEU values(12,29,2)
insert into NGUYENLIEU values(4,32,1)
insert into NGUYENLIEU values(13,29,1)

go
--declare @ma4 int =1
--while @ma4<=10
--begin
--	insert into HOADON(TRANGTHAI,NGAYL,TONGTT,MABA,MANV,MAKH,GIAMGIA) values(0,GETDATE(),0,@ma4,@ma4,@ma4,0)
--	set @ma4=@ma4+1
--end
--go
SELECT*FROM HOADON
go
----------------------------------------------CHI TIET MON AN
--declare @ma5 int =1
--while @ma5<=10
--begin
--	insert into CHITIETMONAN(MAMA,MAHD,SOL) values(@ma5,@ma5,@ma5)
--	set @ma5=@ma5+1
--end
--go
SELECT*FROM CHITIETMONAN

----------------------------------------------------
go
select MONAN.TENMA,ct.SOL,MONAN.GIA,ct.SOL*MONAN.GIA as 'THANHTIEN' from CHITIETMONAN ct,HOADON hd,MONAN
where ct.MAHD=hd.MAHD and ct.MAMA=MONAN.MAMA and hd.TRANGTHAI=0 and hd.MABA=2
go
--------------------them hoa don--------------
create proc addhoadon
@maban int,@manv int,@makh int
as
begin
	insert into HOADON(GIOV,GIOR,TRANGTHAI,NGAYL,TONGTT,MABA,MANV,MAKH,GIAMGIA) values(GETDATE(),null,0,GETDATE(),0,@maban,@manv,@makh,0)
end
go

-------------------them chi tiet hoa don
create proc addchitiethoadon
@mama int,@mahd int,@sl int
as
begin
	declare @tam int
	declare @tam2 int=0
	select @tam2=SOL from CHITIETMONAN where MAMA=@mama and MAHD=@mahd
	if(@mama in (select MaMA from CHITIETMONAN where MAHD = @mahd))
		begin
		declare @tam3 int=@sl+@tam2
		if(@tam3>0)
			update CHITIETMONAN set SOL=SOL+ @sl where MAMA=@mama
		else
			delete CHITIETMONAN where MAMA=@mama and MAHD=@mahd
		end
	else
		insert into CHITIETMONAN(MAMA,MAHD,SOL) values(@mama,@mahd,@sl)
end
go
--------------------------them khach hang
create proc themkhachhang
as
begin
	insert into KHACHHANG(TENKH,DIAC,SDT) values(null,null,null)
end
select MAX(KHACHHANG.MAKH) from KHACHHANG
go
----------------------------thay doi trang thai cua ban an
create trigger checkct_hd 
on CHITIETMONAN
for insert,update
as
begin 
	declare @id_hd int
	declare @id_ba int
	select @id_hd= inserted.MAHD from inserted
	select @id_ba=HOADON.MABA from HOADON where MAHD=@id_hd and TRANGTHAI=0
	declare @count int
	select @count=COUNT(*) from CHITIETMONAN where MAHD=@id_hd
	if(@count>0)
		update BANAN set TRANGTHAI=1 where MABA=@id_ba
	else
		update BANAN set TRANGTHAI=0 where MABA=@id_ba
end
go
create trigger check_HD
on HOADON
for update
as
begin
	declare @id_hd int
	declare @id_ba int
	declare @count int
	select @id_hd= MAHD from inserted
	select @id_ba=HOADON.MABA from HOADON where MAHD=@id_hd
	select @count=count(*) from HOADON where MABA=@id_ba and TRANGTHAI=0
	if(@count=0)
		update BANAN set TRANGTHAI=0 where MABA=@id_ba
end

--create trigger tablekk
--on BANAN for update
--as
--begin 
--	declare @idban int
--	declare @tt int
--	select @idban=MABA,@tt=TRANGTHAI from inserted
--	declare @idhd int
--	select @idhd=MAHD from HOADON where MABA=@idban and TRANGTHAI=0
--	declare @count int
--	select @count=COUNT(*) from CHITIETMONAN where MAHD=@idhd
--	if(@count>0 ) 
--		update BANAN set TRANGTHAI=1 where MABA=@idban
--	else --if(@count<=0 and @tt<>0)
--		update BANAN set TRANGTHAI=0 where MABA=@idban
-- end
go
create proc swap
@id1 int,@id2 int,@manv int
as
begin
	declare @idfist int
	declare @idsecon int
	declare @emty1 int=1
	declare @emty2 int=1
	declare @makh int
	declare @makh2 int
	select @idsecon=MAHD from HOADON where MABA=@id2 and TRANGTHAI=0
	select @idfist=MAHD from HOADON where MABA=@id1 and TRANGTHAI=0
	if(@idfist is null)
	begin
		insert into KHACHHANG(TENKH,DIAC,SDT) values(null,null,null)
		select @makh=MAX(MAKH) from KHACHHANG
		insert into HOADON(GIOV,GIOR,TRANGTHAI,NGAYL,MABA,MANV,MAKH,GIAMGIA) values(GETDATE(),null,0,GETDATE(),@id1,@manv,@makh,0)
		select @idfist=MAX(MAHD) from HOADON where MABA=@id1 and TRANGTHAI=0
		
	end
	select @emty1=COUNT(*) from CHITIETMONAN where MAHD=@idfist
	if(@idsecon is null)
	begin
		insert into KHACHHANG(TENKH,DIAC,SDT) values(null,null,null)
		select @makh2=MAX(MAKH) from KHACHHANG
		insert into HOADON(GIOV,GIOR,TRANGTHAI,NGAYL,MABA,MANV,MAKH,GIAMGIA) values(GETDATE(),null,0,GETDATE(),@id2,@manv,@makh2,0)
		select @idsecon=MAX(MAHD) from HOADON where MABA=@id2 and TRANGTHAI=0
	
	end
	select @emty2=COUNT(*) from CHITIETMONAN where MAHD=@idsecon
	select MACT into idbill from CHITIETMONAN where MAHD=@idsecon
	update CHITIETMONAN set MAHD=@idsecon where MAHD=@idfist
	update CHITIETMONAN set MAHD=@idfist where MACT in (select MACT from idbill)

	drop table idbill
	if(@emty1=0)
		update BANAN set TRANGTHAI =0 where MABA=@id2
	if(@emty2=0)
		update BANAN set TRANGTHAI =0 where MABA=@id1

end
go
delete from CHITIETMONAN
delete from HOADON
select*from HOADON
select*from CHITIETMONAN
go
create proc get_view_doanhthu
@giov datetime,@gior datetime
as
	select TENB as[Tên Bàn],GIOV as[Giờ Vào],GIOR as [Giờ Ra],TONGTT as [Tổng Tiền],GIAMGIA as [Giảm Giá] from HOADON,BANAN
	where BANAN.MABA=HOADON.MABA and HOADON.TRANGTHAI=1 and convert(date,GIOV) >= convert(date,@giov) and convert(date,GIOR)<=convert(date,@gior)
select*from BANAN
go
create proc get_view_doanhthu_NhanVien
@MaNV int
as
	select TENB as[Tên Bàn],GIOV as[Giờ Vào],GIOR as [Giờ Ra],TONGTT as [Tổng Tiền],GIAMGIA as [Giảm Giá] from HOADON,BANAN
	where BANAN.MABA=HOADON.MABA and HOADON.TRANGTHAI=1 and MANV=@MaNV
exec get_view_doanhthu_NhanVien 3
select*from HOADON
select*from account
update account set chucv=0 where MANV=2
select*from account

go
create PROC UpDate_ThongTin_Account
@manv int,@displayname nvarchar(30),@pass varchar(20),@newpass varchar(20)
as
begin
	declare @Count_account int =0
	select @Count_account=COUNT(*) from account where MANV=@manv and pass=@pass
	if(@Count_account=1)
		if(@newpass=null or @newpass='')
			begin
				update account set displayname=@displayname where MANV=@manv
			end
		else
			update account set displayname=@displayname,pass=@newpass where MANV=@manv
end
go
select*from LOAI
 

 select*from THUCPHAM
  select*from NGUYENLIEU
   select*from MONAN
    select*from CHITIETMONAN
	select* from HOADON

go
	alter table NguyenLieu
alter column HAML int
go
--create trigger TuDongCapNhatKhoHangKhiThanhToanHoaDon_insert
--on CHITIETMONAN
--after insert
--as
--begin
--	declare @MAMA int, @sl int
--	select @MAMA = MAMA, @sl = SOL from inserted
--		declare NgLieu cursor
--		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
--		open NgLieu
--		declare @MATP int, @hluong int
--		Fetch next from NgLieu into @MATP, @hluong
--		while(@@FETCH_STATUS=0)
--		begin
--			update THUCPHAM set SOL = SOL - (@hluong*@sl) where MATP = @MATP
--			Fetch next from NgLieu into @MATP, @hluong
--		end	
--		DEALLOCATE NgLieu
--end
--go
--create trigger TuDongCapNhatKhoHangKhiThanhToanHoaDon_delete
--on CHITIETMONAN
--after delete
--as
--begin
--	declare @MAMA int, @sl int
--	select @MAMA = MAMA, @sl = SOL from inserted
--		declare NgLieu cursor
--		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
--		open CTMA
--		declare @MATP int, @hluong int
--		Fetch next from NgLieu into @MATP, @hluong
--		while(@@FETCH_STATUS=0)
--		begin
--			update THUCPHAM set SOL = SOL + (@hluong*@sl) where MATP = @MATP
--			Fetch next from NgLieu into @MATP, @hluong
--		end	
--		DEALLOCATE NgLieu
--end




--go
--drop trigger TuDongCapNhatKhoHangKhiThanhToanHoaDon_update
--on CHITIETMONAN
--after update
--as
--begin
--	declare @MAMA int, @sltruoc int, @slsau int, @slthem int
--	select @MAMA = MAMA, @slsau = SOL from inserted
--	set @slthem = @slsau - @sltruoc
--	select @sltruoc = SOL from deleted
--		declare NgLieu cursor
--		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
--		open CTMA
--		declare @MATP int, @hluong int
--		Fetch next from NgLieu into @MATP, @hluong
--		while(@@FETCH_STATUS=0)
--		begin
--			update THUCPHAM set SOL = SOL - (@hluong*@slthem) where MATP = @MATP
--			Fetch next from NgLieu into @MATP, @hluong
--		end	
--		DEALLOCATE NgLieu
--end
select*from account
go
create function KiemTra_ThongTin_NV_CoTonTai(@Manv int)
returns int
as
begin
	return (select COUNT(NHANVIEN.MANV) from account,NHANVIEN where account.MANV=NHANVIEN.MANV and NHANVIEN.MANV=@Manv)
end
go
print dbo.KiemTra_ThongTin_NV_CoTonTai(2)
--------------------------------kh8guyguygihuhu-----------------




go
create trigger TuDongCapNhatKhoHangKhiThemChiTietHoaDon_insert
on CHITIETMONAN
after insert
as
begin
	declare @MAMA int, @sl int
	select @MAMA = MAMA, @sl = SOL from inserted
		declare NgLieu cursor
		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
		open NgLieu
		declare @MATP int, @hluong int
		Fetch next from NgLieu into @MATP, @hluong
		while(@@FETCH_STATUS=0)
		begin
			update THUCPHAM set SOL = SOL - (@hluong*@sl) where MATP = @MATP
			Fetch next from NgLieu into @MATP, @hluong
		end	
		DEALLOCATE NgLieu
end
go

select * from CHITIETMONAN
go
create trigger TuDongCapNhatKhoHangKhiThemChiTietHoaDon_delete
on CHITIETMONAN
after delete
as
begin
	declare @MAMA int, @sl int
	select @MAMA = MAMA, @sl = SOL from deleted
		declare NgLieu cursor
		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
		open NgLieu
		declare @MATP int, @hluong int
		Fetch next from NgLieu into @MATP, @hluong
		while(@@FETCH_STATUS=0)
		begin
			update THUCPHAM set SOL = SOL + (@hluong*@sl) where MATP = @MATP
			Fetch next from NgLieu into @MATP, @hluong
		end	
		DEALLOCATE NgLieu
end

go
create trigger TuDongCapNhatKhoHangKhiThemChiTietHoaDon_update
on CHITIETMONAN
after update
as
begin
	declare @MAMA int, @sltruoc int, @slsau int, @slthem int
	select @MAMA = MAMA, @slsau = SOL from inserted
	select @sltruoc = SOL from deleted
		set @slthem = @slsau - @sltruoc
		declare NgLieu cursor
		for select MaTP, HAML from NGUYENLIEU where MAMA = @MAMA
		open NgLieu
		declare @MATP int, @hluong int
		Fetch next from NgLieu into @MATP, @hluong
		while(@@FETCH_STATUS=0)
		begin
			update THUCPHAM set SOL = SOL - (@hluong*@slthem) where MATP = @MATP
			Fetch next from NgLieu into @MATP, @hluong
		end	
		DEALLOCATE NgLieu
		print @sltruoc
		print @slsau
end
go
select * from NGUYENLIEU
select * from THUCPHAM
go
--insert into CHITIETMONAN values(1,9,1)
go
--số lượng giao hàng không được lớn hơn 3
create trigger SoLuongGiaoToiDa
on PhieuGiao
After insert
as
begin
declare @langiao int, @maPD int
	select @maPD = MAPD from inserted
	select @langiao = count(*) from PHIEUGIAO where MAPD = @maPD
	if(@langiao > 3)
	begin
		print N'Số lần giao hàng của một phiếu đặt hàng không được lớn hơn 3!!!'
		rollback tran
	end
end
go
select*from account
select*from NHANVIEN
--Ràng buộc mã thực phẩm trong phiếu đặt phải cung một nhà cung cấp của phiếu đặt đó
go
create trigger ChungNhaCCCuaPhieuDatCTPD
on ChiTietphieuDat
after insert, update
as
begin
	declare @maTP int, @maNCC int
	select @maTP = MATP, @maNCC = MANCC from inserted i, PHIEUDAT d where i.MAPD = d.MAPD
	if(@maTP not in (select MaTP from NGUONCUNG where MANCC = @maNCC))
	begin
		print N'Thực phẩm ' +convert(char,@maTP)+ N' không nằm trong danh sách nguồn cung của nhà cung cấp '+convert(char,@maNCC)
		rollback tran
	end
end
go
--mã thực phẩm của chitietphieugiao phải nằm trong bảng nguồn cung tương ứng với nhà cung cấp của phiếu đặt đó và tổng số lượng thực phẩm của 1 chi tiết phiếu giao hàng không được lớn hơn chi tiết đặt hàng, nếu thõa sẽ tự động cập nhật số lượng và thành tiền cho phiếu giao
Create trigger SoLuongChiTietGiaoHangHopLe
on CHITIETPHIEUGIAO
after insert
as
begin
	declare @sluong int, @maPG int, @maTP int, @tsl int, @sldat int, @maPD int
	select @maPD = g.MAPD ,@maPG = g.MAPG, @maTP = MATP, @sluong = SOL from inserted i , PHIEUGiao g where i.MAPG = g.MAPG
	declare @gia float =-1
	select @gia = Gia from NGUONCUNG nc, PHIEUDAT d where d.MANCC = nc.MANCC and MATP = @maTP
	if(@gia = -1)
	begin
		print N'Nhà cung cấp của phiếu đặt này không tồn tại thực phẩm '+convert(char,@maTP)
		rollback tran
	end	
	else
	begin
		if(@maTP not in (select MaTP from CHITIETPHIEUDAT where MAPD = @maPD))
		begin
		print N'Thực phẩm ' +convert(char,@maTP)+ N' không nằm trong chi tiết phiếu đặt của phiếu đặt '+convert(char,@maPD)		
		end
		else
		begin
			select @sldat = SOL from CHITIETPHIEUDAT where MAPD =  @maPD and MATP = @maTP
			select @tsl = sum(SOL) from CHITIETPHIEUGIAO ctg, PHIEUGIAO pg where ctg.MaPG = pg.MAPG and pg.MAPD = @maPD and MATP = @maTP
			if(@tsl>@sldat)
			begin
				print N'Tổng số lượng giao hàng của thực phẩm ' +convert(char,@maTP) +N' Vượt quá số lượng đặt!'
				rollback tran
			end
			else
			begin
				update PHIEUGIAO set TONGSL = TONGSL + @sluong where MAPG = @maPG
				update PHIEUGIAO set THANHTIEN = ThanhTien + (@sluong * @gia) where MAPG = @maPG
				update THUCPHAM set SOL = SOL + @sluong where MATP = @maTP
			end
		end
	end	
end
go
select t.MATP, TENTP, d.SOL from CHITIETPHIEUDAT d, THUCPHAM t where d.MATP = t.MATP and MAPD = 1
go
create proc TaoPhieuDatHang @MaNCC int
as
begin
	insert into PHIEUDAT values(@MaNCC,getdate(),0)
end

go
create proc TaoPhieuGiaoHang @MaPD int
as
begin
declare @sl int =1
	select @sl = count(*) from PHIEUGIAO where MAPD = @MaPD
	insert into PHIEUGIAO values(@MaPD,getdate(),0,0,@sl)
end
go

select*from CHITIETPHIEUGiao
--delete PHIEUGiao
--delete CHITIETPHIEUGiao

select*from PHIEUGIAO
select*from CHITIETPHIEUGIAO
--delete PHIEUDAT
--delete PHIEUGIAO
--delete CHITIETPHIEUGiao
select*from THUCPHAM

select * from PHIEUDAT where MAPD not in (select MAPD from PHIEUGIAO)
select * from NHACUNGCAP
select * from NGUONCUNG

select * from CHITIETPHIEUDAT


select TENTP,NGUONCUNG.MATP from NGUONCUNG,THUCPHAM where THUCPHAM.MATP=NGUONCUNG.MATP and NGUONCUNG.MANCC=3
select * from HOADON
select * from CHITIETMONAN
select*from NGUYENLIEU
select*from THUCPHAM



--------PHÂN QUYỀN NGƯỜI DÙNG (Admin)--------

