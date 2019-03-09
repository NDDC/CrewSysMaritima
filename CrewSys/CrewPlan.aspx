<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="CrewPlan.aspx.vb" Inherits="CrewSys.CrewPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlCrew.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function RefreshDDL() {
            $("#<%= ddlCrew.ClientID%>").selectpicker();

        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()
        }

        function openModalC() {
            $('#CrewModal').modal('show');
        }
        function closeModalC() {
            $('#CrewModal').modal('hide');
            //$("#CrewModal").on("click",function(){
            //    $("#lbAddUpdate").attr("data-dismiss", "modal");
            //});
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">CREW PLAN</h5>
            <p class="text-muted m-b-10">Manage Crew Planning</p>
        </div>
    </div>



    <asp:UpdatePanel ID="upDoc" runat="server">
        <ContentTemplate>


            <div class="page-body">
                <div class="card">
                    <div class="card-block">


                        <div class="row">
                            <div class="col-sm-6">
                            </div>
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-2 pull-right">
                                <div class="form-group row">
                                    <asp:Label ID="lblWeeks" runat="server" Text="Select how many months"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtWeeks" runat="server" CssClass="form-control form-control-round" Text="0" MaxLength="4" TextMode="Number"></asp:TextBox>
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

                            <asp:View ID="vVessels" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvVessel" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbVesselName" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("VesselName")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Offsigning" HeaderText="No. of Off Signing Crew" SortExpression="Offsigning" />

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
                                        &nbsp &nbsp
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary pull-right" />
                                    </header>
                                    <div class="panel-body">

                                        <br />

                                        <div class="table-responsive">

                                            <asp:GridView ID="gvCrewSignoff" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Rank Description">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbRankDescription" runat="server" Text='<%# Bind("RankDescription") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary" OnClick="lbRankDescription_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Off Signer" SortExpression="Off Signer">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlCrewNo" runat="server" CssClass="text-primary"
                                                                NavigateUrl='<%# SetNavigation(Eval("CrewNo").ToString())%>' Text='<%#Eval("FullName")%>' Target="_blank"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SignOff" HeaderText="Sign Off" SortExpression="SignOff" DataFormatString="{0:MM/dd/yyyy }" />
                                                    <asp:TemplateField HeaderText="On Signer" SortExpression="On Signer">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlCrewNo2" runat="server" CssClass="text-primary"
                                                                NavigateUrl='<%# SetNavigation(Eval("Onsigner").ToString())%>' Text='<%#Eval("OnsignerName")%>' Target="_blank"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CrewRemarks" HeaderText="Remarks" SortExpression="CrewRemarks" />

                                                </Columns>

                                                <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                                <HeaderStyle ForeColor="Blue" />

                                            </asp:GridView>


                                            <!-- Modal -->
                                            <div class="modal fade" id="CrewModal" tabindex="-1" role="dialog">
                                                <div class="modal-dialog modal-lg" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <h4 class="modal-title">
                                                                <asp:Label ID="lblRank" runat="server" Text="" CssClass="text-center"></asp:Label></h4>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                        </div>
                                                        <div class="modal-body">

                                                            <div class="form-group row">
                                                                <label class="col-sm-2 col-form-label">Crew Name<span class="required">*</span></label>
                                                                <div class="col-sm-10">
                                                                    <asp:DropDownList ID="ddlCrew" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-2 col-form-label">Remarks</label>
                                                                <div class="col-sm-10">
                                                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-round"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                                                            <asp:LinkButton ID="lbAddUpdate" runat="server" CssClass="btn btn-success" Text="SAVE"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--End of Modal-->


                                        </div>

                                    </div>
                                </div>
                            </asp:View>


                            <asp:View ID="vActionNotification" runat="server">
                                <h4>
                                    <asp:Label ID="lblMessage" runat="server" Text=" Record Successfully Saved"></asp:Label></h4>
                                <div class="actionBar">
                                    <asp:Button ID="btnBack2" runat="server" Text="Continue" CssClass="btn btn-success pull-right" />
                                </div>
                            </asp:View>

                        </asp:MultiView>


                    </div>
                </div>
            </div>

            <asp:HiddenField ID="hdnMode" runat="server" />
            <asp:HiddenField ID="hdnID" runat="server" />
            <asp:HiddenField ID="hdnVesselCode" runat="server" />
            <asp:HiddenField ID="hdnRank" runat="server" />
            <asp:HiddenField ID="hdnRankSort" runat="server" />
            <asp:HiddenField ID="hdnVesselName" runat="server" />
            <asp:HiddenField ID="hdnCrewNo" runat="server" />


            <asp:HiddenField ID="hdnSignOnOff" runat="server" />
            <asp:HiddenField ID="hdnSignOff" runat="server" />
            <asp:HiddenField ID="hdnContract" runat="server" />
            <asp:HiddenField ID="hdnCrew" runat="server" />
            <asp:HiddenField ID="hdnView" runat="server" />


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbAddUpdate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
