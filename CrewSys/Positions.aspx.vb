Public Class Positions
    Inherits System.Web.UI.Page

    Dim htParameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") <> "AD" Then

                btnAddNew.Visible = False
                btnAddUpdateRanks.Visible = False

            End If

            GridBind()

        End If

        Page.Title = "Manage Rank"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        htParameters.Add("Mode", 1)
        htParameters.Add("RankDescription", txtSearch.Text)

        gvRank.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "RankSel")
        gvRank.DataBind()
        htParameters.Clear()
        MultiView1.ActiveViewIndex = 0

        ViewState("Search1") = gvRank.DataSource

        hdnView.Value = "Search1"
    End Sub

    Protected Sub gvRank_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRank.RowCommand
        If e.CommandName = "View" Then

            Dim index = e.CommandArgument

            Try
                ViewRecord(index)

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update Rank"
                btnAddUpdateRanks.Text = "Update Rank"
                btnAddNew.Visible = False
                txtSearch.Visible = False
                btnGo1.Visible = False
                txtRankCode.ReadOnly = True
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
        htParameters.Add("RankID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RankSel")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("RankID").ToString
                txtRank.Text = row("RankDescription").ToString
                txtRankCode.Text = row("RankCode").ToString
                'txtRankSort.Text = row("RankSortCode").ToString

                '  ddlDepartment.SelectedValue = row("Department").ToString

            Catch ex As Exception

            End Try
        Next

        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtRank.Text = String.Empty
        txtRankCode.Text = String.Empty
        'txtRankSort.Text = 0.0

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        hdnMode.Value = 0
        clearFields()
        btnAddUpdateRanks.Text = "Add New Rank"
        lblHead.Text = "New Rank"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        txtSearch.Visible = False
        btnGo1.Visible = False
    End Sub

    Private Sub btnAddUpdateRanks_Click(sender As Object, e As EventArgs) Handles btnAddUpdateRanks.Click
        With htParameters
            .Add("Mode", hdnMode.Value)

            .Add("ID", hdnID.Value)
            '.Add("RankSortCode", txtRankSort.Text)
            .Add("RankCode", txtRankCode.Text)
            .Add("RankDescription", txtRank.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "RankMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Positions.aspx")
        htParameters.Add("ActionTaken", "Add/Update Positions")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        txtRankCode.ReadOnly = False

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateRanks.Text = "Add New Rank"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateRanks.Text = "Add New Rank"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub Rank_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

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

    Protected Sub gvRank_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRank.PageIndexChanging

        gvRank.DataSource = ViewState(hdnView.Value)

        gvRank.PageIndex = e.NewPageIndex
        gvRank.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvRank_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvRank.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvRank.DataSource = ViewState(hdnView.Value)
            gvRank.DataBind()
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