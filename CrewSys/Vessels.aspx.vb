Public Class Vessels
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") = "P" Then

                htParameters.Clear()
                htParameters.Add("Mode", 6)
                htParameters.Add("Keyword", "")
                htParameters.Add("Status", "")
                htParameters.Add("PrincipalCode", Session("PCode"))
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("All") = dt
                lbAll.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 7)
                htParameters.Add("Status", "ACTIVE")
                htParameters.Add("PrincipalCode", Session("PCode"))
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Active") = dt
                lbActive.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 7)
                htParameters.Add("Status", "INACTIVE")
                htParameters.Add("PrincipalCode", Session("PCode"))
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Inactive") = dt
                lbInactive.Text = dt.Rows.Count
                htParameters.Clear()

                btnAddNew.Visible = False
                btnAddUpdateVessel.Visible = False
                ddlPrincipal.Visible = False
                lblddlPrincipal.Visible = False
                gvVessel.Visible = False

                LoadDefaults()

            ElseIf Session("Access") <> "AD" Then
                htParameters.Clear()
                htParameters.Add("Mode", 4)
                htParameters.Add("Keyword", "")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("All") = dt
                lbAll.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 5)
                htParameters.Add("Status", "ACTIVE")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Active") = dt
                lbActive.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 5)
                htParameters.Add("Status", "INACTIVE")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Inactive") = dt
                lbInactive.Text = dt.Rows.Count
                htParameters.Clear()

                gvVesselP.Visible = False
                btnAddNew.Visible = False
                btnAddUpdateVessel.Visible = False

                LoadDefaults()
            Else

                txtVesselCode.Text = CreateSequenceNo("VS")

                htParameters.Clear()
                htParameters.Add("Mode", 4)
                htParameters.Add("Keyword", "")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("All") = dt
                lbAll.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 5)
                htParameters.Add("Status", "ACTIVE")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Active") = dt
                lbActive.Text = dt.Rows.Count

                htParameters.Clear()
                htParameters.Add("Mode", 5)
                htParameters.Add("Status", "INACTIVE")
                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
                ViewState("Inactive") = dt
                lbInactive.Text = dt.Rows.Count
                htParameters.Clear()

                gvVesselP.Visible = False

                LoadDefaults()

            End If

            GridBind()

        End If

        Page.Title = "Manage Vessels"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
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

    Private Sub GridBind()

        If Session("Access") = "P" Then
            htParameters.Add("Mode", 100)
            htParameters.Add("Keyword", ddlVessel.SelectedValue)
            htParameters.Add("PrincipalCode", Session("PCode"))
            gvVesselP.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
            gvVesselP.DataBind()

            htParameters.Clear()

            MultiView1.SetActiveView(vVessels)

            ViewState("Search1") = gvVesselP.DataSource

            hdnView.Value = "Search1"
        Else
            htParameters.Add("Mode", 100)
            htParameters.Add("Keyword", ddlVessel.SelectedValue)
            htParameters.Add("PrincipalCode", ddlPrincipal.SelectedValue)

            gvVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
            gvVessel.DataBind()

            htParameters.Clear()

            MultiView1.SetActiveView(vVessels)

            ViewState("Search1") = gvVessel.DataSource

            hdnView.Value = "Search1"
        End If

    End Sub

    Private Sub LoadDefaults()

        Dim year1 = Year(Now) - 80
        For b = year1 To Year(Now)
            ddlYear.Items.Add(New ListItem(b))
        Next

        ddlDocCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents WHERE DocType='VDOC' ORDER BY DocTitle")
        ddlDocCode.DataTextField = "DocTitle"
        ddlDocCode.DataValueField = "DocCode"
        ddlDocCode.DataBind()

        ddlDocCodeUpdate.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents WHERE DocType='VDOC' ORDER BY DocTitle")
        ddlDocCodeUpdate.DataTextField = "DocTitle"
        ddlDocCodeUpdate.DataValueField = "DocCode"
        ddlDocCodeUpdate.DataBind()

        ddlVesselType.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='VT' ORDER By LookUpDescription")
        ddlVesselType.DataTextField = "LookupDescription"
        ddlVesselType.DataValueField = "LookupCode"
        ddlVesselType.DataBind()

        ddlCBA.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='CB' ORDER By LookUpDescription")
        ddlCBA.DataTextField = "LookupDescription"
        ddlCBA.DataValueField = "LookupCode"
        ddlCBA.DataBind()

        ddlFlag.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER By Country")
        ddlFlag.DataTextField = "Country"
        ddlFlag.DataValueField = "Code"
        ddlFlag.DataBind()

        ddlPrincipalCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT PrincipalCode,PrincipalName FROM Principal ORDER By PrincipalName")
        ddlPrincipalCode.DataTextField = "PrincipalName"
        ddlPrincipalCode.DataValueField = "PrincipalCode"
        ddlPrincipalCode.DataBind()

        If Session("Access") = "P" Then

            ddlVessel.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT VesselName, VesselCode from Vessels WHERE PrincipalCode='" & Session("PCode") & "'")
            ddlVessel.DataTextField = "VesselName"
            ddlVessel.DataValueField = "VesselCode"
            ddlVessel.DataBind()
            htParameters.Clear()

        Else
            BindDropdown(ddlVessel, "VesselCode", "VesselName", "Vessels")
            ddlVessel.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))
        End If

        BindDropdown(ddlPrincipal, "PrincipalCode", "Description", "Principal")
        ddlPrincipal.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))
    End Sub

    Private Sub BindDropdown(ByVal ddl As DropDownList, ByVal DataValueField As String, ByVal DataTextField As String, ByVal TableName As String)

        ddl.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT " & DataValueField & "," & DataTextField & " FROM " & TableName)
        ddl.DataTextField = DataTextField
        ddl.DataValueField = DataValueField
        ddl.DataBind()

    End Sub

    Protected Sub gvVessel_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvVessel.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Try
                ViewRecord(index)

                '  GetDocs()

                MultiView1.ActiveViewIndex = 1

                btnAddNew.Visible = False
                ddlPrincipal.Visible = False
                lblddlPrincipal.Visible = False
                ddlVessel.Visible = False
                lblVessel.Visible = False
                lblSearch.Visible = False
                btnGo1.Visible = False

                btnAddDoc.Attributes.Add("class", "btn btn-success show pull-right")
                gvDocs.Visible = True

                lblHead.Text = "Update Vessel"
                btnAddUpdateVessel.Text = "Update Vessel"

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewVesselRecord")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try

                hdnID.Value = row("ID").ToString
                ddlPrincipalCode.SelectedValue = row("PrincipalCode").ToString
                txtVesselCode.Text = row("VesselCode").ToString
                txtVesselName.Text = row("VesselName").ToString
                txtExVesselName.Text = row("ExVesselName").ToString
                txtCallSign.Text = row("CallSign").ToString
                txtIMONo.Text = row("IMONo").ToString
                ddlFlag.SelectedValue = row("Flag").ToString
                ddlVesselType.SelectedValue = row("VesselType").ToString
                hdnVesselStat.Value = row("VesselStatus").ToString
                txtGRT.Text = row("GRT").ToString
                txtEngineType.Text = row("EngineType").ToString
                ddlYear.SelectedValue = row("YearBuilt").ToString
                txtClassification.Text = row("Classification").ToString
                ddlCBA.SelectedValue = row("CBA").ToString
                '
                ' txtOfficialNo.Text = row("OfficialNo").ToString
                ' txtBuilder.Text = row("Builder").ToString
                '  txtEngineMaker.Text = row("EngineMaker").ToString
                ' txtNetTons.Text = row("NetTons").ToString

                If hdnVesselStat.Value = "INACTIVE" Then
                    VesselStatus.Checked = 0
                Else
                    VesselStatus.Checked = 1
                End If

                '  ddlDepartment.SelectedValue = row("Department").ToString

            Catch ex As Exception

            End Try
        Next
        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtVesselName.Text = ""
        txtExVesselName.Text = ""
        txtCallSign.Text = ""
        txtIMONo.Text = ""
        txtGRT.Text = ""
        txtEngineType.Text = ""
        txtClassification.Text = ""
        txtOfficialNo.Text = ""
        txtBuilder.Text = ""
        txtEngineMaker.Text = ""
        txtNetTons.Text = ""

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        hdnMode.Value = 0
        clearFields()
        btnAddUpdateVessel.Text = "Add Vessel"
        lblHead.Text = "New Vessel"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        ddlPrincipal.Visible = False
        lblddlPrincipal.Visible = False
        ddlVessel.Visible = False
        lblVessel.Visible = False
        lblSearch.Visible = False
        btnGo1.Visible = False

        btnAddDoc.Attributes.Add("class", "hide")
        gvDocs.Visible = False
    End Sub

    Private Sub btnAddUpdateVessel_Click(sender As Object, e As EventArgs) Handles btnAddUpdateVessel.Click

        If VesselStatus.Checked Then
            hdnVesselStat.Value = "ACTIVE"
        Else
            hdnVesselStat.Value = "INACTIVE"
        End If
        With htParameters
            .Add("Mode", hdnMode.Value)
            .Add("ID", hdnID.Value)
            .Add("PrincipalCode", ddlPrincipalCode.SelectedValue)
            .Add("VesselCode", txtVesselCode.Text)
            .Add("VesselName", txtVesselName.Text)
            .Add("ExVesselName", txtExVesselName.Text)
            .Add("CallSign", txtCallSign.Text)
            .Add("IMONo", txtIMONo.Text)
            .Add("Flag", ddlFlag.SelectedValue)
            .Add("VesselType", ddlVesselType.SelectedValue)
            .Add("VesselStatus", hdnVesselStat.Value)
            .Add("GRT", txtGRT.Text)
            .Add("EngineType", txtEngineType.Text)
            .Add("YearBuilt", ddlYear.SelectedValue)
            .Add("Classification", txtClassification.Text)
            .Add("CBA", ddlCBA.SelectedValue)
            '  .Add("OfficialNo", txtOfficialNo.Text)
            ' .Add("Builder", txtBuilder.text)
            ' .Add("EngineMaker", txtEngineMaker.Text)
            ' .Add("NetTons", txtNetTons.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "VesselMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Vessels.aspx")
        htParameters.Add("ActionTaken", "Add/Update Vessel")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        If hdnMode.Value = 0 Then
            MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "VS" & "'")
        End If

        MultiView1.SetActiveView(vActionNotification)

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        Response.Redirect("Vessels.aspx")

    End Sub

    Private Sub lbAll_Click(sender As Object, e As EventArgs) Handles lbAll.Click
        If Session("Access") = "P" Then
            gvVesselP.DataSource = ViewState("All")
            gvVesselP.DataBind()
        Else
            gvVessel.DataSource = ViewState("All")
            gvVessel.DataBind()
        End If
        hdnView.Value = "All"
    End Sub

    Private Sub lbActive_Click(sender As Object, e As EventArgs) Handles lbActive.Click
        If Session("Access") = "P" Then
            gvVesselP.DataSource = ViewState("Active")
            gvVesselP.DataBind()
        Else
            gvVessel.DataSource = ViewState("Active")
            gvVessel.DataBind()
        End If
        hdnView.Value = "Active"
    End Sub

    Private Sub lbInactive_Click(sender As Object, e As EventArgs) Handles lbInactive.Click
        If Session("Access") = "P" Then
            gvVesselP.DataSource = ViewState("Inactive")
            gvVesselP.DataBind()
        Else
            gvVessel.DataSource = ViewState("Inactive")
            gvVessel.DataBind()
        End If
        hdnView.Value = "Inactive"
    End Sub

    Private Sub Vessel_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        'If Session("Access") <> "AD" And Session("Access") <> "P" Then
        '    Session.RemoveAll()
        '    Session.Abandon()
        '    Session.Clear()
        '    Response.Redirect("Login.aspx")
        'End If

    End Sub

    Protected Sub gvVessel_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvVessel.PageIndexChanging

        gvVessel.DataSource = ViewState(hdnView.Value)

        gvVessel.PageIndex = e.NewPageIndex
        gvVessel.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvVesselP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvVesselP.PageIndexChanging

        gvVesselP.DataSource = ViewState(hdnView.Value)

        gvVesselP.PageIndex = e.NewPageIndex
        gvVesselP.DataBind()
        htParameters.Clear()

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        clearFields()

        ddlVessel.Visible = True
        lblVessel.Visible = True

        If Session("Access") <> "P" Then
            ddlPrincipal.Visible = True
            lblddlPrincipal.Visible = True
            btnAddNew.Visible = True
        End If

        lblSearch.Visible = True
        btnGo1.Visible = True

        MultiView1.SetActiveView(vVessels)

    End Sub

    Protected Sub gvVessel_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvVessel.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvVessel.DataSource = ViewState(hdnView.Value)
            gvVessel.DataBind()
        End If

    End Sub

    Protected Sub gvVesselP_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvVesselP.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvVesselP.DataSource = ViewState(hdnView.Value)
            gvVesselP.DataBind()
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

    Private Sub GetDocs()

        htParameters.Add("Mode", 1)
        htParameters.Add("PrincipalCode", txtVesselCode.Text)
        htParameters.Add("IsArchive", 0)

        ViewState("Flags") = MainClass.Library.Adapter.GetRecordSet(htParameters, "VPDocSel")

        gvDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VPDocSel")
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
        Dim saveDir As String = "VPDocs\" + txtVesselName.Text
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
                    fileDocView = "VPDocs\" & txtVesselName.Text & "\" & fuDocUpdate.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnDocPath.Value = "VPDocs\" & txtVesselName.Text & "\" & fuDocUpdate.FileName
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
            .Add("PrincipalCode", txtVesselCode.Text)
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