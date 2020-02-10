<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="CrewProfile.aspx.vb" Inherits="CrewSys.CrewProfile" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="assets/pages/list-scroll/list.css" />
    <script src="assets/pages/list-scroll/list-custom.js"></script>
    <%--    <link href="css/NavTabBs4.css" rel="stylesheet" />
    <script src="js/NavTabBS4.js"></script>--%>

    <script type="text/javascript">

        $(document).ready(function () {
            var selectedTab = $("#<%=TabName.ClientID%>");
            var tabId = selectedTab.val() != "" ? selectedTab.val() : "profile";
            $('#tabsmain a[href="#' + tabId + '"]').tab('show');
            $("#tabsmain a").click(function () {
                selectedTab.val($(this).attr("href").substring(1));
            });
        });
        $(document).ready(function () {
            var selectedTab1 = $("#<%=hdnDocCurrent.ClientID%>");
            var tabId1 = selectedTab1.val() != "" ? selectedTab1.val() : "flagstate";
            $('#tabdocs a[href="#' + tabId1 + '"]').tab('show');
            $("#tabdocs a").click(function () {
                selectedTab1.val($(this).attr("href").substring(1));
            });
        });

        $(document).ready(function () {
            $("#<%= ddlCrewStatus.ClientID%>").selectpicker();
             $("#<%= ddlVessels.ClientID%>").selectpicker();
             $("#<%= ddlRank.ClientID%>").selectpicker();
             $("#<%= ddlYear.ClientID%>").selectpicker();
             $("#<%= ddlCivilStatus.ClientID%>").selectpicker();
             $("#<%= ddlFlagstate.ClientID%>").selectpicker();
             $("#<%= ddlTrainingCenter.ClientID%>").selectpicker();
             $("#<%= ddlDocCode.ClientID%>").selectpicker();
             $("#<%= ddlRelationship.ClientID%>").selectpicker();
             $("#<%= ddlRank2.ClientID%>").selectpicker();
            <%--            $("#<%= ddlFlag.ClientID%>").selectpicker();
            $("#<%= ddlVesselType.ClientID%>").selectpicker();--%>
             $("#<%= ddlERelationship.ClientID%>").selectpicker();
             $("#<%= ddlFlagstateUpdate.ClientID%>").selectpicker();
             $("#<%= ddlTrainingCenterU.ClientID%>").selectpicker();
             $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
             $("#<%= ddlAllotVessels.ClientID%>").selectpicker();
             $("#<%= ddlAllotVesselU.ClientID%>").selectpicker();
             $("#<%= ddlRank3.ClientID%>").selectpicker();
            <%--$("#<%= ddlVesselType2.ClientID%>").selectpicker();--%>
             $("#<%= ddlSearch.ClientID%>").selectpicker();
             $("#<%= ddlAvail.ClientID%>").selectpicker();
             $("#<%= ddlVesselSea.ClientID%>").selectpicker();
             $("#<%= ddlVesselSeaUp.ClientID%>").selectpicker();
            $("#<%= ddlFL.ClientID%>").selectpicker();
            $("#<%= ddlFLs.ClientID%>").selectpicker();

             $("#<%= ddlMedRank.ClientID%>").selectpicker();
             $("#<%= ddlCoe.ClientID%>").selectpicker();
             $("#<%= ddlMedVessel.ClientID%>").selectpicker();
             $("#<%= ddlMonths.ClientID%>").selectpicker();
             $("#<%= ddlTest.ClientID%>").selectpicker();
             $("#<%= ddlMedRankU.ClientID%>").selectpicker();
             $("#<%= ddlCoeU.ClientID%>").selectpicker();
             $("#<%= ddlMedVesselU.ClientID%>").selectpicker();
             $("#<%= ddlMonthsU.ClientID%>").selectpicker();
             $("#<%= ddlTestU.ClientID%>").selectpicker
             $("#<%= ddlReason.ClientID%>").selectpicker();
             $("#<%= ddlReasonU.ClientID%>").selectpicker();

             $(".selectpicker").selectpicker();
         });

         function RefreshDDL() {
             $("#<%= ddlCrewStatus.ClientID%>").selectpicker();
            $("#<%= ddlVessels.ClientID%>").selectpicker();
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();
            $("#<%= ddlCivilStatus.ClientID%>").selectpicker();
            $("#<%= ddlFlagstate.ClientID%>").selectpicker();
            $("#<%= ddlTrainingCenter.ClientID%>").selectpicker();
            $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlRelationship.ClientID%>").selectpicker();
            $("#<%= ddlRank2.ClientID%>").selectpicker();
            <%--            $("#<%= ddlFlag.ClientID%>").selectpicker();
            $("#<%= ddlVesselType.ClientID%>").selectpicker();--%>
            $("#<%= ddlERelationship.ClientID%>").selectpicker();
            $("#<%= ddlFlagstateUpdate.ClientID%>").selectpicker();
            $("#<%= ddlTrainingCenterU.ClientID%>").selectpicker();
            $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
            $("#<%= ddlAllotVessels.ClientID%>").selectpicker();
            $("#<%= ddlAllotVesselU.ClientID%>").selectpicker();
            $("#<%= ddlRank3.ClientID%>").selectpicker();
            <%--$("#<%= ddlVesselType2.ClientID%>").selectpicker();--%>
            $("#<%= ddlSearch.ClientID%>").selectpicker();
            $("#<%= ddlAvail.ClientID%>").selectpicker();
            $("#<%= ddlVesselSea.ClientID%>").selectpicker();
            $("#<%= ddlVesselSeaUp.ClientID%>").selectpicker();
            $("#<%= ddlFL.ClientID%>").selectpicker();
            $("#<%= ddlFLs.ClientID%>").selectpicker();

            $("#<%= ddlMedRank.ClientID%>").selectpicker();
            $("#<%= ddlCoe.ClientID%>").selectpicker();
            $("#<%= ddlMedVessel.ClientID%>").selectpicker();
            $("#<%= ddlMonths.ClientID%>").selectpicker();
            $("#<%= ddlTest.ClientID%>").selectpicker();
            $("#<%= ddlMedRankU.ClientID%>").selectpicker();
            $("#<%= ddlCoeU.ClientID%>").selectpicker();
            $("#<%= ddlMedVesselU.ClientID%>").selectpicker();
            $("#<%= ddlMonthsU.ClientID%>").selectpicker();
            $("#<%= ddlTestU.ClientID%>").selectpicker();
            $("#<%= ddlReason.ClientID%>").selectpicker();
            $("#<%= ddlReasonU.ClientID%>").selectpicker();


        }
        //$(function () {
        //    RefreshDDL()
        //});
        function pageLoad(sender, args) {
           // RefreshDDL()

            $('[id*=GenderM]').bootstrapToggle({
                on: 'FEMALE',
                off: 'MALE',
                onstyle: 'primary',
                offstyle: 'success'
            });
            //$('[id*=ENextKin]').bootstrapToggle({
            //    on: 'NO',
            //    off: 'YES',
            //    onstyle: 'primary',
            //    offstyle: 'default'
            //});
            $('[id*=chkAllotArchiveU]').bootstrapToggle({
                on: 'NO',
                off: 'YES',
                onstyle: 'primary',
                offstyle: 'success'
            });
            $('[id*=chkArchiveUpdate]').bootstrapToggle({
                on: 'NO',
                off: 'YES',
                onstyle: 'primary',
                offstyle: 'success'
            });
            $('[id*=NextKin2]').bootstrapToggle({
                on: 'NO',
                off: 'YES',
                onstyle: 'primary',
                offstyle: 'success'
            });
            $('[id*=ENextKin2]').bootstrapToggle({
                on: 'NO',
                off: 'YES',
                onstyle: 'primary',
                offstyle: 'success'
            });
        }

        function openModalP() {
            $('#UpPhoto').modal('show');
        }
        function openModalO() {
            $('#overinfo').modal('show');
        }
        function openModalJ() {
            $('#joining').modal('show');
        }
        function openModalS() {
            $('#signed').modal('show');
        }
        function openModalDu() {
            $('#CrewDocU').modal('show');
        }
        function openModalD() {
            $('#CrewDoc').modal('show');
        }
        function openModalDs() {
            $('#CrewDocs').modal('show');
        }
        function openModalF() {
            $('#FamPic').modal('show');
        }
        function openModalA() {
            $('#AllotModal').modal('show');
        }
        function openModalAu() {
            $('#AllotModalU').modal('show');
        }
        function openModalAddfam() {
            $('#AddFam2').modal('show');
        }
        function openModaleditfam() {
            $('#EditFam').modal('show');
        }
        function openModalEss() {
            $('#ESSModal').modal('show');
        }
        function openModalEssU() {
            $('#ESSModalU').modal('show');
        }
        function openModalEvalA() {
            $('#UpSeaAddEval').modal('show');
        }
        function openModalEvalG() {
            $('#UpSeaGridEval').modal('show');
        }
        function openModalEvalV() {
            $('#UpSeaViewEval').modal('show');
        }
        function openModalcon() {
            $('#mcontract').modal('show');
        }
        function openModalMedHis() {
            $('#MedHis').modal('show');
        }
        function openModalMedHisU() {
            $('#MedHisu').modal('show');
        }
        function openModalPass() {
            $('#Pass').modal('show');
        }
        function openModalPayslip() {
            $('#payslipM').modal('show');
        }

    </script>

    


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <div class="row">
                <div class="col-sm-4">
                    <h5 class="m-b-10">CREW PROFILE</h5>
                </div>

                <div class="col-sm-8 pull-right">
                    <div class="form-group row">
                        <div class="input-group">
                            <asp:DropDownList ID="ddlSearch" runat="server" CssClass="form-control selectpicker" placeholder="Select Last Name" data-live-search="true"></asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="lbGo" runat="server" CssClass="input-group-addon search-btn"><i class="ti-search"></i></asp:LinkButton>
                                <%--<button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                    <i class="ti-search"></i>
                                </button>--%>
                            </span>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="row">


                            <div class="col-sm-3">
                                <div class="rounded-card">
                                    <div class="img-hover">
                                        <asp:Image ID="CrewImage" runat="server" Width="200px" Height="200px"
                                            AlternateText="Photo"
                                            ImageAlign="Middle"
                                            ImageUrl="PhotoPic/cmale.png" CssClass="img-fluid img-radius" />
                                        <asp:HiddenField ID="hdnPhotoSource" runat="server"></asp:HiddenField>
                                    </div>
                                    <div class="user-content">
                                        <font color="red"><asp:Label ID="lblWarning" runat="server" Text=""></asp:Label></font>
                                        <asp:LinkButton ID="lbChangePic" runat="server" CssClass="btn btn-primary" data-toggle="modal" data-target="#UpPhoto">Change Crew Photo</asp:LinkButton>
                                    </div>
                                    <div class="user-content">
                                        <asp:LinkButton ID="lbOver" runat="server" CssClass="btn btn-primary">View Overall Info</asp:LinkButton>
                                    </div>
                                    <div class="user-content">
                                        <asp:LinkButton ID="lbJoining" runat="server" CssClass="btn btn-primary">Joining Routing Slip</asp:LinkButton>
                                    </div>
                                    <div class="user-content">
                                        <asp:LinkButton ID="lbSignoff" runat="server" CssClass="btn btn-warning">Signed-Off Routing Slip</asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-5">
                                <div class="panel panel-default">
                                    <h4 class="m-b-10">
                                        <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnID" runat="server" />
                                        <asp:HiddenField ID="hdnAllotteeCode" runat="server" />
                                        <asp:HiddenField ID="hdnCrewNo" runat="server" />
                                        <asp:HiddenField ID="hdnCrewStatus" runat="server" />
                                        <asp:HiddenField ID="hdnQueue" runat="server" />
                                        <asp:HiddenField ID="hdnPrincipalCode" runat="server" />
                                    </h4>
                                    <div class="panel-body">

                                        <asp:MultiView ID="mvProfile" runat="server">

                                            <asp:View ID="vProfileInfo" runat="server">

                                                <ul class="basic-list list-icons">
                                                    <li>
                                                        <i class="fa fa-briefcase text-primary p-absolute text-center d-block f-20"></i>
                                                        Rank:
                                        <asp:Label ID="lblRank" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Date Hired: 
                                        <asp:Label ID="lblDateHired" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-birthday-cake text-primary p-absolute text-center d-block f-20"></i>
                                                        Birthday:
                                        <asp:Label ID="lblBirthday" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-birthday-cake text-primary p-absolute text-center d-block f-20"></i>
                                                        Birth Place:
                                        <asp:Label ID="lblBirthplace" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-map-marker text-primary p-absolute text-center d-block f-20"></i>
                                                        Address:
                                        <asp:Label ID="lblAddress" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-phone text-primary p-absolute text-center d-block f-20"></i>
                                                        Contact No: 
                                        <asp:Label ID="lblContactNo" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-envelope text-primary p-absolute text-center d-block f-20"></i>
                                                        Email:
                                        <asp:Label ID="lblEmail" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-building text-primary p-absolute text-center d-block f-20"></i>
                                                        Civil Status: 
                                        <asp:Label ID="lblCivilStatus" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-building text-primary p-absolute text-center d-block f-20"></i>
                                                        School: 
                                        <asp:Label ID="lblSchool" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-certificate text-primary p-absolute text-center d-block f-20"></i>
                                                        Course: 
                                        <asp:Label ID="lblCourse" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Year Graduated: 
                                        <asp:Label ID="lblYearGraduated" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                </ul>
                                                <asp:LinkButton ID="lbEditProfile" runat="server" CssClass="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Edit Profile</asp:LinkButton>

                                            </asp:View>


                                            <asp:View ID="vEditProfileInfo" runat="server">

                                                <ul class="basic-list">
                                                    <li>
                                                        <i class="fa fa-briefcase text-primary p-absolute text-center d-block f-20"></i>
                                                        Rank:
                                        <asp:DropDownList ID="ddlRank" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-birthday-cake text-primary p-absolute text-center d-block f-20"></i>
                                                        Date Hired:
                                        <asp:TextBox ID="txtDateHired" runat="server" CssClass="form-control form-control-round"  TextMode="Date"></asp:TextBox>
                                                      <%--  <ajax:CalendarExtender ID="ceDateHired" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDateHired" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtDateHired" />--%>
                                                    </li>
                                                    <li><i class="fa fa-birthday-cake text-primary p-absolute text-center d-block f-20"></i>
                                                        Birthday:
                                        <asp:TextBox ID="txtBirthdate" runat="server" CssClass="form-control form-control-round" placeholder="DD/MM/YYYY" TextMode="Date"></asp:TextBox>
                                                       <%-- <ajax:CalendarExtender ID="ceBirthdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtBirthdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtBirthdate" />--%>
                                                    </li>
                                                    <li><i class="fa fa-map-marker text-primary p-absolute text-center d-block f-20"></i>
                                                        Birth Place:
                                                        <asp:TextBox ID="txtBirthplace" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Birthplace"></asp:TextBox>
                                                    </li>

                                                    <li><i class="fa fa-map-marker text-primary p-absolute text-center d-block f-20"></i>
                                                        Address:
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-round"></asp:TextBox>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-phone text-primary p-absolute text-center d-block f-20"></i>
                                                        ContactNo:
                                                 <asp:TextBox ID="txtProfileContactNo" runat="server" CssClass="form-control form-control-round">
                                                 </asp:TextBox>
                                                        <%--  <asp:TextBox ID="txtProfileContactNo" runat="server" CssClass="form-control form-control-round"
                                                            onkeydown="if(event.keyCode<32 || event.keyCode>32 && (event.keyCode<40 || event.keyCode>41) && (event.keyCode<43 || event.keyCode>47) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                        </asp:TextBox>--%>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-envelope text-primary p-absolute text-center d-block f-20"></i>
                                                        Email: 
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-round"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address!"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-user text-primary p-absolute text-center d-block f-20"></i>
                                                        Civil Status:  
                                                        <asp:DropDownList ID="ddlCivilStatus" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Civil Status" data-live-search="true"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-building text-primary p-absolute text-center d-block f-20"></i>
                                                        School:  
                                        <asp:TextBox ID="txtSchool" runat="server" CssClass="form-control form-control-round"></asp:TextBox>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-certificate text-primary p-absolute text-center d-block f-20"></i>
                                                        Course:  
                                        <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control form-control-round"></asp:TextBox>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Year Graduated:
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                        <%--<asp:TextBox ID="txtYearGrad" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                    </li>
                                                </ul>
                                                <br />
                                                <asp:LinkButton ID="lbUpdateProfile" runat="server" CssClass="btn btn-success pull-right"><i class="fa fa-edit m-right-xs"></i>Update Profile</asp:LinkButton>
                                                <asp:LinkButton ID="lbCancelProfile" runat="server" CssClass="btn btn-success pull-left"><i class="fa fa-edit m-right-xs"></i>Cancel Update</asp:LinkButton>

                                            </asp:View>

                                        </asp:MultiView>

                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <div class="panel panel-default">
                                    <h4 class="m-b-10">
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </h4>
                                    <div class="panel-body">

                                        <asp:MultiView ID="mvVesselStat" runat="server">
                                            <asp:View ID="vProfileVessel" runat="server">

                                                <ul class="basic-list list-icons">
                                                    <li>
                                                        <i class="fa fa-anchor text-primary p-absolute text-center d-block f-20"></i>
                                                        Crew Status:
                                        <asp:Label ID="lblCrewStatus" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-ship text-primary p-absolute text-center d-block f-20"></i>
                                                        Vessel: 
                                        <asp:Label ID="lblVessel" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-ship text-primary p-absolute text-center d-block f-20"></i>
                                                        Contract Duration: 
                                        <asp:Label ID="lblContractDuration" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-star-o text-primary p-absolute text-center d-block f-20"></i>
                                                        Scale: 
                                        <asp:Label ID="lblScale" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Sign On:
                                        <asp:Label ID="lblSignOn" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Sign Off:
                                        <asp:Label ID="lblSignOff" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Arrival Date:
                                        <asp:Label ID="lblArrival" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Report Date:
                                        <asp:Label ID="lblReport" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Availability:
                                        <asp:Label ID="lblAvail" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                    <li>
                                                        <i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Remarks:
                                        <asp:Label ID="lblAvailRemarks" runat="server" Font-Bold="true"></asp:Label>
                                                    </li>
                                                </ul>
                                                <br />
                                                <asp:LinkButton ID="lbEditProfileVessel" runat="server" CssClass="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Edit Sea Service Details</asp:LinkButton>

                                            </asp:View>


                                            <asp:View ID="vProfileVesselEdit" runat="server">


                                                <ul class="basic-list">
                                                    <li><i class="fa fa-anchor text-primary p-absolute text-center d-block f-20"></i>
                                                        Crew Status:
                                                <%--                                        <asp:DropDownList ID="ddlCrewStatus" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>--%>
                                                        <asp:DropDownList ID="ddlCrewStatus" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-ship text-primary p-absolute text-center d-block f-20"></i>
                                                        Vessel:
                                        <asp:DropDownList ID="ddlVessels" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-ship text-primary p-absolute text-center d-block f-20"></i>
                                                        Contract Duration:
                                        <asp:DropDownList ID="ddlContract" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        </asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-star-o text-primary p-absolute text-center d-block f-20"></i>
                                                        Scale:
                                        <asp:DropDownList ID="ddlScale" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="[--BLANK--]" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Sign On:
                                                 <asp:TextBox ID="txtSignOn" runat="server" CssClass="form-control form-control-round" placeholder="DD/MM/YYYY"   TextMode="Date" ></asp:TextBox>
                                                    <%--    <ajax:CalendarExtender ID="ceSignOn" PopupButtonID="imgPopup" runat="server" TargetControlID="txtSignOn" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Enabled="True" Mask="31/12/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtSignOn" />--%>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Sign Off:
                                                 <asp:TextBox ID="txtSignOff" runat="server" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY" TextMode="Date"></asp:TextBox>
                                                     <%--   <ajax:CalendarExtender ID="ceSignOff" PopupButtonID="imgPopup" runat="server" TargetControlID="txtSignOff" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtSignOff" />--%>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Arrival:
                                                 <asp:TextBox ID="txtArrival" runat="server" CssClass="form-control form-control-round"  TextMode="Date"></asp:TextBox>
                                                      <%--  <ajax:CalendarExtender ID="ceArrival" PopupButtonID="imgPopup" runat="server" TargetControlID="txtArrival" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtArrival" />--%>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Report:
                                                 <asp:TextBox ID="txtReport" runat="server" CssClass="form-control form-control-round" TextMode="Date"></asp:TextBox>
                                                      <%--  <ajax:CalendarExtender ID="ceReport" PopupButtonID="imgPopup" runat="server" TargetControlID="txtReport" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                            InputDirection="LefttoRight" TargetControlID="txtReport" />--%>
                                                    </li>
                                                    <li><i class="fa fa-calendar text-primary p-absolute text-center d-block f-20"></i>
                                                        Availability:
                                                 <asp:DropDownList ID="ddlAvail" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true">
                                                     <asp:ListItem Text="[--BLANK--]" Value=" "></asp:ListItem>
                                                     <asp:ListItem Text="JANUARY" Value="JAN"></asp:ListItem>
                                                     <asp:ListItem Text="FEBRUARY" Value="FEB"></asp:ListItem>
                                                     <asp:ListItem Text="MARCH" Value="MAR"></asp:ListItem>
                                                     <asp:ListItem Text="APRIL" Value="APR"></asp:ListItem>
                                                     <asp:ListItem Text="MAY" Value="MAY"></asp:ListItem>
                                                     <asp:ListItem Text="JUNE" Value="JUN"></asp:ListItem>
                                                     <asp:ListItem Text="JULY" Value="JUL"></asp:ListItem>
                                                     <asp:ListItem Text="AUGUST" Value="AUG"></asp:ListItem>
                                                     <asp:ListItem Text="SEPTEMBER" Value="SEPT"></asp:ListItem>
                                                     <asp:ListItem Text="OCTOBER" Value="OCT"></asp:ListItem>
                                                     <asp:ListItem Text="NOVEMBER" Value="NOV"></asp:ListItem>
                                                     <asp:ListItem Text="DECEMBER" Value="DEC"></asp:ListItem>
                                                 </asp:DropDownList>
                                                    </li>
                                                    <li><i class="fa fa-bookmark text-primary p-absolute text-center d-block f-20"></i>
                                                        Remarks:
                                                 <asp:TextBox ID="txtAvailRemarks" runat="server" CssClass="form-control form-control-round" placeholder="Availability Remarks"></asp:TextBox>
                                                    </li>
                                                </ul>
                                                <br />
                                                <asp:HiddenField ID="hdnCallSign" runat="server" />
                                                <asp:HiddenField ID="hdnGRT" runat="server" />
                                                <asp:HiddenField ID="hdnEngineType" runat="server" />
                                                <asp:HiddenField ID="hdnVesselType" runat="server" />
                                                <asp:HiddenField ID="hdnFlag" runat="server" />

                                                <asp:LinkButton ID="lbProfileVesselUpdate" runat="server" CssClass="btn btn-success pull-right"><i class="fa fa-edit m-right-xs"></i>Update</asp:LinkButton>
                                                <asp:LinkButton ID="lbCancelProfileVessel" runat="server" CssClass="btn btn-success pull-left"><i class="fa fa-edit m-right-xs"></i>Cancel Update</asp:LinkButton>

                                            </asp:View>

                                        </asp:MultiView>

                                    </div>
                                </div>
                            </div>


                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbCancelProfile" />
                        <asp:AsyncPostBackTrigger ControlID="lbUpdateProfile" />

                        <asp:AsyncPostBackTrigger ControlID="lbCancelProfileVessel" />
                        <asp:AsyncPostBackTrigger ControlID="lbProfileVesselUpdate" />

                        <asp:AsyncPostBackTrigger ControlID="lbCancelUpdate2" />
                        <asp:AsyncPostBackTrigger ControlID="lbUpdateProfile2" />

                        <asp:PostBackTrigger ControlID="lbUploadPhoto" />
                    </Triggers>
                </asp:UpdatePanel>



                <div class="card-block tab-icon">

                    <div id="tabsmain" class="row">
                        <div class="col-lg-12 col-xl-12">

                            <ul class="nav nav-tabs md-tabs nav-justified" role="tablist" id="maintab">
                                <li class="nav-item">
                                    <a class="nav-link active" runat="server" id="aprofile" data-toggle="tab" href="#profile1" role="tab"><i class="icofont icofont-home"></i>Profile</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" runat="server" id="adocuments" data-toggle="tab" href="#documents" role="tab"><i class="icofont icofont-home"></i>Documents</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" runat="server" id="aallotment" data-toggle="tab" href="#allotment" role="tab"><i class="icofont icofont-home"></i>Allotment</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" runat="server" id="aseaservice" data-toggle="tab" href="#seaservice" role="tab"><i class="icofont icofont-home"></i>Sea Service</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item" id="tabpayslip" runat="server">
                                    <a class="nav-link" data-toggle="tab" href="#payslip" role="tab"><i class="icofont icofont-home"></i>Pay Slip</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" runat="server" id="acontract" data-toggle="tab" href="#contract" role="tab"><i class="icofont icofont-home"></i>Crew Contract</a>
                                    <div class="slide"></div>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" runat="server" id="amedhistory" data-toggle="tab" href="#medhistory" role="tab"><i class="icofont icofont-home"></i>Medical History</a>
                                    <div class="slide"></div>
                                </li>
                            </ul>

                            <div class="tab-content card-block">

                                <div class="tab-pane active" id="profile1" role="tabpanel">

                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>

                                            <asp:MultiView ID="mvProfile2" runat="server">


                                                <asp:View ID="vProfile" runat="server">

                                                    <div class="card-header">
                                                        <asp:LinkButton ID="lbEditProfile2" runat="server" CssClass="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Edit Profile</asp:LinkButton>
                                                        <asp:Button ID="btnShowPassword" runat="server" CssClass="btn btn-info" Text="Show Password" UseSubmitBehavior="false" />
                                                    </div>
                                                    <div class="row">

                                                        <div class="col-lg-12 col-xl-6">
                                                            <ul class="basic-list">
                                                                <li>Crew Number:
                                                        <asp:Label ID="lblCrewNo" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>Gender:
                                                        <asp:Label ID="lblIsmale" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                              <%--  <li>Address 2:
                                                        <asp:Label ID="lblSAddress" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>--%>
                                                                <li>SSS Number:
                                                        <asp:Label ID="lblSSS" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>Philhealth:
                                                        <asp:Label ID="lblPhilhealth" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>PAGIBIG:
                                                        <asp:Label ID="lblPagibig" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                        <div class="col-lg-12 col-xl-6">
                                                            <ul class="basic-list">
                                                                <li>TIN Number:
                                                        <asp:Label ID="lblTIN" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>SRC:
                                                        <asp:Label ID="lblSrc" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>SIRB:
                                                        <asp:Label ID="lblSirb" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>License Number:
                                                        <asp:Label ID="lblLicense" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                                <li>Remarks:
                                                        <asp:Label ID="lblRemarks" runat="server" Font-Bold="true"></asp:Label>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                </asp:View>

                                                <asp:View ID="vProfileEdit" runat="server">

                                                    <div class="row">

                                                        <div class="col-lg-12 col-xl-6">
                                                            <ul class="basic-list">
                                                                <li>Crew Number:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtCrewNo" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Crew Number" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>Last Name:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtLName" runat="server" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>First Name:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtFName" runat="server" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>Middle Name:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtMidName" runat="server" CssClass="form-control form-control-round" placeholder="Middle Name"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>Gender:
                                                            <div class="form-group row">
                                                                <input id="GenderM" type="checkbox" runat="server" />
                                                                <asp:HiddenField ID="hdnIsMale" runat="server" />
                                                            </div>
                                                                </li>
                                                               <%-- <li>Address 2:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtSAddress" runat="server" CssClass="form-control form-control-round" placeholder="Secondary Address" TextMode="MultiLine"></asp:TextBox>
                                                            </div>--%>
                                                                </li>
                                                                <li>SSS Number:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtSSS" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SSS Number"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="meeSSS" runat="server" Enabled="True" Mask="99-99999999" MaskType="Number"
                                                                    InputDirection="LefttoRight" TargetControlID="txtSSS" />
                                                            </div>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                        <div class="col-lg-12 col-xl-6">
                                                            <ul class="basic-list">
                                                                <li>Philhealth:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtPhilHealth" runat="server" required="required" CssClass="form-control form-control-round" placeholder="PhilHealth"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="meePhilHealth" runat="server" Enabled="True" Mask="99-9999999999" MaskType="Number"
                                                                    InputDirection="LefttoRight" TargetControlID="txtPhilHealth" />
                                                            </div>
                                                                </li>
                                                                <li>PAGIBIG:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtPagibig" runat="server" required="required" CssClass="form-control form-control-round" placeholder="PAGIBIG"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="meePagibig" runat="server" Enabled="True" Mask="99-9999999999" MaskType="Number"
                                                                    InputDirection="LefttoRight" TargetControlID="txtPagibig" />
                                                            </div>
                                                                </li>
                                                                <li>TIN Number:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtTIN" runat="server" required="required" CssClass="form-control form-control-round" placeholder="TIN"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="meeTIN" runat="server" Enabled="True" Mask="999-999-999" MaskType="Number"
                                                                    InputDirection="LefttoRight" TargetControlID="txtTIN" />
                                                            </div>
                                                                </li>
                                                                <li>SRC:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtSrc" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SRC"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>SIRB:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtSirb" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SIRB"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>License Number:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtLicense" runat="server" required="required" CssClass="form-control form-control-round" placeholder="License Number"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                                <li>Remarks:
                                                            <div class="form-group row">
                                                                <asp:TextBox ID="txtCRemarks" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                                </li>
                                                            </ul>

                                                        </div>

                                                        <div class="col-lg-12 col-xl-12">
                                                            <asp:LinkButton ID="lbUpdateProfile2" runat="server" CssClass="btn btn-success pull-right"><i class="fa fa-edit m-right-xs"></i>Update Profile</asp:LinkButton>
                                                            <asp:LinkButton ID="lbCancelUpdate2" runat="server" CssClass="btn btn-success pull-left"><i class="fa fa-edit m-right-xs"></i>Cancel Update</asp:LinkButton>
                                                        </div>

                                                        <asp:HiddenField ID="hdnCOP" runat="server"></asp:HiddenField>

                                                    </div>

                                                </asp:View>


                                            </asp:MultiView>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lbCancelUpdate2" />
                                            <asp:AsyncPostBackTrigger ControlID="lbUpdateProfile2" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>

                                <div class="tab-pane" id="documents" role="tabpanel">
                                    <div id="tabdocs">
                                        <div class="col-lg-12 col-xl-12">
                                            <button type="button" name="btnAddDoc" id="btnAddDoc" class="btn btn-success" data-toggle="modal" data-target="#CrewDoc" runat="server">Add Crew Documents</button>
                                        </div>
                                        <%-- <div class="col-lg-12 col-xl-12">
                                            <ul class="nav nav-tabs md-tabs nav-justified" role="tablist">
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#flagstate" role="tab"><i class="icofont icofont-home"></i>Flagstate</a>
                                                    <div class="slide"></div>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#training" role="tab"><i class="icofont icofont-home"></i>Training</a>
                                                    <div class="slide"></div>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#travel" role="tab"><i class="icofont icofont-home"></i>Travel</a>
                                                    <div class="slide"></div>
                                                </li>
                                            </ul>
                                        </div>--%>

                                        <div class="tab-content">

                                            <%--<div class="tab-pane" id="flagstate" role="tabpanel">--%>
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
                                                        <ajaxToolkit:TabPanel ID="tflagstate" runat="server">
                                                            <HeaderTemplate>Flagstate</HeaderTemplate>
                                                            <ContentTemplate>
                                                                <div class="table-responsive">
                                                                    <%--     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>--%>

                                                                    <asp:GridView ID="gdFlagstate" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Document Title" SortExpression="DocTitle">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbDoc2" runat="server" Text='<%#Eval("DocTitle")%>' CommandName="ViewDocs2" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                                    <asp:HiddenField ID="hdnDocFlag" runat="server" Value='<%#Bind("ExpiryDate")%>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DocNo" HeaderText="Document Number" />
                                                                            <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                        </Columns>

                                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                                        <HeaderStyle ForeColor="Blue" />

                                                                    </asp:GridView>

                                                                    <%--  </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                                </div>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <%--</div>--%>


                                                        <%--<div class="tab-pane" id="training" role="tabpanel">--%>

                                                        <ajaxToolkit:TabPanel ID="ttraining" runat="server">
                                                            <HeaderTemplate>Training</HeaderTemplate>
                                                            <ContentTemplate>
                                                                <div class="table-responsive">

                                                                    <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>--%>

                                                                    <asp:GridView ID="gdTraining" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Document Title" SortExpression="DocTitle">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbDoc4" runat="server" Text='<%#Eval("DocTitle")%>' CommandName="ViewDocs4" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                                    <asp:HiddenField ID="hdnDocTraining" runat="server" Value='<%#Bind("ExpiryDate")%>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DocNo" HeaderText="Document Number" />
                                                                            <asp:BoundField DataField="TrainingCenter" HeaderText="Training Center" SortExpression="TrainingCenter" />
                                                                            <asp:BoundField DataField="IssuedDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="ExpiryDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                        </Columns>

                                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                                        <HeaderStyle ForeColor="Blue" />

                                                                    </asp:GridView>

                                                                    <%-- </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                                </div>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <%-- </div>--%>


                                                        <%--<div class="tab-pane" id="travel" role="tabpanel">--%>

                                                        <ajaxToolkit:TabPanel ID="ttravel" runat="server">
                                                            <HeaderTemplate>Travel</HeaderTemplate>
                                                            <ContentTemplate>
                                                                <div class="table-responsive">

                                                                    <%--        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>--%>

                                                                    <asp:GridView ID="gdTravel" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Document Title" SortExpression="DocTitle">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbDoc1" runat="server" Text='<%#Eval("DocTitle")%>' CommandName="ViewDocs1" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                                    <asp:HiddenField ID="hdnDocTravel" runat="server" Value='<%#Bind("ExpiryDate")%>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DocNo" HeaderText="Document Number" />
                                                                            <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                        </Columns>

                                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                                        <HeaderStyle ForeColor="Blue" />

                                                                    </asp:GridView>

                                                                    <%-- </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                                </div>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <%--</div>--%>
                                                    </ajaxToolkit:TabContainer>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane" id="allotment" role="tabpanel">

                                    <div class="col-lg-12 col-xl-12">
                                        <button type="button" name="btnAddFam2" id="btnAddFam2" class="btn btn-success" data-toggle="modal" data-target="#AddFam2" runat="server">Add Family Member</button>
                                        <button type="button" name="btnAddFam" id="btnAddFam" class="btn btn-success" data-toggle="modal" data-target="#AllotModal" runat="server">Add Allotment</button>
                                    </div>

                                    <br />

                                    <div class="col-lg-12 col-xl-12">

                                        <div class="table-responsive">

                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>


                                                    <asp:GridView ID="gdFamList" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="AlloteeName" SortExpression="AlloteeName">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbCrewNo" runat="server" Text='<%#Eval("AllotteeName")%>' CommandName="ViewAllottee" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="PrimaryAddress" />
                                                            <asp:BoundField DataField="Relationship" HeaderText="Relationship" SortExpression="Relationship" />
                                                            <asp:BoundField DataField="BankAccount" HeaderText="BankAccount" SortExpression="BankAccount" />
                                                            <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                                                            <asp:BoundField DataField="Allot" HeaderText="Allotment" SortExpression="Allotment" DataFormatString="{0:c}" />
                                                            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" SortExpression="ContactNo" />
                                                        </Columns>

                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                        <HeaderStyle ForeColor="Blue" />

                                                    </asp:GridView>


                                                    <asp:GridView ID="gvAllot" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                        <Columns>
                                                            <asp:BoundField DataField="VesselName" HeaderText="Vessel Name" SortExpression="VesselName" />
                                                            <asp:TemplateField HeaderText="Date" SortExpression="AllotDate">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbAllotDate" runat="server" Text='<%#Eval("AllotDate2")%>' CommandName="ViewAllottee" CommandArgument='<%#Eval("ID")%>' DataFormatString="{0:MM/dd/yyyy }" ItemStyle-HorizontalAlign="Center"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                                        </Columns>

                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                        <HeaderStyle ForeColor="Blue" />

                                                    </asp:GridView>

                                                </ContentTemplate>
                                                <Triggers>
                                                    <%-- <asp:AsyncPostBackTrigger ControlID="lbAddAllottee" EventName="Click" />--%>
                                                    <asp:PostBackTrigger ControlID="lbAddAllottee" />
                                                    <asp:PostBackTrigger ControlID="btnEditAllottee" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>

                                    </div>

                                </div>

                                <div class="tab-pane" id="seaservice" role="tabpanel">

                                    <div class="col-lg-12 col-xl-12">
                                        <button type="button" name="btnAddExSeaservice" id="btnAddExSeaservice" class="btn btn-success" data-toggle="modal" data-target="#ESSModal" runat="server">Add Sea Service</button>
                                    </div>
                                    <br />

                                    <div class="row">

                                        <div class="col-lg-12 col-xl-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="table-responsive">

                                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                            <ContentTemplate>

                                                                <asp:GridView ID="gvSeaRank" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RankDescription" HeaderText="Rank" />
                                                                        <asp:BoundField DataField="TotalYears" HeaderText="Total Years" />
                                                                    </Columns>

                                                                    <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                                    <HeaderStyle ForeColor="Blue" />

                                                                </asp:GridView>

                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnSaveESS" EventName="Click" />
                                                                <asp:PostBackTrigger ControlID="btnUploadEval" />
                                                                <asp:PostBackTrigger ControlID="btnUpEval" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>

                                                    </div>
                                                </div>

                                                <div class="col-sm-6">
                                                    <div class="table-responsive">

                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                            <ContentTemplate>

                                                                <asp:GridView ID="gvSeaTanker" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="VesselType" HeaderText="Vessel Type" />
                                                                        <asp:BoundField DataField="TotalYears" HeaderText="Total Years" />
                                                                    </Columns>

                                                                    <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                                    <HeaderStyle ForeColor="Blue" />

                                                                </asp:GridView>

                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnSaveESS" EventName="Click" />
                                                                <asp:PostBackTrigger ControlID="btnUploadEval" />
                                                                <asp:PostBackTrigger ControlID="btnUpEval" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <div class="col-lg-12 col-xl-12">
                                            <div class="table-responsive">

                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                    <ContentTemplate>

                                                        <asp:GridView ID="gdSeaService" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Rank" SortExpression="RankDescription">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbSea" runat="server" Text='<%#Eval("RankDescription")%>' CommandName="ViewSea" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="VesselName" HeaderText="Vessel Name" SortExpression="VesselName" />
                                                                <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                                                <asp:BoundField DataField="ContractDuration" HeaderText="Months" SortExpression="ContractDuration" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                                                <asp:BoundField DataField="EngineType" HeaderText="Engine Type" SortExpression="EngineType" />
                                                                <asp:BoundField DataField="SignOffReason" HeaderText="Sign Off Reason" SortExpression="SignOffReason" />
                                                                <asp:BoundField DataField="StartDate2" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="EndDate2" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:TemplateField HeaderText="Evaluation">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnAddEval" runat="server" Text="ADD" CssClass="text-primary" CommandName="ViewSea2" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                                        |
                                                        <asp:LinkButton ID="btnViewEval" runat="server" Text="VIEW" CssClass="text-primary" CommandName="ViewSea3" CommandArgument='<%#Eval("SeaServiceCode")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbDelete" runat="server" Text="X" CommandName="DeleteCrew" CommandArgument='<%#Eval("ID")%>' CssClass="btn btn-danger"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>

                                                            <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                            <HeaderStyle ForeColor="Blue" />

                                                        </asp:GridView>

                                                        <asp:GridView ID="gvSeaP" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                            <Columns>
                                                                <asp:BoundField DataField="RankDescription" HeaderText="Rank" SortExpression="RankDescription" />
                                                                <asp:BoundField DataField="VesselName" HeaderText="Vessel Name" SortExpression="VesselName" />
                                                                <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                                                <asp:BoundField DataField="ContractDuration" HeaderText="Months" SortExpression="ContractDuration" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                                                <asp:BoundField DataField="EngineType" HeaderText="Engine Type" SortExpression="EngineType" />
                                                                <asp:BoundField DataField="SignOffReason" HeaderText="Sign Off Reason" SortExpression="SignOffReason" />
                                                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:TemplateField HeaderText="Evaluation">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnViewEval" runat="server" Text="VIEW" CssClass="text-primary" CommandName="ViewSea3" CommandArgument='<%#Eval("SeaServiceCode")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>

                                                            <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                            <HeaderStyle ForeColor="Blue" />

                                                        </asp:GridView>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnSaveESS" EventName="Click" />
                                                        <asp:PostBackTrigger ControlID="btnUploadEval" />
                                                        <asp:PostBackTrigger ControlID="btnUpEval" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <div class="tab-pane" id="payslip" role="tabpanel">

                                    <div class="col-lg-12 col-xl-12">
                                        <div class="table-responsive">

                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>

                                                    <asp:GridView ID="gvPaySlip" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Payroll Date" SortExpression="PayrollDate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPayDate" runat="server" Text='<%# Bind("PayrollDate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Remit Date" SortExpression="RemitDate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRDate" runat="server" Text='<%# Bind("RemitDate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVName" runat="server" Text='<%# Bind("VesselName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Allottee Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAlCode" runat="server" Text='<%# Bind("AllotteeCode")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Allottee Name" SortExpression="AllotteeName">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPaySlipID" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Label ID="lblAName" runat="server" Text='<%# Bind("AllotteeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Allotment">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAllotments" runat="server" Text='<%# Bind("Allotment")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDRate" runat="server" Text='<%# Bind("DollarRate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total Income">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTIncome" runat="server" Text='<%# Bind("TotalIncome")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total Deductions">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTDeduc" runat="server" Text='<%# Bind("TotalDeduc")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Net Pay">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNPay" runat="server" Text='<%# Bind("NetPay")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:ButtonField ButtonType="Button" CommandName="ViewPaySlip" Text="View Payslip" ControlStyle-CssClass="btn btn-info" />
                                                        </Columns>

                                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                        <HeaderStyle ForeColor="Blue" />

                                                    </asp:GridView>

                                                </ContentTemplate>
                                                <Triggers>
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>

                                    </div>

                                </div>

                                <div class="tab-pane" id="contract" role="tabpanel">

                                    <%--Employer Name:
                                            <asp:DropDownList ID="ddlEmployer" runat="server" CssClass="form-control selectpicker">
                                                <asp:ListItem Text="BERNIE DELA CRUZ" Value="BERNIE DELA CRUZ"></asp:ListItem>
                                                <asp:ListItem Text="ALVIN A. VILLAFUERTE" Value="ALVIN A. VILLAFUERTE"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                     <div class="form-group row">
                                      <label class="col-sm-2 col-form-label">Signatory</label>

                                     
                                     <asp:DropDownList ID="ddlSignatory" runat="server" CssClass="form-control selectpicker">
                                               
                                            </asp:DropDownList>
                                         </div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lbContract" runat="server" CssClass="btn btn-primary"><i class="fa fa-download"></i> Generate Contract</asp:LinkButton>
                                       
                                            </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="tab-pane" id="medhistory" role="tabpanel">

                                    <div class="col-lg-12 col-xl-12">
                                        <button type="button" name="btnAddHistory" id="btnAddHistory" class="btn btn-success" data-toggle="modal" data-target="#MedHis" runat="server">Add Medical</button>
                                    </div>

                                    <br />

                                    <div class="table-responsive">

                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>

                                                <asp:GridView ID="gvMed" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Rank" SortExpression="RankDescription">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbRankMed" runat="server" Text='<%#Eval("RankDescription")%>' CommandName="ViewMed" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="CoE" HeaderText="CoE" />
                                                        <asp:BoundField DataField="VesselName" HeaderText="Vessel Assignment" />
                                                        <asp:BoundField DataField="MedExam2" HeaderText="Medical Exam Date" DataFormatString="{0:MM/dd/yyyy }" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField DataField="Fit2" HeaderText="Fit" DataFormatString="{0:MM/dd/yyyy }" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField DataField="Months" HeaderText="Months" />
                                                        <asp:BoundField DataField="Validity" HeaderText="Validity" DataFormatString="{0:MM/dd/yyyy }" />
                                                        <asp:BoundField DataField="TestType" HeaderText="Test Type" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbDelete2" runat="server" Text="X" CommandName="DeleteMed" CommandArgument='<%#Eval("ID")%>' CssClass="btn btn-danger"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                    <HeaderStyle ForeColor="Blue" />

                                                </asp:GridView>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnMedUpdate" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lbMedSave" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>



                </div>



            </div>
        </div>
    </div>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>


            <asp:HiddenField ID="hdnFName" runat="server" />
            <asp:HiddenField ID="hdnLName" runat="server" />
            <asp:HiddenField ID="hdnMName" runat="server" />
            <asp:HiddenField ID="hdnCurrent" runat="server" />
            <asp:HiddenField ID="TabName" runat="server" />
            <asp:HiddenField ID="hdnDocCurrent" runat="server" />
            <%--<asp:HiddenField ID="tabsdocs" runat="server" />--%>
            <asp:HiddenField ID="hdnAllotDoc" runat="server" />
            <asp:HiddenField ID="hdnPosition" runat="server" />
            <asp:HiddenField ID="hdnEvalPath" runat="server" />

            <asp:HiddenField ID="hdnTotalAllot" runat="server" />
            <asp:HiddenField ID="hdnAllotteeID" runat="server" />
            <asp:HiddenField ID="hdnTotalRemain" runat="server" />
            <asp:HiddenField ID="hdnTotalAllocation" runat="server" />
            <asp:HiddenField ID="hdnTotalAllocation2" runat="server" />


            <!-- Modal -->
            <div class="modal fade" id="UpPhoto" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Change Crew Photo</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Photo</label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="fuPhoto" runat="server"></asp:FileUpload>
                                    <asp:RegularExpressionValidator ControlToValidate="fuPhoto" ValidationExpression="^.*\.(png|PNG|jpg|jpeg|JPG|JPEG)$" runat="server" ErrorMessage="Upload valid Picture Formats!" CssClass="text-danger" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:LinkButton ID="lbUploadPhoto" runat="server" CssClass="btn btn-success waves-effect waves-light">SAVE</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="CrewDocs" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblDocTitle" runat="server" Text=""></asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <iframe id="ifPDF" runat="server" frameborder="0"
                                style="height: 80vh; width: 100%;"></iframe>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnUpdateCrewDoc" runat="server" Text="Update" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="CrewDocU" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Add Crew Document</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Flagstate<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlFlagstateUpdate" runat="server" CssClass="form-control selectpicker" placeholder="Select Flagstate" data-live-search="true"></asp:DropDownList>
                                    <asp:Label ID="lblFlagst1" runat="server" Text="For Flagstate and Travel" CssClass="text-text-info"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Training Center<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlTrainingCenterU" runat="server" CssClass="form-control selectpicker" placeholder="Select Training Center" data-live-search="true"></asp:DropDownList>
                                    <asp:Label ID="lblTrainingCe1" runat="server" Text="For Training" CssClass="text-text-info"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Document Title<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlDocCodeUpdate" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Document<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="fuDocUpdate" runat="server"></asp:FileUpload>
                                    <asp:RegularExpressionValidator ControlToValidate="fuPath" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                                </div>
                                <asp:Label ID="lblWarning3" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Document Number</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDocNoUpdate" runat="server" CssClass="form-control form-control-round" placeholder="Document Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Issued Date<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtIDateUpdate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceIDateUpdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtIDateUpdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtIDateUpdate" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Expiry Date<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExDateUpdate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExDateUpdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExDateUpdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExDateUpdate" />
                                    <asp:CheckBox ID="chkNoExpiryU" runat="server" Text="No Expiration" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Archive</label>
                                <div class="col-sm-10">
                                    <input id="chkArchiveUpdate" type="checkbox" runat="server" />
                                    <asp:HiddenField ID="hdnArchiveUpdate" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Remarks</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtRemarksUpdate" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnCrewDocuUpdate" runat="server" Text="Update Crew Document" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />

                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="FamPic" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblFamTitle" runat="server" Text=""></asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <iframe id="ifFamPic" runat="server" frameborder="0"
                                style="height: 80vh; width: 100%;"></iframe>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnFamUpdate" runat="server" Text="Update" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="AllotModal" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Add Allotment</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlAllotVessels" runat="server" CssClass="form-control selectpicker" placeholder="Select Vessel" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAllotDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceAllotDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtAllotDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender13" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtAllotDate" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Document</label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="fuAllot" runat="server"></asp:FileUpload>
                                    <asp:RegularExpressionValidator ControlToValidate="fuAllot" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                                    <asp:Label ID="lblWarningAllot" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Document</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAllotRemarks" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="lbAddAllottee" runat="server" Text="Add Allotment" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="AllotModalU" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Update Allotment</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlAllotVesselU" runat="server" CssClass="form-control selectpicker" placeholder="Select Vessel" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAllotDateU" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceAllotDateU" PopupButtonID="imgPopup" runat="server" TargetControlID="txtAllotDateU" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtAllotDateU" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Document</label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="fuAllotDocU" runat="server"></asp:FileUpload>
                                    <asp:RegularExpressionValidator ControlToValidate="fuAllotDocU" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                                    <asp:Label ID="lblWarningAllotU" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Remarks</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAllotRemarksU" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Archive<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <input id="chkAllotArchiveU" type="checkbox" runat="server" />
                                    <asp:HiddenField ID="hdnArchAllot" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnEditAllottee" runat="server" Text="Update Allottee" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="AddFam2" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Family</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Is Next of Kin</label>
                                <div class="col-sm-10">
                                    <input id="NextKin2" type="checkbox" runat="server" />
                                    <asp:HiddenField ID="hdnNextKin" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Last Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtLFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">First Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Middle Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtMFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Middle Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Address 1<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFPAddress" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address 1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Address 2</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFSAddress" runat="server" CssClass="form-control form-control-round" placeholder="Address 2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Relationship</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlRelationship" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Relationship" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Bank Account</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtBankAccount" runat="server" CssClass="form-control form-control-round" placeholder="Bank Account"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Branch</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtBranch" runat="server" CssClass="form-control form-control-round" placeholder="Branch"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Allotment<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAllotment" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Allotment"
                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                    </asp:TextBox>
                                    <asp:Label ID="lblAllotNote" runat="server" Text="" CssClass="text-text-info"></asp:Label>
                                    <asp:Label ID="lblErrorAllot" runat="server" Text="Allotment Allocation Exceeded!" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Allotment<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtZipCode" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Zip Code"
                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                    </asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="meZip" runat="server" Enabled="True" Mask="9999" MaskType="Number"
                                        InputDirection="LefttoRight" TargetControlID="txtZipCode" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Contact Number</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control form-control-round" placeholder="Contact Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:LinkButton ID="lbAddAllottee2" runat="server" CssClass="btn btn-success pull-right">Save Allottee</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="EditFam" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Family</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Is Next of Kin</label>
                                <div class="col-sm-10">
                                    <input id="ENextKin2" type="checkbox" runat="server" />
                                    <asp:HiddenField ID="hdnKinNextE" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Last Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtELFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">First Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEFFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Middle Name<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEMFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Middle Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Address 1<span class="required">*</span> </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEFPAddress" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address 1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Address 2</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEFSAddress" runat="server" CssClass="form-control form-control-round" placeholder="Address 2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Relationship</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlERelationship" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Relationship" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Bank Account</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEBankAccount" runat="server" CssClass="form-control form-control-round" placeholder="Bank Account"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Branch</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEBranch" runat="server" CssClass="form-control form-control-round" placeholder="Branch"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Allotment<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEAllotment" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Allotment"
                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                    </asp:TextBox>
                                    <asp:Label ID="lblAllotEdit" runat="server" Text="" CssClass="text-text-info"></asp:Label>
                                    <asp:Label ID="lblErrorAllotE" runat="server" Text="Allotment Allocation Exceeded!" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Allotment<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEZipCode" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Zip Code"
                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                    </asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="meZipE" runat="server" Enabled="True" Mask="9999" MaskType="Number"
                                        InputDirection="LefttoRight" TargetControlID="txtZipCode" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Contact Number</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEContactNo" runat="server" CssClass="form-control form-control-round" placeholder="Contact Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnEditAllottee2" runat="server" Text="Update Allottee" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="ESSModal" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Add Sea Service</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Rank</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlRank2" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                         <%--   <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Joining Port</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtJoiningPort" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Joining Port"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Embarking Port</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEmbarkingPort" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Embarking Port"></asp:TextBox>
                                </div>
                            </div>--%>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlVesselSea" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtVName" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Call Sign (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCallS" runat="server" CssClass="form-control form-control-round" placeholder="Call Sign"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">GRT (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtSGrt" runat="server" CssClass="form-control form-control-round" placeholder="GRT"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Engine Type (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtET" runat="server" CssClass="form-control form-control-round" placeholder="Engine Type"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Type (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtVS" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Type"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Flag (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlFL" runat="server" required="required" CssClass="form-control form-control-round selectpicker" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Sign Off Reason</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlReason" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Start Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExStartDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExStartDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExStartDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExStartDate" />

                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">End Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExEndDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExEndDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExEndDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExEndDate" />
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnSaveESS" runat="server" Text="Save Sea Service" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="ESSModalU" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Update Sea Service</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Rank</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlRank3" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                          <%--  <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Joining Port</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtJoiningPortUp" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Joining Port"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Embarking Port</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEmbarkingPortUp" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Embarking Port"></asp:TextBox>
                                </div>
                            </div>--%>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlVesselSeaUp" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Name (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtVNames" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Call Sign (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCallSs" runat="server" CssClass="form-control form-control-round" placeholder="Call Sign"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">GRT (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtSGrts" runat="server" CssClass="form-control form-control-round" placeholder="GRT"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Engine Type (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtETs" runat="server" CssClass="form-control form-control-round" placeholder="Engine Type"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel Type (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtVSs" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Type"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Flag (For External Seaservice)</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlFLs" runat="server" required="required" CssClass="form-control form-control-round selectpicker" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Sign Off Reason</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlReasonU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Start Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExStartDate2" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExStart2" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExStartDate2" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender15" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExStartDate2" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">End Date</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExEndDate2" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExEnd2" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExEndDate2" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender16" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExEndDate2" />
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnDelSea" runat="server" Text="Delete Sea Service" CssClass="btn btn-warning pull-left" UseSubmitBehavior="False" />
                            <asp:Button ID="btnUpdateSea" runat="server" Text="Update Sea Service" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="UpSeaGridEval" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Evaluations</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="table-responsive">

                                <asp:GridView ID="gvEval" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Document Title" SortExpression="DocTitle">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbSeaDoc" runat="server" Text='<%#Eval("Evaluation")%>' CommandName="ViewEval" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>

                                    <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                    <HeaderStyle ForeColor="Blue" HorizontalAlign="Center" />

                                </asp:GridView>

                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->



            <!-- Modal -->
            <div class="modal fade" id="UpSeaViewEval" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Evaluation</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <iframe id="ifEval" runat="server" frameborder="0"
                                style="position: relative; height: 80vh; width: 100%;"></iframe>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:FileUpload ID="fuEvalUpdate" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuEvalUpdate" ValidationExpression="^.*\.(png|PNG|jpg|jpeg|JPG|JPEG|pdf|PDF)$" runat="server" ErrorMessage="Upload valid Picture Formats!" CssClass="text-danger" />
                            <asp:Label ID="lblWarning5" runat="server" Text=""></asp:Label>
                            <asp:LinkButton ID="btnUpEval" runat="server" CssClass="btn btn-success waves-effect waves-light">Update</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="MedHis" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Medical History</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Rank</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMedRank" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">CoE</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlCoe" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="[--Select--]" Value=""></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMedVessel" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Medical Exam Date </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtMedDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceMedDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtMedDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender171" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtMedDate" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Fit Date </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFit" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceFit" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFit" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender181" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtFit" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Months</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMonths" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="[--Select--]" Value=""></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Test</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlTest" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="RegMed" Value="RegMed"></asp:ListItem>
                                        <asp:ListItem Text="8 Basic" Value="8 Basic"></asp:ListItem>
                                        <asp:ListItem Text="Dutch" Value="Dutch"></asp:ListItem>
                                        <asp:ListItem Text="NIS" Value="NIS"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Clinic</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtClinic" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Clinic"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Remarks</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtMedRemarks" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="lbMedSave" runat="server" Text="Save" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="MedHisu" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Medical History</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Rank</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMedRankU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">CoE</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlCoeU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="[--Select--]" Value=""></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Vessel</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMedVesselU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Medical Exam Date </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtMedExamU" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceMedDateU" PopupButtonID="imgPopup" runat="server" TargetControlID="txtMedExamU" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender17" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtMedExamU" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Fit Date </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFitU" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceFitU" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFitU" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender18" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtFitU" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Months</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlMonthsU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="[--Select--]" Value=""></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Test</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlTestU" runat="server" required="required" CssClass="form-control form-control-round selectpicker" placeholder="Select Rank" data-live-search="true">
                                        <asp:ListItem Text="RegMed" Value="RegMed"></asp:ListItem>
                                        <asp:ListItem Text="8 Basic" Value="8 Basic"></asp:ListItem>
                                        <asp:ListItem Text="Dutch" Value="Dutch"></asp:ListItem>
                                        <asp:ListItem Text="NIS" Value="NIS"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Clinic</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtClinicU" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Clinic"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Remarks</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtMedRemarksU" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnMedUpdate" runat="server" Text="Update Medical History" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <!-- Modal -->
            <div class="modal fade" id="Pass" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Crew Password</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Current Password</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblPass" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">New Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPass" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnUpdatePass" runat="server" Text="Update Password" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->


            <asp:HiddenField ID="hdnSeaID" runat="server" />

            <asp:HiddenField ID="hdnPathEvalUp" runat="server" />
            <asp:HiddenField ID="hdnSeaServiceCode" runat="server" />
            <asp:HiddenField ID="hdnIDEval" runat="server" />
            <asp:HiddenField ID="hdnEvalIDs" runat="server" />

            <asp:HiddenField ID="hdnMedID" runat="server"></asp:HiddenField>

            <asp:HiddenField ID="hdnAllotDocU" runat="server" />
            <asp:HiddenField ID="hdnAllotID" runat="server" />


            <asp:HiddenField ID="hdnDocPath" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnDocID" runat="server"></asp:HiddenField>


        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="lbSaveDoc" />--%>
            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />

            <%-- <asp:AsyncPostBackTrigger ControlID="lbAddAllottee" EventName="Click" />--%>
            <%--<asp:PostBackTrigger ControlID="lbAddAllottee" />--%>
            <asp:PostBackTrigger ControlID="btnEditAllottee" />

            <asp:AsyncPostBackTrigger ControlID="btnSaveESS" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnUploadEval" />
            <asp:PostBackTrigger ControlID="btnUpEval" />

            <asp:AsyncPostBackTrigger ControlID="btnMedUpdate" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="lbMedSave" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>


    <!-- Modal -->
    <div class="modal fade" id="overinfo" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Overview</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">

                        <rsweb:ReportViewer ID="rvOver" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                            <LocalReport ReportPath="CrewReports\Overall.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="joining" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Joining Crew Routing Slip</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">

                        <rsweb:ReportViewer ID="rvJoining" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                            <LocalReport ReportPath="CrewReports\JoiningRouting.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="signed" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Signed-Off Routing Slip</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">

                        <rsweb:ReportViewer ID="rvSignOff" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                            <LocalReport ReportPath="CrewReports\SignoffRouting.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="mcontract" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Contract</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">

                        <asp:ObjectDataSource ID="objdtContract" runat="server" SelectMethod="GetData" TypeName="CrewSys.CrewSysDataSetTableAdapters.WageSelTableAdapter"></asp:ObjectDataSource>
                        <rsweb:ReportViewer ID="rvContract" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                            <LocalReport ReportPath="ContractLOA\Contract.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="CrewDoc" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Crew Document</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Flagstate<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlFlagstate" runat="server" CssClass="form-control selectpicker" placeholder="Select Flagstate" data-live-search="true"></asp:DropDownList>
                            <asp:Label ID="lblFlagst" runat="server" Text="For Flagstate and Travel" CssClass="text-text-info"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Training Center<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlTrainingCenter" runat="server" CssClass="form-control selectpicker" placeholder="Select Training Center" data-live-search="true"></asp:DropDownList>
                            <asp:Label ID="lblTrainingCe" runat="server" Text="For Training" CssClass="text-text-info"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Document Title<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlDocCode" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Upload Document<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="fuPath" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuPath" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                        </div>
                        <asp:Label ID="lblWarning2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Document Number</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtDocNo" runat="server" CssClass="form-control form-control-round" placeholder="Document Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Issued Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtIDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                            <ajax:CalendarExtender ID="ceIDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtIDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                InputDirection="LefttoRight" TargetControlID="txtIDate" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Expiry Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExdate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                            <ajax:CalendarExtender ID="ceExdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                InputDirection="LefttoRight" TargetControlID="txtExdate" />
                            <asp:CheckBox ID="chkNoExpiry" runat="server" Text="No Expiration" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Remarks</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnPath" runat="server" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:Button ID="lbSaveDoc" runat="server" Text="Save Crew Document" CssClass="btn btn-success waves-effect waves-light pull-right" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="UpSeaAddEval" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Upload Evaluation</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Upload Evaluation</label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="fuSeaUpload" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuSeaUpload" ValidationExpression="^.*\.(png|PNG|jpg|jpeg|JPG|JPEG|pdf|PDF)$" runat="server" ErrorMessage="Upload valid Picture Formats!" CssClass="text-danger" />
                            <asp:Label ID="lblWarning4" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:LinkButton ID="btnUploadEval" runat="server" CssClass="btn btn-success waves-effect waves-light">SAVE</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="payslipM" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">PaySlip</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">

                        <rsweb:ReportViewer ID="rvSlip" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                            <LocalReport ReportPath="Reports\Payslip.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


</asp:Content>
