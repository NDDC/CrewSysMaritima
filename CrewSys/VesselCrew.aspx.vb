Public Class VesselCrew
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LoadDefaults()
            GridBind()

        End If

        Page.Title = "Manage Vessel Crew List"

    End Sub

    Private Sub VesselCrew_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        'If Session("Access") <> "AD" Then
        '    If Session("Access") <> "CW" And Session("Access") <> "P" Then
        '        Session.RemoveAll()
        '        Session.Abandon()
        '        Session.Clear()
        '        Response.Redirect("Login.aspx")
        '    End If
        'End If

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

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

            ddlPrincipal.Visible = False
            lblddlPrincipal.Visible = False
            gvVessel.Visible = False
        Else
            htParameters.Add("Mode", 100)
            htParameters.Add("Keyword", ddlVessel.SelectedValue)
            htParameters.Add("PrincipalCode", ddlPrincipal.SelectedValue)

            gvVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
            gvVessel.DataBind()

            htParameters.Clear()

            MultiView1.SetActiveView(vVessels)

            ViewState("Search1") = gvVessel.DataSource

            gvVesselP.Visible = False
        End If
        hdnView.Value = "Search1"
    End Sub

    Private Sub PopulateCrewList()

        htParameters.Add("Keyword", lblVesselName.Text)
        gvCrewList.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselCrewSel")
        gvCrewList.DataBind()

        htParameters.Clear()
        ViewState("Search2") = gvCrewList.DataSource
        hdnView.Value = "Search2"
    End Sub

    Protected Sub gvVessel_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvVessel.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Try
                ViewRecord(index)

                PopulateCrewList()

                CountCrew()

                MultiView1.ActiveViewIndex = 1

                lblVessel.Visible = False
                ddlVessel.Visible = False
                lblddlPrincipal.Visible = False
                ddlPrincipal.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Protected Sub gvVesselP_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvVesselP.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Try
                ViewRecord(index)

                PopulateCrewList()

                CountCrew()

                MultiView1.ActiveViewIndex = 1

                lblVessel.Visible = False
                ddlVessel.Visible = False
                lblddlPrincipal.Visible = False
                ddlPrincipal.Visible = False
                btnGo1.Visible = False

            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Protected Sub ddlPrincipalCode_TextChanged(sender As Object, e As EventArgs)

        ddlVessel.Items.Clear()
        ddlVessel.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT VesselCode,VesselName FROM Vessels WHERE PrincipalCode='" & ddlPrincipal.SelectedValue & "' and VesselStatus='ACTIVE' ORDER By VesselName")
        ddlVessel.DataTextField = "VesselName"
        ddlVessel.DataValueField = "VesselCode"
        ddlVessel.DataBind()
        ddlVessel.Items.Insert(0, New ListItem("[--All--]", 0))

    End Sub

    Private Sub LoadDefaults()
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

    Private Sub CountCrew()

        lblCrewOnboard.Text = MainClass.Library.Command.ExecScalar("SELECT COUNT(CrewNo) from CrewInfo WHERE VesselCode='" & hdnVesselCode.Value & "' and CrewStatus='Onboard' ")

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewVesselRecord")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("ID").ToString
                hdnVesselCode.Value = row("VesselCode").ToString
                lblVesselName.Text = row("VesselName").ToString

                '  ddlDepartment.SelectedValue = row("Department").ToString

            Catch ex As Exception

            End Try
        Next
        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        lblVessel.Visible = True
        If Session("Access") <> "P" Then
            ddlPrincipal.Visible = True
            lblddlPrincipal.Visible = True
        End If
        ddlVessel.Visible = True
        btnGo1.Visible = True

    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        Response.Redirect("VesselCrew.aspx")

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

    'Protected Sub gvCrewList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCrewList.RowCommand
    '    If e.CommandName = "ViewRankList" Then

    '        Dim index As String = e.CommandArgument
    '        'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '        ' Retrieve the row that contains the button 
    '        ' from the Rows collection.

    '        ' Dim row As GridViewRow = gvAllotment.Rows(index)

    '        'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
    '        Try
    '            htParameters.Clear()
    '            ' ViewRecordList(index)

    '            htParameters.Clear()

    '        Catch ex As Exception
    '            lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
    '            MultiView1.ActiveViewIndex = 3
    '        End Try

    '    End If

    'End Sub

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

    'Protected Sub gvRankList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRankList.PageIndexChanging

    '    With htParameters
    '        .Add("Mode", 1)
    '        .Add("VesselCode", hdnVesselCode.Value)
    '        .Add("RankCode", Index)
    '    End With
    '    gvRankList.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselCrewSel")
    '    gvVessel.PageIndex = e.NewPageIndex
    '    gvVessel.DataBind()
    '    htParameters.Clear()

    'End Sub

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

    Protected Sub gvCrewList_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrewList.Sorting

        Dim dt = TryCast(ViewState(hdnView.Value), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrewList.DataSource = ViewState(hdnView.Value)
            gvCrewList.DataBind()
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