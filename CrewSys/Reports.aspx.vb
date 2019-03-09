Imports Microsoft.Reporting.WebForms

Public Class Reports
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As DataTable
    Dim params(1) As Microsoft.Reporting.WebForms.ReportParameter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '   ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "anything", "ScriptProcess();", True)

        If Not Page.IsPostBack Then

            ceStartDate.StartDate = DateTime.Now.AddYears(-5)
            ceStartDate.EndDate = DateTime.Now

            ceEndDate.StartDate = DateTime.Now.AddYears(-5)
            ceEndDate.EndDate = DateTime.Now.AddYears(+2)

            BindVessel()

        End If

        Page.Title = "Reports"

    End Sub

    Private Sub Reports_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Session("Access") <> "AD" Then
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("Login.aspx")
        End If

    End Sub

    Private Sub BindVessel()

        htParameters.Add("KeyWord", String.Empty)
        htParameters.Add("Mode", 4)
        ddlVessel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlVessel.DataTextField = "VesselName"
        ddlVessel.DataValueField = "VesselCode"
        ddlVessel.DataBind()
        ddlVessel.Items.Insert(0, New ListItem("[--Select All--]", String.Empty))

        htParameters.Clear()
    End Sub

    Private Sub btnOffSigner_Click(sender As Object, e As EventArgs) Handles btnOffSigner.Click

        htParameters.Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        htParameters.Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        htParameters.Add("Vessel", ddlVessel.SelectedValue)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "OffSignerSel")

        Dim datasource As New ReportDataSource("OffSignerDS", dt)

        rvOffSigners.LocalReport.DataSources.Clear()
        rvOffSigners.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        params(0) = New Microsoft.Reporting.WebForms.ReportParameter("DateFrom", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        params(1) = New Microsoft.Reporting.WebForms.ReportParameter("DateTo", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        rvOffSigners.LocalReport.SetParameters(params)

        MultiView1.SetActiveView(vOffSigner)

    End Sub

    Private Sub btnOnSigner_Click(sender As Object, e As EventArgs) Handles btnOnSigner.Click

        htParameters.Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        htParameters.Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        htParameters.Add("Vessel", ddlVessel.SelectedValue)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "OnSignerSel")

        Dim datasource As New ReportDataSource("OnSignerDS", dt)

        rvOnSigner.LocalReport.DataSources.Clear()
        rvOnSigner.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        params(0) = New Microsoft.Reporting.WebForms.ReportParameter("DateFrom", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        params(1) = New Microsoft.Reporting.WebForms.ReportParameter("DateTo", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        rvOnSigner.LocalReport.SetParameters(params)

        MultiView1.SetActiveView(vOnSigner)

    End Sub

    Private Sub btnLinedUp_Click(sender As Object, e As EventArgs) Handles btnLinedUp.Click

        htParameters.Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        htParameters.Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        htParameters.Add("Vessel", ddlVessel.SelectedValue)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "LinedUpSel")

        Dim datasource As New ReportDataSource("LinedUpDS", dt)

        rvLinedUp.LocalReport.DataSources.Clear()
        rvLinedUp.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        params(0) = New Microsoft.Reporting.WebForms.ReportParameter("DateFrom", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        params(1) = New Microsoft.Reporting.WebForms.ReportParameter("DateTo", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        rvLinedUp.LocalReport.SetParameters(params)

        MultiView1.SetActiveView(vLinedUp)

    End Sub

    Private Sub btnOnVacation_Click(sender As Object, e As EventArgs) Handles btnOnVacation.Click

        htParameters.Add("Vessel", ddlVessel.SelectedValue)
        htParameters.Add("Status", "On-Vacation")
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "StatusSel")

        Dim datasource As New ReportDataSource("StatusDS", dt)

        rvVacation.LocalReport.DataSources.Clear()
        rvVacation.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        MultiView1.SetActiveView(vVacation)

    End Sub

    Private Sub btnOnboard_Click(sender As Object, e As EventArgs) Handles btnOnboard.Click

        htParameters.Add("Vessel", ddlVessel.SelectedValue)
        htParameters.Add("Status", "Onboard")
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "StatusSel")

        Dim datasource As New ReportDataSource("StatusDS", dt)

        rvOnboard.LocalReport.DataSources.Clear()
        rvOnboard.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        MultiView1.SetActiveView(vOnboard)

    End Sub

    Private Sub btnNtbr_Click(sender As Object, e As EventArgs) Handles btnNtbr.Click

        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "StatusNTBRSel")

        Dim datasource As New ReportDataSource("NTBRDS", dt)

        rvNTBR.LocalReport.DataSources.Clear()
        rvNTBR.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        MultiView1.SetActiveView(vNTBR)

    End Sub

    Private Sub btnAge_Click(sender As Object, e As EventArgs) Handles btnAge.Click

        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "StatusAgeSel")

        Dim datasource As New ReportDataSource("AgeDS", dt)

        rvAge.LocalReport.DataSources.Clear()
        rvAge.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        MultiView1.SetActiveView(vAge)

    End Sub

    Private Sub btnExDeocs_Click(sender As Object, e As EventArgs) Handles btnExDeocs.Click

        htParameters.Add("DateFrom", Request.Form("ctl00$ContentPlaceHolder1$txtStartDate"))
        htParameters.Add("DateTo", Request.Form("ctl00$ContentPlaceHolder1$txtEndDate"))
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ExpirationsReportsDocs")

        Dim datasource As New ReportDataSource("ExDocDS", dt)

        rvDocuments.LocalReport.DataSources.Clear()
        rvDocuments.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        MultiView1.SetActiveView(vDocuments)

    End Sub

End Class