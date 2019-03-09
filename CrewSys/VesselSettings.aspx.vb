Public Class VesselSettings
    Inherits System.Web.UI.Page

    Dim htParameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") = "AD" Then

                GridBind()
            Else

                gvTC.Columns(1).Visible = False
                btnAddNew.Visible = False
                btnAddUpdateReason.Visible = False

                GridBind()
            End If

        End If

        Page.Title = "Manage Vessel Type & CBA"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        htParameters.Add("Mode", 1)
        htParameters.Add("TypeCBA", txtSearch.Text)

        gvTC.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "TCSel")
        gvTC.DataBind()
        htParameters.Clear()
        MultiView1.ActiveViewIndex = 0

        ViewState("Search1") = gvTC.DataSource

        hdnView.Value = "Search1"
    End Sub

    Public Function CreateSequenceNo(ByVal SequenceCode As String) As String
        Dim sBin As String
        Dim NewSequenceNo As String
        Try
            sBin = MainClass.Library.Command.ExecScalar("Select MAX(SequenceNo) FROM SequenceNo WHERE SequenceCode='" & SequenceCode & "'")
            NewSequenceNo = Right("00000" & sBin, 4)

        NewSequenceNo = SequenceCode & NewSequenceNo
            Return NewSequenceNo
        Catch ex As Exception
            Dim errmsg As String = ex.ToString
            Return errmsg
        End Try
    End Function

    Protected Sub gvTC_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvTC.RowCommand
        If e.CommandName = "View" Then

            Dim index = e.CommandArgument

            Try
                ViewRecord(index)

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update"
                btnAddUpdateReason.Text = "Update"
                btnAddNew.Visible = False
                txtSearch.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        ElseIf e.CommandArgument = "DeleteReason" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            htParameters.Add("ID", index)
            htParameters.Add("Mode", 2)
            MainClass.Library.Command.Execute(htParameters, "TCMod")

            htParameters.Clear()

            htParameters.Add("UserName", Session("UserName"))
            htParameters.Add("ModuleAccess", Session("Access"))
            htParameters.Add("Mode", 1)
            htParameters.Add("PageAccess", "VesselSettings.aspx")
            htParameters.Add("ActionTaken", "Delete")
            MainClass.Library.Command.Execute(htParameters, "AuditMod")
            htParameters.Clear()

        End If

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""
        Dim dt As New DataTable

        htParameters.Add("Mode", 2)
        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "TCSel")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("GenericLookUpID").ToString
                txtSignOffReason.Text = row("LookUpDescription").ToString
                hdnCode.Value = row("LookUpCode").ToString
                ddlChoose.SelectedValue = row("GenericLookUpCode").ToString

            Catch ex As Exception

            End Try
        Next

        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtSignOffReason.Text = String.Empty

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        hdnMode.Value = 0
        clearFields()
        hdnCode.Value = CreateSequenceNo("SR")
        btnAddUpdateReason.Text = "Add New"
        lblHead.Text = "New"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        txtSearch.Visible = False
        btnGo1.Visible = False
    End Sub

    Private Sub btnAddUpdateReason_Click(sender As Object, e As EventArgs) Handles btnAddUpdateReason.Click
        With htParameters
            .Add("Mode", hdnMode.Value)
            .Add("ID", hdnID.Value)

            If ddlChoose.SelectedValue = "VT" Then
                .Add("GenericLookUpCode", "VT")
                .Add("GenericLookUpDesc", "Vessel Type")
            ElseIf ddlChoose.SelectedValue = "CB" Then
                .Add("GenericLookUpCode", "CB")
                .Add("GenericLookUpDesc", "CBA")
            End If

            .Add("LookUpCode", hdnCode.Value)
            .Add("LookUpDescription", txtSignOffReason.Text)

        End With
        MainClass.Library.Command.Execute(htParameters, "TCMod")

        htParameters.Clear()

        If hdnMode.Value = 0 Then
            MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "SR" & "'")
        End If

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "VesselSettings.aspx")
        htParameters.Add("ActionTaken", "Add/Update")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateReason.Text = "Add New"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateReason.Text = "Add New"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub VesselSettings_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

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

    Protected Sub gvTC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvTC.PageIndexChanging

        gvTC.DataSource = ViewState(hdnView.Value)

        gvTC.PageIndex = e.NewPageIndex
        gvTC.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvTC_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvTC.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvTC.DataSource = ViewState(hdnView.Value)
            gvTC.DataBind()
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