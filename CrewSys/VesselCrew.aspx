<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="VesselCrew.aspx.vb" Inherits="CrewSys.VesselCrew" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">VESSEL CREW LIST</h5>
            <p class="text-muted m-b-10">Crew List Per Vessel</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">

                <asp:UpdatePanel ID="upVessel" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblddlPrincipal" runat="server" Text="Principal:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlPrincipal" runat="server" CssClass="form-control pull-right" data-live-search="true" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblVessel" runat="server" Text="Vessel:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlVessel" runat="server" CssClass="form-control pull-right" data-live-search="true" AutoPostBack="true"></asp:DropDownList>
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

                            <asp:View ID="vVessels" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvVessel" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbVesselName" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CrewOnboard" HeaderText="Crew Onboard" SortExpression="CrewOnboard" />
                                            <asp:BoundField DataField="Description" HeaderText="Principal" SortExpression="Description" />
                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                            <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                            <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                            <asp:BoundField DataField="Imono" HeaderText="IMO No" SortExpression="Imono" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                    <asp:GridView ID="gvVesselP" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbVesselName" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Description" HeaderText="Principal" SortExpression="Description" />
                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                            <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                            <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                            <asp:BoundField DataField="Imono" HeaderText="IMO No" SortExpression="Imono" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vViewCrewList" runat="server">
                                <div class="panel panel-default">
                                    <header class="panel-heading bg-info">
                                        <asp:Label ID="lblVesselName" runat="server" Text="" CssClass="pull-left" Font-Bold="True"></asp:Label>
                                        &nbsp - &nbsp
                                        Total Crew in Vessel (
                                        <asp:Label ID="lblCrewOnboard" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        )
                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary pull-right" />
                                    </header>
                                    <div class="panel-body">

                                        <br />

                                        <div class="table-responsive">

                                            <asp:GridView ID="gvCrewList" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                                <Columns>

                                                    <asp:BoundField DataField="RankDescription" HeaderText="Rank" SortExpression="RankSortCode" />
                                                    <asp:TemplateField HeaderText="Crew Name" SortExpression="FullName">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary"
                                                                NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' Target="_blank"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SignOn" HeaderText="Sign On" SortExpression="SignOn" DataFormatString="{0:MM/dd/yyyy }" />
                                                    <asp:BoundField DataField="SignOff" HeaderText="Sign Off" SortExpression="SignOff" DataFormatString="{0:MM/dd/yyyy }" />
                                                    <asp:TemplateField HeaderText="Onsigner Name" SortExpression="OnsignerName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOnsigner" runat="server" Text='<%# Bind("OnsignerName") %>' CommandName="ViewCrew" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>

                                                <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                <HeaderStyle ForeColor="Blue" />

                                            </asp:GridView>

                                        </div>

                                    </div>
                                </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnVesselCode" runat="server" />
                                <asp:HiddenField ID="hdnRank" runat="server" />
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
