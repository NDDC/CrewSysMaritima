Public Class MasterPage
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserName") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        GetAccess()

        lblProfileName2.Text = Session("Name")

        If Session("Photo").ToString.Length > 0 Then
            ProfileImage.ImageUrl = Session("Photo")
            ProfileImage.DataBind()
            ' ProfileImage2.ImageUrl = Session("Photo")
            ' ProfileImage2.DataBind()
        End If

        GetCurrent()

    End Sub

    Public Sub GetAccess()

        'Docs Coordinator
        If Session("Access") = "DOCO" Or Session("Access") = "ADAS" Or Session("Access") = "RM" Or Session("Access") = "LIAO" Then

            Rec.Attributes.Add("class", "hide")
            Recs.Attributes.Add("class", "hide")
            Recs2.Attributes.Add("class", "hide")
            RecAF.Attributes.Add("class", "hide")
            AccUM.Attributes.Add("class", "hide")
            AccUMs.Attributes.Add("class", "hide")
            Reports.Attributes.Add("class", "hide")
            Reports1.Attributes.Add("class", "hide")
            Reports2.Attributes.Add("class", "hide")
            ReportsR.Attributes.Add("class", "hide")
            Pay.Attributes.Add("class", "hide")
            Pay1.Attributes.Add("class", "hide")
            Pay2.Attributes.Add("class", "hide")
            pPay.Attributes.Add("class", "hide")

            'Accounting
        ElseIf Session("Access") = "AC" Then

            Rec.Attributes.Add("class", "hide")
            Recs.Attributes.Add("class", "hide")
            Recs2.Attributes.Add("class", "hide")
            RecAF.Attributes.Add("class", "hide")
            AccUM.Attributes.Add("class", "hide")
            AccUMs.Attributes.Add("class", "hide")
            Reports.Attributes.Add("class", "hide")
            Reports1.Attributes.Add("class", "hide")
            Reports2.Attributes.Add("class", "hide")
            ReportsR.Attributes.Add("class", "hide")

            'Principal
        ElseIf Session("Access") = "P" Then

            Rec.Attributes.Add("class", "hide")
            Recs.Attributes.Add("class", "hide")
            Recs2.Attributes.Add("class", "hide")
            RecAF.Attributes.Add("class", "hide")
            'AlertAl.Attributes.Add("class", "hide")
            AlertCP.Attributes.Add("class", "hide")
            AlertCPs.Attributes.Add("class", "hide")
            Acc.Attributes.Add("class", "hide")
            Accs.Attributes.Add("class", "hide")
            Accs2.Attributes.Add("class", "hide")
            AccUM.Attributes.Add("class", "hide")
            AccUMs.Attributes.Add("class", "hide")
            AccMP.Attributes.Add("class", "hide")
            AccMPs.Attributes.Add("class", "hide")
            ' VWMV.Attributes.Add("class", "hide")
            ' VWMW.Attributes.Add("class", "hide")
            Reports.Attributes.Add("class", "hide")
            Reports1.Attributes.Add("class", "hide")
            Reports2.Attributes.Add("class", "hide")
            ReportsR.Attributes.Add("class", "hide")
            Pay.Attributes.Add("class", "hide")
            Pay1.Attributes.Add("class", "hide")
            Pay2.Attributes.Add("class", "hide")
            pPay.Attributes.Add("class", "hide")
            Sett.Attributes.Add("class", "hide")
            Setts.Attributes.Add("class", "hide")
            Setts2.Attributes.Add("class", "hide")
            SettDR.Attributes.Add("class", "hide")
            SettDRs.Attributes.Add("class", "hide")
            SettTC.Attributes.Add("class", "hide")
            SettTCs.Attributes.Add("class", "hide")
            SettRa.Attributes.Add("class", "hide")
            SettRas.Attributes.Add("class", "hide")
            SettRea.Attributes.Add("class", "hide")
            SettReas.Attributes.Add("class", "hide")
            SettVC.Attributes.Add("class", "hide")
            SettVC1.Attributes.Add("class", "hide")

        End If

    End Sub

    Public Sub GetCurrent()
        Dim thisURL As String = Me.Page.[GetType]().Name.ToString()
        Select Case thisURL
            Case "crewapplication_aspx"
                Rec.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                RecAF.Attributes.Add("class", "active")
                Exit Select
            'Case "logout_aspx"
            '    Rec.Attributes.Add("class", "active")
            '    RecrNA.Attributes.Add("class", "active")
            '    Exit Select
            'Case "home_aspx"
            '    Rec.Attributes.Add("class", "active")
            '    RecHA.Attributes.Add("class", "active")
            '    Exit Select

            Case "alerts_aspx"
                Alert.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                AlertAl.Attributes.Add("class", "active")
                Exit Select
            Case "vesselcrew_aspx"
                Home.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                HomeVe.Attributes.Add("class", "active")
                Exit Select
            Case "crewplan_aspx"
                Alert.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                AlertCP.Attributes.Add("class", "active")
                Exit Select
            Case "searchcrew_aspx"
                Home.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                HomeCr.Attributes.Add("class", "active")
                Exit Select

            Case "users_aspx"
                Acc.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                AccUM.Attributes.Add("class", "active")
                Exit Select
            Case "documents_aspx"
                Sett.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                SettDR.Attributes.Add("class", "active")
                Exit Select
            Case "trainingcenter_aspx"
                Sett.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                SettTC.Attributes.Add("class", "active")
                Exit Select
            'Case "payroll_aspx"
            '    Sett.Attributes.Add("class", "active")
            '    SettUMMA.Attributes.Add("class", "active")
            '    Exit Select
            Case "positions_aspx"
                Sett.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                SettRa.Attributes.Add("class", "active")
                Exit Select
            Case "signoffreason_aspx"
                Sett.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                SettRea.Attributes.Add("class", "active")
                Exit Select
            Case "wages_aspx"
                VW.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                VWMW.Attributes.Add("class", "active")
                Exit Select
            Case "principals_aspx"
                Acc.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                AccMP.Attributes.Add("class", "active")
                Exit Select
            Case "vessels_aspx"
                VW.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                VWMV.Attributes.Add("class", "active")
                Exit Select
            Case "reports_aspx"
                Reports.Attributes.Add("class", "pcoded-hasmenu active pcoded-trigger")
                ReportsR.Attributes.Add("class", "active")
                Exit Select
        End Select

    End Sub

    Private Sub lblLogout1_Click(sender As Object, e As EventArgs) Handles lblLogout1.Click
        Session.RemoveAll()
        Session.Abandon()
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub

    Private Sub lblProfile2_Click(sender As Object, e As EventArgs) Handles lblProfile2.Click
        Response.Redirect("UserAccount.aspx")
    End Sub

    'Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
    '    Session.RemoveAll()
    '    Session.Abandon()
    '    Session.Clear()
    '    Response.Redirect("Login.aspx")
    'End Sub


End Class