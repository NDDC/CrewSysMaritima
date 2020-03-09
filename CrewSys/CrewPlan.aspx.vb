Public Class CrewPlan
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Dim ab As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            GridBind()

            LoadDefaults()

        End If

        Page.Title = "Crew Plan"

    End Sub

    Private Sub Page_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        'If Session("Access") <> "AD" Then
        '    If Session("Access") <> "CW" Then
        '        Session.RemoveAll()
        '        Session.Abandon()
        '        Session.Clear()
        '        Response.Redirect("Login.aspx")
        '    End If
        'End If

    End Sub

    Private Sub LoadDefaults()
        htParameters.Clear()
        htParameters.Add("Mode", 1)
        htParameters.Add("VesselName", hdnVesselName.Value)
        htParameters.Add("Rank", hdnRank.Value)

        ddlCrew.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewPlanSel")
        ddlCrew.DataTextField = "FullName"
        ddlCrew.DataValueField = "CrewNo"
        ddlCrew.DataBind()
        ddlCrew.Items.Insert(0, New ListItem(" ", String.Empty))

        htParameters.Clear()
    End Sub

    Private Sub GridBind()

        txtWeeks.Text = 2

        htParameters.Add("Mode", 2)
        htParameters.Add("Weeks", txtWeeks.Text)
        gvVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsCrew")
        gvVessel.DataBind()
        htParameters.Clear()
        MultiView1.SetActiveView(vVessels)

        ViewState("Search1") = gvVessel.DataSource

        hdnView.Value = "Search1"
    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        If txtWeeks.Text = "" Or txtWeeks.Text < 0 Then

            GridBind()
            txtWeeks.Text = 2
        Else

            htParameters.Add("Mode", 2)
            htParameters.Add("Weeks", txtWeeks.Text)
            gvVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsCrew")
            gvVessel.DataBind()
            htParameters.Clear()
            MultiView1.SetActiveView(vVessels)

        End If

    End Sub

    Public Function SetNavigation(ByVal Code As String) As String
        Dim result As String = ""
        Dim PageToTransfer As String = ""
        Dim URLEncoded As String = ""


        PageToTransfer = "CrewProfile.aspx?x="

        URLEncoded = System.Web.HttpUtility.UrlEncode(MainClass.Library.EncDec.Encrypt(Code))
        result = PageToTransfer & URLEncoded
        Return result

    End Function

    Protected Sub gvVessel_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvVessel.RowCommand
        If e.CommandName = "View" Then

            ab = e.CommandArgument
            lblVesselName.Text = ab
            Try
                'ViewRecord(ab)

                htParameters.Add("VesselName", ab)
                htParameters.Add("Weeks", txtWeeks.Text)
                htParameters.Add("Mode", 1)
                gvCrewSignoff.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SchedulerSel")
                gvCrewSignoff.DataBind()

                htParameters.Clear()

                MultiView1.SetActiveView(vViewCrewList)

                lblWeeks.Visible = False
                txtWeeks.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    'Protected Sub gvCrewSignoff_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCrewSignoff.RowCommand
    '    If e.CommandName = "View" Then

    '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

    '        Try
    '            ViewRecord(index)

    '            mdpPlan.Show()


    '            lblWeeks.Visible = False
    '            txtWeeks.Visible = False
    '            btnGo1.Visible = False
    '            hdnView.Value = "Search1"
    '        Catch ex As Exception
    '            lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
    '            MultiView1.SetActiveView(vActionNotification)
    '        End Try

    '    End If

    'End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        ' ddlCrew.Items.Clear()

        Dim result As String = ""

        htParameters.Add("ID", Code)
        htParameters.Add("Weeks", txtWeeks.Text)
        htParameters.Add("Mode", 2)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "SchedulerSel")

        For Each row As DataRow In dt.Rows
            Try
                hdnVesselName.Value = row("VesselName").ToString
                hdnVesselCode.Value = row("VesselCode").ToString
                hdnRank.Value = row("RankCode").ToString
                hdnRankSort.Value = row("RankSortCode").ToString
                hdnCrewNo.Value = row("CrewNo").ToString
                hdnSignOnOff.Value = row("SignOff").ToString

                If Not hdnRank.Value Is Nothing Then
                    htParameters.Clear()
                    htParameters.Add("Mode", 2)
                    htParameters.Add("VesselName", hdnVesselName.Value)
                    htParameters.Add("Rank", hdnRankSort.Value)

                    ddlCrew.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewPlanSel")
                    ddlCrew.DataTextField = "FullName"
                    ddlCrew.DataValueField = "CrewNo"
                    ddlCrew.DataBind()
                End If

                If row("Onsigner").ToString.Length > 0 Then
                    ddlCrew.Items.Insert(0, New ListItem(row("OnsignerName").ToString, row("Onsigner").ToString))
                    ddlCrew.SelectedValue = row("Onsigner").ToString
                    hdnCrew.Value = row("Onsigner").ToString
                End If
                txtRemarks.Text = row("CrewRemarks").ToString

                If Not row("OnsignerName") Is Nothing Then
                    lbAddUpdate.Text = "Update Crew Plan"
                Else
                    lbAddUpdate.Text = "Save New Onsigner"
                End If
            Catch ex As Exception
            End Try
        Next

        htParameters.Clear()

        Return result
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        lblWeeks.Visible = True
        txtWeeks.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        Response.Redirect("CrewPlan.aspx")

    End Sub

    Private Sub lbAddUpdate_Click(sender As Object, e As EventArgs) Handles lbAddUpdate.Click

        Try
            With htParameters
                .Add("Mode", 1)
                .Add("Onsigner", ddlCrew.SelectedValue)
                .Add("CrewRemarks", txtRemarks.Text)
                .Add("CrewNo", hdnCrewNo.Value)
                .Add("VesselCode", hdnVesselCode.Value)
                .Add("Queue", "NO")
            End With
            MainClass.Library.Command.Execute(htParameters, "SchedulerMod")

            htParameters.Clear()

            MainClass.Library.Command.Execute("UPDATE CrewInfo SET Queue='N', CrewStatus='Lined-up' WHERE CrewNo='" & ddlCrew.SelectedValue & "'")

            If ddlCrew.SelectedValue <> hdnCrew.Value Then

                MainClass.Library.Command.Execute("UPDATE CrewInfo SET Queue='Y' WHERE CrewNo='" & hdnCrew.Value & "'")

            End If


            hdnContract.Value = MainClass.Library.Command.ExecScalar("Select ContractDuration from CrewInfo where CrewNo='" & ddlCrew.SelectedValue & "'")

            'With htParameters
            '    .Add("Mode", 2)
            '    .Add("SignOn", hdnSignOnOff.Value)
            '    .Add("ContractDuration", hdnContract.Value)
            '    .Add("CrewNo", ddlCrew.SelectedValue)
            '    .Add("VesselCode", hdnVesselCode.Value)
            'End With

            'MainClass.Library.Command.Execute(htParameters, "SchedulerMod")


            'If ddlCrew.SelectedValue <> hdnCrew.Value Then
            '    With htParameters
            '        .Add("Mode", 3)
            '        .Add("CrewNo", hdnCrew.Value)
            '    End With
            '    MainClass.Library.Command.Execute(htParameters, "SchedulerMod")
            'End If[dbo].[AuditTrail]

            htParameters.Clear()

            htParameters.Add("UserName", Session("UserName"))
            htParameters.Add("ModuleAccess", Session("Access"))
            htParameters.Add("Mode", 1)
            htParameters.Add("PageAccess", "CrewPlan.aspx")
            htParameters.Add("ActionTaken", "Update Crew Planning")
            MainClass.Library.Command.Execute(htParameters, "AuditMod")
            htParameters.Clear()

            htParameters.Add("VesselName", hdnVesselName.Value)
            htParameters.Add("Weeks", txtWeeks.Text)
            htParameters.Add("Mode", 1)
            gvCrewSignoff.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SchedulerSel")
            gvCrewSignoff.DataBind()

        Catch ex As Exception

        End Try
        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewModal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewModal').hide();", True)

    End Sub

    Protected Sub gvVessel_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvVessel.PageIndexChanging

        gvVessel.DataSource = ViewState(hdnView.Value)

        gvVessel.PageIndex = e.NewPageIndex
        gvVessel.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvCrewSignoff_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCrewSignoff.PageIndexChanging

        htParameters.Add("VesselName", lblVesselName.Text)
        htParameters.Add("Weeks", txtWeeks.Text)
        htParameters.Add("Mode", 1)
        gvCrewSignoff.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SchedulerSel")

        gvCrewSignoff.PageIndex = e.NewPageIndex
        gvCrewSignoff.DataBind()
        htParameters.Clear()

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

    Protected Sub gvCrewSignoff_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrewSignoff.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrewSignoff.DataSource = ViewState(hdnView.Value)
            gvCrewSignoff.DataBind()
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

    Protected Sub lbRankDescription_Click(sender As Object, e As EventArgs)
        Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
        Dim row As GridViewRow = gvCrewSignoff.Rows(rowIndex)

        ViewRecord(TryCast(row.FindControl("lbRankDescription"), LinkButton).CommandArgument)
        '  lblVesselName.Text = TryCast(row.FindControl("lbVesselName"), LinkButton).Text

        lblWeeks.Visible = False
        txtWeeks.Visible = False
        btnGo1.Visible = False
        hdnView.Value = "Search1"

        ViewState(hdnView.Value) = gvCrewSignoff.DataSource

        ' ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalC();", True)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalC();", True)

        htParameters.Clear()
    End Sub

End Class