Public Class SearchCrew
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            DropdownLoad()

            LoadPanels()

            ' SearchCrew()

        End If

        Page.Title = "Crew List"

    End Sub

    Private Sub LoadPanels()

        If Session("Access") = "P" Then
            htParameters.Clear()
            htParameters.Add("Mode", 4)
            htParameters.Add("Status", "Onboard")
            htParameters.Add("PrincipalCode", Session("PCode"))
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("Onboard") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbOnboard.Text = dt.Rows.Count

            htParameters.Clear()
            htParameters.Add("Mode", 4)
            htParameters.Add("Status", "Lined-Up")
            htParameters.Add("PrincipalCode", Session("PCode"))
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("Lined-up") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbLineup.Text = dt.Rows.Count

            htParameters.Clear()
            htParameters.Add("Mode", 4)
            htParameters.Add("Status", "On-Vacation")
            htParameters.Add("PrincipalCode", Session("PCode"))
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("On-Vacation") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbOnvacation.Text = dt.Rows.Count

            divAppli.Attributes.Add("class", "hide")
            divOther.Attributes.Add("class", "hide")

        Else
            htParameters.Clear()
            htParameters.Add("Mode", 2)
            htParameters.Add("Status", "Onboard")
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("Onboard") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbOnboard.Text = dt.Rows.Count

            htParameters.Clear()
            htParameters.Add("Mode", 2)
            htParameters.Add("Status", "Lined-Up")
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("Lined-up") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbLineup.Text = dt.Rows.Count

            htParameters.Clear()
            htParameters.Add("Mode", 2)
            htParameters.Add("Status", "On-Vacation")
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("On-Vacation") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbOnvacation.Text = dt.Rows.Count

            htParameters.Clear()
            htParameters.Add("Mode", 2)
            htParameters.Add("Status", "Applicant")
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            Session("Applicant") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
            lbApplicants.Text = dt.Rows.Count

            htParameters.Clear()
            dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel2")
            Session("Others") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel2")
            lbOthers.Text = dt.Rows.Count

        End If

        If Session("Access") = "AD" Then
            gvCrewP.Visible = False
        Else
            gvCrew.Visible = False
        End If
        htParameters.Clear()

        hdnMode.Value = 11
    End Sub

    Private Sub DropdownLoad()

        If Session("Access") = "P" Then
            htParameters.Add("Status", "Active")
            htParameters.Add("PrincipalCode", Session("PCode"))
            htParameters.Add("Mode", 7)
            ddlVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
            ddlVessel.DataTextField = "VesselName"
            ddlVessel.DataValueField = "VesselCode"
            ddlVessel.DataBind()
            ddlVessel.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

            htParameters.Clear()

            ddlStatus.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='CT' and LookUpDescription NOT IN ('Applicant', 'Transferred','Retired','DNR','Pooled') ORDER BY LookUpDescription")
            ddlStatus.DataTextField = "LookupDescription"
            ddlStatus.DataValueField = "LookupDescription"
            ddlStatus.DataBind()
            ddlStatus.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

        Else
            htParameters.Add("KeyWord", String.Empty)
            htParameters.Add("Mode", 4)
            ddlVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
            ddlVessel.DataTextField = "VesselName"
            ddlVessel.DataValueField = "VesselCode"
            ddlVessel.DataBind()
            ddlVessel.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

            htParameters.Clear()

            ddlStatus.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DISTINCT gl.LookUpCode,gl.LookUpDescription FROM GenericLookUp gl INNER JOIN CrewInfo ci ON ci.CrewStatus=gl.LookUpDescription WHERE GenericLookupCode='CT' ORDER BY LookUpDescription")
            ddlStatus.DataTextField = "LookupDescription"
            ddlStatus.DataValueField = "LookupDescription"
            ddlStatus.DataBind()
            ddlStatus.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

        End If

        ddlRank.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT r.RankCode,RankDescription FROM Rank r INNER JOIN CrewINfo CI ON CI.RankCode =r.RankCode  ORDER By RankSortCode")
        ddlRank.DataTextField = "RankDescription"
        ddlRank.DataValueField = "RankCode"
        ddlRank.DataBind()
        ddlRank.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

    End Sub

    Private Sub lbLineup_Click(sender As Object, e As EventArgs) Handles lbLineup.Click
        If Session("Access") = "AD" Then
            gvCrew.DataSource = Session("Lined-up")
            gvCrew.DataBind()
        Else
            gvCrewP.DataSource = Session("Lined-up")
            gvCrewP.DataBind()
        End If
        ddlStatus.SelectedValue = "Lined-up"

        hdnView.Value = "Lined-up"
        lblStatus.Text = hdnView.Value
        lblCount.Text = lbLineup.Text
    End Sub

    Private Sub lbOnboard_Click(sender As Object, e As EventArgs) Handles lbOnboard.Click
        If Session("Access") = "AD" Then
            gvCrew.DataSource = Session("Onboard")
            gvCrew.DataBind()
        Else
            gvCrewP.DataSource = Session("Onboard")
            gvCrewP.DataBind()
        End If

        ddlStatus.SelectedValue = "Onboard"

        hdnView.Value = "Onboard"
        lblStatus.Text = hdnView.Value
        lblCount.Text = lbOnboard.Text
    End Sub

    Private Sub lbOnvacation_Click(sender As Object, e As EventArgs) Handles lbOnvacation.Click
        If Session("Access") = "AD" Then
            gvCrew.DataSource = Session("On-Vacation")
            gvCrew.DataBind()
        Else
            gvCrewP.DataSource = Session("On-Vacation")
            gvCrewP.DataBind()
        End If
        ddlStatus.SelectedValue = "On-Vacation"

        hdnView.Value = "On-Vacation"
        lblStatus.Text = hdnView.Value
        lblCount.Text = lbOnvacation.Text
    End Sub

    Private Sub lbApplicants_Click(sender As Object, e As EventArgs) Handles lbApplicants.Click
        If Session("Access") = "AD" Then
            gvCrew.DataSource = Session("Applicant")
            gvCrew.DataBind()
        Else
            gvCrewP.DataSource = Session("Applicant")
            gvCrewP.DataBind()
        End If
        ddlStatus.SelectedValue = "Applicant"

        hdnView.Value = "Applicant"
        lblStatus.Text = hdnView.Value
        lblCount.Text = lbApplicants.Text
    End Sub

    Private Sub lbOthers_Click(sender As Object, e As EventArgs) Handles lbOthers.Click
        If Session("Access") = "AD" Then
            gvCrew.DataSource = Session("Others")
            gvCrew.DataBind()
        Else
            gvCrewP.DataSource = Session("Others")
            gvCrewP.DataBind()
        End If
        ddlStatus.SelectedValue = ""

        hdnView.Value = "Others"
        lblStatus.Text = hdnView.Value
        lblCount.Text = lbOthers.Text
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

    Private Sub SearchCrew_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        'If Session("Access") <> "AD" Then
        '    If Session("Access") <> "CW" And Session("P") Then
        '        Session.RemoveAll()
        '        Session.Abandon()
        '        Session.Clear()
        '        Response.Redirect("Login.aspx")
        '    End If
        'End If

    End Sub

    Private Sub SearchCrew()

        htParameters.Clear()

        If Session("Access") = "P" Then

            htParameters.Add("Mode", 3)
            htParameters.Add("Vessel", ddlVessel.SelectedValue)
            htParameters.Add("Rank", ddlRank.SelectedValue)
            htParameters.Add("Status", ddlStatus.SelectedValue)
            htParameters.Add("Avail", ddlAvail.SelectedValue)
            htParameters.Add("LastName", txtLastName.Text)
            htParameters.Add("FirstName", txtFirstName.Text)
            htParameters.Add("PrincipalCode", Session("PCode"))

        Else
            If ddlVessel.SelectedValue = String.Empty And ddlRank.SelectedValue = String.Empty And ddlStatus.SelectedValue = String.Empty And ddlAvail.SelectedValue = "" And txtLastName.Text = "" And txtFirstName.Text = "" Then
                htParameters.Add("Mode", 0)
            Else
                htParameters.Add("Mode", 1)

                htParameters.Add("Rank", ddlRank.SelectedValue)
                htParameters.Add("Status", ddlStatus.SelectedValue)
                htParameters.Add("LastName", txtLastName.Text)
                htParameters.Add("FirstName", txtFirstName.Text)
                htParameters.Add("Vessel", ddlVessel.SelectedValue)
                htParameters.Add("Avail", ddlAvail.SelectedValue)
            End If
        End If
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
        'gvCrewP.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
        'gvCrewP.DataBind()

        gvCrew.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
        gvCrew.DataBind()

        htParameters.Clear()

        Session("SearchCrew") = dt

        hdnView.Value = "SearchCrew"

        If ddlStatus.SelectedItem.Text <> "[--Select All--]" Then
            lblStatus.Text = ddlStatus.SelectedItem.Text
        Else
            lblStatus.Text = ""
        End If
        lblCount.Text = dt.Rows.Count

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        SearchCrew()
    End Sub

    Protected Sub gvCrew_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCrew.PageIndexChanging

        gvCrew.DataSource = Session(hdnView.Value)
        gvCrew.PageIndex = e.NewPageIndex
        gvCrew.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvCrewP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCrewP.PageIndexChanging

        gvCrewP.DataSource = Session(hdnView.Value)
        gvCrewP.PageIndex = e.NewPageIndex
        gvCrewP.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvCrew_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrew.Sorting

        Dim dt = TryCast(Session("SearchCrew"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrew.DataSource = Session("SearchCrew")
            gvCrew.DataBind()
        End If

    End Sub

    Protected Sub gvCrewP_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrewP.Sorting

        Dim dt = TryCast(Session("SearchCrew"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrewP.DataSource = Session("SearchCrew")
            gvCrewP.DataBind()
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

    Private Sub gvCrew_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCrew.RowCommand

        If e.CommandName = "DeleteCrew" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            htParameters.Add("ID", index)
            htParameters.Add("CrewNo", MainClass.Library.Command.ExecScalar("Select CrewNo from CrewInfo WHERE ID='" & index & "'"))
            htParameters.Add("Mode", 2)
            MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")

            htParameters.Clear()

            htParameters.Add("UserName", Session("UserName"))
            htParameters.Add("ModuleAccess", Session("Access"))
            htParameters.Add("Mode", 1)
            htParameters.Add("PageAccess", "SearchCrew.aspx")
            htParameters.Add("ActionTaken", "Delete Crew")
            MainClass.Library.Command.Execute(htParameters, "AuditMod")
            htParameters.Clear()

            DropdownLoad()

            LoadPanels()

            SearchCrew()

        End If

    End Sub

    'Private Sub lbGo_Click(sender As Object, e As EventArgs) Handles lbGo.Click
    '    SearchCrew()
    'End Sub
End Class