Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserName") IsNot Nothing Then
            'Crewing
            'If Session("Access") = "CW" Then
            '    Response.Redirect("SearchCrew.aspx")
            '    'Recruitment
            'ElseIf Session("Access") = "RM" Then
            '    Response.Redirect("CrewApplication.aspx")
            '    'Accounting
            'ElseIf Session("Access") = "AC" Then
            '    Response.Redirect("Payroll.aspx")
            'Principal
            If Session("Access") = "P" Then
                Response.Redirect("Alerts.aspx")
                'Admin
            Else
                Response.Redirect("SearchCrew.aspx")
            End If
        End If

    End Sub

    Private Sub Login_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not Page.IsPostBack Then
            'BindAgencies()
            txtLoginEmail.Text = ""
        End If
    End Sub

    'Private Sub BindAgencies()

    '    ddlAgencies.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT AgencyCode,AgencyName FROM Agencies")
    '    ddlAgencies.DataTextField = "AgencyName"
    '    ddlAgencies.DataValueField = "AgencyCode"
    '    ddlAgencies.DataBind()

    'End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dtCrew As DataTable
        Dim htParameters As New Hashtable

        htParameters.Add("UserName", txtLoginEmail.Text)
        htParameters.Add("Password", txtLoginPassword.Text)
        dtCrew = MainClass.Library.Adapter.GetRecordSet(htParameters, "LoginSel")
        If dtCrew.Rows.Count > 0 Then
            For Each row As DataRow In dtCrew.Rows

                'If txtUserName.Text = row("EmpNo").ToString And txtPassword.Text = row("Password").ToString Then
                ' pLogin.Visible = False
                '  pIN.Visible = True
                '  lblName.Text = row("FName").ToString & " " & row("LName").ToString
                Session("Name") = row("FirstName").ToString & " " & row("LastName").ToString
                Session("UserName") = row("UserName").ToString
                Session("Photo") = row("Photo").ToString
                Session("Access") = row("ModuleAccess").ToString
                Dim a = row("PrincipalCode").ToString
                If a <> "" Then
                    Session("PCode") = a
                End If

                htParameters.Clear()

                htParameters.Add("UserName", txtLoginEmail.Text)
                htParameters.Add("ModuleAccess", Session("Access"))
                htParameters.Add("Mode", 1)
                htParameters.Add("PageAccess", "Login.aspx")
                htParameters.Add("ActionTaken", "Login")
                MainClass.Library.Command.Execute(htParameters, "AuditMod")

                htParameters.Clear()

                'Crewing
                'If Session("Access") = "CW" Then
                '    Response.Redirect("SearchCrew.aspx")
                '    'Recruitment
                'ElseIf Session("Access") = "RM" Then
                '    Response.Redirect("CrewApplication.aspx")
                '    'Accounting
                'ElseIf Session("Access") = "AC" Then
                '    Response.Redirect("Payroll.aspx")
                'Principal
                If Session("Access") = "P" Then
                    Response.Redirect("Alerts.aspx")
                    'Admin
                Else
                    Response.Redirect("SearchCrew.aspx")
                End If

                'If row("UserType") <> "Admin" Then
                '    ' pAdmin.Visible = False
                'Else
                '    '  pAdmin.Visible = True
                '    Session("IsAdmin") = True
                'End If
                'If Session("UserType") <> "Admin" Then
                '    Response.Redirect("Dashboard.aspx")
                '    '  Exit Sub
                'Else
                '    Response.Redirect("Dashboard.aspx")
                'End If
                ' End If
            Next
        Else

            '   mpeAlert.Show()

        End If
    End Sub

    'Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
    '    Save()
    'End Sub

    'Private Sub Save()
    '    Dim IsError As Boolean = False
    '    Dim htParameters As New Hashtable

    '    htParameters.Add("Mode", 0)
    '    htParameters.Add("UserName", txtEmailAdd.Text)
    '    htParameters.Add("FirstName", txtFirstName.Text)
    '    htParameters.Add("MiddleName", txtMiddleName.Text)
    '    htParameters.Add("LastName", txtLastName.Text)
    '    htParameters.Add("Active", True)
    '    'htParameters.Add("AgencyCode", ddlAgencies.SelectedValue)
    '    htParameters.Add("Password", txtPasswordConfirm.Text)

    '    If txtPasswordS.Text <> txtPasswordConfirm.Text Then
    '        pError.Visible = True
    '        lblErrorMessage.Text = "Password do not matcha!"
    '        IsError = True
    '    End If


    '    If IsError = False Then

    '        MainClass.Library.Command.Execute(htParameters, "UsersMod")

    '    End If
    'End Sub

End Class