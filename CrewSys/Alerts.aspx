<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Alerts.aspx.vb" Inherits="CrewSys.Alerts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type='text/javascript'>
        function openModalC() {
            $('#CrewModal').modal('show');
        }
        function openModalD() {
            $('#DocModal').modal('show');
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">ALERTS</h5>
        </div>
    </div>


      <asp:UpdatePanel ID="upAlert" runat="server">
        <ContentTemplate>


    <div class="page-body">
        <div class="row">


            <div class="col-lg-6 col-md-12">
                <div class="card">
                    <div class="card-header bg-c-yellow text-center">
                        <h4 class="m-b-10">Expiring Documents for the Next 6 Months</h4>
                    </div>
                    <div class="card-block">
                        <div class="table-responsive">

                            <asp:GridView ID="gvDocs" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                <Columns>

                                    <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbVesselName" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("VesselName")%>' CssClass="text-primary" OnClick="lbVesselName_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ExpiredDoc" HeaderText="No. of Expired/Expiring Document" SortExpression="ExpiredDoc" />

                                </Columns>

                                <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                <HeaderStyle ForeColor="Blue" />

                            </asp:GridView>

                        </div>

                         <!-- Modal -->
                        <div class="modal fade" id="DocModal" tabindex="-1" role="dialog">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblVesselName" runat="server" Text="" CssClass="text-center"></asp:Label></h4>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">

                                        <div class="table-responsive">

                                            <asp:GridView ID="gvCrewDocEx" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display" OnRowDataBound="gvCrewDocEx_RowDataBound">
                                                <Columns>

                                                        <asp:BoundField DataField="CrewNo" HeaderText="Crew Number" SortExpression="CrewNo" />
                                                        <asp:TemplateField HeaderText="FullName" SortExpression="FullName">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary" NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' ></asp:HyperLink>
                                                                <asp:HiddenField ID="ExpiryDate" runat="server" Value='<%#Bind("ExpiryDate")%>'></asp:HiddenField>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RankDescription" HeaderText="Rank" SortExpression="RankSortCode" />
                                                        <asp:BoundField DataField="DocTitle" HeaderText="Document Title" SortExpression="DocTitle" />
                                                        <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="ExpiryDate" />

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

                    </div>
                </div>
            </div>



            <div class="col-lg-6 col-md-12">
                <div class="card">
                    <div class="card-header bg-c-pink text-center">
                        <h4 class="m-b-10">Crew Contracts Expiring within a Month</h4>
                    </div>
                    <div class="card-block">


                        <div class="table-responsive">

                            <asp:GridView ID="gvOffSign" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                <Columns>

                                    <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbVesselName2" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("VesselName")%>' OnClick="lbVesselName2_Click" CssClass="text-primary"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Offsigning" HeaderText="No. of Off Signing Crew" SortExpression="Offsigning" />

                                </Columns>

                                <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                <HeaderStyle ForeColor="Blue" HorizontalAlign="Center" />

                            </asp:GridView>

                        </div>


                        <!-- Modal -->
                        <div class="modal fade" id="CrewModal" tabindex="-1" role="dialog">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblVesselName2" runat="server" Text="" CssClass="text-center"></asp:Label></h4>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">

                                        <div class="table-responsive">

                                            <asp:GridView ID="gvCrewSignoff" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display" OnRowDataBound="gvCrewSignoff_RowDataBound">
                                                <Columns>

                                                    <asp:BoundField DataField="CrewNo" HeaderText="Crew Number" SortExpression="CrewNo" />
                                                    <asp:TemplateField HeaderText="FullName" SortExpression="FullName">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary"
                                                                NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' Target="_blank"></asp:HyperLink>
                                                            <asp:HiddenField ID="SignOff" runat="server" Value='<%#Bind("SignOff")%>'></asp:HiddenField>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="RankDescription" HeaderText="Rank" SortExpression="RankSortCode" />
                                                    <asp:BoundField DataField="SignOn" HeaderText="Sign On" SortExpression="SignOn" />
                                                    <asp:BoundField DataField="SignOff" HeaderText="Sign Off" SortExpression="SignOff" />

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

                    </div>
                </div>
            </div>


            <asp:HiddenField ID="hdnVesselCode" runat="server" />
            <asp:HiddenField ID="hdnVesselName" runat="server" />
            <asp:HiddenField ID="hdnCrewNo" runat="server" />


        </div>
    </div>


            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
