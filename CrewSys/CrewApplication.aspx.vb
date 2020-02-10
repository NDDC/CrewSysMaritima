
Public Class CrewApplication
    Inherits System.Web.UI.Page
    Dim htparameters As New Hashtable
    Dim li As System.Web.UI.HtmlControls.HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            '   If Request.QueryString("x") Is Nothing Then
            txtCrewNo.Text = CreateSequenceNo("CN")
            txtPass.Text = GenerateString() + txtCrewNo.Text
            'End If

            LoadDefaults()
            LoadGrid(CreateSequenceNo("CN"))
            mvApplicants.SetActiveView(vProfile)

        End If

        Page.Title = "Crew Application"

    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("UserName") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Session("Access") <> "AD" Then
            ' If Session("Access") <> "RM" Then
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("Login.aspx")
            '   End If
        End If

    End Sub

    Private Function GenerateString() As String
        Dim Letters As New List(Of Integer)
        'add ASCII codes for numbers
        For i As Integer = 48 To 57
            Letters.Add(i)
        Next
        'lowercase letters
        For i As Integer = 97 To 122
            Letters.Add(i)
        Next
        'uppercase letters
        For i As Integer = 65 To 90
            Letters.Add(i)
        Next
        'select 8 random integers from number of items in Letters
        'then convert those random integers to characters and
        'add each to a string and display in Textbox
        Dim Rnd As New Random
        Dim SB As New System.Text.StringBuilder
        Dim Temp As Integer
        For count As Integer = 1 To 5
            Temp = Rnd.Next(0, Letters.Count)
            SB.Append(Chr(Letters(Temp)))
        Next
        Return SB.ToString

    End Function

    Private Sub LoadGrid(ByVal a As String)
        htparameters.Add("CrewNo", a)
        gdFamList.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "FamilySel")
        gdFamList.DataBind()

        gdSeaService.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "SeaServiceSel")
        gdSeaService.DataBind()

        htparameters.Clear()

        htparameters.Add("Mode", 5)
        htparameters.Add("CrewNo", hdnCrewNo.Value)
        gdDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "CrewDocSel")
        gdDocs.DataBind()
        htparameters.Clear()

    End Sub

    Private Sub LoadDefaults()

        ceBDate.StartDate = DateTime.Now.AddYears(-60)
        ceBDate.EndDate = DateTime.Now.AddYears(-18)

        Dim year1 = Year(Now) - 50
        For a = year1 To Year(Now)
            ddlYear.Items.Add(New ListItem(a))
        Next

        ddlCivilStatus.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='CS' ORDER BY LookUpDescription")
        ddlCivilStatus.DataTextField = "LookupDescription"
        ddlCivilStatus.DataValueField = "LookupCode"
        ddlCivilStatus.DataBind()


        ddlRelationship.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='RS' ORDER BY LookUpDescription")
        ddlRelationship.DataTextField = "LookupDescription"
        ddlRelationship.DataValueField = "LookupCode"
        ddlRelationship.DataBind()


        ddlRank2.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank2.DataTextField = "RankDescription"
        ddlRank2.DataValueField = "RankCode"
        ddlRank2.DataBind()


        ddlRank.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank.DataTextField = "RankDescription"
        ddlRank.DataValueField = "RankCode"
        ddlRank.DataBind()


        ddlDocCode.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents  ORDER BY DocTitle")
        ddlDocCode.DataTextField = "DocTitle"
        ddlDocCode.DataValueField = "DocCode"
        ddlDocCode.DataBind()

        ddlVesselType.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='VT' ORDER BY LookUpDescription")
        ddlVesselType.DataTextField = "LookupDescription"
        ddlVesselType.DataValueField = "LookupCode"
        ddlVesselType.DataBind()

        ddlFlag.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFlag.DataTextField = "Country"
        ddlFlag.DataValueField = "Code"
        ddlFlag.DataBind()

        ddlFlagstate.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFlagstate.DataTextField = "Country"
        ddlFlagstate.DataValueField = "Code"
        ddlFlagstate.DataBind()

        ddlTrainingCenter.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT TrainingCenterCode, TrainingCenter FROM TrainingCenter ORDER BY TrainingCenter")
        ddlTrainingCenter.DataTextField = "TrainingCenter"
        ddlTrainingCenter.DataValueField = "TrainingCenterCode"
        ddlTrainingCenter.DataBind()

    End Sub

    Public Function CreateSequenceNo(ByVal SequenceCode As String) As String
        Dim sBin As String
        Dim NewSequenceNo As String
        Try
            sBin = MainClass.Library.Command.ExecScalar("SELECT MAX(SequenceNo) FROM SequenceNo WHERE SequenceCode='" & SequenceCode & "'")
            NewSequenceNo = Right("00000" & sBin, 4)

            NewSequenceNo = SequenceCode & NewSequenceNo
            Return NewSequenceNo
        Catch ex As Exception
            Dim errmsg As String = ex.ToString
            Return errmsg
        End Try
    End Function

    Private Function UploadPhoto() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "PhotoPic\" + txtLastName.Text & "_" + txtFirstName.Text
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuPhoto.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuPhoto.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    'fuPhoto.SaveAs(savePath & "\" & fuPhoto.FileName)
                    fuPhoto.SaveAs(Server.MapPath(saveDir + "\" + fuPhoto.FileName))
                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "PhotoPic\" & txtLastName.Text & "_" & txtFirstName.Text & "\" & fuPhoto.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPhotoSource.Value = "PhotoPic\" & txtLastName.Text & "_" & txtFirstName.Text & "\" & fuPhoto.FileName

                    CrewImage.ImageUrl = hdnPhotoSource.Value
                    CrewImage.DataBind()
                    lblWarning.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning.Text = "Please Upload only a valid picture format!"
            End If
        Else
            lblWarning.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Function UploadPhotoDoc() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Docs\" + txtLastName.Text & "_" + txtFirstName.Text
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuPath.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuPath.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    'fuPath.SaveAs(savePath & "\" & fuPath.FileName)
                    fuPath.SaveAs(Server.MapPath(saveDir + "\" + fuPath.FileName))
                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Docs\" & txtLastName.Text & "_" & txtFirstName.Text & "\" & fuPath.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPath.Value = "Docs\" & txtLastName.Text & "_" & txtFirstName.Text & "\" & fuPath.FileName
                    lblWarning2.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning2.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning2.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Sub lbUploadPhoto_Click(sender As Object, e As EventArgs) Handles lbUploadPhoto.Click

        Try
            If fuPhoto.HasFile Then
                UploadPhoto()
            End If
        Catch
        End Try

    End Sub

    Private Sub btnNextFam_Click(sender As Object, e As EventArgs) Handles btnNextFam.Click

        If GenderMF.Checked Then
            hdnGender.Value = 0
        Else
            hdnGender.Value = 1
        End If

        'UploadPhoto()

        hdnCrewNo.Value = CreateSequenceNo("CN")

        With htparameters
            .Add("Mode", 10)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("RankCode", ddlRank.SelectedValue)


            .Add("Passwords", txtPass.Text)
            .Add("Photo", hdnPhotoSource.Value)
            .Add("FirstName", txtFirstName.Text)
            .Add("MiddleName", txtMiddleName.Text)
            .Add("LastName", txtLastName.Text)
            .Add("Birthdate", Request.Form("ctl00$ContentPlaceHolder1$txtBirthdate"))
            .Add("Birthplace", txtBirthplace.Text)
            .Add("PrimaryAddress", txtPrimaryAddress.Text)
            .Add("SecondaryAddress", txtSAddress.Text)
            .Add("ContactNos", txtContact.Text)
            .Add("Email", txtEAdd.Text)
            '  .Add("Coordinates", txtCoor.Text)
            .Add("MaleGender", hdnGender.Value)
            .Add("CivilStatus", ddlCivilStatus.SelectedValue)
            .Add("School", txtSchool.Text)
            .Add("Course", txtCourse.Text)
            '    .Add("YearGraduated", ddlYear.SelectedValue)
            .Add("SSSNo", txtSSS.Text)
            .Add("Philhealth", txtPhilHealth.Text)
            .Add("Pagibig", txtPagibig.Text)
            .Add("TIN", txtTIN.Text)
            '.Add("Passport", txtPassport.Text)
            .Add("Src", txtSRC.Text)
            '.Add("Sirb", txtSirb.Text)
            '.Add("LicenseNo", txtLicense.Text)
            '.Add("COP", hdnCOP.Value)

            .Add("CrewStatus", "Applicant")

        End With

        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")

        MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "CN" & "'")
        htparameters.Clear()

        htparameters.Add("UserName", Session("UserName"))
        htparameters.Add("ModuleAccess", Session("Access"))
        htparameters.Add("Mode", 1)
        htparameters.Add("PageAccess", "CrewApplication.aspx")
        htparameters.Add("ActionTaken", "Add Crew")
        MainClass.Library.Command.Execute(htparameters, "AuditMod")
        htparameters.Clear()

        mvApplicants.SetActiveView(vFamily)
        Step1.Attributes.Add("class", "nav-item done")
        Step2.Attributes.Add("class", "nav-item active")
        Step3.Attributes.Add("class", "nav-item")
        Step4.Attributes.Add("class", "nav-item")

        Clearfields()
    End Sub

    Private Sub btnAddAllottee_Click(sender As Object, e As EventArgs) Handles btnAddAllottee.Click

        With htparameters

            .Add("Mode", 0)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("AllotteeCode", CreateSequenceNo("AC"))
            .Add("LastName", txtLFName.Text)
            .Add("FirstName", txtFFName.Text)
            .Add("MiddleName", txtMFName.Text)
            .Add("Primary", txtFPAddress.Text)
            .Add("Secondary", txtFSAddress.Text)
            .Add("Relationship", ddlRelationship.SelectedValue)
            .Add("BankAccount", txtBankAccount.Text)
            .Add("Branch", txtBranch.Text)
            .Add("ZipCode", txtZipCode.Text)
            .Add("ContactNo", txtContactNo.Text)

        End With
        MainClass.Library.Command.Execute(htparameters, "FamilyMod")

        MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "AC" & "'")

        htparameters.Clear()

        htparameters.Add("UserName", Session("UserName"))
        htparameters.Add("ModuleAccess", Session("Access"))
        htparameters.Add("Mode", 1)
        htparameters.Add("PageAccess", "CrewApplication.aspx")
        htparameters.Add("ActionTaken", "Add Family")
        MainClass.Library.Command.Execute(htparameters, "AuditMod")
        htparameters.Clear()


        htparameters.Add("CrewNo", hdnCrewNo.Value)
        ViewState("Fam") = MainClass.Library.Adapter.GetRecordSet(htparameters, "FamilySel")
        gdFamList.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "FamilySel")
        gdFamList.DataBind()
        htparameters.Clear()
        Clearfields()
    End Sub

    Private Sub lbNextSea_Click(sender As Object, e As EventArgs) Handles lbNextSea.Click

        mvApplicants.SetActiveView(vSeaService)
        Step1.Attributes.Add("class", "nav-item done")
        Step2.Attributes.Add("class", "nav-item done")
        Step3.Attributes.Add("class", "nav-item active")
        Step4.Attributes.Add("class", "nav-item")

    End Sub

    Private Sub btnSaveESS_Click(sender As Object, e As EventArgs) Handles btnSaveESS.Click

        With htparameters

            .Add("Mode", 0)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("SeaServiceCode", CreateSequenceNo("SC"))
            .Add("RankCode", ddlRank2.SelectedValue)
            .Add("JoiningPort", txtJoiningPort.Text)
            .Add("EmbarkingPort", txtEmbarkingPort.Text)
            .Add("CallSign", txtCallsign.Text)
            .Add("GRT", txtGRT.Text)
            .Add("EngineType", txtEngineType.Text)
            .Add("VesselType", ddlVesselType.SelectedValue)
            .Add("Flag", ddlFlag.SelectedValue)
            .Add("VesselName", txtExVesselName.Text)
            .Add("ContractDuration", monthDifference(Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate"), Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate")))
            .Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate"))
            .Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate"))

        End With
        MainClass.Library.Command.Execute(htparameters, "SeaServiceMod")

        MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "SC" & "'")
        htparameters.Clear()

        htparameters.Add("UserName", Session("UserName"))
        htparameters.Add("ModuleAccess", Session("Access"))
        htparameters.Add("Mode", 1)
        htparameters.Add("PageAccess", "CrewApplication.aspx")
        htparameters.Add("ActionTaken", "Add Sea Service")
        MainClass.Library.Command.Execute(htparameters, "AuditMod")
        htparameters.Clear()


        htparameters.Add("CrewNo", hdnCrewNo.Value)
        ViewState("Sea") = MainClass.Library.Adapter.GetRecordSet(htparameters, "SeaServiceSel")
        gdSeaService.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "SeaServiceSel")
        gdSeaService.DataBind()
        htparameters.Clear()
        Clearfields()
    End Sub

    Private Sub lbBackFam_Click(sender As Object, e As EventArgs) Handles lbBackFam.Click

        mvApplicants.SetActiveView(vFamily)
        Step1.Attributes.Add("class", "nav-item done")
        Step2.Attributes.Add("class", "nav-item active")
        Step3.Attributes.Add("class", "nav-item")
        Step4.Attributes.Add("class", "nav-item")

    End Sub
    Private Sub lbPrevProfile_Click(sender As Object, e As EventArgs) Handles lbPrevProfile.Click

        mvApplicants.SetActiveView(vProfile)
        Step1.Attributes.Add("class", "nav-item active")
        Step2.Attributes.Add("class", "nav-item")
        Step3.Attributes.Add("class", "nav-item")
        Step4.Attributes.Add("class", "nav-item")

    End Sub

    Private Sub lbNextDocs_Click(sender As Object, e As EventArgs) Handles lbNextDocs.Click

        mvApplicants.SetActiveView(vDocs)
        Step1.Attributes.Add("class", "nav-item done")
        Step2.Attributes.Add("class", "nav-item done")
        Step3.Attributes.Add("class", "nav-item done")
        Step4.Attributes.Add("class", "nav-item active")

    End Sub

    Private Sub btnSaveDoc_Click(sender As Object, e As EventArgs) Handles btnSaveDoc.Click

        'If chkArchive.Checked Then
        '    hdnISArchive.Value = 0
        'Else
        '    hdnISArchive.Value = 1
        'End If

        UploadPhotoDoc()

        With htparameters

            .Add("Mode", 0)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("DocCode", ddlDocCode.SelectedValue)
            .Add("DocNo", txtDocNo.Text)
            .Add("DocTitle", ddlDocCode.SelectedItem.ToString)
            .Add("Flag", ddlFlagstate.SelectedValue)
            .Add("TrainingCenter", ddlTrainingCenter.SelectedValue)
            .Add("DocType", MainClass.Library.Command.ExecScalar("SELECT DocType FROM Documents WHERE DocCode='" & ddlDocCode.SelectedValue & "' "))
            .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDate"))
            If chkNoExpiry.Checked = True Then
                .Add("ExpiryDate", "1900-01-01")
            Else
                .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExDateUpdate"))
            End If
            .Add("IsArchive", 0)
            .Add("Path", hdnPath.Value)
            .Add("Remarks", txtRemarks.Text)

        End With
        MainClass.Library.Command.Execute(htparameters, "CrewDocMod")

        htparameters.Clear()

        htparameters.Add("UserName", Session("UserName"))
        htparameters.Add("ModuleAccess", Session("Access"))
        htparameters.Add("Mode", 1)
        htparameters.Add("PageAccess", "CrewApplication.aspx")
        htparameters.Add("ActionTaken", "Add Crew Docs")
        MainClass.Library.Command.Execute(htparameters, "AuditMod")
        htparameters.Clear()


        ' UPDATECREPROFILE()

        htparameters.Add("Mode", 5)
        htparameters.Add("CrewNo", hdnCrewNo.Value)
        ViewState("Doc") = MainClass.Library.Adapter.GetRecordSet(htparameters, "CrewDocSel")
        gdDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "CrewDocSel")
        gdDocs.DataBind()
        htparameters.Clear()
        Clearfields()
    End Sub


    Private Sub lbDone_Click(sender As Object, e As EventArgs) Handles lbDone.Click

        Response.Redirect("CrewApplication.aspx")

    End Sub

    Private Sub lbBackSea_Click(sender As Object, e As EventArgs) Handles lbBackSea.Click

        mvApplicants.SetActiveView(vSeaService)
        Step1.Attributes.Add("class", "nav-item done")
        Step2.Attributes.Add("class", "nav-item done")
        Step3.Attributes.Add("class", "nav-item active")
        Step4.Attributes.Add("class", "nav-item")

    End Sub

    'Private Sub UPDATECREPROFILE()

    '    With htparameters

    '        .Add("CrewNo", hdnCrewNo.Value)
    '        .Add("DocNo", txtDocNo.Text)
    '        .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDate"))
    '        .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExdate"))

    '    End With

    '    If ddlDocCode.SelectedItem.ToString = "Passport" Then

    '        htparameters.Add("Mode", 50)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Seaman Registration Certificate" Then

    '        htparameters.Add("Mode", 51)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Seafarer's Identification and Record Book" Then

    '        htparameters.Add("Mode", 52)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "License Number" Then

    '        htparameters.Add("Mode", 53)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "NCI/NCII" Then

    '        htparameters.Add("Mode", 54)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Certificate of Proficiency" Then

    '        htparameters.Add("Mode", 55)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Certificate of Competency" Then

    '        htparameters.Add("Mode", 56)
    '        MainClass.Library.Command.Execute(htparameters, "CrewInfoMod")
    '        htparameters.Clear()

    '    End If
    '    htparameters.Clear()
    'End Sub

    Private Sub Clearfields()

        txtPass.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtBirthplace.Text = String.Empty
        txtPrimaryAddress.Text = String.Empty
        txtSAddress.Text = String.Empty
        txtContactNo.Text = String.Empty
        txtEAdd.Text = String.Empty
        txtSchool.Text = String.Empty
        txtCourse.Text = String.Empty
        txtSSS.Text = String.Empty
        txtPhilHealth.Text = String.Empty
        txtPagibig.Text = String.Empty
        txtTIN.Text = String.Empty
        txtBirthdate.Text = String.Empty



        txtLFName.Text = String.Empty
        txtFFName.Text = String.Empty
        txtMFName.Text = String.Empty
        txtFPAddress.Text = String.Empty
        txtFSAddress.Text = String.Empty
        txtBankAccount.Text = String.Empty
        txtBranch.Text = String.Empty
        txtZipCode.Text = String.Empty
        txtContactNo.Text = String.Empty



        txtCallsign.Text = String.Empty
        txtGRT.Text = String.Empty
        txtEngineType.Text = String.Empty
        txtJoiningPort.Text = String.Empty
        txtEmbarkingPort.Text = String.Empty
        txtExVesselName.Text = String.Empty
        txtExStartDate.Text = String.Empty
        txtExEndDate.Text = String.Empty



        txtDocNo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtIDate.Text = String.Empty
        txtExdate.Text = String.Empty

    End Sub

    Public Function monthDifference(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
        Dim t As TimeSpan = endDate - startDate
        Dim difference As Integer = t.Days
        Dim months As Integer = Math.Floor(difference / 30.475)
        Return months

    End Function

    Protected Sub gdDocs_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdDocs.PageIndexChanging

        htparameters.Add("Mode", 5)
        htparameters.Add("CrewNo", hdnCrewNo.Value)
        gdDocs.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "CrewDocSel")

        gdDocs.PageIndex = e.NewPageIndex
        gdDocs.DataBind()
        htparameters.Clear()

    End Sub

    Protected Sub gdFamList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdFamList.PageIndexChanging

        htparameters.Add("CrewNo", hdnCrewNo.Value)
        gdFamList.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "FamilySel")

        gdFamList.PageIndex = e.NewPageIndex
        gdFamList.DataBind()
        htparameters.Clear()

    End Sub

    Protected Sub gdSeaService_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdSeaService.PageIndexChanging

        htparameters.Add("CrewNo", hdnCrewNo.Value)
        gdSeaService.DataSource = MainClass.Library.Adapter.GetRecordSet(htparameters, "SeaServiceSel")

        gdSeaService.PageIndex = e.NewPageIndex
        gdSeaService.DataBind()
        htparameters.Clear()

    End Sub

    Protected Sub txtBirthdate_TextChanged(sender As Object, e As EventArgs)
        ddlYear.Items.Clear()
        Dim aa As Date = txtBirthdate.Text
        Dim b As Integer = aa.Year
        For a = b To Year(Now)
            ddlYear.Items.Add(New ListItem(a))
        Next
    End Sub

    Protected Sub gdFamList_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdFamList.Sorting

        Dim dt = TryCast(ViewState("Fam"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdFamList.DataSource = ViewState("Fam")
            gdFamList.DataBind()
        End If

    End Sub

    Protected Sub gdSeaService_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdSeaService.Sorting

        Dim dt = TryCast(ViewState("Sea"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdSeaService.DataSource = ViewState("Sea")
            gdSeaService.DataBind()
        End If

    End Sub

    Protected Sub gdDocs_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdDocs.Sorting

        Dim dt = TryCast(ViewState("Doc"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdDocs.DataSource = ViewState("Doc")
            gdDocs.DataBind()
        End If

    End Sub

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