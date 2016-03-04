Imports System.Data.SqlClient
Imports System.Data
Public Class Class1
    Public Function Loadkhachang() As DataSet
        Dim chuoiketnoi As String = "workstation id=ps03136.mssql.somee.com;packet size=4096;user id=trongntps03136_SQLLogin_1;pwd=uzzej9mfqz;data source=ps03136.mssql.somee.com;persist security info=False;initial catalog=ps03136"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadKH As New SqlDataAdapter("select MAKH as 'Mã KH' ,TENKH as 'Tên Khách Hàng', DIACHI as 'Địa chỉ', SDT as 'SĐT', EMAIL from KHACHHANG_PS03136", conn)
        Dim db As New DataSet
        conn.Open()
        LoadKH.Fill(db)
        conn.Close()
        Return db
    End Function
    Public Function Loadsanpham() As DataSet
        Dim chuoiketnoi As String = "workstation id=ps03136.mssql.somee.com;packet size=4096;user id=trongntps03136_SQLLogin_1;pwd=uzzej9mfqz;data source=ps03136.mssql.somee.com;persist security info=False;initial catalog=ps03136"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadSP As New SqlDataAdapter("select SANPHAM_PS03136.MASP as 'Mã sản phẩm',SANPHAM_PS03136.TENSP as 'Tên sản phẩm', LOAISANPHAM_PS03136.MALOAI as 'Mã Loại', LOAISANPHAM_PS03136.TENLOAI as 'Tên Loại',SANPHAM_PS03136.SOLUONG as 'Số lượng' from SANPHAM_PS03136 inner join LOAISANPHAM_PS03136 on SANPHAM_PS03136.MASP = LOAISANPHAM_PS03136.MASP", conn)
        Dim db As New DataSet
        conn.Open()
        LoadSP.Fill(db)
        conn.Close()
        Return db
    End Function
End Class
