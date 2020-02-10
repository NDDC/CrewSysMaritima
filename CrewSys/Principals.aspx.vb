Public Class Principals
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim htParameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") <> "AD" Then
                btnAddNew.Visible = False
                btnAddUpdatePrincipals.Visible = False
            End If
            LoadDefaults()
            GridBind()
        End If

        Page.Title = "Manage Principals"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        htParameters.Add("Keyword", txtSearch.Text)

        gvPrincipal.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "PrincipalSel")
        gvPrincipal.DataBind()
        htParameters.Clear()
        MultiView1.ActiveViewIndex = 0

        ViewState("Search1") = gvPrincipal.DataSource

        hdnView.Value = "Search1"
    End Sub

    Protected Sub gvPrincipal_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPrincipal.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gvAllotment.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            Try
                ViewRecord(index)

                GetDocs()

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update Principal Info"
                btnAddUpdatePrincipals.Text = "Update Principal Info"
                btnAddDoc.Attributes.Add("class", "btn btn-success show pull-right")
                gvDocs.Visible = True
                btnAddNew.Visible = False
                txtSearch.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""
        Dim dt As New DataTable

        MultiView1.ActiveViewIndex = 1

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewPrincipalRecord")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("ID").ToString

                txtPrincipalCode.Text = row("PrincipalCode").ToString
                txtPrincipalName.Text = row("PrincipalName").ToString
                txtDescription.Text = row("Description").ToString
                txtContactDetails.Text = row("ContactDetails").ToString
                txtEmail.Text = row("Email").ToString
                txtAddress.Text = row("Address").ToString
                txtContactNo.Text = row("ContactNo").ToString
                txtStart.Text = row("StartDate").ToString
                txtExpiry.Text = row("ExpiryDate").ToString

            Catch ex As Exception

            End Try
        Next
        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        hdnMode.Value = 0
        '    txtPrincipalCode.Text = CreateSequenceNo("P")
        txtPrincipalName.Text = String.Empty
        txtDescription.Text = String.Empty
        txtContactDetails.Text = String.Empty
        txtEmail.Text = String.Empty
        txtAddress.Text = String.Empty
        txtContactNo.Text = String.Empty

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        hdnMode.Value = 0
        clearFields()
        txtPrincipalCode.Text = CreateSequenceNo("P")
        btnAddUpdatePrincipals.Text = "Add New Principal"
        lblHead.Text = "New Principal"

        btnAddDoc.Attributes.Add("class", "hide")
        gvDocs.Visible = False
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        txtSearch.Visible = False
        btnGo1.Visible = False

    End Sub

    Private Sub btnAddUpdatePrincipals_Click(sender As Object, e As EventArgs) Handles btnAddUpdatePrincipals.Click
        With htParameters
            .Add("Mode", hdnMode.Value)
            .Add("ID", hdnID.Value)
            .Add("PrincipalCode", txtPrincipalCode.Text)
            .Add("PrincipalName", txtPrincipalName.Text)
            .Add("Description", txtDescription.Text)
            .Add("ContactDetails", txtContactDetails.Text)
            .Add("Email", txtEmail.Text)
            .Add("Address", txtAddress.Text)
            .Add("ContactNo", txtContactNo.Text)
            .Add("StartDate", txtStart.Text)
            .Add("ExpiryDate", txtExpiry.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "PrincipalMod")


        If hdnMode.Value = 0 Then
            MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "P" & "'")
        End If

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Principals.aspx")
        htParameters.Add("ActionTaken", "Add/Update Principals")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdatePrincipals.Text = "Add New Principal"

        btnAddDoc.Attributes.Add("class", "btn btn-success show pull-right")
        gvDocs.Visible = True
        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdatePrincipals.Text = "Add New Principal"

        btnAddDoc.Attributes.Add("class", "btn btn-success show pull-right")
        gvDocs.Visible = True
        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Public Function CreateSequenceNo(ByVal SequenceCode As String) As String
        Dim sBin As String
        Dim NewSequenceNo As String
        Try
            sBin = MainClass.Library.Command.ExecScalar("SELECT MAX(SequenceNo) FROM SequenceNo WHERE SequenceCode='" & SequenceCode & "'")
            NewSequenceNo = Right("00000" & sBin, 4)

            NewSequenceNo = SequenceCode & NewSequenceNo
            Return NewSequenceNo
        Catch ex As Exception
            Dim errmsg As String = ex.ToString
            Return errmsg
        End Try
    End Function

    Private Sub LoadDefaults()

        ddlDocCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents WHERE DocType='PDOC' ORDER BY DocTitle")
        ddlDocCode.DataTextField = "DocTitle"
        ddlDocCode.DataValueField = "DocCode"
        ddlDocCode.DataBind()

        ddlDocCodeUpdate.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents WHERE DocType='PDOC' ORDER BY DocTitle")
        ddlDocCodeUpdate.DataTextField = "DocTitle"
        ddlDocCodeUpdate.DataValueField = "DocCode"
        ddlDocCodeUpdate.DataBind()

    End Sub

    Private Sub Principal_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        'If Session("Access") <> "AD" Then
        '    Session.RemoveAll()
        '    Session.Abandon()
        '    Session.Clear()
        '    Response.Redirect("Login.aspx")
        'End If

    End Sub

    Protected Sub gvPrincipal_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPrincipal.PageIndexChanging

        gvPrincipal.DataSource = ViewState(hdnView.Value)

        gvPrincipal.PageIndex = e.NewPageIndex
        gvPrincipal.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvPrincipal_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvPrincipal.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvPrincipal.DataSource = ViewState(hdnView.Value)
            gvPrincipal.DataBind()
        End If

    End Sub

    Public Shared Function ChangeColumnDataType(ByVal table As DataTable, ByVal columnname As String, ByVal newtype As Type) As Boolean
        If table.Columns.Contains(columnname) = False Then
            Return False
        End If

        Dim column As DataColumn = table.Columns(columnname)
        If column.DataType = newtype Then
            Return True
        End If

        Try
            Dim newcolumn As New DataColumn("temperary", newtype)
            table.Columns.Add(newcolumn)
            For Each row As DataRow In table.Rows
                Try
                    row("temperary") = Convert.ChangeType(row(columnname), newtype)
                Catch
                End Try
            Next row
            table.Columns.Remove(columnname)
            newcolumn.ColumnName = columnname
        Catch e1 As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function GetSortDirection(ByVal column As String) As String

        ' By default, set the sort direction to ascending.
        Dim sortDirection = "ASC"

        ' Retrieve the last column that was sorted.
        Dim sortExpression = TryCast(ViewState("SortExpression"), String)

        If sortExpression IsNot Nothing Then
            ' Check if the same column is being sorted.
            ' Otherwise, the default value can be returned.
            If sortExpression = column Then
                Dim lastDirection = TryCast(ViewState("SortDirection"), String)
                If lastDirection IsNot Nothing _
                  AndAlso lastDirection = "ASC" Then

                    sortDirection = "DESC"

                End If
            End If
        End If

        ' Save new values in ViewState.
        ViewState("SortDirection") = sortDirection
        ViewState("SortExpression") = column

        Return sortDirection

    End Function

    Private Function UploadPhotoDoc() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "VPDocs\" + txtPrincipalName.Text
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuPath.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuPath.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuPath.SaveAs(Server.MapPath(saveDir + "\" + fuPath.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "VPDocs\" & txtPrincipalName.Text & "\" & fuPath.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPath.Value = "VPDocs\" & txtPrincipalName.Text & "\" & fuPath.FileName
                    lblWarning2.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning2.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning2.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Sub lbSaveDoc_Click(sender As Object, e As EventArgs) Handles lbSaveDoc.Click

        'If chkArchive.Checked Then
        '    hdnISArchive.Value = 0
        'Else
        '    hdnISArchive.Value = 1
        'End If

        UploadPhotoDoc()

        With htParameters

            .Add("Mode", 0)
            .Add("PrincipalCode", txtPrincipalCode.Text)
            .Add("DocCode", ddlDocCode.SelectedValue)
            '.Add("DocTitle", ddlDocCode.SelectedItem.ToString)
            .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDate"))
            If chkNoExpiry.Checked = True Then
                .Add("ExpiryDate", "1900-01-01")
            Else
                .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExdate"))
            End If
            .Add("IsArchive", 0)
            .Add("Path", hdnPath.Value)
            .Add("Remarks", txtRemarks.Text)

        End With
        MainClass.Library.Command.Execute(htParameters, "VPDocMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Principals.aspx")
        htParameters.Add("ActionTaken", "Add Document")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        'UPDATECREPROFILE()

        '     MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "DN" & "'")

        GetDocs()

        clearFields()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewDoc", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewDoc').hide();", True)

    End Sub

    Private Sub GetDocs()

        htParameters.Add("Mode", 1)
        '  htParameters.Add("PrincipalCode", txtPrincipalCode.Text)
        ' htParameters.Add("IsArchive", 0)

        ViewState("Flags") = MainClass.Library.Adapter.GetRecordSet(htParameters, "DocSel")

        gvDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "DocSel")
        gvDocs.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvDocs_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvDocs.Sorting

        Dim dt = TryCast(ViewState("Flags"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvDocs.DataSource = ViewState("Flags")
            gvDocs.DataBind()
        End If

    End Sub

    Protected Sub gvDocs_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDocs.RowCommand

        If e.CommandName = "ViewDocs2" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ViewDocRec(index)

            ifPDF.Attributes.Add("src", hdnDocPath.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalDs();", True)

        End If

    End Sub

    Public Function ViewDocRec(ByVal Code As String) As String

        Dim result As String = ""

        htParameters.Add("Mode", 1)
        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VPDocSel")
        If dt.Rows.Count > 0 Then
            Try
                For Each row As DataRow In dt.Rows
                    Try
                        hdnDocID.Value = row("ID").ToString
                        hdnDocPath.Value = row("Path").ToString
                        lblDocTitle.Text = row("DocTitle")
                        ddlDocCodeUpdate.SelectedValue = MainClass.Library.Command.ExecScalar("SELECT DocCode from Documents WHERE DocTitle='" & row("DocTitle").ToString & "'")

                        txtIDateUpdate.Text = row("IssuedDate")

                        If row("ExpiryDate") = "1900-01-01" Then
                            txtExDateUpdate.Text = ""
                            chkNoExpiryU.Checked = True
                        Else
                            txtExDateUpdate.Text = row("ExpiryDate")
                            chkNoExpiryU.Checked = False
                        End If

                        hdnArchiveUpdate.Value = row("IsArchive")
                        txtRemarksUpdate.Text = row("Remarks")

                    Catch ex As Exception

                    End Try

                Next
            Catch ex As Exception
            End Try
        End If

        If hdnArchiveUpdate.Value = "True" Then
            chkArchiveUpdate.Checked = False
        Else
            chkArchiveUpdate.Checked = True
        End If
        htParameters.Clear()
        Return result
    End Function

    Private Function UploadPhotoDocUpdate() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "VPDocs\" + txtPrincipalName.Text
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuDocUpdate.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuDocUpdate.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuDocUpdate.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuDocUpdate.SaveAs(Server.MapPath(saveDir + "\" + fuDocUpdate.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "VPDocs\" & txtPrincipalName.Text & "\" & fuDocUpdate.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnDocPath.Value = "VPDocs\" & txtPrincipalName.Text & "\" & fuDocUpdate.FileName
                    lblWarning3.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning3.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning3.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Sub btnCrewDocuUpdate_Click(sender As Object, e As EventArgs) Handles btnCrewDocuUpdate.Click

        If chkArchiveUpdate.Checked Then
            hdnArchiveUpdate.Value = 0
        Else
            hdnArchiveUpdate.Value = 1
        End If

        If fuDocUpdate.HasFile Then
            UploadPhotoDocUpdate()
        End If

        With htParameters

            .Add("Mode", 1)
            .Add("ID", hdnDocID.Value)
            .Add("PrincipalCode", txtPrincipalCode.Text)
            .Add("DocCode", ddlDocCodeUpdate.SelectedValue)
            .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDateUpdate"))
            If chkNoExpiryU.Checked = True Then
                .Add("ExpiryDate", "1900-01-01")
            Else
                .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExDateUpdate"))
            End If
            .Add("IsArchive", hdnArchiveUpdate.Value)
            .Add("Path", hdnDocPath.Value)
            .Add("Remarks", txtRemarksUpdate.Text)


        End With
        MainClass.Library.Command.Execute(htParameters, "VPDocMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Principals.aspx")
        htParameters.Add("ActionTaken", "Update Document")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        GetDocs()

        ' UPDATECREPROFILE()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewDocU", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewDocU').hide();", True)

    End Sub

End Class