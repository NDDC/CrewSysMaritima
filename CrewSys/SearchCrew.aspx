<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="SearchCrew.aspx.vb" Inherits="CrewSys.SearchCrew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlStatus.ClientID%>").selectpicker();
            $("#<%= ddlVessel.ClientID%>").selectpicker();
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlAvail.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

       <%-- function RefreshDDL() {
            $("#<%= ddlStatus.ClientID%>").selectpicker();
            $("#<%= ddlVessel.ClientID%>").selectpicker();
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlAvail.ClientID%>").selectpicker();
        }
        $(function () {
            RefreshDDL()
        });--%>
        //function pageLoad(sender, args) {
        //    RefreshDDL()
        //}

    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="upSearch" runat="server">
        <ContentTemplate>

            <div class="page-header card">
                <div class="card-block">
                    <h5 class="m-b-10 pull-left"></h5>
                    <h5 class="m-b-10 pull-right">
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                        Total Crew All Status -
                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                    </h5>
                </div>
            </div>


            <div class="card-block">

                <div class="row">
                    <div class="col-md-12 col-lg-2">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="ti-anchor text-c-blue d-block f-40"></i>
                                <h5 class="m-t-20">Onboard</h5>
                                <asp:LinkButton ID="lbOnboard" runat="server" CssClass="btn btn-info btn-round">Onboard</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-2">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="fa fa-users text-c-green d-block f-40"></i>
                                <h5 class="m-t-20">Lined-up</h5>
                                <asp:LinkButton ID="lbLineup" runat="server" CssClass="btn btn-success btn-round">Lined-up</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-2">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="ti-home text-c-yellow d-block f-40"></i>
                                <h5 class="m-t-20">On-Vacation</h5>
                                <asp:LinkButton ID="lbOnvacation" runat="server" CssClass="btn btn-warning btn-round">On-Vacation</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-2" runat="server" id="divAppli">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="fa fa-plus text-c-blue d-block f-40"></i>
                                <h5 class="m-t-20">Applicants</h5>
                                <asp:LinkButton ID="lbApplicants" runat="server" CssClass="btn btn-primary btn-round">Applicants</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-2" runat="server" id="divOther">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="fa fa-ship text-c-pink d-block f-40"></i>
                                <h5 class="m-t-20">Others</h5>
                                <asp:LinkButton ID="lbOthers" runat="server" CssClass="btn btn-danger btn-round">Others</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-2" runat="server" id="divAlert">
                        <div class="card">
                            <a href="Alerts.aspx">
                                <div class="card-block text-center">
                                    <i class="fa fa-exclamation-triangle text-c-yellow d-block f-40"></i>
                                    <h5 class="m-t-20">
                                        <asp:Label ID="Label14" runat="server" Text="">Alerts</asp:Label>
                                    </h5>
                                </div>
                            </a>
                        </div>
                    </div>

                </div>
            </div>


            <div class="page-body">
                <div class="card">
                    <div class="card-block">


                        <div class="form-group row">
                            <div class="col-md-12 col-lg-2">
                                <asp:Label ID="Label2" runat="server" Text="Vessel:" Font-Bold="True"></asp:Label>
                                <asp:DropDownList ID="ddlVessel" runat="server" CssClass="form-control pull-right" data-live-search="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-12 col-lg-2">
                                <asp:Label ID="Label5" runat="server" Text="Rank:" Font-Bold="True"></asp:Label>
                                <asp:DropDownList ID="ddlRank" runat="server" CssClass="form-control pull-right" data-live-search="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-12 col-lg-2">
                                <asp:Label ID="Label6" runat="server" Text="Status:" Font-Bold="True"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control pull-right" data-live-search="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-12 col-lg-1">
                                <asp:Label ID="Label11" runat="server" Text="Avail:" Font-Bold="True"></asp:Label>
                                <asp:DropDownList ID="ddlAvail" runat="server" CssClass="form-control" data-live-search="true">
                                   
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12 col-lg-2">
                                <asp:Label ID="Label7" runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control form-control-round pull-right" placeholder="Last Name"></asp:TextBox>
                            </div>
                            <div class="col-md-12 col-lg-2">
                                <asp:Label ID="Label8" runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control form-control-round pull-right" placeholder="First Name"></asp:TextBox>
                            </div>
                            <div class="col-md-12 col-lg-1">
                                <asp:Label ID="Label3" runat="server" Text="Search" Font-Bold="True"></asp:Label>
                                <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                    <i class="ti-search"></i>
                                </button>
                            </div>
                        </div>
                    </div>




                    <div class="table-responsive">

                        <asp:GridView ID="gvCrew" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                            <Columns>

                                <asp:TemplateField HeaderText="Rank" SortExpression="RankSortCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label111" runat="server" Text='<%# Bind("RankDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary"
                                            NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' Target="_self"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("VesselName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Crew Status" SortExpression="CrewStatus">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Availability" SortExpression="Avail">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox222" runat="server" Text='<%# Bind("Avail")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label222" runat="server" Text='<%# Bind("Avail")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDelete" runat="server" Text="DELETE" CommandName="DeleteCrew" CommandArgument='<%#Eval("ID")%>' CssClass="btn btn-warning"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                            <HeaderStyle ForeColor="Blue" />

                        </asp:GridView>


                        <asp:GridView ID="gvCrewP" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped b-t b-light" PageSize="30" EmptyDataText="There are no data records to display">
                            <Columns>

                                <asp:TemplateField HeaderText="Rank" SortExpression="RankSortCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1112" runat="server" Text='<%# Bind("RankDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary"
                                            NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' Target="_blank"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("VesselName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Crew Status" SortExpression="CrewStatus">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("CrewStatus")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Availability" SortExpression="Avail">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox222" runat="server" Text='<%# Bind("Avail")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2232" runat="server" Text='<%# Bind("Avail")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                            <HeaderStyle ForeColor="Blue" />

                        </asp:GridView>

                    </div>

                    <asp:HiddenField ID="hdnView" runat="server" />
                    <asp:HiddenField ID="hdnMode" runat="server" />


                </div>
            </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
