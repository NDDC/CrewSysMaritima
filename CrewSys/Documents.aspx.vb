Public Class Documents
    Inherits System.Web.UI.Page

    Dim htParameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") = "AD" Or Session("Access") = "DOCO" Then

                LoadDefaults()

                GridBind()
            Else

                btnAddNew.Visible = False
                btnAddUpdateDocs.Visible = False

                GridBind()
            End If

        End If

        Page.Title = "Manage Documents"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        htParameters.Add("Mode", 1)
        htParameters.Add("DocTitle", txtSearch.Text)

        gvDoc.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "DocSel")
        gvDoc.DataBind()
        htParameters.Clear()
        MultiView1.ActiveViewIndex = 0

        ViewState("Search1") = gvDoc.DataSource

        hdnView.Value = "Search1"
    End Sub

    Private Sub LoadDefaults()

        ddlDocType.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='DT' ORDER BY LookUpDescription")
        ddlDocType.DataTextField = "LookupDescription"
        ddlDocType.DataValueField = "LookupCode"
        ddlDocType.DataBind()

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

    Protected Sub gvDoc_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDoc.RowCommand
        If e.CommandName = "View" Then

            Dim index = e.CommandArgument

            Try
                ViewRecord(index)

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update Document"
                btnAddUpdateDocs.Text = "Update Document"
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

        ' mvAllotment.ActiveViewIndex = 1

        htParameters.Add("Mode", 2)
        htParameters.Add("DocCode", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "DocSel")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("ID").ToString
                ddlDocType.SelectedValue = row("DocType").ToString
                txtDocCode.Text = row("DocCode").ToString
                txtDocTitle.Text = row("DocTitle").ToString


                '  ddlDepartment.SelectedValue = row("Department").ToString

            Catch ex As Exception

            End Try
        Next

        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtDocTitle.Text = String.Empty
        txtDocCode.Text = String.Empty

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        '    PrincipalCode,
        'RankCode,
        'Scale,
        'BasicWage,
        'WorkHours,
        'OverTimePay,
        'OverTimeRate,
        'OverTimeRateAfter,
        'LeavePay,
        'WeekEndPay,
        'SocialBonus,
        'Allowance,
        'DndAllowance,
        'IMO


        'Dim htParameters As New Hashtable

        'htParameters.Add("Mode", 0)
        'htParameters.Add("PrincipalCode", ddlPrincipalCode.SelectedValue)
        'htParameters.Add("RankCode", ddlrank.SelectedValue)
        'htParameters.Add("BasicWage", txtBasicWage.Text)
        'htParameters.Add("WorkHours", txtWorkHours.Text)
        'htParameters.Add("OverTimePay", txtOTPay.Text)
        'htParameters.Add("OverTimeRate", txtOTRate.Text)
        '' htParameters.Add("OverTimeRateAfter", txtOTRateAfter.Text)
        'htParameters.Add("LeavePay", txtLeavePay.Text)
        'htParameters.Add("WeekEndPay", txtWeekEndPay.Text)
        'htParameters.Add("SocialBonus", txtSocialbonus.Text)
        'htParameters.Add("Allowance", txtAllowance.Text)
        'htParameters.Add("DndAllowance", txtdndAllowance.Text)
        'htParameters.Add("IMO", txtIMO.Text)

        'MainClass.Library.Command.Execute(htParameters, "WageMod")
        hdnMode.Value = 0
        clearFields()
        txtDocCode.Text = CreateSequenceNo("DC")
        btnAddUpdateDocs.Text = "Add New Document"
        lblHead.Text = "New Document"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        txtSearch.Visible = False
        btnGo1.Visible = False
    End Sub

    Private Sub btnAddUpdateDocs_Click(sender As Object, e As EventArgs) Handles btnAddUpdateDocs.Click
        With htParameters
            .Add("Mode", hdnMode.Value)

            .Add("ID", hdnID.Value)
            .Add("DocType", ddlDocType.SelectedValue)
            .Add("DocCode", txtDocCode.Text)
            .Add("DocTitle", txtDocTitle.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "DocMod")

        If hdnMode.Value = 0 Then
            MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "DC" & "'")
        End If

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Documents.aspx")
        htParameters.Add("ActionTaken", "Add/Update Documents")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateDocs.Text = "Add New Document"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateDocs.Text = "Add New Document"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub Documents_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        Session("Access") = "AD"
        'If Session("UserName") Is Nothing Then
        '    Response.Redirect("login.aspx")
        'End If

        'If Session("Access") <> "AD" Then
        '    Session.RemoveAll()
        '    Session.Abandon()
        '    Session.Clear()
        '    Response.Redirect("Login.aspx")
        'End If

    End Sub

    Protected Sub gvDoc_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvDoc.PageIndexChanging

        gvDoc.DataSource = ViewState(hdnView.Value)

        gvDoc.PageIndex = e.NewPageIndex
        gvDoc.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvDoc_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvDoc.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvDoc.DataSource = ViewState(hdnView.Value)
            gvDoc.DataBind()
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

End Class