Imports Microsoft.Reporting.WebForms

Public Class Payroll
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LoadDefaults()

            SearchCrew()

            pAllottments.Visible = False

        End If

        Page.Title = "Manage Payroll"

    End Sub

    Private Sub Payroll_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Session("Access") <> "AD" Then
            If Session("Access") <> "AC" Then
                Session.RemoveAll()
                Session.Abandon()
                Session.Clear()
                Response.Redirect("Login.aspx")
            End If
        End If

    End Sub

    Private Sub SearchCrew()

        htParameters.Clear()

        If ddlCrewName.SelectedItem.Text = "[-SELECT ALL-]" Then
            htParameters.Add("Mode", 2)
            htParameters.Add("Keyword", "")
        Else
            htParameters.Add("Mode", 1)
            htParameters.Add("Keyword", ddlCrewName.SelectedValue)
        End If
        gvCrew.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewPaySel")
        gvCrew.DataBind()
        htParameters.Clear()

        MultiView1.SetActiveView(vCrew)

        ViewState("Search1") = gvCrew.DataSource

        hdnView.Value = "Search1"
    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick

        SearchCrew()

    End Sub

    Private Sub LoadDefaults()

        Dim year1 = Year(Now) - 1
        For b = year1 To Year(Now)
            ddlYear.Items.Add(New ListItem(b))
        Next

        ddlCrewName.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT CrewNo, LastName + ',' + FirstName + ' ' + MiddleName as FullName FROM CrewInfo WHERE CrewStatus='Onboard' ORDER BY FullName")
        ddlCrewName.DataTextField = "FullName"
        ddlCrewName.DataValueField = "CrewNo"
        ddlCrewName.DataBind()
        ddlCrewName.Items.Insert(0, New ListItem("[-SELECT ALL-]", String.Empty))

    End Sub

    Private Sub PopulateCrewList()

        htParameters.Add("ID", "")
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        gvPaySlip.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "PayslipSel")
        gvPaySlip.DataBind()

        htParameters.Clear()

        ViewState("Pay") = gvCrew.DataSource

        hdnView.Value = "Pay"
    End Sub

    Protected Sub gvCrew_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCrew.RowCommand
        If e.CommandName = "View" Then

            '   Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim index = e.CommandArgument

            Try
                ViewRecord(index)

                PopulateCrewList()

                MultiView1.ActiveViewIndex = 1

                lblCrewName2.Visible = False
                ddlCrewName.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""

        htParameters.Add("Mode", 10)
        htParameters.Add("CrewNo", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try

                hdnID.Value = row("ID").ToString
                hdnCrewNo.Value = row("CrewNo").ToString
                hdnRank.Value = row("RankCode").ToString
                hdnVesselCode.Value = row("VesselCode").ToString

                lblCrewName.Text = row("FullName").ToString
                lblRank.Text = row("RankDescription").ToString

                ddlAllottee.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT AllotteeCode, CASE WHEN FirstName IS NULL AND MiddleName IS NULL THEN LastName WHEN FirstName IS NULL THEN LastName ELSE FirstName + ' ' + MiddleName + ' ' + LastName END as AllotteeName FROM Family WHERE CrewNo='" & hdnCrewNo.Value & "' ORDER BY AllotteeName")
                ddlAllottee.DataTextField = "AllotteeName"
                ddlAllottee.DataValueField = "AllotteeCode"
                ddlAllottee.DataBind()

            Catch ex As Exception

            End Try
        Next
        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        txtAmosup.Text = 0.00
        txtAllowance.Text = 0.00
        txtHDMF.Text = 0.00
        txtHDMFLoan.Text = 0.00
        txtLoan.Text = 0.00
        txtMisc.Text = 0.00
        txtOthers.Text = 0.00
        txtPanama.Text = 0.00
        txtPhilhealth.Text = 0.00
        txtPLoan.Text = 0.00
        txtRate.Text = 0.00
        txtSSS.Text = 0.00
        txtTraining.Text = 0.00

        txtRemitDate.Text = String.Empty

    End Sub

    Private Sub btnAllot_Click(sender As Object, e As EventArgs) Handles btnAllot.Click

        hdnMode.Value = 0
        clearFields()

        lblAllotteeName.Text = ddlAllottee.SelectedItem.Text
        lblAllotteeCode.Text = ddlAllottee.SelectedValue
        lblAllottment.Text = MainClass.Library.Command.ExecScalar("Select CHAR(36) + CONVERT(varchar, CAST(Allotment AS money), 1) AS Allotment from Family WHERE AllotteeCode='" & ddlAllottee.SelectedValue & "'")

        pAllottments.Visible = True

        lblCrewName2.Visible = False
        ddlCrewName.Visible = False
        btnGo1.Visible = False

    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        With htParameters
            .Add("Mode", hdnMode.Value)
            .Add("Allotment", MainClass.Library.Command.ExecScalar("Select CONVERT(varchar, CAST(Allotment AS money), 1) AS Allotment from Family WHERE AllotteeCode='" & ddlAllottee.SelectedValue & "'"))
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("AllotteeCode", ddlAllottee.SelectedValue)
            .Add("Pass", "a")
            .Add("RankCode", hdnRank.Value)
            .Add("VesselCode", hdnVesselCode.Value)
            .Add("PayrollDate", ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue)
            .Add("RemitDate", Request.Form("ctl00$ContentPlaceHolder1$txtRemitDate"))
            '.Add("TotalIncome", ddlFlag.SelectedValue)
            .Add("Allowance", txtAllowance.Text)
            .Add("DollarRate", txtRate.Text)
            .Add("HDMF", txtHDMF.Text)
            .Add("HDMFLoan", txtHDMFLoan.Text)
            .Add("SSS", txtSSS.Text)
            .Add("AMOSUP", txtAmosup.Text)
            .Add("PhilHealth", txtPhilhealth.Text)
            .Add("Loan", txtLoan.Text)
            .Add("PLoan", txtPLoan.Text)
            .Add("Panama", txtPanama.Text)
            .Add("Training", txtTraining.Text)
            .Add("Others", txtOthers.Text)
            .Add("Misc", txtMisc.Text)
            '.Add("TotalDeduc", txtGRT.Text)
            '.Add("NetPay", txtEngineType.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "PayslipMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Payroll.aspx")
        htParameters.Add("ActionTaken", "Add Payroll")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()


        clearFields()

        MultiView1.SetActiveView(vActionNotification)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ddlCrewName.SelectedValue = String.Empty

        SearchCrew()

        pAllottments.Visible = False

        MultiView1.SetActiveView(vCrew)
        lblCrewName2.Visible = False
        ddlCrewName.Visible = False
        btnGo1.Visible = False

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        ViewRecord(hdnCrewNo.Value)

        PopulateCrewList()

        pAllottments.Visible = False

        MultiView1.ActiveViewIndex = 1
        lblCrewName2.Visible = False
        ddlCrewName.Visible = False
        btnGo1.Visible = False

    End Sub

    Protected Sub gvPaySlip_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPaySlip.RowCommand
        Try
            Dim gvPaySlip = CType(sender, GridView)
            If e.CommandName = "ViewPaySlip" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                Dim PaySlipID As HiddenField = DirectCast(gvPaySlip.Rows(index).FindControl("hdnPaySlipID"), HiddenField)
                ' Dim row As GridViewRow = DirectCast(gvPaySlip.Rows(index), GridViewRow)
                'Dim CrewNo As HiddenField = DirectCast(gvPaySlip.Rows(index).FindControl("hdnCrewNo"), HiddenField)

                htParameters.Add("ID", PaySlipID.Value)
                htParameters.Add("CrewNo", hdnCrewNo.Value)

                dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "PayslipSel")
                '  ReportViewer1.ServerReport.DisplayName = decEmpNo & "_Contract"

                Dim datasource As New ReportDataSource("PaySel", dt)

                rvSlip.LocalReport.DataSources.Clear()
                rvSlip.LocalReport.DataSources.Add(datasource)
                htParameters.Clear()


                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openPay();", True)


            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvCrew_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCrew.PageIndexChanging

        gvCrew.DataSource = ViewState(hdnView.Value)

        gvCrew.PageIndex = e.NewPageIndex
        gvCrew.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvPaySlip_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPaySlip.PageIndexChanging

        gvPaySlip.DataSource = ViewState(hdnView.Value)

        gvPaySlip.PageIndex = e.NewPageIndex
        gvPaySlip.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvCrew_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrew.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrew.DataSource = ViewState(hdnView.Value)
            gvCrew.DataBind()
        End If

    End Sub

    Protected Sub gvPaySlip_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvPaySlip.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvPaySlip.DataSource = ViewState(hdnView.Value)
            gvPaySlip.DataBind()
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