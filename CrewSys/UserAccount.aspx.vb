Public Class UserAccount
    Inherits System.Web.UI.Page
    Dim htparameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LoadAccount()

            mvProfile.SetActiveView(vProfileInfo)

        End If
        Page.Title = lblModule.Text & ": " & lblUserName.Text
    End Sub

    Private Sub UserAccount_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

    End Sub

    Private Sub LoadAccount()

        htparameters.Add("Keyword", Session("UserName"))
        htparameters.Add("Mode", 3)
        dt = MainClass.Library.Adapter.GetRecordSet(htparameters, "UserSel")


        For Each row As DataRow In dt.Rows
            Try

                hdnID.Value = row("ID").ToString
                lblFullName.Text = row("FullName").ToString

                If row("Photo").ToString.Length > 0 Then
                    UserImage.ImageUrl = row("Photo").ToString
                    UserImage.DataBind()
                End If

                lblModule.Text = row("LookUpDescription").ToString
                lblUserName.Text = row("UserName").ToString
                lblEmail.Text = row("EmailAddress").ToString

                Page.Title = lblModule.Text & ": " & lblUserName.Text
                htparameters.Clear()

            Catch ex As Exception

            End Try
        Next

    End Sub

    Private Function UploadPhoto() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "PhotoPic\" + Session("Name")
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuPhoto.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuPhoto.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    'fuPhoto.SaveAs(savePath & "\" & fuPhoto.FileName)
                    fuPhoto.SaveAs(Server.MapPath(saveDir + "\" + fuPhoto.FileName))
                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "PhotoPic\" & Session("Name") & "\" & fuPhoto.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPhotoSource.Value = "PhotoPic\" & Session("Name") & "\" & fuPhoto.FileName

                    UserImage.ImageUrl = hdnPhotoSource.Value
                    UserImage.DataBind()
                    lblWarning.Text = ""
                    MainClass.Library.Command.Execute("UPDATE Users SET Photo='" & UserImage.ImageUrl & "' WHERE UserName='" & lblUserName.Text & "'")
                    ' fileDocView = savePath & fileUpload.FileName
                    hdnMode.Value = "Ok"
                Catch ex As Exception
                    ' lblWarning.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning.Text = "Please Upload only a valid picture format!"
                hdnMode.Value = "Error"
            End If
        Else
            lblWarning.Text = "You have not specified a file."
            hdnMode.Value = "Error2"
        End If
        Return fileDocView

    End Function

    Private Sub lbUploadPhoto_Click(sender As Object, e As EventArgs) Handles lbUploadPhoto.Click

        Try
            If fuPhoto.HasFile Then
                UploadPhoto()
                If hdnMode.Value = "Ok" Then
                    Session("Photo") = hdnPhotoSource.Value
                    Response.Redirect("UserAccount.aspx")
                End If
            Else
                UploadPhoto()
            End If
        Catch
        End Try

    End Sub

    Private Sub lbChangePass_Click(sender As Object, e As EventArgs) Handles lbChangePass.Click
        mvProfile.SetActiveView(vEditProfileInfo)
    End Sub

    Private Sub lbCancelUpdate_Click(sender As Object, e As EventArgs) Handles lbCancelUpdate.Click
        mvProfile.SetActiveView(vProfileInfo)
    End Sub

    Private Sub lbUpdatePass_Click(sender As Object, e As EventArgs) Handles lbUpdatePass.Click

        MainClass.Library.Command.Execute("UPDATE Users SET Password='" & txtNewPass.Text & "' WHERE ID='" & hdnID.Value & "'")

        htparameters.Clear()

        htparameters.Add("UserName", Session("UserName"))
        htparameters.Add("ModuleAccess", Session("Access"))
        htparameters.Add("Mode", 1)
        htparameters.Add("PageAccess", "UserAccount.aspx")
        htparameters.Add("ActionTaken", "Update Password")
        MainClass.Library.Command.Execute(htparameters, "AuditMod")
        htparameters.Clear()

        txtNewPass.Text = String.Empty

        mvProfile.SetActiveView(vProfileInfo)
    End Sub

End Class