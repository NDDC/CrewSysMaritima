<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Payroll.aspx.vb" Inherits="CrewSys.Payroll" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlAllottee.ClientID%>").selectpicker();
            $("#<%= ddlMonth.ClientID%>").selectpicker();
            $("#<%= ddlCrewName.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function RefreshDDL() {
            $("#<%= ddlAllottee.ClientID%>").selectpicker();
            $("#<%= ddlMonth.ClientID%>").selectpicker();
            $("#<%= ddlCrewName.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();
        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()
        }

        function openPay() {
            $('#payslip').modal('show');
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">PAYROLL</h5>
            <p class="text-muted m-b-10">Manage Crew Payroll</p>

            <div class="form-group row pull-right">
                <label class="col-sm-3 col-form-label">Dollar Rate:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtRate" runat="server" required="required" CssClass="form-control form-control-round" Font-Bold="True"
                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                    </asp:TextBox>
                </div>
            </div>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upPay" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-2">
                                        <asp:Label ID="lblCrewName2" runat="server" Text="Crew Name:" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-md-12 col-lg-8">
                                        <asp:DropDownList ID="ddlCrewName" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-2">
                                        <%--<asp:Label ID="lblSearch" runat="server" Text="Search" Font-Bold="True"></asp:Label>--%>
                                        <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                            <i class="ti-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vCrew" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvCrew" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Rank" SortExpression="RankDescription">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("RankDescription")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("VesselName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Label3" runat="server" Text='<%# Bind("FullName") %>' CommandName="View" CommandArgument='<%#Eval("CrewNo")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Crew Status" SortExpression="CrewStatus">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label121" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>


                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vViewCrewList" runat="server">


                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-group row">
                                            <div class="col-md-12 col-lg-6">
                                                <asp:Label ID="lblCrewName" runat="server" Text="a" CssClass="pull-left" Font-Bold="True"></asp:Label>
                                                &nbsp - &nbsp
                                        <asp:Label ID="lblRank" runat="server" Text="a" Font-Bold="True"></asp:Label>
                                            </div>
                                            <div class="col-md-12 col-lg-1">
                                                <asp:Label ID="lblAllotment" runat="server" Text="Allottee"></asp:Label>
                                            </div>
                                            <div class="col-md-12 col-lg-3">
                                                <asp:DropDownList ID="ddlAllottee" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-12 col-lg-1">
                                                <asp:Button ID="btnAllot" runat="server" Text="Go" CssClass="btn btn-primary pull-left" />
                                            </div>
                                            <div class="col-md-12 col-lg-1">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary pull-right" />
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <asp:Panel ID="pAllottments" runat="server">

                                    <div class="row">

                                        <div class="col-sm-6">
                                            <div class="row">
                                                <label class="col-sm-3">Allottee Code:</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblAllotteeCode" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <label class="col-sm-3">Allottee Name:</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblAllotteeName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="row">
                                                <label class="col-sm-3">Allottment:</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblAllottment" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="row">
                                                <label class="col-sm-3">Payroll Date:</label>
                                                <div class="col-sm-5">
                                                    <asp:DropDownList ID="ddlMonth" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true">
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
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="ddlYear" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Remit Date:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtRemitDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY"></asp:TextBox>
                                                    <ajax:CalendarExtender ID="ceRemitDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtRemitDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                        InputDirection="LefttoRight" TargetControlID="txtRemitDate" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Allowance:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtAllowance" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Pagibig:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtHDMF" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Pagibig Loan:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtHDMFLoan" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">SSS:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtSSS" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Amosup:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtAmosup" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Philhealth:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtPhilhealth" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Loan:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtLoan" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Personal Loan:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtPLoan" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Panama:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtPanama" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Training:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtTraining" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Others:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtOthers" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-sm-3 col-form-label">Miscellaneous:</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtMisc" runat="server" required="required" CssClass="form-control form-control-round"
                                                        onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row pull-right">
                                                <asp:Button ID="btnPay" runat="server" Text="Compute and Pay" CssClass="btn btn-success pull-right" />
                                            </div>
                                        </div>

                                    </div>

                                </asp:Panel>


                                <br />

                                <div class="table-responsive">

                                    <asp:GridView ID="gvPaySlip" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Payroll Date" SortExpression="PayrollDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PayrollDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remit Date" SortExpression="RemitDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("RemitDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("VesselName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Allottee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("AllotteeCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Allottee Name" SortExpression="AllotteeName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnPaySlipID" runat="server" Value='<%# Eval("ID")%>' />
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("AllotteeName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Allotment">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Allotment")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("DollarRate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Income">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("TotalIncome")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Deductions">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label27" runat="server" Text='<%# Bind("TotalDeduc")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Pay">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NetPay")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:ButtonField ButtonType="Button" CommandName="ViewPaySlip" Text="View Payslip" ControlStyle-CssClass="btn btn-info" />
                                        </Columns>


                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>


                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnCrewNo" runat="server" />
                                <asp:HiddenField ID="hdnVesselCode" runat="server" />
                                <asp:HiddenField ID="hdnRank" runat="server" />
                                <asp:HiddenField ID="hdnView" runat="server" />
                            </asp:View>



                            <asp:View ID="vActionNotification" runat="server">
                                <h4>
                                    <asp:Label ID="lblMessage" runat="server" Text=" Record Successfully Saved"></asp:Label></h4>
                                <div class="actionBar">
                                    <asp:Button ID="btnBack2" runat="server" Text="Continue" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                                </div>
                            </asp:View>

                        </asp:MultiView>


                    </ContentTemplate>
                </asp:UpdatePanel>



                <!-- Modal -->
                <div class="modal fade" id="payslip" tabindex="-1" role="dialog">
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



            </div>
        </div>
    </div>

</asp:Content>
