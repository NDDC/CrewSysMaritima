<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Users.aspx.vb" Inherits="CrewSys.Users" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlModule.ClientID%>").selectpicker();
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function RefreshDDL() {
            $("#<%= ddlModule.ClientID%>").selectpicker();
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();

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
            <h5 class="m-b-10">USERS MANAGEMENT</h5>
            <p class="text-muted m-b-10">Manage Users</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upUser" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New User Account" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-round" placeholder="Search for User Name, Full Name"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                                <i class="ti-search"></i>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vViewKewords" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbUserName" runat="server" Text='<%# Bind("UserName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
                                            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
                                            <asp:BoundField DataField="LookUpDescription" HeaderText="Module Access" SortExpression="LookUpDescription" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vUpdateKeywords" runat="server">
                                <div class="panel panel-default">
                                    <header class="panel-heading bg-primary">
                                        <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label>
                                    </header>
                                    <div class="panel-body">

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">User Name<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtUserName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="User Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Password<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtPassword" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Last Name<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtLastName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">First Name<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtFirstName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Middle Name<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtMiddleName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Middle Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Email Address<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtEmail" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Email Address"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address!"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="upModule" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">Module</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlModule" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <asp:Label ID="lblPrin" runat="server" Text="Principal Name" CssClass="col-sm-2 col-form-label"></asp:Label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="ddlPrincipalCode" runat="server" required="required" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateUser" runat="server" Text="Update User Details" CssClass="btn btn-success pull-right" />
                                        </div>

                                    </div>
                                </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnPhoto" runat="server" />
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
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddUpdateUser" />
                    </Triggers>
                </asp:UpdatePanel>


            </div>
        </div>
    </div>

</asp:Content>
