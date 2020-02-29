Imports System.Drawing
Imports Microsoft.Reporting.WebForms

Public Class CrewProfile
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As DataTable
    Dim CrewNo, decEmpNo As String
    'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Clearfields()

            CrewNo = Request.QueryString("x")

            decEmpNo = MainClass.Library.EncDec.Decrypt(CrewNo)

            GetCrew(decEmpNo)
            GetAllotte(decEmpNo)
            GetDocs()
            GetSea(decEmpNo)
            GetMed()


            mvProfile.SetActiveView(vProfileInfo)
            mvVesselStat.SetActiveView(vProfileVessel)
            mvProfile2.SetActiveView(vProfile)

            Page.Title = lblRank.Text & ": " & lblFullName.Text

            'lblErrorAllot.Visible = False
            'lblErrAllotE.Visible = False

            hdnCurrent.Value = "1"

        End If

        'Not for Norteam
        'lbAddAllottee2.Visible = False
        'btnEditAllottee2.Visible = False
        'tabpayslip.Attributes.Add("class", "hide")
        'btnAddFam2.Attributes.Add("class", "hide")
        'gdFamList.Visible = False
        'lblErrorAllotE.Visible = False
        'lblErrorAllot.Visible = False

        'For Norteam
        lbAddAllottee.Visible = False
        btnEditAllottee.Visible = False
        btnAddFam.Attributes.Add("class", "hide")
        gvAllot.Visible = False

        Page.Title = lblRank.Text & ": " & lblFullName.Text

        GetCurrentTab(hdnCurrent.Value)

    End Sub

    Protected Sub Page_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        If Not Page.IsPostBack Then

            LoadDefaults()
            'PopulateCalendar()

            If Session("Access") = "P" Then
                lbJoining.Visible = False
                lbSignoff.Visible = False
                gdSeaService.Visible = False
                fuEvalUpdate.Visible = False
                btnUpEval.Visible = False
                btnMedUpdate.Visible = False

                lbChangePic.Visible = False
                lbEditProfile.Visible = False
                lbEditProfileVessel.Visible = False
                lbEditProfile2.Visible = False
                lbAddAllottee.Visible = False
                ' lbAddAllottee2.Visible = False
                btnEditAllottee.Visible = False
                'btnEditAllottee2.Visible = False
                btnSaveESS.Visible = False
                lblPass.Visible = False
                btnShowPassword.Visible = False
                btnUpdateCrewDoc.Visible = False
                btnUpdatePass.Visible = False
                btnCrewDocuUpdate.Visible = False
                btnUpdateSea.Visible = False
                btnDelSea.Visible = False
                ddlSearch.Visible = False
                btnAddHistory.Attributes.Add("Class", "hide")
                lbGo.Visible = False
                'btnGo1.Attributes.Add("Class", "hide")
                btnAddDoc.Attributes.Add("Class", "hide")
                btnAddFam.Attributes.Add("Class", "hide")
                btnAddExSeaservice.Attributes.Add("Class", "hide")
                '                tabcontract.Attributes.Add("Class", "hide")
                tabpayslip.Attributes.Add("Class", "hide")
            ElseIf Session("Access") = "AC" Then
                gdSeaService.Visible = False
                fuEvalUpdate.Visible = False
                btnUpEval.Visible = False
                btnMedUpdate.Visible = False

                lbChangePic.Visible = False
                lbEditProfile.Visible = False
                lbEditProfileVessel.Visible = False
                '  lbEditProfile2.Visible = False
                '    lbAddAllottee.Visible = False
                ' lbAddAllottee2.Visible = False
                '    btnEditAllottee.Visible = False
                'btnEditAllottee2.Visible = False
                btnSaveESS.Visible = False
                lblPass.Visible = False
                btnShowPassword.Visible = False
                btnUpdateCrewDoc.Visible = False
                btnUpdatePass.Visible = False
                btnCrewDocuUpdate.Visible = False
                btnAddHistory.Attributes.Add("Class", "hide")
                btnAddDoc.Attributes.Add("Class", "hide")
                ' btnAddFam.Attributes.Add("Class", "hide")
                btnAddExSeaservice.Attributes.Add("Class", "hide")
                '                tabcontract.Attributes.Add("Class", "hide")
                'tabpayslip.Attributes.Add("Class", "hide")
            ElseIf Session("Access") = "DOCO" Then
                '  gdSeaService.Visible = False
                gvSeaP.Visible = False
                fuEvalUpdate.Visible = False
                btnUpEval.Visible = False
                btnMedUpdate.Visible = False

                lbChangePic.Visible = False
                'lbEditProfile.Visible = False
                'lbEditProfileVessel.Visible = False
                lbEditProfile2.Visible = False
                lbAddAllottee.Visible = False
                ' lbAddAllottee2.Visible = False
                btnEditAllottee.Visible = False
                'btnEditAllottee2.Visible = False
                ' btnSaveESS.Visible = False
                lblPass.Visible = False
                btnShowPassword.Visible = False
                '  btnUpdateCrewDoc.Visible = False
                btnUpdatePass.Visible = False
                '   btnCrewDocuUpdate.Visible = False
                btnAddHistory.Attributes.Add("Class", "hide")
                '  btnAddDoc.Attributes.Add("Class", "hide")
                btnAddFam.Attributes.Add("Class", "hide")
                ' btnAddExSeaservice.Attributes.Add("Class", "hide")
                '                tabcontract.Attributes.Add("Class", "hide")
                tabpayslip.Attributes.Add("Class", "hide")
            ElseIf Session("Access") = "ADAS" Or Session("Access") = "RM" Then
                gdSeaService.Visible = False
                fuEvalUpdate.Visible = False
                btnUpEval.Visible = False
                'btnMedUpdate.Visible = False

                lbChangePic.Visible = False
                lbEditProfile.Visible = False
                lbEditProfileVessel.Visible = False
                lbEditProfile2.Visible = False
                lbAddAllottee.Visible = False
                ' lbAddAllottee2.Visible = False
                btnEditAllottee.Visible = False
                'btnEditAllottee2.Visible = False
                btnSaveESS.Visible = False
                lblPass.Visible = False
                btnShowPassword.Visible = False
                btnUpdateCrewDoc.Visible = False
                btnUpdatePass.Visible = False
                btnCrewDocuUpdate.Visible = False
                'btnAddHistory.Attributes.Add("Class", "hide")
                btnAddDoc.Attributes.Add("Class", "hide")
                btnAddFam.Attributes.Add("Class", "hide")
                btnAddExSeaservice.Attributes.Add("Class", "hide")
                '              tabcontract.Attributes.Add("Class", "hide")
                tabpayslip.Attributes.Add("Class", "hide")
            ElseIf Session("Access") = "LIAO" Then
                gdSeaService.Visible = False
                fuEvalUpdate.Visible = False
                btnUpEval.Visible = False
                btnMedUpdate.Visible = False

                lbChangePic.Visible = False
                '  lbEditProfile.Visible = False
                lbEditProfileVessel.Visible = False
                ' lbEditProfile2.Visible = False
                lbAddAllottee.Visible = False
                ' lbAddAllottee2.Visible = False
                btnEditAllottee.Visible = False
                'btnEditAllottee2.Visible = False
                btnSaveESS.Visible = False
                lblPass.Visible = False
                btnShowPassword.Visible = False
                btnUpdateCrewDoc.Visible = False
                btnUpdatePass.Visible = False
                btnCrewDocuUpdate.Visible = False
                btnAddHistory.Attributes.Add("Class", "hide")
                btnAddDoc.Attributes.Add("Class", "hide")
                btnAddFam.Attributes.Add("Class", "hide")
                btnAddExSeaservice.Attributes.Add("Class", "hide")
                '    tabcontract.Attributes.Add("Class", "hide")
                '   tabpayslip.Attributes.Add("Class", "hide")
            Else
                gvSeaP.Visible = False
            End If

        End If

    End Sub

    Public Sub GetCurrentTab(ByVal thisTab As String)
        ' Dim thisURL As String = Me.Page.[GetType]().Name.ToString()
        Select Case thisTab
            Case "1"
                TabName.Value = "profile"
                'aprofile.Attributes.Add("class", "nav-link active")
                'adocuments.Attributes.Add("class", "nav-link")
                'aallotment.Attributes.Add("class", "nav-link")
                'aseaservice.Attributes.Add("class", "nav-link")
                'acontract.Attributes.Add("class", "nav-link")
                'amedhistory.Attributes.Add("class", "nav-link")

                'profile1.Attributes.Add("class", "tab-pane active")
                'documents.Attributes.Add("class", "tab-pane")
                'allotment.Attributes.Add("class", "tab-pane")
                'seaservice.Attributes.Add("class", "tab-pane")
                'contract.Attributes.Add("class", "tab-pane")
                'medhistory.Attributes.Add("class", "tab-pane")
                Exit Select

            Case "2"
                TabName.Value = "documents"
                'aprofile.Attributes.Add("class", "nav-link")
                'adocuments.Attributes.Add("class", "nav-link active")
                'aallotment.Attributes.Add("class", "nav-link")
                'aseaservice.Attributes.Add("class", "nav-link")
                'acontract.Attributes.Add("class", "nav-link")
                'amedhistory.Attributes.Add("class", "nav-link")

                'profile1.Attributes.Add("class", "tab-pane")
                'documents.Attributes.Add("class", "tab-pane active")
                'allotment.Attributes.Add("class", "tab-pane")
                'seaservice.Attributes.Add("class", "tab-pane")
                'contract.Attributes.Add("class", "tab-pane")
                'medhistory.Attributes.Add("class", "tab-pane")

                'Select Case hdnDocCurrent.Value
                '    Case "flagstate"
                '        tabsdocs.Value = "flagstate"
                '        Exit Select
                '    Case "training"
                '        tabsdocs.Value = "training"
                '        Exit Select
                '    Case "travel"
                '        tabsdocs.Value = "travel"
                'End Select

            Case "3"
                TabName.Value = "allotment"
                'aprofile.Attributes.Add("class", "nav-link")
                'adocuments.Attributes.Add("class", "nav-link")
                'aallotment.Attributes.Add("class", "nav-link active")
                'aseaservice.Attributes.Add("class", "nav-link")
                'acontract.Attributes.Add("class", "nav-link")
                'amedhistory.Attributes.Add("class", "nav-link")

                'profile1.Attributes.Add("class", "tab-pane")
                'documents.Attributes.Add("class", "tab-pane")
                'allotment.Attributes.Add("class", "tab-pane active")
                'seaservice.Attributes.Add("class", "tab-pane")
                'contract.Attributes.Add("class", "tab-pane")
                'medhistory.Attributes.Add("class", "tab-pane")
                Exit Select

            Case "4"
                TabName.Value = "seaservice"
                'aprofile.Attributes.Add("class", "nav-link")
                'adocuments.Attributes.Add("class", "nav-link")
                'aallotment.Attributes.Add("class", "nav-link")
                'aseaservice.Attributes.Add("class", "nav-link active")
                'acontract.Attributes.Add("class", "nav-link")
                'amedhistory.Attributes.Add("class", "nav-link")

                'profile1.Attributes.Add("class", "tab-pane")
                'documents.Attributes.Add("class", "tab-pane")
                'allotment.Attributes.Add("class", "tab-pane")
                'seaservice.Attributes.Add("class", "tab-pane active")
                'contract.Attributes.Add("class", "tab-pane")
                'medhistory.Attributes.Add("class", "tab-pane")
                Exit Select

            Case "5"
                TabName.Value = "payslip"

                'tabpanel1.Attributes.Add("class", "")
                'tabpanel2.Attributes.Add("class", "")
                'tabpanel3.Attributes.Add("class", "")
                'tabpanel4.Attributes.Add("class", "")
                'tabpanel5.Attributes.Add("class", "active")
                'tabpanel6.Attributes.Add("class", "")
                Exit Select

            Case "6"
                TabName.Value = "contract"
                'aprofile.Attributes.Add("class", "nav-link")
                'adocuments.Attributes.Add("class", "nav-link")
                'aallotment.Attributes.Add("class", "nav-link")
                'aseaservice.Attributes.Add("class", "nav-link")
                'acontract.Attributes.Add("class", "nav-link active")
                'amedhistory.Attributes.Add("class", "nav-link")

                'profile1.Attributes.Add("class", "tab-pane")
                'documents.Attributes.Add("class", "tab-pane")
                'allotment.Attributes.Add("class", "tab-pane")
                'seaservice.Attributes.Add("class", "tab-pane")
                'contract.Attributes.Add("class", "tab-pane active")
                'medhistory.Attributes.Add("class", "tab-pane")
                Exit Select

            Case "7"
                TabName.Value = "medhistory"
                'aprofile.Attributes.Add("class", "nav-link")
                'adocuments.Attributes.Add("class", "nav-link")
                'aallotment.Attributes.Add("class", "nav-link")
                'aseaservice.Attributes.Add("class", "nav-link")
                'acontract.Attributes.Add("class", "nav-link")
                'amedhistory.Attributes.Add("class", "nav-link active")

                'profile1.Attributes.Add("class", "tab-pane")
                'documents.Attributes.Add("class", "tab-pane")
                'allotment.Attributes.Add("class", "tab-pane")
                'seaservice.Attributes.Add("class", "tab-pane")
                'contract.Attributes.Add("class", "tab-pane")
                'medhistory.Attributes.Add("class", "tab-pane active")
                Exit Select

        End Select

    End Sub

    'Private Sub PopulateCalendar()

    '    ceBirthdate.StartDate = DateTime.Now.AddYears(-60)
    '    ceBirthdate.EndDate = DateTime.Now.AddYears(-18)

    '    ceExStartDate.StartDate = DateTime.Now.AddYears(-60)
    '    ceExStartDate.EndDate = DateTime.Now

    '    ceExEndDate.StartDate = DateTime.Now.AddYears(-60)
    '    ceExEndDate.EndDate = DateTime.Now.AddYears(+15)

    '    ceIDate.StartDate = DateTime.Now.AddYears(-60)
    '    ceIDate.EndDate = DateTime.Now

    '    ceExdate.StartDate = DateTime.Now.AddYears(-60)
    '    ceExdate.EndDate = DateTime.Now.AddYears(+15)

    '    ceIDateUpdate.StartDate = DateTime.Now.AddYears(-60)
    '    ceIDateUpdate.EndDate = DateTime.Now

    '    ceExDateUpdate.StartDate = DateTime.Now.AddYears(-60)
    '    ceExDateUpdate.EndDate = DateTime.Now.AddYears(+15)

    '    ceDateHired.StartDate = DateTime.Now.AddYears(-60)
    '    ceDateHired.EndDate = DateTime.Now

    '    ceArrival.StartDate = DateTime.Now.AddMonths(-2)
    '    ceArrival.EndDate = DateTime.Now.AddYears(+2)

    '    ceReport.StartDate = DateTime.Now.AddMonths(-2)
    '    ceReport.EndDate = DateTime.Now.AddYears(+2)

    '    ceSignOn.StartDate = DateTime.Now.AddMonths(-2)
    '    ceSignOn.EndDate = DateTime.Now.AddYears(+2)

    '    ceSignOff.StartDate = DateTime.Now.AddMonths(-2)
    '    ceSignOff.EndDate = DateTime.Now.AddYears(+2)

    '    ceAllotDate.StartDate = DateTime.Now.AddYears(-2)
    '    ceAllotDate.EndDate = DateTime.Now.AddYears(+2)

    '    ceAllotDateU.StartDate = DateTime.Now.AddYears(-2)
    '    ceAllotDateU.EndDate = DateTime.Now.AddYears(+2)

    '    ceExStart2.StartDate = DateTime.Now.AddYears(-60)
    '    ceExStart2.EndDate = DateTime.Now

    '    ceExEnd2.StartDate = DateTime.Now.AddYears(-60)
    '    ceExEnd2.EndDate = DateTime.Now.AddYears(+15)

    '    ceMedDate.StartDate = DateTime.Now.AddYears(-5)
    '    ceMedDate.EndDate = DateTime.Now.AddYears(+5)

    '    ceFit.StartDate = DateTime.Now.AddYears(-5)
    '    ceFit.EndDate = DateTime.Now.AddYears(+5)

    '    ceMedDateU.StartDate = DateTime.Now.AddYears(-5)
    '    ceMedDateU.EndDate = DateTime.Now.AddYears(+5)

    '    ceFitU.StartDate = DateTime.Now.AddYears(-5)
    '    ceFitU.EndDate = DateTime.Now.AddYears(+5)
    'End Sub

    Private Sub LoadDefaults()
        'Fill Contract DDL
        'For a = 0 To 12
        '    ddlContract.Items.Add(New ListItem(a, a))
        'Next

        ddlSearch.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT CrewNo, LastName + ', '+ FirstName + ' ' + MiddleName as FullName FROM CrewInfo ORDER By FullName")
        ddlSearch.DataTextField = "FullName"
        ddlSearch.DataValueField = "CrewNo"
        ddlSearch.DataBind()

        ' Dropdown Rank

        ViewState("RankData") = MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank3.DataSource = ViewState("RankData")


        ddlRank3.DataTextField = "RankDescription"
        ddlRank3.DataValueField = "RankCode"
        ddlRank3.DataBind()

        ddlRank2.DataSource = ViewState("RankData") 'MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank2.DataTextField = "RankDescription"
        ddlRank2.DataValueField = "RankCode"
        ddlRank2.DataBind()

        ' Dropdown Profile Rank
        ddlRank.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlRank.DataTextField = "RankDescription"
        ddlRank.DataValueField = "RankCode"
        ddlRank.DataBind()

        ddlMedRank.DataSource = ViewState("RankData") 'MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlMedRank.DataTextField = "RankDescription"
        ddlMedRank.DataValueField = "RankCode"
        ddlMedRank.DataBind()

        ddlMedRankU.DataSource = ViewState("RankData") 'MainClass.Library.Adapter.GetRecordSet("SELECT RankCode,RankDescription FROM Rank ORDER By RankSortCode")
        ddlMedRankU.DataTextField = "RankDescription"
        ddlMedRankU.DataValueField = "RankCode"
        ddlMedRankU.DataBind()


        ViewState("DocList") = MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents ORDER BY DocTitle")
        ddlDocCode.DataSource = ViewState("DocList")
        ddlDocCode.DataTextField = "DocTitle"
        ddlDocCode.DataValueField = "DocCode"
        ddlDocCode.DataBind()

        ddlDocCodeUpdate.DataSource = ViewState("DocList") ' MainClass.Library.Adapter.GetRecordSet("SELECT DocCode,DocTitle FROM Documents ORDER BY DocTitle")
        ddlDocCodeUpdate.DataTextField = "DocTitle"
        ddlDocCodeUpdate.DataValueField = "DocCode"
        ddlDocCodeUpdate.DataBind()

        ViewState("Reason") = MainClass.Library.Adapter.GetRecordSet("SELECT Code,SignOffReason FROM SignOffReason ORDER BY SignOffReason")
        ddlReason.DataSource = ViewState("Reason")
        ddlReason.DataTextField = "SignOffReason"
        ddlReason.DataValueField = "Code"
        ddlReason.DataBind()
        ddlReason.Items.Insert(0, New ListItem("[--Select--]", String.Empty))

        ddlReasonU.DataSource = ViewState("Reason") 'MainClass.Library.Adapter.GetRecordSet("SELECT Code,SignOffReason FROM SignOffReason ORDER BY SignOffReason")
        ddlReasonU.DataTextField = "SignOffReason"
        ddlReasonU.DataValueField = "Code"
        ddlReasonU.DataBind()
        ddlReasonU.Items.Insert(0, New ListItem("[--Select--]", String.Empty))

        ViewState("Relationship") = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='RS' ORDER BY LookUpDescription")
        ddlRelationship.DataSource = ViewState("Relationship")
        ddlRelationship.DataTextField = "LookupDescription"
        ddlRelationship.DataValueField = "LookupCode"
        ddlRelationship.DataBind()

        ddlERelationship.DataSource = ViewState("Relationship") 'MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='RS' ORDER BY LookUpDescription")
        ddlERelationship.DataTextField = "LookupDescription"
        ddlERelationship.DataValueField = "LookupCode"
        ddlERelationship.DataBind()

        ddlCrewStatus.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='CT' and LookUpDescription != 'Applicant' ORDER BY LookUpDescription")
        ddlCrewStatus.DataTextField = "LookupDescription"
        ddlCrewStatus.DataValueField = "LookupDescription"
        ddlCrewStatus.DataBind()

        ddlCivilStatus.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='CS' ORDER BY LookUpDescription")
        ddlCivilStatus.DataTextField = "LookupDescription"
        ddlCivilStatus.DataValueField = "LookupCode"
        ddlCivilStatus.DataBind()

        'ddlVesselType.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='VT' ORDER BY LookUpDescription")
        'ddlVesselType.DataTextField = "LookupDescription"
        'ddlVesselType.DataValueField = "LookupCode"
        'ddlVesselType.DataBind()

        'ddlVesselType2.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT LookUpCode,LookUpDescription FROM GenericLookUp WHERE GenericLookupCode='VT' ORDER BY LookUpDescription")
        'ddlVesselType2.DataTextField = "LookupDescription"
        'ddlVesselType2.DataValueField = "LookupCode"
        'ddlVesselType2.DataBind()

        'ddlFlag.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        'ddlFlag.DataTextField = "Country"
        'ddlFlag.DataValueField = "Code"
        'ddlFlag.DataBind()

        'ddlFlag2.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        'ddlFlag2.DataTextField = "Country"
        'ddlFlag2.DataValueField = "Code"
        'ddlFlag2.DataBind()

        ViewState("Country") = MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFL.DataSource = ViewState("Country")
        ddlFL.DataTextField = "Country"
        ddlFL.DataValueField = "Code"
        ddlFL.DataBind()
        ddlFL.Items.Insert(0, New ListItem("", String.Empty))

        ddlFLs.DataSource = ViewState("Country") 'MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFLs.DataTextField = "Country"
        ddlFLs.DataValueField = "Code"
        ddlFLs.DataBind()

        ddlFlagstate.DataSource = ViewState("Country") 'MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFlagstate.DataTextField = "Country"
        ddlFlagstate.DataValueField = "Code"
        ddlFlagstate.DataBind()

        ddlFlagstateUpdate.DataSource = ViewState("Country") 'MainClass.Library.Adapter.GetRecordSet("SELECT Country,Code FROM Countries ORDER BY Country")
        ddlFlagstateUpdate.DataTextField = "Country"
        ddlFlagstateUpdate.DataValueField = "Code"
        ddlFlagstateUpdate.DataBind()


        ViewState("TrainingCenter") = MainClass.Library.Adapter.GetRecordSet("SELECT TrainingCenterCode, TrainingCenter FROM TrainingCenter ORDER BY TrainingCenter")
        ddlTrainingCenter.DataSource = ViewState("TrainingCenter")
        ddlTrainingCenter.DataTextField = "TrainingCenter"
        ddlTrainingCenter.DataValueField = "TrainingCenterCode"
        ddlTrainingCenter.DataBind()

        ddlTrainingCenterU.DataSource = ViewState("TrainingCenter") 'MainClass.Library.Adapter.GetRecordSet("SELECT TrainingCenterCode, TrainingCenter FROM TrainingCenter ORDER BY TrainingCenter")
        ddlTrainingCenterU.DataTextField = "TrainingCenter"
        ddlTrainingCenterU.DataValueField = "TrainingCenterCode"
        ddlTrainingCenterU.DataBind()

        'btnNew.CssClass = "btn btn-success active"
        'btnOld.CssClass = "btn btn-info"

        'ddlVesselCode.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        'ddlVesselCode.DataTextField = "VesselName"
        'ddlVesselCode.DataValueField = "VesselCode"
        'ddlVesselCode.DataBind()

        htParameters.Add("Mode", 44)
        htParameters.Add("KeyWord", String.Empty)

        ViewState("VesselList") = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlVessels.DataSource = ViewState("VesselList")
        ddlVessels.DataTextField = "VesselName"
        ddlVessels.DataValueField = "VesselCode"
        ddlVessels.DataBind()

        ddlVesselSea.DataSource = ViewState("VesselList")  'MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlVesselSea.DataTextField = "VesselName"
        ddlVesselSea.DataValueField = "VesselCode"
        ddlVesselSea.DataBind()
        ddlVesselSea.Items.Insert(0, New ListItem("[--Select--]", String.Empty))

        ddlVesselSeaUp.DataSource = ViewState("VesselList")  'MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlVesselSeaUp.DataTextField = "VesselName"
        ddlVesselSeaUp.DataValueField = "VesselCode"
        ddlVesselSeaUp.DataBind()
        ddlVesselSeaUp.Items.Insert(0, New ListItem("[--Select--]", String.Empty))

        'htParameters.Clear()

        'htParameters.Add("Mode", 44)
        'htParameters.Add("KeyWord", String.Empty)
        ddlAllotVessels.DataSource = ViewState("VesselList") 'MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlAllotVessels.DataTextField = "VesselName"
        ddlAllotVessels.DataValueField = "VesselCode"
        ddlAllotVessels.DataBind()

        'htParameters.Clear()

        'htParameters.Add("Mode", 44)
        'htParameters.Add("KeyWord", String.Empty)
        ddlAllotVesselU.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlAllotVesselU.DataTextField = "VesselName"
        ddlAllotVesselU.DataValueField = "VesselCode"
        ddlAllotVesselU.DataBind()

        'htParameters.Clear()

        'htParameters.Add("Mode", 44)
        'htParameters.Add("KeyWord", String.Empty)
        ddlMedVessel.DataSource = ViewState("VesselList") 'MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlMedVessel.DataTextField = "VesselName"
        ddlMedVessel.DataValueField = "VesselCode"
        ddlMedVessel.DataBind()

        ddlMedVesselU.DataSource = ViewState("VesselList")  'MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        ddlMedVesselU.DataTextField = "VesselName"
        ddlMedVesselU.DataValueField = "VesselCode"
        ddlMedVesselU.DataBind()

        ddlSignatory.DataSource = MainClass.Library.Adapter.GetRecordSet("SELECT FirstName + ' ' + LastName as Signatory,Designation FROM Users WHERE IsSignatory=1")
        ddlSignatory.DataTextField = "Signatory"
        ddlSignatory.DataValueField = "Designation"
        ddlSignatory.DataBind()

        htParameters.Clear()
    End Sub

    Private Sub GetCrew(ByVal CrewNo As String)

        htParameters.Add("Mode", 10)
        htParameters.Add("CrewNo", CrewNo)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "ViewCrewRecord")


        For Each row As DataRow In dt.Rows
            Try

                hdnPrincipalCode.Value = row("PrincipalCode").ToString
                If Session("Access") = "P" Then
                    If Session("PCode") <> hdnPrincipalCode.Value Then
                        Session.RemoveAll()
                        Session.Abandon()
                        Session.Clear()
                        Response.Redirect("Login.aspx")
                    End If
                End If

                hdnID.Value = row("ID").ToString
                hdnCrewNo.Value = row("CrewNo").ToString
                ddlSearch.SelectedValue = row("CrewNo").ToString
                lblFullName.Text = row("FullName").ToString

                If row("Photo").ToString.Length > 0 Then
                    hdnPhotoSource.Value = row("Photo").ToString
                    CrewImage.ImageUrl = row("Photo").ToString
                    CrewImage.DataBind()
                End If

                lblCrewStatus.Text = row("CrewStatus").ToString
                If row("CrewStatus").ToString = "Applicant" Then
                    ddlCrewStatus.SelectedValue = "Lined-up"
                Else
                    ddlCrewStatus.SelectedValue = row("CrewStatus").ToString
                End If

                lblScale.Text = row("Scale").ToString
                If lblScale.Text <> "" Then
                    ddlScale.SelectedValue = row("Scale").ToString
                End If

                hdnCrewStatus.Value = row("CrewStatus").ToString
                lblContactNo.Text = row("ContactNos").ToString
                txtProfileContactNo.Text = row("ContactNos").ToString
                lblAddress.Text = row("PrimaryAddress").ToString
                txtAddress.Text = row("PrimaryAddress").ToString
                If row("Bdate").ToString <> "01/01/1900" Then
                    lblBirthday.Text = row("Birthdate").ToString
                    txtBirthdate.Text = row("BDate").ToString
                Else
                    lblBirthday.Text = ""
                End If

                If row("SignOn2").ToString <> "01/01/1900" Then
                    lblSignOn.Text = row("SignOn").ToString
                    txtSignOn.Text = row("SignOn2").ToString
                Else
                    lblSignOn.Text = ""
                End If
                If row("SignOff2").ToString <> "01/01/1900" Then
                    lblSignOff.Text = row("SignOff").ToString
                    txtSignOff.Text = row("SignOff2").ToString
                Else
                    lblSignOff.Text = ""
                End If

                If row("VesselCode").ToString <> "" Then
                    lblVessel.Text = row("VesselName").ToString
                    ddlVessels.SelectedValue = row("VesselCode").ToString
                    ddlMedVessel.SelectedValue = row("VesselCode").ToString
                Else
                    lblVessel.Text = "NO ASSIGNED VESSEL"
                End If

                If row("ArrivalDate2").ToString <> "01/01/1900" Then
                    lblArrival.Text = row("ArrivalDate").ToString
                    txtArrival.Text = row("ArrivalDate2").ToString
                Else
                    lblArrival.Text = ""
                End If
                If row("ReportDate2").ToString <> "01/01/1900" Then
                    lblReport.Text = row("ReportDate").ToString
                    txtReport.Text = row("ReportDate2").ToString
                Else
                    lblReport.Text = ""
                End If

                If row("Avail").ToString <> "" Then
                    lblAvail.Text = row("Avail").ToString
                    ddlAvail.SelectedValue = row("Avail").ToString
                End If

                lblAvailRemarks.Text = row("AvailRemarks").ToString
                txtAvailRemarks.Text = row("AvailRemarks").ToString

                If row("ContractDuration").ToString <> "" Then
                    lblContractDuration.Text = row("ContractDuration").ToString
                    ddlContract.SelectedValue = row("ContractDuration").ToString
                    ddlCoe.SelectedValue = row("ContractDuration").ToString
                Else
                    lblContractDuration.Text = 0
                End If
                'ddlVessels.SelectedItem.Text = row("VesselCode").ToString

                If row("RankCode").ToString <> "" Then
                    lblRank.Text = row("RankDescription").ToString
                    ddlRank.SelectedValue = row("RankCode").ToString
                    ddlMedRank.SelectedValue = row("RankCode").ToString
                End If
                lblEmail.Text = row("Email").ToString
                txtEmail.Text = row("Email").ToString
                lblSchool.Text = row("School").ToString
                txtSchool.Text = row("School").ToString
                lblCourse.Text = row("Course").ToString
                txtCourse.Text = row("Course").ToString
                If row("YearGraduated").ToString <> "" Then
                    lblYearGraduated.Text = row("YearGraduated").ToString

                    ddlYear.Items.Clear()
                    Dim aa As Date = txtBirthdate.Text
                    Dim b As Integer = aa.Year
                    For a = b To Year(Now)
                        ddlYear.Items.Add(New ListItem(a))
                    Next

                    ddlYear.SelectedValue = row("YearGraduated").ToString
                Else
                    ddlYear.Items.Clear()
                    Dim year1 = Year(Now) - 50
                    For b = year1 To Year(Now)
                        ddlYear.Items.Add(New ListItem(b))
                    Next
                End If
                If row("DateHired2").ToString <> "01/01/1900" Then
                    lblDateHired.Text = row("DateHired").ToString
                    txtDateHired.Text = row("DateHired2").ToString
                End If
                lblCrewNo.Text = row("CrewNo").ToString
                txtCrewNo.Text = row("CrewNo").ToString
                hdnFName.Value = row("FirstName").ToString
                hdnLName.Value = row("LastName").ToString
                hdnMName.Value = row("MiddleName").ToString
                'hdnPass.Value = row("Password").ToString
                lblPass.Text = row("Password").ToString
                lblBirthplace.Text = row("Birthplace").ToString
                ' lblSAddress.Text = row("SecondaryAddress").ToString
                lblSSS.Text = row("SSSNo").ToString
                lblPhilhealth.Text = row("Philhealth").ToString
                lblPagibig.Text = row("Pagibig").ToString
                lblTIN.Text = row("TIN").ToString
                'lblPassport.Text = row("Passport").ToString
                lblSrc.Text = row("SRC").ToString
                lblSirb.Text = row("Sirb").ToString
                lblLicense.Text = row("LicenseNo").ToString
                lblRemarks.Text = row("Remarks").ToString

                txtFName.Text = row("FirstName").ToString
                txtLName.Text = row("LastName").ToString
                txtMidName.Text = row("MiddleName").ToString
                'txtPass.Text = row("Password").ToString
                hdnIsMale.Value = row("MaleGender").ToString
                txtBirthplace.Text = row("Birthplace").ToString
                '  txtSAddress.Text = row("SecondaryAddress").ToString
                If row("CivilStatus").ToString <> "" Then
                    ddlCivilStatus.SelectedValue = row("CivilStatus").ToString
                    lblCivilStatus.Text = row("CivilStatusDesc").ToString
                End If
                txtSSS.Text = row("SSSNo").ToString
                txtPhilHealth.Text = row("Philhealth").ToString
                txtPagibig.Text = row("Pagibig").ToString
                txtTIN.Text = row("TIN").ToString
                txtCRemarks.Text = row("Remarks").ToString
                txtLicense.Text = row("LicenseNo").ToString
                txtSirb.Text = row("Sirb").ToString
                txtSrc.Text = row("SRC").ToString

                If hdnIsMale.Value = "True" Then
                    lblIsmale.Text = "Male"
                    GenderM.Checked = False
                Else
                    lblIsmale.Text = "Female"
                    GenderM.Checked = True
                End If

                Page.Title = lblRank.Text & ": " & row("FullName").ToString
                htParameters.Clear()

            Catch ex As Exception

            End Try
        Next

        PopulateCrewList(hdnCrewNo.Value)

    End Sub

    Private Sub PopulateCrewList(ByVal CrewNo As String)

        htParameters.Clear()

        htParameters.Add("ID", "")
        htParameters.Add("CrewNo", CrewNo)

        ViewState("Pay") = MainClass.Library.Adapter.GetRecordSet(htParameters, "PayslipSel")

        gvPaySlip.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "PayslipSel")
        gvPaySlip.DataBind()

        htParameters.Clear()

    End Sub

    Private Sub GetSea(ByVal CrewNo As String)
        htParameters.Clear()
        htParameters.Add("CrewNo", CrewNo)
        htParameters.Add("Mode", 1)
        gvSeaRank.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel2")
        gvSeaRank.DataBind()

        htParameters.Clear()
        htParameters.Add("CrewNo", CrewNo)
        htParameters.Add("Mode", 2)
        gvSeaTanker.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel2")
        gvSeaTanker.DataBind()

        htParameters.Clear()
        htParameters.Add("CrewNo", CrewNo)

        ViewState("Sea") = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel")

        gdSeaService.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel")
        gdSeaService.DataBind()

        gvSeaP.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel")
        gvSeaP.DataBind()
        htParameters.Clear()

    End Sub

    Private Sub GetMed()

        htParameters.Add("CrewNo", hdnCrewNo.Value)

        ViewState("MedHistory") = MainClass.Library.Adapter.GetRecordSet(htParameters, "MedSel")

        gvMed.DataSource = ViewState("MedHistory")
        gvMed.DataBind()
        htParameters.Clear()

    End Sub

    Private Sub GetDocs()

        htParameters.Add("Mode", 4)
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        htParameters.Add("IsArchive", 0)

        ViewState("Trainings") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

        gdTraining.DataSource = ViewState("Trainings")            ' MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
        gdTraining.DataBind()
        htParameters.Clear()

        htParameters.Add("Mode", 41)
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        htParameters.Add("IsArchive", 0)

        ViewState("Travels") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

        gdTravel.DataSource = ViewState("Travels")       'MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
        gdTravel.DataBind()
        htParameters.Clear()

        'htParameters.Add("Mode", 42)
        'htParameters.Add("CrewNo", hdnCrewNo.Value)
        'htParameters.Add("IsArchive", 0)

        'ViewState("Medicals") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

        'gdMedical.DataSource = ViewState("Medicals")
        'gdMedical.DataBind()
        'htParameters.Clear()

        htParameters.Add("Mode", 43)
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        htParameters.Add("IsArchive", 0)

        ViewState("Flags") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

        gdFlagstate.DataSource = ViewState("Flags") 'MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
        gdFlagstate.DataBind()
        htParameters.Clear()

        'htParameters.Add("Mode", 44)
        'htParameters.Add("CrewNo", hdnCrewNo.Value)
        'htParameters.Add("IsArchive", 0)

        'ViewState("Certs") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

        'gdCert.DataSource = ViewState("Certs")
        'gdCert.DataBind()
        'htParameters.Clear()

    End Sub

    Private Sub GetAllotte(ByVal CrewNo As String)

        htParameters.Add("CrewNo", CrewNo)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "FamilySel")

        ViewState("Fam") = dt

        gdFamList.DataSource = dt
        gdFamList.DataBind()
        'hdnTotalRemain.Value = 0
        'If dt.Rows.Count > 0 Then

        '    For Each row As DataRow In dt.Rows
        '        Try

        '            hdnTotalRemain.Value = Val(hdnTotalRemain.Value) + Val(row("Allotment"))

        '        Catch ex As Exception

        '        End Try
        '    Next

        'End If
        htParameters.Clear()

        '   GetTotalAllotment(CrewNo)

        htParameters.Add("Mode", 1)
        htParameters.Add("CrewNo", CrewNo)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "AllotSel")

        ViewState("Fam") = dt

        gvAllot.DataSource = dt
        gvAllot.DataBind()

        htParameters.Clear()
    End Sub

    'Private Sub GetTotalAllotment(ByVal CrewNo As String)

    '    htParameters.Add("CrewNo", CrewNo)
    '    dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "WageSel")
    '    hdnTotalAllot.Value = 0
    '    If dt.Rows.Count > 0 Then

    '        For Each row As DataRow In dt.Rows
    '            Try

    '                hdnTotalAllot.Value = Val(row("BasicWage")) + Val(row("OverTimePay")) + Val(row("LeavePay")) + Val(row("WeekEndPay")) + Val(row("SocialBonus")) + Val(row("Allowance"))

    '            Catch ex As Exception

    '            End Try
    '        Next

    '    End If
    '    htParameters.Clear()

    '    hdnTotalAllocation.Value = Val(hdnTotalAllot.Value) - Val(hdnTotalRemain.Value)
    '    lblAllotNote.Text = "Total Allotment remaining for allocation is $" + hdnTotalAllocation.Value + ".00"

    'End Sub

    Public Function CreateSequenceNo(ByVal SequenceCode As String) As String
        Dim sBin As String
        Dim NewSequenceNo As String
        Try
            sBin = MainClass.Library.Command.ExecScalar("SELECT MAX(SequenceNo) FROM SequenceNo WHERE SequenceCode='" & SequenceCode & "'")
            NewSequenceNo = Right("00000" & sBin, 4)
            If SequenceCode = "SS" Then
                NewSequenceNo = SequenceCode & sBin
            Else
                NewSequenceNo = SequenceCode & NewSequenceNo
            End If
            Return NewSequenceNo
        Catch ex As Exception
            Dim errmsg As String = ex.ToString
            Return errmsg
        End Try
    End Function

    Public Function ViewRecord(ByVal Code As String) As String

        Dim result As String = ""
        Dim dt As New DataTable

        'mvAllotment.ActiveViewIndex = 1

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "AlloteeSel")
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                Try
                    ENextKin2.Checked = row("IsNOK").ToString
                    hdnKinNextE.Value = row("IsNOK").ToString
                    hdnAllotteeID.Value = row("ID").ToString
                    hdnAllotteeCode.Value = row("AllotteeCode").ToString
                    txtELFName.Text = row("LastName").ToString
                    txtEFFName.Text = row("FirstName").ToString
                    txtEMFName.Text = row("MiddleName").ToString

                    txtEFPAddress.Text = row("PrimaryAddress").ToString
                    txtEFSAddress.Text = row("SecondaryAddress").ToString
                    If row("Relationship").ToString <> "" Then
                        ddlERelationship.SelectedValue = row("Relationship").ToString
                    End If
                    txtEBankAccount.Text = row("BankAccount").ToString
                    txtEBranch.Text = row("Branch").ToString
                    txtEAllotment.Text = row("Allotment").ToString
                    txtEZipCode.Text = row("ZipCode").ToString
                    txtEContactNo.Text = row("ContactNo").ToString

                Catch ex As Exception

                End Try
            Next

        End If
        htParameters.Clear()
        'hdnTotalAllocation2.Value = 0
        'hdnTotalAllocation2.Value = Val(hdnTotalAllocation.Value) + Val(txtEAllotment.Text)
        'lblAllotEdit.Text = "Total Allotment remaining for allocation is $" + hdnTotalAllocation2.Value + ".00"



        htParameters.Add("Mode", 2)
        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "AllotSel")
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                Try
                    hdnAllotID.Value = row("ID").ToString
                    'hdnAllotteeID.Value = row("ID").ToString
                    hdnAllotDocU.Value = row("AllotPath").ToString
                    txtAllotDateU.Text = row("AllotDate").ToString
                    txtAllotRemarksU.Text = row("Remarks").ToString
                    '  hdnArchAllot.Value = row("Archive").ToString
                    If row("VesselCode").ToString <> "" Then
                        ddlAllotVesselU.SelectedValue = row("VesselCode").ToString
                    End If

                    'If hdnArchAllot.Value = "True" Then
                    '    chkAllotArchiveU.Checked = False
                    'Else
                    chkAllotArchiveU.Checked = True
                    ' End If
                Catch ex As Exception

                End Try
            Next

        End If
        htParameters.Clear()


        Return result
    End Function

    Public Function ViewDocRec(ByVal Code As String) As String

        Dim result As String = ""

        htParameters.Add("Mode", 6)
        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
        If dt.Rows.Count > 0 Then
            Try
                For Each row As DataRow In dt.Rows
                    Try
                        hdnDocID.Value = row("ID").ToString
                        hdnDocPath.Value = row("Path").ToString
                        lblDocTitle.Text = row("DocTitle")
                        'hdnDocTitleUpdate.Value = row("DocTitle")
                        If row("DocTitle") = "Seaman's Book" Then
                            ddlDocCodeUpdate.SelectedValue = MainClass.Library.Command.ExecScalar("SELECT DocCode from Documents WHERE DocTitle='Seaman'+char(39)+'s book'")
                        ElseIf row("DocTitle") = "Seaman's_Book" Then
                            ddlDocCodeUpdate.SelectedValue = MainClass.Library.Command.ExecScalar("SELECT DocCode from Documents WHERE DocTitle='Seaman'+char(39)+'s_book'")
                        Else
                            ddlDocCodeUpdate.SelectedValue = MainClass.Library.Command.ExecScalar("SELECT DocCode from Documents WHERE DocTitle='" & row("DocTitle").ToString & "'")
                        End If
                        Dim a = row("Flag").ToString
                        If a <> "" Then
                            ddlFlagstateUpdate.SelectedValue = row("Flag")
                        End If
                        Dim b = row("TrainingCenter").ToString
                        If b <> "" Then
                            ddlTrainingCenterU.SelectedValue = row("TrainingCenter")
                        End If

                        txtDocNoUpdate.Text = row("DocNo")
                        txtIDateUpdate.Text = row("IssuedDate")

                        If row("ExpiryDate") = "1900-01-01" Then
                            txtExDateUpdate.Text = ""
                            chkNoExpiryU.Checked = True
                        Else
                            txtExDateUpdate.Text = row("ExpiryDate")
                            chkNoExpiryU.Checked = False
                        End If

                        hdnArchiveUpdate.Value = row("IsArchive")
                        txtRemarksUpdate.Text = row("Remarks")

                    Catch ex As Exception

                    End Try

                Next
            Catch ex As Exception
            End Try
        End If

        If hdnArchiveUpdate.Value = "True" Then
            chkArchiveUpdate.Checked = False
        Else
            chkArchiveUpdate.Checked = True
        End If
        htParameters.Clear()
        Return result
    End Function

    Public Function ViewSea(ByVal Code As String) As String

        Dim result As String = ""

        'mvAllotment.ActiveViewIndex = 1

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel3")
        If dt.Rows.Count > 0 Then
            Try
                For Each row As DataRow In dt.Rows
                    Try
                        hdnSeaID.Value = row("ID").ToString
                        hdnSeaServiceCode.Value = row("SeaServiceCode").ToString
                        ddlRank3.SelectedValue = row("RankCode").ToString
                        'txtJoiningPortUp.Text = row("JoiningPort").ToString
                        ' txtEmbarkingPortUp.Text = row("EmbarkingPort").ToString
                        '   txtCallsignUp.Text = row("CallSign").ToString
                        '   txtGRTUp.Text = row("GRT").ToString
                        '   txtEngineType2.Text = row("EngineType").ToString
                        '   ddlVesselType2.SelectedValue = row("VesselType").ToString
                        'ddlFlag2.SelectedValue = row("Flag").ToString
                        ddlVesselSeaUp.SelectedItem.Text = row("VesselName").ToString

                        txtVNames.Text = MainClass.Library.Command.ExecScalar("Select VesselName from Vessels WHERE VesselName='" & row("VesselName").ToString & "'")
                        If txtVNames.Text = "" Then
                            txtVNames.Text = row("VesselName").ToString
                            txtCallSs.Text = row("CallSign").ToString
                            txtSGrts.Text = row("GRT").ToString
                            txtETs.Text = row("EngineType").ToString
                            txtVSs.Text = row("VesselType").ToString
                            ddlFLs.SelectedItem.Text = row("Flag").ToString
                        End If

                        If row("Reason") <> "" Or row("Reason") IsNot Nothing Then
                            ddlReasonU.SelectedValue = row("Reason").ToString
                        Else
                            ddlReasonU.SelectedItem.Text = ""
                        End If

                        If row("StartDate").ToString <> "01/01/1900" Then
                            txtExStartDate2.Text = row("StartDate").ToString
                        End If
                        If row("EndDate").ToString <> "01/01/1900" Then
                            txtExEndDate2.Text = row("EndDate").ToString
                        End If

                    Catch ex As Exception

                    End Try

                Next
            Catch ex As Exception
            End Try
        End If

        htParameters.Clear()
        Return result
    End Function

    Public Function ViewMed(ByVal Code As String) As String

        Dim result As String = ""

        'mvAllotment.ActiveViewIndex = 1

        htParameters.Add("ID", Code)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "MedSel2")
        If dt.Rows.Count > 0 Then
            Try
                For Each row As DataRow In dt.Rows
                    Try
                        hdnMedID.Value = row("ID").ToString
                        ddlMedRankU.SelectedValue = row("RankCode").ToString
                        ddlCoeU.SelectedValue = row("CoE").ToString
                        ddlMedVesselU.SelectedValue = row("VesselAss").ToString
                        ddlMonthsU.SelectedValue = row("Months").ToString
                        ddlTestU.SelectedValue = row("TestType").ToString
                        txtClinicU.Text = row("Clinic").ToString
                        txtMedRemarksU.Text = row("Remarks").ToString

                        If row("MedExam").ToString <> "01/01/1900" Then
                            txtMedExamU.Text = row("MedExam").ToString
                        End If
                        If row("Fit").ToString <> "01/01/1900" Then
                            txtFitU.Text = row("Fit").ToString
                        End If

                    Catch ex As Exception

                    End Try

                Next
            Catch ex As Exception
            End Try
        End If

        htParameters.Clear()
        Return result
    End Function

    Private Sub lbContract_Click(sender As Object, e As EventArgs) Handles lbContract.Click

        'If ddlEmployer.SelectedItem.ToString = "ALVIN A. VILLAFUERTE" Then
        '    hdnPosition.Value = "FIELD PERSONNEL OFFICER"
        'ElseIf ddlEmployer.SelectedItem.ToString = "BERNIE DELA CRUZ" Then
        '  hdnPosition.Value = "POSITION HERE"
        'End If

        htParameters.Add("CrewNo", hdnCrewNo.Value)
        ' htParameters.Add("")
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "WageSel")
        '  ReportViewer1.ServerReport.DisplayName = decEmpNo & "_Contract"

        Dim datasource As New ReportDataSource("WageDS", dt)

        rvContract.LocalReport.DataSources.Clear()
        rvContract.LocalReport.DataSources.Add(datasource)
        htParameters.Clear()

        Dim params(1) As ReportParameter
        params(0) = New ReportParameter("EmployerName", ddlSignatory.SelectedItem.Text)
        params(1) = New ReportParameter("Designation", ddlSignatory.SelectedValue)
        rvContract.LocalReport.SetParameters(params)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalcon();", True)

    End Sub

    'Private Sub lbLoa_Click(sender As Object, e As EventArgs) Handles lbLoa.Click


    '    htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "LOASel")
    '    '  ReportViewer1.ServerReport.DisplayName = decEmpNo & "_Contract"

    '    Dim datasource As New ReportDataSource("LOADS", dt)

    '    rvLOA.LocalReport.DataSources.Clear()
    '    rvLOA.LocalReport.DataSources.Add(datasource)

    '    mdpLOA.Show()
    'End Sub

    Private Sub SaveAllottee(ByVal CrewNo As String)

        If fuAllot.HasFile Then
            UploadAllot()
        End If

        With htParameters

            .Add("Mode", 0)
            .Add("CrewNo", CrewNo)
            .Add("VesselCode", ddlAllotVessels.SelectedValue)
            .Add("AllotPath", hdnAllotDoc.Value)
            .Add("AllotDate", txtAllotDate.Text)
            .Add("Remarks", txtAllotRemarks.Text)
            .Add("Archive", 0)

        End With

        MainClass.Library.Command.Execute(htParameters, "AllotMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Save Allotment")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        htParameters.Clear()
        Clearfields()

        GetAllotte(CrewNo)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "famAllotClose();", True)
    End Sub

    Private Sub SaveAllottee2(ByVal CrewNo As String)

        If NextKin2.Checked Then
            hdnNextKin.Value = 0
        Else
            hdnNextKin.Value = 1
        End If

        With htParameters

            .Add("Mode", 0)
            .Add("CrewNo", CrewNo)
            .Add("AllotteeCode", CreateSequenceNo("AC"))
            .Add("LastName", txtLFName.Text)
            .Add("FirstName", txtFFName.Text)
            .Add("MiddleName", txtMFName.Text)
            .Add("Relationship", ddlRelationship.SelectedValue)
            .Add("BankAccount", txtBankAccount.Text)
            .Add("Primary", txtFPAddress.Text)
            .Add("Secondary", txtFSAddress.Text)
            .Add("Allotment", txtAllotment.Text)
            .Add("Branch", txtBranch.Text)
            .Add("ZipCode", txtZipCode.Text)
            .Add("ContactNo", txtContactNo.Text)
            .Add("IsNOK", hdnNextKin.Value)

        End With

        MainClass.Library.Command.Execute(htParameters, "FamilyMod")

        MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "AC" & "'")

        htParameters.Clear()
        Clearfields()

        GetAllotte(CrewNo)

    End Sub

    Protected Sub btnEditAllottee_Click(sender As Object, e As EventArgs) Handles btnEditAllottee.Click

        If chkAllotArchiveU.Checked Then
            hdnArchAllot.Value = 0
        Else
            hdnArchAllot.Value = 1
        End If

        If fuAllotDocU.HasFile Then
            UploadAllotU()
        End If

        With htParameters
            .Add("Mode", 1)
            .Add("ID", hdnAllotID.Value)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("VesselCode", ddlAllotVesselU.SelectedValue)
            .Add("AllotDate", txtAllotDateU.Text)
            .Add("Remarks", txtAllotRemarksU.Text)
            .Add("Archive", hdnArchAllot.Value)
            .Add("AllotPath", hdnAllotDocU.Value)
        End With
        MainClass.Library.Command.Execute(htParameters, "AllotMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Allotment")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "AllotModalU", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AllotModalU').hide();", True)

        GetAllotte(hdnCrewNo.Value)

    End Sub

    Protected Sub btnEditAllottee2_Click(sender As Object, e As EventArgs) Handles btnEditAllottee2.Click

        With htParameters
            .Add("Mode", 1)
            .Add("ID", hdnAllotteeID.Value)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("AllotteeCode", hdnAllotteeCode.Value)
            .Add("LastName", txtELFName.Text)
            .Add("FirstName", txtEFFName.Text)
            .Add("MiddleName", txtEMFName.Text)
            .Add("Relationship", ddlERelationship.SelectedValue)
            .Add("BankAccount", txtEBankAccount.Text)
            .Add("Primary", txtEFPAddress.Text)
            .Add("Secondary", txtEFSAddress.Text)
            .Add("Allotment", txtEAllotment.Text)
            .Add("Branch", txtEBranch.Text)
            .Add("ZipCode", txtEZipCode.Text)
            .Add("ContactNo", txtEContactNo.Text)
            .Add("IsNOK", hdnKinNextE.Value)
        End With
        MainClass.Library.Command.Execute(htParameters, "FamilyMod")
        htParameters.Clear()
        GetAllotte(hdnCrewNo.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "EditFam", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#EditFam').hide();", True)

    End Sub

    Protected Sub gdFamList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdFamList.RowCommand

        If e.CommandName = "ViewAllottee" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gdFamList.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            ViewRecord(index)

            'For Each row As GridViewRow In gdFamList.Rows
            '    Dim lbCrewNo11 As LinkButton = CType(row.FindControl("lbCrewNo"), LinkButton)
            '    lbCrewNo11.Attributes.Add("data-toggle", "modal")
            'Next row

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModaleditfam();", True)

        End If

    End Sub

    Protected Sub gvAllot_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAllot.RowCommand

        If e.CommandName = "ViewAllottee" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gdFamList.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            ViewRecord(index)

            'For Each row As GridViewRow In gdFamList.Rows
            '    Dim lbCrewNo11 As LinkButton = CType(row.FindControl("lbCrewNo"), LinkButton)
            '    lbCrewNo11.Attributes.Add("data-toggle", "modal")
            'Next row

            ifFamPic.Attributes.Add("src", hdnAllotDocU.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalF();", True)

        End If

    End Sub

    Protected Sub gdTraining_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdTraining.RowCommand

        If e.CommandName = "ViewDocs4" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gdDocs.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            'hdnIndex.Value = index
            ViewDocRec(index)
            'lblDocTitle.Text = hdnDocTitleUpdate.Value
            'ifPDF.Attributes.Add("src", hdnDocPath.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalDs();", True)

            hdnDocCurrent.Value = "training"
        End If

    End Sub

    Protected Sub gdTravel_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdTravel.RowCommand

        If e.CommandName = "ViewDocs1" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gdDocs.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            'hdnIndex.Value = index
            ViewDocRec(index)
            'lblDocTitle.Text = hdnDocTitleUpdate.Value
            ' ifPDF.Attributes.Add("src", hdnDocPath.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalDs();", True)

            hdnDocCurrent.Value = "travel"
        End If

    End Sub

    'Protected Sub gdMedical_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdMedical.RowCommand

    '    If e.CommandName = "ViewDocs3" Then

    '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

    '        ' Retrieve the row that contains the button 
    '        ' from the Rows collection.

    '        ' Dim row As GridViewRow = gdDocs.Rows(index)

    '        'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
    '        'hdnIndex.Value = index
    '        ViewDocRec(index)
    '        'lblDocTitle.Text = hdnDocTitleUpdate.Value
    '        ifPDF.Attributes.Add("src", hdnDocPath.Value)
    '        mdpDoc.Show()

    '    End If

    'End Sub

    Protected Sub gdFlagstate_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdFlagstate.RowCommand

        If e.CommandName = "ViewDocs2" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.

            ' Dim row As GridViewRow = gdDocs.Rows(index)

            'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
            'hdnIndex.Value = index
            ViewDocRec(index)
            'lblDocTitle.Text = hdnDocTitleUpdate.Value
            ' ifPDF.Attributes.Add("src", hdnDocPath.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalDs();", True)

            hdnDocCurrent.Value = "flagstate"
        End If

    End Sub

    'Protected Sub gdCert_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdCert.RowCommand

    '    If e.CommandName = "ViewDocs5" Then

    '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

    '        ' Retrieve the row that contains the button 
    '        ' from the Rows collection.

    '        ' Dim row As GridViewRow = gdDocs.Rows(index)

    '        'Dim ID = CType(row.FindControl("PriceLabel"), LinkButton)
    '        'hdnIndex.Value = index
    '        ViewDocRec(index)
    '        'lblDocTitle.Text = hdnDocTitleUpdate.Value
    '        ifPDF.Attributes.Add("src", hdnDocPath.Value)
    '        mdpDoc.Show()

    '    End If

    '  End Sub

    Private Function UploadPhoto() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "PhotoPic\" + hdnLName.Value & "_" + hdnFName.Value
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
                    fileDocView = "PhotoPic\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuPhoto.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPhotoSource.Value = "PhotoPic\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuPhoto.FileName

                    CrewImage.ImageUrl = hdnPhotoSource.Value
                    CrewImage.DataBind()
                    lblWarning.Text = ""
                    MainClass.Library.Command.Execute("UPDATE CrewInfo SET Photo='" & CrewImage.ImageUrl & "' WHERE CrewNo='" & hdnCrewNo.Value & "'")
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

    Private Function UploadEval() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Docs\" + hdnLName.Value + "_" + hdnFName.Value + "\Eval"
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuSeaUpload.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuSeaUpload.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuSeaUpload.SaveAs(Server.MapPath(saveDir + "\" + fuSeaUpload.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\Eval" & "\" & fuSeaUpload.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnEvalPath.Value = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\Eval" & "\" & fuSeaUpload.FileName
                    lblWarning4.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning4.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning4.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Function UploadEvalUp() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Docs\" + hdnLName.Value + "_" + hdnFName.Value + "\Eval"
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuEvalUpdate.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuEvalUpdate.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuEvalUpdate.SaveAs(Server.MapPath(saveDir + "\" + fuEvalUpdate.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\Eval" & "\" & fuEvalUpdate.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPathEvalUp.Value = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\Eval" & "\" & fuEvalUpdate.FileName
                    lblWarning5.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning5.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning5.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Function UploadPhotoDoc() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Docs\" + hdnLName.Value + "_" + hdnFName.Value
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
                    fuPath.SaveAs(Server.MapPath(saveDir + "\" + fuPath.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuPath.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnPath.Value = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuPath.FileName
                    lblWarning3.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarning3.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarning3.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Function UploadPhotoDocUpdate() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Docs\" + hdnLName.Value + "_" + hdnFName.Value
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuDocUpdate.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuDocUpdate.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuDocUpdate.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuDocUpdate.SaveAs(Server.MapPath(saveDir + "\" + fuDocUpdate.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuDocUpdate.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnDocPath.Value = "Docs\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuDocUpdate.FileName
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

    Private Function UploadAllot() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Allot\" + hdnLName.Value + "_" + hdnFName.Value
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuAllot.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuAllot.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuAllot.SaveAs(Server.MapPath(saveDir + "\" + fuAllot.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Allot\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuAllot.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnAllotDoc.Value = "Allot\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuAllot.FileName
                    lblWarningAllot.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarningAllot.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarningAllot.Text = "You have not specified a file."
        End If
        Return fileDocView

    End Function

    Private Function UploadAllotU() As String

        Dim fileUrl As String = Nothing
        Dim fileDocView As String = Nothing
        Dim saveDir As String = "Allot\" + hdnLName.Value + "_" + hdnFName.Value
        Dim appPath As String = Request.PhysicalApplicationPath

        If fuAllotDocU.HasFile Then
            Dim fileExt As String

            fileExt = System.IO.Path.GetExtension(fuAllotDocU.FileName)

            If (fileExt = ".jpg") Or (fileExt = ".pdf") Or (fileExt = ".PDF") Or (fileExt = ".JPG") Or (fileExt = ".JEPG") Or (fileExt = ".jpeg") Or (fileExt = ".PNG") Or (fileExt = ".png") Then
                Try
                    Dim savePath As String = appPath + saveDir '+ Server.HtmlEncode(fuPhoto.FileName)

                    Dim IsExist As Boolean = System.IO.Directory.Exists(savePath)
                    If Not IsExist Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    fuAllotDocU.SaveAs(Server.MapPath(saveDir + "\" + fuAllotDocU.FileName))

                    ' imgImage.ImageUrl(fuPhoto1.FileName)
                    ' Label1.Text = "File name: " & _
                    ' FileUpload1.PostedFile.FileName & "<br>" & _
                    ' "File Size: " & _
                    ' FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                    ' "Content type: " & _
                    ' FileUpload1.PostedFile.ContentType
                    'fileDocView = "EmpDocs/" & txtLastName.Text.Trim & "_" & txtFirstName.Text.Trim & "/" & docType & "/" & txtEmpNo.Text & "_" & ddlDocTitle.SelectedItem.Text.Replace(" ", "_") & fileExt
                    fileDocView = "Allot\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuAllotDocU.FileName
                    'imgImage.ImageUrl = fileDocView & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName
                    ' imgImage.DataBind()
                    '  hdnPhotoSource.Value = Server.MapPath("~/Photo/" & txtLastName.Text & "_" & txtFirstName.Text & fileUpload.FileName)
                    hdnAllotDocU.Value = "Allot\" & hdnLName.Value & "_" & hdnFName.Value & "\" & fuAllotDocU.FileName
                    lblWarningAllotU.Text = ""
                    ' fileDocView = savePath & fileUpload.FileName
                Catch ex As Exception
                    ' lblWarning1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                lblWarningAllotU.Text = "Please Upload only a pdf or picture format!"
            End If
        Else
            lblWarningAllotU.Text = "You have not specified a file."
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

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "UpPhoto", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#UpPhoto').hide();", True)

    End Sub

    Private Sub lbEditProfile_Click(sender As Object, e As EventArgs) Handles lbEditProfile.Click
        mvProfile.SetActiveView(vEditProfileInfo)
    End Sub

    Private Sub lbCancelProfile_Click(sender As Object, e As EventArgs) Handles lbCancelProfile.Click
        GetCrew(hdnCrewNo.Value)
        mvProfile.SetActiveView(vProfileInfo)
    End Sub

    Private Sub lbUpdateProfile_Click(sender As Object, e As EventArgs) Handles lbUpdateProfile.Click
        With htParameters
            .Add("Mode", 11)
            .Add("ID", hdnID.Value)
            .Add("RankCode", ddlRank.SelectedValue)
            .Add("DateHired", Request.Form("ctl00$ContentPlaceHolder1$txtDateHired"))
            .Add("Birthdate", Request.Form("ctl00$ContentPlaceHolder1$txtBirthdate"))
            .Add("Birthplace", txtBirthplace.Text)
            .Add("ContactNos", txtProfileContactNo.Text)
            .Add("PrimaryAddress", txtAddress.Text)
            .Add("Email", txtEmail.Text)
            .Add("CivilStatus", ddlCivilStatus.SelectedValue)
            .Add("School", txtSchool.Text)
            .Add("Course", txtCourse.Text)
            .Add("YearGraduated", ddlYear.SelectedValue)
        End With

        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Primary Profile")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        GetCrew(hdnCrewNo.Value)

        mvProfile.SetActiveView(vProfileInfo)

    End Sub

    Private Sub btnSaveESS_Click(sender As Object, e As EventArgs) Handles btnSaveESS.Click

        With htParameters

            .Add("Mode", 0)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("SeaServiceCode", CreateSequenceNo("SS"))
            .Add("RankCode", ddlRank2.SelectedValue)
            ' .Add("JoiningPort", txtJoiningPort.Text)
            ' .Add("EmbarkingPort", txtEmbarkingPort.Text)

            If txtVName.Text <> "" Then
                .Add("VesselName", txtVName.Text)
                .Add("CallSign", txtCallS.Text)
                .Add("GRT", txtSGrt.Text)
                .Add("EngineType", txtET.Text)
                .Add("VesselType", txtVS.Text)
                .Add("Flag", ddlFL.SelectedItem.ToString)
            Else
                .Add("VesselName", ddlVesselSea.SelectedItem.ToString)
                .Add("CallSign", MainClass.Library.Command.ExecScalar("Select CallSign from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("GRT", MainClass.Library.Command.ExecScalar("Select GRT from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("EngineType", MainClass.Library.Command.ExecScalar("Select EngineType from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("VesselType", MainClass.Library.Command.ExecScalar("Select VesselType from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("Flag", MainClass.Library.Command.ExecScalar("Select Flag from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
            End If
            .Add("Reason", ddlReason.SelectedValue)
            '.Add("ContractDuration", monthDifference(Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate"), Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate")))
            .Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate"))
            .Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate"))

        End With
        MainClass.Library.Command.Execute(htParameters, "SeaServiceMod")

        MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "SS" & "'")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Add Sea Service")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        htParameters.Add("CrewNo", hdnCrewNo.Value)
        gdSeaService.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel")
        gdSeaService.DataBind()
        htParameters.Clear()

        Clearfields()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "ESSModal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#ESSModal').hide();", True)

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    'Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

    '    GetDocs()

    '    btnNew.CssClass = "btn btn-success active"
    '    btnOld.CssClass = "btn btn-info"
    'End Sub

    'Private Sub btnOld_Click(sender As Object, e As EventArgs) Handles btnOld.Click

    '    htParameters.Add("Mode", 4)
    '    htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    htParameters.Add("IsArchive", 1)

    '    ViewState("Trainings1") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

    '    gdTraining.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
    '    gdTraining.DataBind()
    '    htParameters.Clear()

    '    htParameters.Add("Mode", 41)
    '    htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    htParameters.Add("IsArchive", 1)

    '    ViewState("Travels1") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

    '    gdTravel.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
    '    gdTravel.DataBind()
    '    htParameters.Clear()

    '    'htParameters.Add("Mode", 42)
    '    'htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    'htParameters.Add("IsArchive", 1)

    '    'ViewState("Medicals1") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

    '    'gdMedical.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
    '    'gdMedical.DataBind()
    '    'htParameters.Clear()

    '    htParameters.Add("Mode", 43)
    '    htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    htParameters.Add("IsArchive", 1)

    '    ViewState("Flags1") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

    '    gdFlagstate.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
    '    gdFlagstate.DataBind()
    '    htParameters.Clear()

    '    'htParameters.Add("Mode", 44)
    '    'htParameters.Add("CrewNo", hdnCrewNo.Value)
    '    'htParameters.Add("IsArchive", 1)

    '    'ViewState("Certs1") = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")

    '    'gdCert.DataSource = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewDocSel")
    '    'gdCert.DataBind()
    '    'htParameters.Clear()

    '    btnNew.CssClass = "btn btn-success"
    '    btnOld.CssClass = "btn btn-info active"
    'End Sub

    Private Sub btnUpdateCrewDoc_Click(sender As Object, e As EventArgs) Handles btnUpdateCrewDoc.Click
        ' ViewDocRec(hdnIndex.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewDocs", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewDocs').hide();", True)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalDu();", True)

    End Sub

    Private Sub btnCrewDocuUpdate_Click(sender As Object, e As EventArgs) Handles btnCrewDocuUpdate.Click

        If chkArchiveUpdate.Checked Then
            hdnArchiveUpdate.Value = 0
        Else
            hdnArchiveUpdate.Value = 1
        End If

        If fuDocUpdate.HasFile Then
            UploadPhotoDocUpdate()
        End If

        With htParameters

            .Add("Mode", 1)
            .Add("ID", hdnDocID.Value)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("DocCode", ddlDocCodeUpdate.SelectedValue)
            .Add("DocNo", txtDocNoUpdate.Text)
            .Add("DocTitle", ddlDocCodeUpdate.SelectedItem.ToString)
            .Add("Flag", ddlFlagstateUpdate.SelectedValue)
            .Add("TrainingCenter", ddlTrainingCenterU.SelectedValue)
            .Add("DocType", MainClass.Library.Command.ExecScalar("SELECT DocType FROM Documents WHERE DocCode='" & ddlDocCodeUpdate.SelectedValue & "' "))
            .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDateUpdate"))
            If chkNoExpiryU.Checked = True Then
                .Add("ExpiryDate", "1900-01-01")
            Else
                .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExDateUpdate"))
            End If
            .Add("IsArchive", hdnArchiveUpdate.Value)
            .Add("Path", hdnDocPath.Value)
            .Add("Remarks", txtRemarksUpdate.Text)


        End With
        MainClass.Library.Command.Execute(htParameters, "CrewDocMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Document")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        GetDocs()

        ' UPDATECREPROFILE()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewDocU", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewDocU').hide();", True)

        hdnCurrent.Value = "2"
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub lbUpdateProfile2_Click(sender As Object, e As EventArgs) Handles lbUpdateProfile2.Click

        If GenderM.Checked Then
            hdnIsMale.Value = 0
        Else
            hdnIsMale.Value = 1
        End If

        With htParameters
            .Add("Mode", 31)
            .Add("ID", hdnID.Value)
            .Add("FirstName", txtFName.Text)
            .Add("LastName", txtLName.Text)
            .Add("MiddleName", txtMidName.Text)
            .Add("MaleGender", hdnIsMale.Value)
            ' .Add("SecondaryAddress", txtSAddress.Text)
            .Add("SSSNo", txtSSS.Text)
            .Add("Philhealth", txtPhilHealth.Text)
            .Add("Pagibig", txtPagibig.Text)
            .Add("TIN", txtTIN.Text)
            .Add("Src", txtSrc.Text)
            .Add("Sirb", txtSirb.Text)
            .Add("LicenseNo", txtLicense.Text)
            .Add("Remarks", txtCRemarks.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")

        htParameters.Clear()

        GetCrew(hdnCrewNo.Value)

        mvProfile2.SetActiveView(vProfile)

    End Sub

    Private Sub lbCancelUpdate2_Click(sender As Object, e As EventArgs) Handles lbCancelUpdate2.Click
        GetCrew(hdnCrewNo.Value)
        mvProfile2.SetActiveView(vProfile)
    End Sub

    Private Sub lbEditProfile2_Click(sender As Object, e As EventArgs) Handles lbEditProfile2.Click
        mvProfile2.SetActiveView(vProfileEdit)
    End Sub

    Private Sub btnShowPassword_Click(sender As Object, e As EventArgs) Handles btnShowPassword.Click
        'lblPass.Text = hdnPass.Value
        GetCrew(hdnCrewNo.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalPass();", True)

    End Sub

    Private Sub btnUpdatePass_Click(sender As Object, e As EventArgs) Handles btnUpdatePass.Click
        htParameters.Add("Mode", 123)
        htParameters.Add("ID", hdnID.Value)
        htParameters.Add("Passwords", txtPass.Text)
        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Change Crew Password")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        GetCrew(hdnCrewNo.Value)

        Clearfields()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pass", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#Pass').hide();", True)

        hdnCurrent.Value = "1"
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub Clearfields()

        'txtPass.Text = String.Empty
        'txtFName.Text = String.Empty
        'txtMidName.Text = String.Empty
        'txtLName.Text = String.Empty
        'txtBirthplace.Text = String.Empty
        'txtAddress.Text = String.Empty
        'txtSAddress.Text = String.Empty
        'txtContactNo.Text = String.Empty
        'txtEmail.Text = String.Empty
        'txtSchool.Text = String.Empty
        'txtCourse.Text = String.Empty
        'txtSSS.Text = String.Empty
        'txtPhilHealth.Text = String.Empty
        'txtPagibig.Text = String.Empty
        'txtTIN.Text = String.Empty
        'txtBirthdate.Text = String.Empty



        'txtLFName.Text = String.Empty
        'txtFFName.Text = String.Empty
        'txtMFName.Text = String.Empty
        'txtFPAddress.Text = String.Empty
        'txtFSAddress.Text = String.Empty
        'txtBankAccount.Text = String.Empty
        'txtBranch.Text = String.Empty
        'txtZipCode.Text = String.Empty
        'txtAllotment.Text = 0.00
        'txtContactNo.Text = String.Empty


        '   txtEAllotment.Text = 0.00

        ' txtCallsign.Text = String.Empty
        '   txtGRT.Text = String.Empty
        '  txtEngineType.Text = String.Empty
        ' txtJoiningPort.Text = String.Empty
        'txtEmbarkingPort.Text = String.Empty
        '  txtVesselName.Text = String.Empty
        txtExStartDate.Text = String.Empty
        txtExEndDate.Text = String.Empty

        txtPass.Text = String.Empty

        txtDocNo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtIDate.Text = String.Empty
        txtExdate.Text = String.Empty

        txtMedDate.Text = String.Empty
        txtFit.Text = String.Empty
        txtMedRemarks.Text = String.Empty
        txtClinic.Text = String.Empty
    End Sub

    'Private Sub UPDATECREPROFILE()

    '    With htParameters

    '        .Add("CrewNo", hdnCrewNo.Value)
    '        .Add("DocNo", txtDocNo.Text)
    '        .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDate"))
    '        .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExdate"))

    '    End With

    '    If ddlDocCode.SelectedItem.ToString = "Passport" Then

    '        htParameters.Add("Mode", 50)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Seaman Registration Certificate" Then

    '        htParameters.Add("Mode", 51)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Seafarer's Identification and Record Book" Then

    '        htParameters.Add("Mode", 52)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "License Number" Then

    '        htParameters.Add("Mode", 53)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "NCI Certificate" Or ddlDocCode.SelectedItem.ToString = "NCII Certificate" Or ddlDocCode.SelectedItem.ToString = "NCIII Certificate" Then

    '        htParameters.Add("Mode", 54)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Certificate of Proficiency" Then

    '        htParameters.Add("Mode", 55)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    ElseIf ddlDocCode.SelectedItem.ToString = "Certificate of Competency" Then

    '        htParameters.Add("Mode", 56)
    '        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")
    '        htParameters.Clear()

    '    End If

    '    htParameters.Clear()

    'End Sub

    Public Function monthDifference(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
        Dim t As TimeSpan = endDate - startDate
        Dim difference As Integer = t.Days
        Dim months As Integer = Math.Floor(difference / 30.475)
        Return months

    End Function

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

                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalPayslip();", True)

            End If
        Catch ex As Exception

        End Try

    End Sub

    'Protected Sub gdCert_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdCert.PageIndexChanging

    '    If btnNew.CssClass = "btn btn-success active" Then
    '        gdCert.DataSource = ViewState("Certs")
    '    Else
    '        gdCert.DataSource = ViewState("Certs1")
    '    End If

    '    gdCert.PageIndex = e.NewPageIndex
    '    gdCert.DataBind()
    '    htParameters.Clear()

    'End Sub

    Protected Sub gvPaySlip_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPaySlip.PageIndexChanging

        gvPaySlip.DataSource = ViewState("Pay")

        gvPaySlip.PageIndex = e.NewPageIndex
        gvPaySlip.DataBind()
        htParameters.Clear()

    End Sub

    'Protected Sub gdFamList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdFamList.PageIndexChanging

    '    gdFamList.DataSource = ViewState("Fam")

    '    gdFamList.PageIndex = e.NewPageIndex
    '    gdFamList.DataBind()
    '    htParameters.Clear()

    'End Sub

    Protected Sub gvAllot_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAllot.PageIndexChanging

        gvAllot.DataSource = ViewState("Fam")

        gvAllot.PageIndex = e.NewPageIndex
        gvAllot.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gdFlagstate_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdFlagstate.PageIndexChanging

        'If btnNew.CssClass = "btn btn-success active" Then
        gdFlagstate.DataSource = ViewState("Flags")
        'Else
        '    gdFlagstate.DataSource = ViewState("Flags1")
        'End If

        gdFlagstate.PageIndex = e.NewPageIndex
        gdFlagstate.DataBind()
        htParameters.Clear()

    End Sub

    'Protected Sub gdMedical_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdMedical.PageIndexChanging

    '    If btnNew.CssClass = "btn btn-success active" Then
    '        gdMedical.DataSource = ViewState("Medicals")
    '    Else
    '        gdMedical.DataSource = ViewState("Medicals1")
    '    End If

    '    gdMedical.PageIndex = e.NewPageIndex
    '    gdMedical.DataBind()
    '    htParameters.Clear()

    'End Sub

    Protected Sub gdSeaService_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdSeaService.PageIndexChanging

        gdSeaService.DataSource = ViewState("Sea")

        gdSeaService.PageIndex = e.NewPageIndex
        gdSeaService.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gdTraining_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdTraining.PageIndexChanging

        'If btnNew.CssClass = "btn btn-success active" Then
        gdTraining.DataSource = ViewState("Trainings")
        'Else
        '    gdTraining.DataSource = ViewState("Trainings1")
        'End If

        gdTraining.PageIndex = e.NewPageIndex
        gdTraining.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gdTravel_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdTravel.PageIndexChanging

        'If btnNew.CssClass = "btn btn-success active" Then
        gdTravel.DataSource = ViewState("Travels")
        'Else
        '    gdTravel.DataSource = ViewState("Travels1")
        'End If

        gdTravel.PageIndex = e.NewPageIndex
        gdTravel.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub txtBirthdate_TextChanged(sender As Object, e As EventArgs)
        ddlYear.Items.Clear()
        Dim aa = DateTime.Parse(txtBirthdate.Text)
        ' Dim b As Integer = aa.Year
        For a = aa.Year To Year(Now)
            ddlYear.Items.Add(New ListItem(a))
        Next
        ddlYear.SelectedValue = lblYearGraduated.Text

    End Sub

    Protected Sub txtIDate_TextChanged(sender As Object, e As EventArgs)
        If txtIDate.Text <> "" Then
            ceExdate.StartDate = txtIDate.Text
            ceExdate.EndDate = DateTime.Now.AddYears(+15)
        End If
    End Sub

    Protected Sub txtExStartDate_TextChanged(sender As Object, e As EventArgs)
        If txtExStartDate.Text <> "" Then
            ceExEndDate.StartDate = txtExStartDate.Text
            ceExEndDate.EndDate = DateTime.Now.AddYears(+15)
        End If
    End Sub

    Protected Sub gdTravel_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim hdnDocTravel As HiddenField = TryCast(e.Row.FindControl("hdnDocTravel"), HiddenField)
            If hdnDocTravel.Value <> "" And hdnDocTravel.Value <> "No Expiration" Then
                Dim aa As Date = hdnDocTravel.Value
                Dim a As Date = DateTime.Parse(aa.ToString("MM/dd/yy"))
                Dim b As Date = DateTime.Parse(DateTime.Now.ToString("MM/dd/yy"))
                Dim c As Date = DateTime.Parse(DateTime.Now.AddMonths(2).ToString("MM/dd/yy"))

                If a <= b Then
                    ' e.Row.BackColor = Color.Red
                    e.Row.ForeColor = Color.Red
                ElseIf a <= c Then
                    ' e.Row.BackColor = Color.Yellow
                    e.Row.ForeColor = Color.DarkOrange
                End If
            End If
        End If

    End Sub

    Protected Sub gdFlagstate_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim hdnDocFlag As HiddenField = TryCast(e.Row.FindControl("hdnDocFlag"), HiddenField)
            If hdnDocFlag.Value <> "" And hdnDocFlag.Value <> "No Expiration" Then
                Dim aa As Date = hdnDocFlag.Value
                Dim a As Date = DateTime.Parse(aa.ToString("MM/dd/yy"))
                Dim b As Date = DateTime.Parse(DateTime.Now.ToString("MM/dd/yy"))
                Dim c As Date = DateTime.Parse(DateTime.Now.AddMonths(2).ToString("MM/dd/yy"))

                If a <= b Then
                    ' e.Row.BackColor = Color.Red
                    e.Row.ForeColor = Color.Red
                ElseIf a <= c Then
                    ' e.Row.BackColor = Color.Yellow
                    e.Row.ForeColor = Color.DarkOrange
                End If
            End If
        End If

    End Sub

    'Protected Sub gdTraining_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim hdnDocTraining As HiddenField = TryCast(e.Row.FindControl("hdnDocTraining"), HiddenField)
    '        If hdnDocTraining.Value <> "" And hdnDocTraining.Value <> "No Expiration" Then
    '            Dim aa As Date = hdnDocTraining.Value
    '            Dim a As Date = DateTime.Parse(aa.ToString("MM/dd/yy"))
    '            Dim b As Date = DateTime.Parse(DateTime.Now.ToString("MM/dd/yy"))
    '            Dim c As Date = DateTime.Parse(DateTime.Now.AddMonths(2).ToString("MM/dd/yy"))

    '            If a <= b Then
    '                ' e.Row.BackColor = Color.Red
    '                e.Row.ForeColor = Color.Red
    '            ElseIf a <= c Then
    '                ' e.Row.BackColor = Color.Yellow
    '                e.Row.ForeColor = Color.DarkOrange
    '            End If
    '        End If
    '    End If

    'End Sub

    Protected Sub txtIDateUpdate_TextChanged(sender As Object, e As EventArgs)
        If txtIDateUpdate.Text <> "" Then
            ceExDateUpdate.StartDate = txtIDateUpdate.Text
            ceExDateUpdate.EndDate = DateTime.Now.AddYears(+15)
        End If
    End Sub

    Private Sub lbSaveDoc_Click(sender As Object, e As EventArgs) Handles lbSaveDoc.Click

        'If chkArchive.Checked Then
        '    hdnISArchive.Value = 0
        'Else
        '    hdnISArchive.Value = 1
        'End If

        UploadPhotoDoc()

        With htParameters

            .Add("Mode", 0)
            .Add("ID", hdnDocID.Value)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("DocCode", ddlDocCode.SelectedValue)
            .Add("DocNo", txtDocNo.Text)
            .Add("DocTitle", ddlDocCode.SelectedItem.ToString)
            .Add("Flag", ddlFlagstate.SelectedValue)
            .Add("TrainingCenter", ddlTrainingCenter.SelectedValue)
            .Add("DocType", MainClass.Library.Command.ExecScalar("Select DocType FROM Documents WHERE DocCode='" & ddlDocCode.SelectedValue & "' "))
            .Add("IssuedDate", Request.Form("ctl00$ContentPlaceHolder1$txtIDate"))
            If chkNoExpiry.Checked = True Then
                .Add("ExpiryDate", "1900-01-01")
            Else
                .Add("ExpiryDate", Request.Form("ctl00$ContentPlaceHolder1$txtExdate"))
            End If
            .Add("IsArchive", 0)
            .Add("Path", hdnPath.Value)
            .Add("Remarks", txtRemarks.Text)

        End With
        MainClass.Library.Command.Execute(htParameters, "CrewDocMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Add Document")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        'UPDATECREPROFILE()

        '     MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "DN" & "'")

        GetDocs()

        Clearfields()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "CrewDoc", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#CrewDoc').hide();", True)

        hdnCurrent.Value = "2"
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    'Private Sub txtEAllotment_TextChanged(sender As Object, e As EventArgs) Handles txtEAllotment.TextChanged
    '    If Val(hdnTotalAllocation2.Value) < Val(txtEAllotment.Text) Then
    '        lblErrAllotE.Visible = True
    '    Else
    '        lblErrAllotE.Visible = False
    '    End If
    'End Sub

    'Private Sub txtAllotment_TextChanged(sender As Object, e As EventArgs) Handles txtAllotment.TextChanged
    '    If Val(hdnTotalAllocation.Value) < Val(txtAllotment.Text) Then
    '        lblErrorAllot.Visible = True
    '    Else
    '        lblErrorAllot.Visible = False
    '    End If
    'End Sub

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

    Protected Sub gvAllot_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvAllot.Sorting

        Dim dt = TryCast(ViewState("Fam"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvAllot.DataSource = ViewState("Fam")
            gvAllot.DataBind()
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

    Protected Sub gdTravel_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdTravel.Sorting

        Dim dt = TryCast(ViewState("Travels"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdTravel.DataSource = ViewState("Travels")
            gdTravel.DataBind()
        End If

    End Sub

    Protected Sub gdTraining_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdTraining.Sorting

        Dim dt = TryCast(ViewState("Trainings"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdTraining.DataSource = ViewState("Trainings")
            gdTraining.DataBind()
        End If

    End Sub

    Protected Sub gdFlagstate_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gdFlagstate.Sorting

        Dim dt = TryCast(ViewState("Flags"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gdFlagstate.DataSource = ViewState("Flags")
            gdFlagstate.DataBind()
        End If

    End Sub

    Protected Sub gvPaySlip_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvPaySlip.Sorting

        Dim dt = TryCast(ViewState("Pay"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvPaySlip.DataSource = ViewState("Pay")
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

    Private Sub lbAddAllottee_Click(sender As Object, e As EventArgs) Handles lbAddAllottee.Click
        SaveAllottee(hdnCrewNo.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "AllotModal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AllotModal').hide();", True)

        hdnCurrent.Value = 3
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub lbAddAllottee2_Click(sender As Object, e As EventArgs) Handles lbAddAllottee2.Click
        SaveAllottee2(hdnCrewNo.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "AddFam2", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AddFam2').hide();", True)

        hdnCurrent.Value = 3
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub btnFamUpdate_Click(sender As Object, e As EventArgs) Handles btnFamUpdate.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalAu();", True)

        hdnCurrent.Value = 3
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub lbEditProfileVessel_Click(sender As Object, e As EventArgs) Handles lbEditProfileVessel.Click
        mvVesselStat.SetActiveView(vProfileVesselEdit)
    End Sub

    Private Sub lbCancelProfileVessel_Click(sender As Object, e As EventArgs) Handles lbCancelProfileVessel.Click
        GetCrew(hdnCrewNo.Value)
        mvVesselStat.SetActiveView(vProfileVessel)
    End Sub

    'Protected Sub txtSignOn_TextChanged(sender As Object, e As EventArgs)
    '    If txtSignOn.Text <> "" Then
    '        Dim sSignOn = New Date("MM/dd/yyyy")
    '        sSignOn = txtSignOn.Text
    '        ceSignOff.StartDate = sSignOn
    '        ceSignOff.EndDate = DateTime.Now.AddYears(+2)
    '    End If
    'End Sub

    'Protected Sub txtArrival_TextChanged(sender As Object, e As EventArgs)
    '    If txtArrival.Text <> "" Then
    '        ceReport.StartDate = txtArrival.Text
    '        ceReport.EndDate = DateTime.Now.AddYears(+2)
    '    End If
    'End Sub

    Private Sub lbProfileVesselUpdate_Click(sender As Object, e As EventArgs) Handles lbProfileVesselUpdate.Click

        With htParameters
            .Add("Mode", 12)
            .Add("ID", hdnID.Value)
            .Add("CrewStatus", ddlCrewStatus.SelectedValue)
            .Add("VesselCode", ddlVessels.SelectedValue)
            .Add("ContractDuration", ddlContract.SelectedItem.Text)
            .Add("Scale", ddlScale.SelectedValue)
            .Add("SignOn", Request.Form("ctl00$ContentPlaceHolder1$txtSignOn"))
            .Add("SignOff", Request.Form("ctl00$ContentPlaceHolder1$txtSignOff"))
            .Add("Arrival", Request.Form("ctl00$ContentPlaceHolder1$txtArrival"))
            .Add("Report", Request.Form("ctl00$ContentPlaceHolder1$txtReport"))
            .Add("Avail", ddlAvail.SelectedValue)
            .Add("AvailRemarks", txtAvailRemarks.Text)
        End With
        MainClass.Library.Command.Execute(htParameters, "CrewInfoMod")

        htParameters.Clear()
        htParameters.Add("Mode", 44)
        htParameters.Add("Keyword", ddlVessels.SelectedItem.ToString)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "VesselSel")
        For Each row As DataRow In dt.Rows
            Try

                hdnCallSign.Value = row("CallSign").ToString
                hdnGRT.Value = row("GRT").ToString
                hdnEngineType.Value = row("EngineType").ToString
                hdnVesselType.Value = row("LookUpDescription").ToString
                hdnFlag.Value = row("Flag").ToString

            Catch ex As Exception

            End Try
        Next
        htParameters.Clear()

        If hdnCrewStatus.Value = "Lined-up" Or hdnCrewStatus.Value = "On-Vacation" Then
            If ddlCrewStatus.SelectedValue = "Onboard" Then
                With htParameters
                    .Add("Mode", 112)
                    .Add("CrewNo", hdnCrewNo.Value)
                    .Add("SeaServiceCode", CreateSequenceNo("SS"))
                    .Add("RankCode", ddlRank.SelectedValue)
                    .Add("ContractDuration", ddlContract.SelectedItem.Text)
                    .Add("VesselCode", ddlVessels.SelectedValue)
                    .Add("VesselName", ddlVessels.SelectedItem.ToString)
                    .Add("CallSign", hdnCallSign.Value)
                    .Add("GRT", hdnGRT.Value)
                    .Add("EngineType", hdnEngineType.Value)
                    .Add("VesselType", hdnVesselType.Value)
                    .Add("Flag", hdnFlag.Value)
                    .Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtSignOn"))
                    .Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtSignOff"))
                End With
                hdnCrewStatus.Value = ddlCrewStatus.SelectedValue
                MainClass.Library.Command.Execute(htParameters, "SeaServiceMod")

                MainClass.Library.Command.Execute("UPDATE SequenceNo SET SequenceNo = SequenceNo+1,DateUpdated=GetDate() WHERE SequenceCode = '" & "SS" & "'")
            End If
        End If

        'htParameters.Clear()

        'hdnQueue.Value = MainClass.Library.Command.ExecScalar("Select ID from CrewQueue where CrewNo='" & hdnCrewNo.Value & "' and Status='Lined-up'")
        'If hdnCrewStatus.Value = "Applicant" Then
        '    If ddlCrewStatus.SelectedValue = "Lined-up" Then
        '        With htParameters
        '            .Add("Mode", 0)
        '            .Add("ID", hdnQueue.Value)
        '            .Add("CrewNo", hdnCrewNo.Value)
        '            .Add("RankCode", ddlRank.SelectedValue)
        '            .Add("Status", ddlCrewStatus.SelectedValue)
        '        End With
        '        hdnCrewStatus.Value = ddlCrewStatus.SelectedValue
        '        MainClass.Library.Command.Execute(htParameters, "QueueMod")
        '    End If
        'ElseIf hdnCrewStatus.Value = "Lined-up" Then
        '    If ddlCrewStatus.SelectedValue = "Onboard" Then
        '        With htParameters
        '            .Add("Mode", 1)
        '            .Add("ID", hdnQueue.Value)
        '            .Add("CrewNo", hdnCrewNo.Value)
        '            .Add("RankCode", ddlRank.SelectedValue)
        '            .Add("Status", ddlCrewStatus.SelectedValue)
        '        End With
        '        hdnCrewStatus.Value = ddlCrewStatus.SelectedValue
        '        MainClass.Library.Command.Execute(htParameters, "QueueMod")
        '    End If
        'ElseIf hdnCrewStatus.Value = "On-Vacation" Then
        '    If ddlCrewStatus.SelectedValue = "Lined-up" Then
        '        With htParameters
        '            .Add("Mode", 0)
        '            .Add("ID", hdnQueue.Value)
        '            .Add("CrewNo", hdnCrewNo.Value)
        '            .Add("RankCode", ddlRank.SelectedValue)
        '            .Add("Status", ddlCrewStatus.SelectedValue)
        '        End With
        '        hdnCrewStatus.Value = ddlCrewStatus.SelectedValue
        '        MainClass.Library.Command.Execute(htParameters, "QueueMod")
        '    End If
        'ElseIf hdnCrewStatus.Value = "Onboard" Then
        '    If ddlCrewStatus.SelectedValue = "Lined-up" Then
        '        With htParameters
        '            .Add("Mode", 0)
        '            .Add("ID", hdnQueue.Value)
        '            .Add("CrewNo", hdnCrewNo.Value)
        '            .Add("RankCode", ddlRank.SelectedValue)
        '            .Add("Status", ddlCrewStatus.SelectedValue)
        '        End With
        '        hdnCrewStatus.Value = ddlCrewStatus.SelectedValue
        '        MainClass.Library.Command.Execute(htParameters, "QueueMod")
        '    End If

        '    htParameters.Clear()

        '    '  MainClass.Library.Command.Execute("UPDATE CrewInfo SET ContractDuration=0 WHERE CrewNo='" & hdnCrewNo.Value & "'")

        'End If

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Sea Service Profile")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        GetCrew(hdnCrewNo.Value)
        GetSea(hdnCrewNo.Value)

        mvVesselStat.SetActiveView(vProfileVessel)

    End Sub

    Protected Sub gdSeaService_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdSeaService.RowCommand

        If e.CommandName = "ViewSea" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ViewSea(index)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalEssU();", True)

        ElseIf e.CommandName = "ViewSea2" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            hdnEvalIDs.Value = e.CommandArgument
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalEvalA();", True)

        ElseIf e.CommandName = "ViewSea3" Then

            hdnEvalIDs.Value = e.CommandArgument
            ' Dim dtViewEvaluation As DataTable
            Dim sbEvaluation As New StringBuilder
            sbEvaluation.Append("SELECT EvalPath,REVERSE(RTRIM(SUBSTRING(REVERSE (EvalPath), (CHARINDEX('?', REVERSE (EvalPath), 1)+1), ")
            sbEvaluation.Append("((CHARINDEX('\', REVERSE (EvalPath), 1)) - (CHARINDEX('?', REVERSE (EvalPath), 1))- 1)))) as 'Evaluation', ID ")
            sbEvaluation.Append("FROM Evaluation ")
            sbEvaluation.Append("WHERE SeaServiceCode='" & hdnEvalIDs.Value & "'")
            ' dtViewEvaluation = DataAccess.DataAccess.Adapter.GetRecordSet("SELECT EvaluationPath FROM Evaluation WHERE SeaServiceID=" & seaServiceID)
            ' ViewState("SeaServiceNo") = hdnSeaServiceCode.Value

            gvEval.DataSource = MainClass.Library.Adapter.GetRecordSet(sbEvaluation.ToString())
            ViewState("Evaluation") = MainClass.Library.Adapter.GetRecordSet(sbEvaluation.ToString())
            gvEval.DataBind()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalEvalG();", True)

        ElseIf e.CommandName = "DeleteCrew" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' ViewSea(Index)

            htParameters.Add("Mode", 2)
            htParameters.Add("ID", index)
            MainClass.Library.Command.Execute(htParameters, "SeaServiceMod")

            GetSea(hdnCrewNo.Value)

            htParameters.Clear()

            htParameters.Add("UserName", Session("UserName"))
            htParameters.Add("ModuleAccess", Session("Access"))
            htParameters.Add("Mode", 1)
            htParameters.Add("PageAccess", "CrewProfile.aspx")
            htParameters.Add("ActionTaken", "Delete Sea Service")
            MainClass.Library.Command.Execute(htParameters, "AuditMod")
            htParameters.Clear()
        End If

    End Sub

    Private Sub btnUpdateSea_Click(sender As Object, e As EventArgs) Handles btnUpdateSea.Click

        With htParameters

            .Add("Mode", 1)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("ID", hdnSeaID.Value)
            .Add("SeaServiceCode", hdnSeaServiceCode.Value)
            .Add("RankCode", ddlRank3.SelectedValue)
            '  .Add("JoiningPort", txtJoiningPortUp.Text)
            ' .Add("EmbarkingPort", txtEmbarkingPortUp.Text)

            If txtVName.Text = "" Then
                .Add("VesselName", txtVNames.Text)
                .Add("CallSign", txtCallSs.Text)
                .Add("GRT", txtSGrts.Text)
                .Add("EngineType", txtETs.Text)
                .Add("VesselType", txtVSs.Text)
                .Add("Flag", ddlFLs.SelectedItem.ToString)
            Else
                .Add("VesselName", ddlVesselSea.SelectedItem.ToString)
                .Add("CallSign", MainClass.Library.Command.ExecScalar("Select CallSign from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("GRT", MainClass.Library.Command.ExecScalar("Select GRT from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("EngineType", MainClass.Library.Command.ExecScalar("Select EngineType from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("VesselType", MainClass.Library.Command.ExecScalar("Select VesselType from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
                .Add("Flag", MainClass.Library.Command.ExecScalar("Select Flag from Vessels WHERE VesselName='" & ddlVesselSea.SelectedItem.ToString & "'"))
            End If

            .Add("Reason", ddlReasonU.SelectedValue)
            '  .Add("ContractDuration", monthDifference(Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate"), Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate")))
            .Add("StartDate", Request.Form("ctl00$ContentPlaceHolder1$txtExStartDate2"))
            .Add("EndDate", Request.Form("ctl00$ContentPlaceHolder1$txtExEndDate2"))

        End With
        MainClass.Library.Command.Execute(htParameters, "SeaServiceMod")

        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Sea Service")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        Clearfields()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "ESSModalU", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#ESSModalU').hide();", True)

        GetSea(hdnCrewNo.Value)

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub lbOver_Click(sender As Object, e As EventArgs) Handles lbOver.Click

        rvOver.LocalReport.DataSources.Clear()
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepCrewInfo")
        Dim datasource As New ReportDataSource("InfoDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepTravel")
        Dim datasource1 As New ReportDataSource("TravelDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepTraining")
        Dim datasource2 As New ReportDataSource("TrainDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepFlag")
        Dim datasource3 As New ReportDataSource("FlagDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepSeaRank")
        Dim datasource4 As New ReportDataSource("SeaRankDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepSeaVessel")
        Dim datasource5 As New ReportDataSource("SeaVesselDS", dt)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "SeaServiceSel")
        Dim datasource6 As New ReportDataSource("SeaDS", dt)

        rvOver.LocalReport.DataSources.Add(datasource)
        rvOver.LocalReport.DataSources.Add(datasource1)
        rvOver.LocalReport.DataSources.Add(datasource2)
        rvOver.LocalReport.DataSources.Add(datasource3)
        rvOver.LocalReport.DataSources.Add(datasource4)
        rvOver.LocalReport.DataSources.Add(datasource5)
        rvOver.LocalReport.DataSources.Add(datasource6)

        rvOver.LocalReport.EnableExternalImages = True
        ' Dim a = "~http://119.92.226.27/EMS/Photo/Abalorio_Joel/PHOTO.jpg"
        '  Dim imagePath = New Uri(Server.MapPath(a)).AbsoluteUri

        ' Dim ImgURL As String = ConvertURI("~/Photo/cmale.png")

        Dim imagePath = New Uri(Server.MapPath("~/" + hdnPhotoSource.Value)).AbsoluteUri

        Dim params(0) As Microsoft.Reporting.WebForms.ReportParameter
        params(0) = New Microsoft.Reporting.WebForms.ReportParameter("ImagePath", imagePath)
        rvOver.LocalReport.SetParameters(params)

        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalO();", True)

    End Sub

    'Function ConvertURI(URI As String)
    '    Dim DecodeURI As String = HttpUtility.UrlDecode(URI) 'Decode URI string
    '    Dim SubURI = DecodeURI.Substring(DecodeURI.IndexOf("EMS"))
    '    Dim URL As String = "~/" & SubURI ' Restore the URL string format
    '    Return URL
    'End Function

    Public Function SetNavigation(ByVal Code As String) As String
        Dim result As String = ""
        Dim PageToTransfer As String = ""
        Dim URLEncoded As String = ""


        PageToTransfer = "CrewProfile.aspx?x="

        URLEncoded = System.Web.HttpUtility.UrlEncode(MainClass.Library.EncDec.Encrypt(Code))
        result = PageToTransfer & URLEncoded
        Return result

    End Function

    Private Sub lbGo_Click(sender As Object, e As EventArgs) Handles lbGo.Click
        Response.Redirect(SetNavigation(ddlSearch.SelectedValue))
    End Sub

    'Private Sub btnGo1_ServerClick(sender As Object, e As EventArgs) Handles btnGo1.ServerClick
    '    Response.Redirect(SetNavigation(ddlSearch.SelectedValue))
    'End Sub

    Private Sub btnUploadEval_Click(sender As Object, e As EventArgs) Handles btnUploadEval.Click

        If fuSeaUpload.HasFile Then
            UploadEval()

            With htParameters
                .Add("Mode", 0)
                .Add("CrewNo", hdnCrewNo.Value)
                .Add("SeaServiceCode", hdnEvalIDs.Value)
                .Add("EvalPath", hdnEvalPath.Value)
            End With

            MainClass.Library.Command.Execute(htParameters, "EvalMod")
        End If

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub btnUpEval_Click(sender As Object, e As EventArgs) Handles btnUpEval.Click

        If fuEvalUpdate.HasFile Then
            UploadEvalUp()

            With htParameters
                .Add("Mode", 1)
                .Add("ID", hdnIDEval.Value)
                .Add("CrewNo", hdnCrewNo.Value)
                .Add("SeaServiceCode", hdnEvalIDs.Value)
                .Add("EvalPath", hdnPathEvalUp.Value)
            End With

            MainClass.Library.Command.Execute(htParameters, "EvalMod")
        End If

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "UpSeaViewEval", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#UpSeaViewEval').hide();", True)

    End Sub

    Protected Sub GvEval_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvEval.RowCommand

        If e.CommandName = "ViewEval" Then

            hdnIDEval.Value = Convert.ToInt32(e.CommandArgument)

            hdnPathEvalUp.Value = MainClass.Library.Command.ExecScalar("Select EvalPath from Evaluation WHERE ID='" & hdnIDEval.Value & "'")

            ifEval.Attributes.Add("src", hdnPathEvalUp.Value)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "UpSeaGridEval", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#UpSeaGridEval').hide();", True)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalEvalV();", True)

        End If

    End Sub

    Protected Sub gvSeaP_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvSeaP.RowCommand

        If e.CommandName = "ViewSea3" Then

            hdnEvalIDs.Value = e.CommandArgument
            ' Dim dtViewEvaluation As DataTable
            Dim sbEvaluation As New StringBuilder
            sbEvaluation.Append("SELECT EvalPath,REVERSE(RTRIM(SUBSTRING(REVERSE (EvalPath), (CHARINDEX('?', REVERSE (EvalPath), 1)+1), ")
            sbEvaluation.Append("((CHARINDEX('\', REVERSE (EvalPath), 1)) - (CHARINDEX('?', REVERSE (EvalPath), 1))- 1)))) as 'Evaluation', ID ")
            sbEvaluation.Append("FROM Evaluation ")
            sbEvaluation.Append("WHERE SeaServiceCode='" & hdnEvalIDs.Value & "'")
            ' dtViewEvaluation = DataAccess.DataAccess.Adapter.GetRecordSet("SELECT EvaluationPath FROM Evaluation WHERE SeaServiceID=" & seaServiceID)
            ' ViewState("SeaServiceNo") = hdnSeaServiceCode.Value

            gvEval.DataSource = MainClass.Library.Adapter.GetRecordSet(sbEvaluation.ToString())
            ViewState("Evaluation") = MainClass.Library.Adapter.GetRecordSet(sbEvaluation.ToString())
            gvEval.DataBind()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalEvalG();", True)

        End If

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Protected Sub gvSeaP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvSeaP.PageIndexChanging

        gvSeaP.DataSource = ViewState("Sea")

        gvSeaP.PageIndex = e.NewPageIndex
        gvSeaP.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvSeaP_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvSeaP.Sorting

        Dim dt = TryCast(ViewState("Sea"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvSeaP.DataSource = ViewState("Sea")
            gvSeaP.DataBind()
        End If

    End Sub

    Private Sub lbMedSave_Click(sender As Object, e As EventArgs) Handles lbMedSave.Click

        With htParameters
            .Add("Mode", 0)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("RankCode", ddlMedRank.SelectedValue)
            .Add("CoE", ddlCoe.SelectedValue)
            .Add("VesselAss", ddlMedVessel.SelectedValue)
            .Add("MedExam", Request.Form("ctl00$ContentPlaceHolder1$txtMedDate"))
            .Add("Fit", Request.Form("ctl00$ContentPlaceHolder1$txtFit"))
            .Add("Months", ddlMonths.SelectedValue)
            .Add("TestType", ddlTest.SelectedValue)
            .Add("Clinic", txtClinic.Text)
            .Add("Remarks", txtMedRemarks.Text)
        End With

        MainClass.Library.Command.Execute(htParameters, "MedMod")
        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Save Medical History")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        htParameters.Clear()
        Clearfields()

        GetMed()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "MedHis", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#MedHis').hide();", True)

        hdnCurrent.Value = "7"
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Protected Sub gvMed_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMed.RowCommand

        If e.CommandName = "ViewMed" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Dim dtViewEvaluation As DataTable
            ViewMed(index)

            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalMedHisU();", True)

        ElseIf e.CommandName = "DeleteMed" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' ViewSea(Index)
            If Session("Access") = "AD" Then
                htParameters.Add("Mode", 2)
                htParameters.Add("ID", index)
                MainClass.Library.Command.Execute(htParameters, "MedMod")

                GetSea(hdnCrewNo.Value)

                htParameters.Clear()

                htParameters.Add("UserName", Session("UserName"))
                htParameters.Add("ModuleAccess", Session("Access"))
                htParameters.Add("Mode", 1)
                htParameters.Add("PageAccess", "CrewProfile.aspx")
                htParameters.Add("ActionTaken", "Delete Medical History")
                MainClass.Library.Command.Execute(htParameters, "AuditMod")
                htParameters.Clear()
            End If
        End If

            hdnCurrent.Value = 7
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Protected Sub gvMed_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvMed.PageIndexChanging

        gvMed.DataSource = ViewState("MedHistory")

        gvMed.PageIndex = e.NewPageIndex
        gvMed.DataBind()
        htParameters.Clear()

    End Sub

    Protected Sub gvMed_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvMed.Sorting

        Dim dt = TryCast(ViewState("MedHistory"), DataTable)

        If dt IsNot Nothing Then

            'Sort the data.
            'ChangeColumnDataType(dt, "Sign-Off", GetType(Date))
            dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)

            gvMed.DataSource = ViewState("MedHistory")
            gvMed.DataBind()
        End If

    End Sub

    Private Sub btnMedUpdate_Click(sender As Object, e As EventArgs) Handles btnMedUpdate.Click

        With htParameters
            .Add("Mode", 1)
            .Add("ID", hdnMedID.Value)
            .Add("CrewNo", hdnCrewNo.Value)
            .Add("RankCode", ddlMedRankU.SelectedValue)
            .Add("CoE", ddlCoeU.SelectedValue)
            .Add("VesselAss", ddlMedVesselU.SelectedValue)
            .Add("MedExam", Request.Form("ctl00$ContentPlaceHolder1$txtMedExamU"))
            .Add("Fit", Request.Form("ctl00$ContentPlaceHolder1$txtFitu"))
            .Add("Months", ddlMonthsU.SelectedValue)
            .Add("TestType", ddlTestU.SelectedValue)
            .Add("Clinic", txtClinicU.Text)
            .Add("Remarks", txtMedRemarksU.Text)
        End With

        MainClass.Library.Command.Execute(htParameters, "MedMod")
        htParameters.Clear()

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Update Medical History")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        htParameters.Clear()
        Clearfields()

        GetMed()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "MedHisu", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#MedHisu').hide();", True)

        hdnCurrent.Value = "7"
        GetCurrentTab(hdnCurrent.Value)
    End Sub

    Private Sub lbJoining_Click(sender As Object, e As EventArgs) Handles lbJoining.Click

        rvJoining.LocalReport.DataSources.Clear()
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepCrewInfo")
        Dim datasource As New ReportDataSource("RoutingDS", dt)

        rvJoining.LocalReport.DataSources.Add(datasource)

        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalJ();", True)

    End Sub

    Private Sub lbSignoff_Click(sender As Object, e As EventArgs) Handles lbSignoff.Click

        rvSignOff.LocalReport.DataSources.Clear()
        htParameters.Add("CrewNo", hdnCrewNo.Value)
        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "RepCrewInfo")
        Dim datasource As New ReportDataSource("RoutingDS", dt)

        rvSignOff.LocalReport.DataSources.Add(datasource)

        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Pop", "openModalS();", True)

    End Sub

    Private Sub btnDelSea_Click(sender As Object, e As EventArgs) Handles btnDelSea.Click

        htParameters.Add("Mode", 2)
        htParameters.Add("ID", hdnSeaID.Value)
        MainClass.Library.Command.Execute(htParameters, "SeaServiceMod")

        htParameters.Clear()

        GetSea(hdnCrewNo.Value)

        htParameters.Add("UserName", Session("UserName"))
        htParameters.Add("ModuleAccess", Session("Access"))
        htParameters.Add("Mode", 1)
        htParameters.Add("PageAccess", "CrewProfile.aspx")
        htParameters.Add("ActionTaken", "Delete Sea Service")
        MainClass.Library.Command.Execute(htParameters, "AuditMod")
        htParameters.Clear()

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "ESSModalU", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#ESSModalU').hide();", True)

        hdnCurrent.Value = 4
        GetCurrentTab(hdnCurrent.Value)


    End Sub
    'Protected Sub hlScannedDocs_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
    '    sender.navigateurl = "javascript:openModalDs(" & "'" & HttpContext.Current.Request.Url.Authority & "/" & Eval("Path") & "'" & ")"


    '    ' ifPDF.Attributes.Add("src", HttpContext.Current.Request.Url.Authority & "/" & Eval("Path"))
    'End Sub

End Class