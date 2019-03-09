<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="WagesArchive.aspx.vb" Inherits="CrewSys.WagesArchive" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlScale.ClientID%>").selectpicker();
            
            $("#<%= ddlRankS.ClientID%>").selectpicker();
            $("#<%= ddlPrincipal.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function RefreshDDL() {
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlScale.ClientID%>").selectpicker();
            
            $("#<%= ddlRankS.ClientID%>").selectpicker();
            $("#<%= ddlPrincipal.ClientID%>").selectpicker();
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
            <h5 class="m-b-10">WAGES</h5>
            <p class="text-muted m-b-10">Manage Crew Wages</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Wage Scale" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblddlPrincipal" runat="server" Text="Principal:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlPrincipal" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblRankS" runat="server" Text="Rank:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlRankS" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-2">
                                        <asp:Label ID="lblSearch" runat="server" Text="Search" Font-Bold="True"></asp:Label>
                                        <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                            <i class="ti-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vViewKewords" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvWage" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Principal" SortExpression="PrincipalName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbPrincipal" runat="server" Text='<%# Bind("PrincipalName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="RankSortCode" />
                                            <asp:BoundField DataField="Scale" HeaderText="Scale" SortExpression="Scale" />
                                            <asp:BoundField DataField="BasicWage" HeaderText="Basic Wage" SortExpression="BasicWage" />
                                            <asp:BoundField DataField="WorkHours" HeaderText="Work Hours" SortExpression="WorkHours" />
                                            <asp:BoundField DataField="OverTimePay" HeaderText="OT Pay" SortExpression="OverTimePay" />
                                            <asp:BoundField DataField="OverTimeRate" HeaderText="OT Rate" SortExpression="OverTimeRate" />
                                            <asp:BoundField DataField="LeavePay" HeaderText="Leave Pay" SortExpression="LeavePay" />
                                            <asp:BoundField DataField="WeekEndPay" HeaderText="Weekend Pay" SortExpression="WeekEndPay" />
                                            <asp:BoundField DataField="SocialBonus" HeaderText="Social Bonus" SortExpression="SocialBonus" />
                                            <asp:BoundField DataField="Allowance" HeaderText="Allowance" SortExpression="Allowance" />
                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                    <asp:GridView ID="gvWageP" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped b-t b-light" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Rank" SortExpression="RankSortCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRank" runat="server" Text='<%# Bind("Rank") %>' CssClass="text-primary"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Scale" HeaderText="Scale" SortExpression="Scale" />
                                            <asp:BoundField DataField="BasicWage" HeaderText="Basic Wage" SortExpression="BasicWage" />
                                            <asp:BoundField DataField="WorkHours" HeaderText="Work Hours" SortExpression="WorkHours" />
                                            <asp:BoundField DataField="OverTimePay" HeaderText="OT Pay" SortExpression="OverTimePay" />
                                            <asp:BoundField DataField="OverTimeRate" HeaderText="OT Rate" SortExpression="OverTimeRate" />
                                            <asp:BoundField DataField="LeavePay" HeaderText="Leave Pay" SortExpression="LeavePay" />
                                            <asp:BoundField DataField="WeekEndPay" HeaderText="Weekend Pay" SortExpression="WeekEndPay" />
                                            <asp:BoundField DataField="SocialBonus" HeaderText="Social Bonus" SortExpression="SocialBonus" />
                                            <asp:BoundField DataField="Allowance" HeaderText="Allowance" SortExpression="Allowance" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vUpdateKeywords" runat="server">
                                <div class="panel panel-default">
                                    <div class="panel-heading bg-primary">
                                        <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="panel-body">

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Principal</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlPrincipalCode" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Rank</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlRank" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Scale</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlScale" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Basic Wage<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtBasicWage" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Basic Wage"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Work Hours<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtWorkHours" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Work Hours"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">OT Pay<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtOTPay" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="OT Pay"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">OT Rate<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtOTRate" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="OT Rate"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Leave Pay<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtLeavePay" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Leave Pay"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Weekend Pay<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtWeekendPay" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Weekend Pay"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Social Bonus<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtSocialBonus" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Social Bonus"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Allowance<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAllowance" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Allowance"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">DND Allowance<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtDndAllowance" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="DND Allowance"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">IMO<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtIMO" runat="server"
                                                    onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="IMO"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateWages" runat="server" Text="Update Wage Scale" CssClass="btn btn-success pull-right" />
                                        </div>
                                    </div>
                                </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnView" runat="server" />
                            </asp:View>



                            <asp:View ID="vActionNotification" runat="server">
                                <h4>
                                    <asp:Label ID="lblMessage" runat="server" Text=" Record Successfully Saved"></asp:Label></h4>
                                <div class="actionBar">
                                    <asp:Button ID="btnBack2" runat="server" Text="Continue" CssClass="btn btn-success pull-right" />
                                </div>
                            </asp:View>

                        </asp:MultiView>


                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </div>
    </div>

</asp:Content>
