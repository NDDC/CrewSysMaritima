Imports System.Drawing

Public Class Alerts
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Dim ab As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            GridBind()

        End If

        Page.Title = "Alerts"

    End Sub

    Private Sub Page_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("Login.aspx")
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

    Private Sub GridBind()

        If Session("Access") = "P" Then

            htParameters.Add("Mode", 2)
            htParameters.Add("PrincipalCode", Session("PCode"))
            gvDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsDocs")
            gvDocs.DataBind()
            htParameters.Clear()

            ViewState("Docs1") = gvDocs.DataSource

            htParameters.Add("Mode", 3)
            htParameters.Add("PrincipalCode", Session("PCode"))
            gvOffSign.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsCrew")
            gvOffSign.DataBind()
            htParameters.Clear()

            ViewState("Crew1") = gvOffSign.DataSource
        Else
            htParameters.Add("Mode", 1)
            gvDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsDocs")
            gvDocs.DataBind()
            htParameters.Clear()

            ViewState("Docs1") = gvDocs.DataSource

            htParameters.Add("Mode", 1)
            gvOffSign.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsCrew")
            gvOffSign.DataBind()
            htParameters.Clear()

            ViewState("Crew1") = gvOffSign.DataSource
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

    'Protected Sub gvDocs_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDocs.RowCommand
    '    If e.CommandName = "View" Then

    '        ab = e.CommandArgument
    '        lblVesselName.Text = ab
    '        'Try
    '        ViewRecordDocs(ab)

    '        gvCrewDocEx.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")
    '        gvCrewDocEx.DataBind()

    '        ViewState("Docs2") = gvCrewDocEx.DataSource

    '        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalD();", True)

    '        htParameters.Clear()
    '        'Catch ex As Exception
    '        '    lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
    '        '    MultiView1.ActiveViewIndex = 3
    '        'End Try

    '    End If

    'End Sub

    Public Function ViewRecordDocs(ByVal Code As String) As String
        Dim result As String = ""

        htParameters.Add("VesselName", Code)
        htParameters.Add("Mode", 2)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")

        For Each row As DataRow In dt.Rows

            hdnVesselName.Value = row("VesselName").ToString
            hdnVesselCode.Value = row("VesselCode").ToString
            hdnCrewNo.Value = row("CrewNo").ToString

            '  ddlDepartment.SelectedValue = row("Department").ToString

        Next

        Return result
    End Function

    'Protected Sub gvOffSign_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvOffSign.RowCommand
    '    If e.CommandName = "View" Then

    '        ab = e.CommandArgument
    '        lblVesselName2.Text = ab
    '        'Try
    '        ViewRecord(ab)

    '        gvCrewSignoff.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")
    '        gvCrewSignoff.DataBind()

    '        ViewState("Crew2") = gvCrewSignoff.DataSource

    '        ' mdpSignoff.Show()
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalC();", True)

    '        htParameters.Clear()
    '        'Catch ex As Exception
    '        '    lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
    '        '    MultiView1.ActiveViewIndex = 3
    '        'End Try

    '    End If

    'End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""

        htParameters.Add("VesselName", Code)
        htParameters.Add("Mode", 1)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")

        For Each row As DataRow In dt.Rows

            hdnVesselName.Value = row("VesselName").ToString
            hdnVesselCode.Value = row("VesselCode").ToString
            hdnCrewNo.Value = row("CrewNo").ToString

            '  ddlDepartment.SelectedValue = row("Department").ToString

        Next

        Return result
    End Function

    Protected Sub gvCrewDocEx_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ExpiryDate As HiddenField = TryCast(e.Row.FindControl("ExpiryDate"), HiddenField)
            Dim aa As Date = ExpiryDate.Value
            Dim a As Date = DateTime.Parse(aa.ToString("MM/dd/yy"))
            Dim b As Date = DateTime.Parse(DateTime.Now.ToString("MM/dd/yy"))
            Dim c As Date = DateTime.Parse(DateTime.Now.AddMonths(2).ToString("MM/dd/yy"))

            If a <= b Then
                ' e.Row.BackColor = Color.Red
                e.Row.ForeColor = Color.Red
            Else
                ' e.Row.BackColor = Color.Yellow
                e.Row.ForeColor = Color.DarkOrange
            End If
        End If

    End Sub

    Protected Sub gvCrewSignoff_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim SignOff As HiddenField = TryCast(e.Row.FindControl("SignOff"), HiddenField)
            Dim aa As Date = SignOff.Value
            Dim a As Date = DateTime.Parse(aa.ToString("MM/dd/yy"))
            Dim b As Date = DateTime.Parse(DateTime.Now.ToString("MM/dd/yy"))

            If a <= b Then
                ' e.Row.BackColor = Color.Red
                e.Row.ForeColor = Color.Red
            Else
                ' e.Row.BackColor = Color.Yellow
                e.Row.ForeColor = Color.DarkOrange
            End If
        End If

    End Sub

    Protected Sub gvCrewDocEx_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrewDocEx.Sorting

        Dim dt = TryCast(ViewState("Docs2"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrewDocEx.DataSource = ViewState("Docs2")
            gvCrewDocEx.DataBind()

            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalD();", True)

            ' mdpDocs.Show()
        End If

    End Sub

    Protected Sub gvDocs_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvDocs.Sorting

        Dim dt = TryCast(ViewState("Docs1"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvDocs.DataSource = ViewState("Docs1")
            gvDocs.DataBind()
        End If

    End Sub

    Protected Sub gvCrewSignoff_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCrewSignoff.Sorting

        Dim dt = TryCast(ViewState("Crew2"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvCrewSignoff.DataSource = ViewState("Crew2")
            gvCrewSignoff.DataBind()

            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalC();", True)

            ' mdpSignoff.Show()
        End If

    End Sub

    Protected Sub gvOffSign_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvOffSign.Sorting

        Dim dt = TryCast(ViewState("Crew1"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvOffSign.DataSource = ViewState("Crew1")
            gvOffSign.DataBind()
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

    Protected Sub lbVesselName2_Click(sender As Object, e As EventArgs)
        Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
        Dim row As GridViewRow = gvOffSign.Rows(rowIndex)

        ViewRecord(TryCast(row.FindControl("lbVesselName2"), LinkButton).Text)
        lblVesselName2.Text = TryCast(row.FindControl("lbVesselName2"), LinkButton).Text
        gvCrewSignoff.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")
        gvCrewSignoff.DataBind()

        ViewState("Crew2") = gvCrewSignoff.DataSource

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalC();", True)

        'ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalC();", True)

        htParameters.Clear()
    End Sub

    Protected Sub lbVesselName_Click(sender As Object, e As EventArgs)
        Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
        Dim row As GridViewRow = gvDocs.Rows(rowIndex)

        ViewRecordDocs(TryCast(row.FindControl("lbVesselName"), LinkButton).Text)
        lblVesselName.Text = TryCast(row.FindControl("lbVesselName"), LinkButton).Text
        gvCrewDocEx.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")
        gvCrewDocEx.DataBind()

        ViewState("Docs2") = gvCrewDocEx.DataSource

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalD();", True)

        htParameters.Clear()
    End Sub
End Class