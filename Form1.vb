Imports System.Data.OleDb

Public Class Form1
    Dim con As New OleDbConnection
    Dim adapter As OleDbDataAdapter
    Dim myDataSet As New DataSet
    Dim command As New OleDbCommand
    Dim check As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        check = True
        adapter = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte;", con)
        myDataSet.Clear()
        adapter.Fill(myDataSet)
        Form2.DataGridView1.DataSource = myDataSet.Tables(0)
        MsgBox(myDataSet.Tables(0).Rows(1).ItemArray(2))
        For i As Integer = 0 To Form2.DataGridView1.Rows.Count - 1
            If myDataSet.Tables(0).Rows(i).ItemArray(0) = txtUsername.Text And myDataSet.Tables(0).Rows(i).ItemArray(1) = txtPassword.Text Then
                MsgBox(myDataSet.Tables(0).Rows(1).ItemArray(5))
                If check = myDataSet.Tables(0).Rows(i).ItemArray(2) Then
                    Form2.Show()
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(3) Then
                    Form2.Show()
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(4) Then
                    Form2.DataGridView1.Rows(i).ReadOnly = False
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(5) Then
                    Form2.Show()
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(6) Then
                    Form2.Show()
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(7) Then
                    Form2.Show()
                ElseIf check = myDataSet.Tables(0).Rows(i).ItemArray(8) Then
                    Form2.Show()
                End If
            End If

            Exit For
        Next i

    End Sub
End Class
