Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim adapter7 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim myDataSet7 As New DataSet
    Dim command As New OleDbCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load, DataGridView1.ReadOnlyChanged
        Form1.Hide()
        Panel1.Hide()
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\Desktop\vbshit-main\vbshit-main\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNr1.Text = String.Empty Then
            MsgBox("Bitte geben sie die Auftragsnummer an")
        End If
        If txtFertig.Text = String.Empty Then
            MsgBox("Bitte geben sie die Menge an")
        End If
        Try


            Me.myDataSet1.Tables.Clear()

            command.CommandText = "UPDATE Arbeitsvorräte SET BereitsGefertigt = BereitsGefertigt + '" + txtFertig.Text + "' WHERE Auftragsnummer = " + txtNr1.Text + ";"
            command.ExecuteNonQuery()

            adapter1 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Artikelnr, Bezeichnung, Menge, BereitsGefertigt, Starttermin, Endtermin, StartZustand, FertigungsZustand FROM Arbeitsvorräte WHERE Fertiger = '" + Form1.txtUsername.Text + "';", con)
            adapter1.Fill(myDataSet1)
            Me.DataGridView1.DataSource = myDataSet1.Tables(0)

            MsgBox("Daten wurden eingetragen")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If txtNr1.Text = String.Empty Then
            MsgBox("Bitte geben sie die Auftragsnummer an")
        End If
        Try


            Me.myDataSet1.Tables.Clear()
            command.CommandText = "UPDATE Arbeitsvorräte SET StartZustand = '" + ComboBox1.Text + "', FertigungsZustand = '" + ComboBox2.Text + "' WHERE Auftragsnummer = " + txtNr1.Text + ";"
            command.ExecuteNonQuery()

            adapter1 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Artikelnr, Bezeichnung, Menge, BereitsGefertigt, Starttermin, Endtermin, StartZustand, FertigungsZustand FROM Arbeitsvorräte WHERE Fertiger = '" + Form1.txtUsername.Text + "';", con)
            adapter1.Fill(myDataSet1)
            Me.DataGridView1.DataSource = myDataSet1.Tables(0)
            MsgBox("Daten wurden eingetragen")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.myDataSet7.Tables.Clear()
        adapter7 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Kommentar, KommentarAntwort FROM Arbeitsvorräte WHERE Fertiger = '" + Form1.txtUsername.Text + "';", con)
        adapter7.Fill(myDataSet7)
        Me.DataGridView3.DataSource = myDataSet7.Tables(0)
        Panel1.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Hide()
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If txtNr2.Text = String.Empty Then
            MsgBox("Bitte geben sie die Auftragsnummer an")
        End If
        If txtKom.Text = String.Empty Then
            MsgBox("Bitte geben sie einen Kommentar ein")
        End If
        Try

            Me.myDataSet7.Tables.Clear()
            command.CommandText = "UPDATE Arbeitsvorräte SET Kommentar = '" + txtKom.Text + "' WHERE Auftragsnummer = " + txtNr2.Text + ";"
            command.ExecuteNonQuery()

            adapter7 = New OleDbDataAdapter("SELECT Auftragsnummer, Fertiger, Kommentar, KommentarAntwort FROM Arbeitsvorräte WHERE Fertiger = '" + Form1.txtUsername.Text + "';", con)
            adapter7.Fill(myDataSet7)
            Me.DataGridView3.DataSource = myDataSet7.Tables(0)
            MsgBox("Daten wurden eingetragen")

        Catch ex As Exception

        End Try
    End Sub


End Class