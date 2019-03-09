Public Class WagesArchive
    Inherits System.Web.UI.Page

    Dim htParameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("Access") = "P" Then
                ddlPrincipal.Visible = False
                lblddlPrincipal.Visible = False
                btnAddNew.Visible = False
                btnAddUpdateWages.Visible = False
                gvWage.Visible = False
            ElseIf Session("Access") = "AC" Or Session("Access") = "AD" Then
                LoadDefaults()
                gvWageP.Visible = False
            Else
                btnAddNew.Visible = False
                btnAddUpdateWages.Visible = False
                gvWageP.Visible = False
            End If

            GridBind()

        End If

        Page.Title = "Manage Wages"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        If Session("Access") = "P" Then
            htParameters.Add("Keyword", ddlRankS.SelectedValue)
            htParameters.Add("Mode", 2)
            htParameters.Add("PrincipalCode", Session("PCode"))

            gvWageP.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ManageWages")
            gvWageP.DataBind()
            htParameters.Clear()
            MultiView1.ActiveViewIndex = 0

            ViewState("Search1") = gvWageP.DataSource
        Else
            htParameters.Add("Keyword", ddlRankS.SelectedValue)
            htParameters.Add("PrincipalCode", ddlPrincipal.SelectedValue)
            htParameters.Add("Mode", 1)

            gvWage.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ManageWages")
            gvWage.DataBind()
            htParameters.Clear()
            MultiView1.ActiveViewIndex = 0

            ViewState("Search1") = gvWage.DataSource

        End If
        hdnView.Value = "Search1"
    End Sub

    Private Sub LoadDefaults()

        ddlRank.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank.DataTextField = "RankDescription"
        ddlRank.DataValueField = "RankCode"
        ddlRank.DataBind()

        'ddlPrincipalCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT PrincipalCode,Description FROM Principal")
        'ddlPrincipalCode.DataTextField = "Description"
        'ddlPrincipalCode.DataValueField = "PrincipalCode"
        'ddlPrincipalCode.DataBind()

        BindDropdown(ddlPrincipalCode, "PrincipalCode", "PrincipalName", "Principal")
    End Sub

    Private Sub BindDropdown(ByVal ddl As DropDownList, ByVal DataValueField As String, ByVal DataTextField As String, ByVal TableName As String)

        ddl.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT " & DataValueField & "," & DataTextField & " FROM " & TableName)
        ddl.DataTextField = DataTextField
        ddl.DataValueField = DataValueField
        ddl.DataBind()

    End Sub

    Protected Sub gvWage_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvWage.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gvAllotment.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            Try
                ViewRecord(index)

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update Wage Scale"
                btnAddUpdateWages.Text = "Update Wage Scale"
                btnAddNew.Visible = False
                ddlPrincipal.Visible = False
                ddlRankS.Visible = False
                btnGo1.Visible = False
                lblddlPrincipal.Visible = False
                lblRankS.Visible = False
                lblSearch.Visible = False

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

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "GetWageRecord")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("ID").ToString
                ddlPrincipalCode.SelectedValue = row("PrincipalCode").ToString
                ddlRank.SelectedValue = row("RankCode").ToString
                ddlScale.SelectedValue = row("Scale").ToString
                txtBasicWage.Text = row("BasicWage").ToString
                txtWorkHours.Text = row("WorkHours").ToString
                txtOTPay.Text = row("OvertimePay").ToString
                txtOTRate.Text = row("OvertimeRate").ToString
                txtLeavePay.Text = row("LeavePay").ToString
                txtWeekendPay.Text = row("WeekEndpay").ToString
                txtSocialBonus.Text = row("SocialBonus").ToString
                txtAllowance.Text = row("Allowance").ToString
                txtDndAllowance.Text = row("DndAllowance").ToString
                txtIMO.Text = row("IMO").ToString


                '  ddlDepartment.SelectedValue = row("Department").ToString

            Catch ex As Exception

            End Try
        Next

        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtBasicWage.Text = 0.00
        txtWorkHours.Text = 44
        txtOTPay.Text = 0.00
        txtOTRate.Text = 0.00
        txtLeavePay.Text = 0.00
        txtWeekendPay.Text = 0.00
        txtSocialBonus.Text = 0.00
        txtAllowance.Text = 0.00
        txtDndAllowance.Text = 0.00
        txtIMO.Text = 0.00

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
        btnAddUpdateWages.Text = "Add New Wage Scale"
        lblHead.Text = "New Wage Scale"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        ddlPrincipal.Visible = False
        ddlRankS.Visible = False
        btnGo1.Visible = False
        lblddlPrincipal.Visible = False
        lblRankS.Visible = False
        lblSearch.Visible = False

    End Sub

    Private Sub btnAddUpdateWages_Click(sender As Object, e As EventArgs) Handles btnAddUpdateWages.Click
        With htParameters
            .Add("Mode", hdnMode.Value)

            .Add("ID", hdnID.Value)
            .Add("PrincipalCode", ddlPrincipalCode.SelectedValue)
            .Add("RankCode", ddlRank.SelectedValue)
            .Add("Scale", ddlScale.SelectedValue)
            .Add("BasicWage", txtBasicWage.Text)
            .Add("WorkHours", txtWorkHours.Text)
            .Add("OverTimePay", txtOTPay.Text)
            .Add("OverTimeRate", txtOTRate.Text)
            ' .Add("OverTimeRateAfter", txtOTRateAfter.Text)
            .Add("LeavePay", txtLeavePay.Text)
            .Add("WeekEndPay", txtWeekendPay.Text)
            .Add("SocialBonus", txtSocialBonus.Text)
            .Add("Allowance", txtAllowance.Text)
            .Add("DndAllowance", txtDndAllowance.Text)
            .Add("IMO", txtIMO.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "WageMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Wages.aspx")
        htParameters.Add("ActionTaken", "Add/Update Wage Scale")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateWages.Text = "Add New Wage Scale"

        btnAddNew.Visible = True
        If Session("Access") <> "P" Then
            ddlPrincipal.Visible = True
            lblddlPrincipal.Visible = True
        End If
        ddlRankS.Visible = True
        btnGo1.Visible = True
        lblRankS.Visible = True
        lblSearch.Visible = True

        ddlPrincipalCode.Enabled = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateWages.Text = "Add New Wage Scale"

        btnAddNew.Visible = True
        If Session("Access") <> "P" Then
            ddlPrincipal.Visible = True
            lblddlPrincipal.Visible = True
        End If
        ddlRankS.Visible = True
        btnGo1.Visible = True
        lblRankS.Visible = True
        lblSearch.Visible = True

        ddlPrincipalCode.Enabled = True

    End Sub

    Private Sub Wages_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        'If Session("Access") <> "AD" Then
        '    If Session("Access") <> "AC" And Session("Access") <> "P" Then
        '        Session.RemoveAll()
        '        Session.Abandon()
        '        Session.Clear()
        '        Response.Redirect("Login.aspx")
        '    End If
        'End If

    End Sub

    Protected Sub gvWage_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvWage.PageIndexChanging

        gvWage.DataSource = ViewState(hdnView.Value)

        gvWage.PageIndex = e.NewPageIndex
        gvWage.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvWageP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvWageP.PageIndexChanging

        gvWageP.DataSource = ViewState(hdnView.Value)

        gvWageP.PageIndex = e.NewPageIndex
        gvWageP.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvWageP_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvWageP.Sorting

        Dim dt = TryCast(ViewState("Search1"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvWageP.DataSource = ViewState("Search1")
            gvWageP.DataBind()
        End If

    End Sub

    Protected Sub gvWage_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvWage.Sorting

        Dim dt = TryCast(ViewState("Search1"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvWage.DataSource = ViewState("Search1")
            gvWage.DataBind()
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