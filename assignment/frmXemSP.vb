Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmXemSP
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=ps03136.mssql.somee.com;packet size=4096;user id=trongntps03136_SQLLogin_1;pwd=uzzej9mfqz;data source=ps03136.mssql.somee.com;persist security info=False;initial catalog=ps03136"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnXemall_Click(sender As Object, e As EventArgs) Handles btnXemall.Click
        Dim hienthi As New Class1
        dgvXemsp.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim timkiem As SqlDataAdapter = New SqlDataAdapter("select SANPHAM_PS03136.MASP as 'Mã sản phẩm',SANPHAM_PS03136.TENSP as 'Tên sản phẩm', LOAISANPHAM_PS03136.MALOAI as 'Mã Loại', LOAISANPHAM_PS03136.TENLOAI as 'Tên Loại',SANPHAM_PS03136.SOLUONG as 'Số lượng' from SANPHAM_PS03136 inner join LOAISANPHAM_PS03136 on SANPHAM_PS03136.MASP = LOAISANPHAM_PS03136.MASP where SANPHAM_PS03136.MASP ='" & txtMASP.Text & "' ", connect)
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                db.Clear()
                dgvXemsp.DataSource = Nothing
                timkiem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvXemsp.DataSource = db.DefaultView
                    txtMASP.Text = Nothing
                Else
                    MessageBox.Show("Không tìm được")
                    txtMASP.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
        Me.Close()
    End Sub

    Private Sub frmXemSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class