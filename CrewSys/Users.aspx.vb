Public Class Users

    Inherits System.Web.UI.Page

    Dim htParameters As New Hashtable
    Dim dt As New DataTable

    Private Sub Users_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            GridBind()

            LoadDefaults()

            MultiView1.SetActiveView(vViewKewords)

            ddlPrincipalCode.Visible = False
            lblPrin.Visible = False

        End If

        Page.Title = "Manage Users"

    End Sub

    Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
        GridBind()
    End Sub

    Private Sub GridBind()

        htParameters.Add("Keyword", txtSearch.Text)
        htParameters.Add("Mode", 1)
        gvUser.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "UserSel")
        gvUser.DataBind()
        htParameters.Clear()
        MultiView1.ActiveViewIndex = 0

    End Sub

    Private Sub LoadDefaults()

        ddlModule.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='MA' ORDER BY LookUpDescription")
        ddlModule.DataTextField = "LookupDescription"
        ddlModule.DataValueField = "LookupCode"
        ddlModule.DataBind()

        ddlPrincipalCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT PrincipalCode,Description FROM Principal ORDER By PrincipalName")
        ddlPrincipalCode.DataTextField = "Description"
        ddlPrincipalCode.DataValueField = "PrincipalCode"
        ddlPrincipalCode.DataBind()

    End Sub

    Protected Sub gvUser_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvUser.RowCommand
        If e.CommandName = "View" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gvAllotment.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            Try
                ViewRecord(index)

                MultiView1.ActiveViewIndex = 1

                lblHead.Text = "Update User Info"
                btnAddUpdateUser.Text = "Update User Info"
                btnAddNew.Visible = False
                txtSearch.Visible = False
                btnGo1.Visible = False
                txtUserName.ReadOnly = True
            Catch ex As Exception
                lblMessage.Text = "there was an error on the record. kindly contact the administrator!"   'ex.ToString
                MultiView1.ActiveViewIndex = 3
            End Try

        End If

    End Sub

    Public Function ViewRecord(ByVal Code As String) As String
        Dim result As String = ""
        MultiView1.ActiveViewIndex = 1

        htParameters.Add("ID", Code)
        htParameters.Add("Mode", 2)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "UserSel")

        hdnMode.Value = 1
        For Each row As DataRow In dt.Rows
            Try
                hdnID.Value = row("ID").ToString
                txtUserName.Text = row("UserName").ToString
                'If row("Photo").ToString.Length > 0 Then
                '    CrewImage.ImageUrl = row("Photo").ToString
                '    CrewImage.DataBind()
                'End If
                txtPassword.Text = row("Password").ToString
                txtFirstName.Text = row("FirstName").ToString
                txtMiddleName.Text = row("MiddleName").ToString
                txtLastName.Text = row("LastName").ToString
                txtEmail.Text = row("EmailAddress").ToString
                ddlModule.SelectedValue = row("ModuleAccess").ToString

            Catch ex As Exception

            End Try
        Next

        htParameters.Clear()
        Return result
    End Function

    Private Sub clearFields()

        hdnMode.Value = 0

        txtPassword.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtEmail.Text = String.Empty
        txtUserName.Text = String.Empty
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        hdnMode.Value = 0
        clearFields()
        btnAddUpdateUser.Text = "Add New User"
        lblHead.Text = "New User"
        MultiView1.ActiveViewIndex = 1

        btnAddNew.Visible = False
        txtSearch.Visible = False
        btnGo1.Visible = False

    End Sub

    Private Sub btnAddUpdateUser_Click(sender As Object, e As EventArgs) Handles btnAddUpdateUser.Click

        With htParameters
            .Add("Mode", hdnMode.Value)
            .Add("ID", hdnID.Value)
            .Add("UserName", txtUserName.Text)
            .Add("Password", txtPassword.Text)
            .Add("FirstName", txtFirstName.Text)
            .Add("MiddleName", txtMiddleName.Text)
            .Add("LastName", txtLastName.Text)
            .Add("EmailAddress", txtEmail.Text)
            .Add("ModuleAccess", ddlModule.SelectedValue)
            If ddlModule.SelectedValue = "P" Then
                .Add("PrincipalCode", ddlPrincipalCode.SelectedValue)
            Else
                .Add("PrincipalCode", "")
            End If
        End With
        MainClass.Library.Command.Execute(htParameters, "UsersMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "Users.aspx")
        htParameters.Add("ActionTaken", "Add/Update users")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        'With htParameters
        '    .Add("Mode", 11)
        '    .Add("UserName", txtUserName.Text)
        '    .Add("ModuleAccess", ddlModule.SelectedValue)
        'End With

        'MainClass.Library.Command.Execute(htParameters, "UsersMod")

        'htParameters.Clear()

        txtUserName.ReadOnly = False

        MultiView1.ActiveViewIndex = 3

    End Sub

    Private Sub lbBack_Click(sender As Object, e As EventArgs) Handles lbBack.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateUser.Text = "Add New User"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

        txtUserName.ReadOnly = False
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click

        GridBind()

        MultiView1.ActiveViewIndex = 0
        btnAddUpdateUser.Text = "Add New User"

        btnAddNew.Visible = True
        txtSearch.Visible = True
        btnGo1.Visible = True

        txtUserName.ReadOnly = False
    End Sub

    Protected Sub gvUser_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvUser.PageIndexChanging

        htParameters.Add("Keyword", txtSearch.Text)
        htParameters.Add("Mode", 1)
        gvUser.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "UserSel")

        gvUser.PageIndex = e.NewPageIndex
        gvUser.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub ddlModule_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlModule.SelectedValue = "P" Then
            ddlPrincipalCode.Visible = True
            lblPrin.Visible = True
        Else
            ddlPrincipalCode.Visible = False
            lblPrin.Visible = False
        End If
    End Sub
End Class