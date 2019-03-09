<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Reports.aspx.vb" Inherits="CrewSys.Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlVessel.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function RefreshDDL() {
            $("#<%= ddlVessel.ClientID%>").selectpicker();
        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">Reports</h5>
            <p class="text-muted m-b-10">Manage Reports</p>
        </div>
    </div>
      
    
    <div class="page-body">
        <div class="card">
            <div class="card-block">


<%--                <asp:UpdatePanel ID="upRep" runat="server">
                    <ContentTemplate>--%>


                        <div class="row">
                            <div class="col-md-12 col-lg-12">

                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-4">
                                        <asp:Label ID="Label2" runat="server" Text="Date From:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                        <ajax:CalendarExtender ID="ceStartDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                            InputDirection="LefttoRight" TargetControlID="txtStartDate" />
                                    </div>
                                    <div class="col-md-12 col-lg-4">
                                        <asp:Label ID="Label1" runat="server" Text="Date To:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                        <ajax:CalendarExtender ID="ceEndDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                            InputDirection="LefttoRight" TargetControlID="txtEndDate" />
                                    </div>
                                    <div class="col-md-12 col-lg-4">
                                        <asp:Label ID="Label5" runat="server" Text="Vessel:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlVessel" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnOnSigner" runat="server" Text="On-Signer Report&nbsp;&nbsp;&nbsp;" CssClass="btn btn-success" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnOffSigner" runat="server" Text="Off-Signer Report" CssClass="btn btn-warning" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnLinedUp" runat="server" Text="Lined-Ups Report" CssClass="btn btn-success" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnExDeocs" runat="server" Text="Expiring Documents Report" CssClass="btn btn-warning" UseSubmitBehavior="False" />
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnOnVacation" runat="server" Text="On-Vacation Report" CssClass="btn btn-primary" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnOnboard" runat="server" Text="On-board Report" CssClass="btn btn-info" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnAge" runat="server" Text="Aging 60 Report&nbsp;&nbsp;" CssClass="btn btn-warning" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-md-12 col-lg-3">
                                        <asp:Button ID="btnNtbr" runat="server" Text="Not to be Rehired Report&nbsp;&nbsp;&nbsp;" CssClass="btn btn-danger" UseSubmitBehavior="False" />
                                    </div>
                                </div>

                            </div>
                        </div>


<%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                        
                <asp:MultiView ID="MultiView1" runat="server">

                    <asp:View ID="vOnSigner" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label3" runat="server" Text="On-Signer Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvOnSigner" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\OnSigners.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vOffSigner" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="lblHead" runat="server" Text="Off-Signer Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvOffSigners" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\OffSigners.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vLinedUp" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label4" runat="server" Text="Lined-Up Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvLinedUp" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\LinedUp.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vVacation" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label6" runat="server" Text="On-Vacation Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvVacation" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\Vacation.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vOnboard" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label7" runat="server" Text="On-Board Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvOnboard" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\Onboard.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vNTBR" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label8" runat="server" Text="Not To Be Rehired Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvNTBR" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\NTBR.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vAge" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label9" runat="server" Text="Aging 60 Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvAge" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\Age.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>



                    <asp:View ID="vDocuments" runat="server">
                        <div class="panel panel-default">
                            <header class="panel-heading font-bold">
                                <asp:Label ID="Label10" runat="server" Text="Expiring Documents Reports"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <rsweb:ReportViewer ID="rvDocuments" runat="server" Width="100%" Height="800px">
                                    <LocalReport ReportPath="Reports\ExDocuments.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </asp:View>

                </asp:MultiView>




            </div>
        </div>
    </div>


</asp:Content>
